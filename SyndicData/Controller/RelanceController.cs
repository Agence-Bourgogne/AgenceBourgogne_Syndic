using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using SyndicData.Entites;

namespace SyndicData.Controller;

public static class RelanceController
{
//        public static decimal[] montant_relance = new decimal[] { 0, (decimal)15.32, (decimal)51.07, (decimal)51.07 };
//        public static string[] texte_relance = new string[] { "1er Rappel", "2eme Rappel", "Mise en demeure", "Mise en Demeure." };

    public static string getTexteRelance(int type_relance)
    {
        switch ( type_relance )
        {
            case 0 :
                return ParametresDB.getParam1("RELANCE", "TEXTE RELANCE 1");
            case 1:
                return ParametresDB.getParam1("RELANCE", "TEXTE RELANCE 2");
            default:
                return ParametresDB.getParam1("RELANCE", "TEXTE RELANCE 3");
        }
    }
    public static string getLibelleEcritureRelance(int type_relance)
    {
        switch (type_relance)
        {
            case 0:
                return ParametresDB.getParam1("RELANCE", "ECRITURE RELANCE 1");
            case 1:
                return ParametresDB.getParam1("RELANCE", "ECRITURE RELANCE 2");
            default:
                return ParametresDB.getParam1("RELANCE", "ECRITURE RELANCE 3");
        }
    }
    public static NatureEntite getNatureRelance()
    {
        var reference = ParametresDB.getParam1("RELANCE", "NATURE");
        return NatureController.getController().getEntiteFromField("reference", reference);
    }
    public static FournisseurEntite getFournisseurRelance()
    {
        var reference = ParametresDB.getParam1("RELANCE", "FOURNISSEUR");
        return FournisseurController.getController().getEntiteFromField("reference", reference);
    }
    public static decimal getMontantRelance(int type_relance)
    {
        var montant = "";
        switch ( type_relance)
        {
            case 0:
                montant = ParametresDB.getParam1("RELANCE", "FRAIS 1");
                break;
            case 1:
                montant = ParametresDB.getParam1("RELANCE", "FRAIS 2");
                break;
            default:
                montant = ParametresDB.getParam1("RELANCE", "FRAIS 3");
                break;
        }
        return Convertir.ToDecimal(montant);
    }


    public static bool GenerateRelance(List<RelanceEntite>[] relances, DateTime dt)
    {
        var rc = false;

        var cnx = Database.GetInstance();
        var trx = cnx.BeginTransaction();
        try
        {
            var numero_operation = 0;

            var base_repart = ParametresDB.getParam1("RELANCE", "BASE");
            var fournisseur = getFournisseurRelance();
            var nature = getNatureRelance();

            var facCtl = SaisieFactureController.getController();
            var opeCtl = OperationController.getController();
            for ( var type = 0; type < relances.Length; type ++)
            {
                var montant_relance = getMontantRelance(type);
                var lib_relance = getLibelleEcritureRelance(type);

                var relanceList = relances[type];
                if (relanceList.Count > 0)
                {
                    var copro_ids = getQuotedCoproprietaireId(relanceList);
                    if (!CoproprietaireController.getController().MiseAjourDateRelances(copro_ids, dt, type))
                        throw new Exception("Mise A Jour date Relances");
                    if (type > 0)
                    {
                        // TODO Attention le type 3 ne doit pas générer d'écriture ( Déja Générée )
                        //if ( type < 3 )
                        if (montant_relance > 0)
                            foreach ( var relance in relanceList)
                            {
                                var facture = new SaisieFactureEntite();
                                facture.date_operation = facture.date_reference = dt;
                                facture.numero_operation = numero_operation++;
                                facture.liasse_id = "relance";
                                facture.immeuble_id = relance.immeuble_id;
                                facture.nature_id = nature.id;
                                facture.fournisseur_id = fournisseur.id;
                                facture.reglement = 0;
                                facture.lot_id = relance.lot_id;
                                facture.libelle = lib_relance;
                                facture.comment_fournisseur = fournisseur.nom;
                                facture.montant = montant_relance;
                                facture.base_repart = base_repart;
                                facture.statut = (int) GlobalConstantes.StatutOperation.Valide;
                                if (!facCtl.InsertOrUpdate(facture))
                                    throw new Exception("Generate Facture");

                                var operation = new OperationEntite(facture)
                                {
                                    debit = montant_relance,
                                    coproprietaire_id = relance.coproprietaire_id,
                                    lot_id = relance.lot_id,
                                    numero_ligne = 1,
                                    statut = (int)GlobalConstantes.StatutOperation.Valide
                                };
                                if (!opeCtl.InsertOrUpdate(operation))
                                    throw new Exception("Generate operation");
                            }
                    }
                }
            }
            trx.Commit();
            rc = true;
        }
        catch (Exception ex)
        {
            trx.Rollback();
            MessageBox.Show(ex.Message);
        }
        return rc;
    }
    public static string getQuotedCoproprietaireId(List<RelanceEntite> relances)
    {
        var quoted = "";

        foreach (var relance in relances)
        {
            quoted += (quoted == "" ? "" : ", ") + $"'{relance.coproprietaire_id}'";
        }
        return quoted;
    }
    public static string getQuotedCoproprietaireId(List<string> ids_copro)
    {
        var quoted = "";

        foreach (var id_copro in ids_copro)
        {
            quoted += (quoted == "" ? "" : ", ") + $"'{id_copro}'";
        }
        return quoted;
    }
}