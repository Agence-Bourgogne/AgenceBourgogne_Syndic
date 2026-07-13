using System;
using System.Collections.Generic;
using Npgsql;
using CommonProjectsPartners.Utils;
using SyndicData.Entites;
using System.Windows.Forms;
using SyndicData.Common;

namespace SyndicData.Controller
{
    public class RelanceController
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
            string reference = ParametresDB.getParam1("RELANCE", "NATURE");
            return NatureController.getController().getEntiteFromField("reference", reference);
        }
        public static FournisseurEntite getFournisseurRelance()
        {
            string reference = ParametresDB.getParam1("RELANCE", "FOURNISSEUR");
            return FournisseurController.getController().getEntiteFromField("reference", reference);
        }
        public static decimal getMontantRelance(int type_relance)
        {
            string montant = "";
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
            bool rc = false;

            NpgsqlConnection cnx = Database.GetInstance();
            NpgsqlTransaction trx = cnx.BeginTransaction();
            try
            {
                int numero_operation = 0;

                string base_repart = ParametresDB.getParam1("RELANCE", "BASE");
                FournisseurEntite fournisseur = getFournisseurRelance();
                NatureEntite nature = getNatureRelance();

                SaisieFactureController facCtl = SaisieFactureController.getController();
                OperationController opeCtl = OperationController.getController();
                for ( int type = 0; type < relances.Length; type ++)
                {
                    decimal montant_relance = getMontantRelance(type);
                    string lib_relance = getLibelleEcritureRelance(type);

                    List<RelanceEntite> relanceList = relances[type];
                    if (relanceList.Count > 0)
                    {
                        string copro_ids = getQuotedCoproprietaireId(relanceList);
                        if (!CoproprietaireController.getController().MiseAjourDateRelances(copro_ids, dt, type))
                            throw new Exception("Mise A Jour date Relances");
                        if (type > 0)
                        {
                            // TODO Attention le type 3 ne doit pas générer d'écriture ( Déja Générée )
                            //if ( type < 3 )
                            if (montant_relance > 0)
                                foreach ( RelanceEntite relance in relanceList)
                                {
                                    SaisieFactureEntite facture = new SaisieFactureEntite();
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

                                    OperationEntite operation = new OperationEntite(facture);
                                    operation.debit = montant_relance;
                                    operation.coproprietaire_id = relance.coproprietaire_id;
                                    operation.lot_id = relance.lot_id;
                                    operation.numero_ligne = 1;
                                    operation.statut = (int)GlobalConstantes.StatutOperation.Valide;
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
            string quoted = "";

            foreach (RelanceEntite relance in relances)
            {
                quoted += (quoted == "" ? "" : ", ") + String.Format("'{0}'", relance.coproprietaire_id);
            }
            return quoted;
        }
        public static string getQuotedCoproprietaireId(List<string> ids_copro)
        {
            string quoted = "";

            foreach (string id_copro in ids_copro)
            {
                quoted += (quoted == "" ? "" : ", ") + String.Format("'{0}'", id_copro);
            }
            return quoted;
        }
    }
}
