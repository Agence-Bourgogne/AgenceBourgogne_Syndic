using System;
using System.Collections.Generic;
using System.Data;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Utils;
using Npgsql;
using SyndicData.Common;
using SyndicData.Entites;

namespace SyndicData.Controller;

public class OperationController : AbstractBaseController<OperationEntite>
{
    private static readonly OperationController controller = new();

    public override string getTable()
    {
        return "operation";
    }

    public static OperationController getController()
    {
        //return new OperationController();
        return controller;
    }

    private LotRepartitionEntite getLotRepartition(DataTable lots, string lot_id, string base_repart)
    {
        foreach (DataRow row in lots.Rows)
        {
            var lot = new LotRepartitionEntite(row);
            if (lot_id == lot.lot_id && base_repart == lot.reference) return lot;
        }

        return null;
    }

    private static ImmeubleRepartitionEntite getRepartitionImmeuble(DataTable immeubles, string base_repart)
    {
        if (base_repart == "0")
            base_repart = "10";
        foreach (DataRow row in immeubles.Rows)
        {
            var repart = new ImmeubleRepartitionEntite(row);
            if (base_repart == repart.reference) return repart;
        }

        return null;
    }

    public void ValidateReglement(string liasse_id)
    {
        var saisiesReglement = SaisieReglementController.getController()
            .getListeSaisiesNonValidees(liasse_id, (int)GlobalConstantes.StatutOperation.Brouillon);
        var bAllValide = true;
        if (saisiesReglement.Rows.Count < 0)
            return;

        var trx = Database.GetInstance().BeginTransaction();
        try
        {
            foreach (DataRow row in saisiesReglement.Rows)
            {
                var reglement = new SaisieReglementEntite(row);
                if (ValidOperationRepartitionIndividuelle(reglement.immeuble_id, liasse_id, reglement.numero_operation))
                {
                    reglement.statut = (int)GlobalConstantes.StatutOperation.Valide;
                    SaisieReglementController.getController().InsertOrUpdate(reglement);
                }
                else
                {
                    bAllValide = false;
                    break;
                }
            }

            if (bAllValide)
            {
                var controllerLiasse = LiasseController.getController();
                var liasse = controllerLiasse.getEntiteById(liasse_id);
                liasse.statut = (int)GlobalConstantes.StatutOperation.Valide;
                controllerLiasse.InsertOrUpdate(liasse);

                CoproprietaireController.getController().resetDatesRelance();
                trx.Commit();
            }
            else
            {
                trx.Rollback();
            }
        }
        catch (Exception)
        {
            trx.Rollback();
        }
    }

    public void ValidateAppelDeFond(string liasse_id)
    {
        var saisiesAppel = SaisieAppelFondController.getController()
            .getListeSaisiesNonValidees(liasse_id, (int)GlobalConstantes.StatutOperation.Brouillon);
        var bAllValide = true;
        if (saisiesAppel.Rows.Count < 0)
            return;
        var controller = getController();

        var appel = new SaisieAppelFondEntite(saisiesAppel.Rows[0]);
        var table_immrepart = ImmeubleRepartitionController.getController().getRepartitionImmeuble(appel.immeuble_id);
        var table_lotsrepart = LotRepartitionController.getController().GetLotsRepartition(appel.immeuble_id);
        var table_lotdesc = LotDescriptionController.getController().getListeLot(appel.immeuble_id);

        var trx = Database.GetInstance().BeginTransaction();

        try
        {
            foreach (DataRow row in saisiesAppel.Rows)
            {
                appel = new SaisieAppelFondEntite(row);
                var numero_ligne = 1;
                var immm_repart = getRepartitionImmeuble(table_immrepart, appel.base_repart);
                if (immm_repart != null)
                {
                    if (immm_repart.type_ventilation == (int)GlobalConstantes.TypeRepartition.Millieme)
                    {
                        foreach (DataRow row_lotdesc in table_lotdesc.Rows)
                        {
                            var lot = new LotDescriptionEntite(row_lotdesc);
                            var lot_repart = getLotRepartition(table_lotsrepart, lot.id, appel.base_repart);
                            if (lot_repart == null)
                                //Console.WriteLine("erreur sur {0} {1} {2}", lot.immeuble_id, lot.numero_lot, appel.base_repart);
                                continue;
                            var montant = appel.montant * lot_repart.valeur / immm_repart.valeur;
                            if (montant != 0)
                            {
                                var operation = new OperationEntite(appel)
                                {
                                    numero_ligne = numero_ligne++,
                                    coproprietaire_id = lot.coproprietaire_id,
                                    lot_id = row_lotdesc["id"].ToString(),
                                    debit = montant,
                                    statut = (int)GlobalConstantes.StatutOperation.Valide
                                };
                                if (!controller.InsertOrUpdate(operation))
                                {
                                    bAllValide = false;
                                    break;
                                }

                                appel.statut = (int)GlobalConstantes.StatutOperation.Valide;
                                SaisieAppelFondController.getController().InsertOrUpdate(appel);
                            }
                        }
                    }
                    else
                    {
                        if (ValidOperationRepartitionIndividuelle(appel.immeuble_id, liasse_id, appel.numero_operation))
                        {
                            appel.statut = (int)GlobalConstantes.StatutOperation.Valide;
                            SaisieAppelFondController.getController().InsertOrUpdate(appel);
                        }
                        else
                        {
                            bAllValide = false;
                        }
                    }
                }

                if (!bAllValide)
                    break;
            }

            if (bAllValide)
            {
                var controllerLiasse = LiasseController.getController();
                var liasse = controllerLiasse.getEntiteById(liasse_id);
                liasse.statut = (int)GlobalConstantes.StatutOperation.Valide;
                controllerLiasse.InsertOrUpdate(liasse);
                trx.Commit();
            }
            else
            {
                trx.Rollback();
            }
        }
        catch (Exception)
        {
            trx.Rollback();
        }
    }

    public bool ValidOperationRepartitionIndividuelle(string immeuble_id, string liasse_id, int numero_operation)
    {
        var controller = getController();
        var repartCtl = RepartIndividuelleController.getController();
        var cmd = $"select * from {getSchemaTable()} ";
        cmd +=
            " where immeuble_id=@immeuble_id  and liasse_id=@liasse_id and numero_operation = @numero_operation and statut = @statut";
        var statut = (int)GlobalConstantes.StatutOperation.Brouillon;
        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@statut", statut),
            new("@liasse_id", liasse_id),
            new("@numero_operation", numero_operation)
        };
        var table = getResultSQL(cmd, parameters);
        foreach (DataRow row in table.Rows)
        {
            var entite = new OperationEntite(row)
            {
                statut = (int)GlobalConstantes.StatutOperation.Valide
            };
            if (!controller.InsertOrUpdate(entite))
                return false;
            var repart = repartCtl.getEntiteFromField("operation_id", entite.id);
            if (repart != null)
            {
                repart.statut = (int)GlobalConstantes.StatutOperation.Valide;
                if (!repartCtl.InsertOrUpdate(repart))
                    return false;
            }
        }

        return true;
    }

    public bool ValidateFacture(List<string> liasses)
    {
        var bAllValide = true;

        foreach (var liasse_id in liasses)
            if (!ValidateFacture(liasse_id))
            {
                bAllValide = false;
                break;
            }

        return bAllValide;
    }

    public bool ValidateFacture(string liasse_id)
    {
        var saisies = SaisieFactureController.getController()
            .getListeSaisiesNonValidees(liasse_id, (int)GlobalConstantes.StatutOperation.Brouillon);
        var bAllValide = true;
        if (saisies.Rows.Count < 0)
            return false;
        var controller = getController();
        var trx = Database.GetInstance().BeginTransaction();

        try
        {
            foreach (DataRow row in saisies.Rows)
            {
                var facture = new SaisieFactureEntite(row);
                var numero_ligne = 1;

                var table_immrepart = ImmeubleRepartitionController.getController()
                    .getRepartitionImmeuble(facture.immeuble_id);
                var table_lotsrepart = LotRepartitionController.getController().GetLotsRepartition(facture.immeuble_id);
                var table_lotdesc = LotDescriptionController.getController().getListeLot(facture.immeuble_id);

                var immm_repart = getRepartitionImmeuble(table_immrepart, facture.base_repart);
                if (immm_repart != null)
                {
                    if (immm_repart.type_ventilation == (int)GlobalConstantes.TypeRepartition.Millieme)
                    {
                        foreach (DataRow row_lotdesc in table_lotdesc.Rows)
                        {
                            var lot = new LotDescriptionEntite(row_lotdesc);
                            var lot_repart = getLotRepartition(table_lotsrepart, lot.id, facture.base_repart);
                            if (lot_repart == null)
                                //Console.WriteLine("erreur sur {0} {1} {2}", lot.immeuble_id, lot.numero_lot, facture.base_repart);
                                continue;
                            var montant = facture.montant * lot_repart.valeur / immm_repart.valeur;
                            if (montant == 0)
                                continue;
                            var operation = new OperationEntite(facture)
                            {
                                isNew = true,
                                numero_ligne = numero_ligne++,
                                coproprietaire_id = lot.coproprietaire_id,
                                lot_id = row_lotdesc["id"].ToString()
                            };
                            if (montant >= 0)
                                operation.debit = montant;
                            else
                                operation.credit = Math.Abs(montant);
                            operation.statut = (int)GlobalConstantes.StatutOperation.Valide;
                            if (!controller.InsertOrUpdate(operation))
                            {
                                bAllValide = false;
                                break;
                            }

                            facture.statut = (int)GlobalConstantes.StatutOperation.Valide;
                            SaisieFactureController.getController().InsertOrUpdate(facture);
                        }
                    }
                    else
                    {
                        if (ValidOperationRepartitionIndividuelle(facture.immeuble_id, liasse_id,
                                facture.numero_operation))
                        {
                            facture.statut = (int)GlobalConstantes.StatutOperation.Valide;
                            SaisieFactureController.getController().InsertOrUpdate(facture);
                        }
                        else
                        {
                            bAllValide = false;
                        }
                    }
                }

                if (!bAllValide)
                    break;
            }

            if (bAllValide)
            {
                var controllerLiasse = LiasseController.getController();
                var liasse = controllerLiasse.getEntiteById(liasse_id);
                liasse.statut = (int)GlobalConstantes.StatutOperation.Valide;
                controllerLiasse.InsertOrUpdate(liasse);
                trx.Commit();
            }
            else
            {
                trx.Rollback();
            }
        }
        catch (Exception)
        {
            trx.Rollback();
        }

        return bAllValide;
    }

    public DataTable getCoproprietaireOperation(string immeuble_id, string coproprietaire_id, DateTime dtDeb,
        DateTime dtFin)
    {
        var cmd = "select immeuble_id, coproprietaire_id , libelle, ";
        cmd += " case when debit < 0 then 0 when credit < 0 then abs(credit) else debit end as debit, ";
        cmd += " case when debit < 0 then abs(debit) when credit <0 then 0 else credit end as credit,";
        //cmd += " debit, credit, ";
        cmd += " id, date_reference";
        cmd += $" from {getSchemaTable()} ";
        cmd += " where immeuble_id=@immeuble_id  and coproprietaire_id=@coproprietaire_id and statut = @statut ";
        cmd += " and type_mouvement = @type_mouvement";
        cmd += " and date_reference >= @dtDeb ";
        if (dtFin != Database.NullDate)
            cmd += " and date_reference <= @dtFin ";
        cmd += " order by date_reference, numero_operation, numero_ligne";
        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Valide),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@coproprietaire_id", coproprietaire_id),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin)
        };
        Console.WriteLine(cmd);
        return getResultSQL(cmd, parameters);
    }

    public DataTable getSoldeRepriseCoproprietaireVide(string coproprietaire_id)
    {
        var cmd =
            "select  concat(i.reference, ' ', i.nom) as immeuble, l.immeuble_id, l.id as lot_id, numero_lot, i.comptebanque, ";
        cmd += " 0 as solde , 0 as debit, 0 as credit ";
//            cmd += String.Format(" from {0} o ", getSchemaTable());
        cmd += $" From {getSchema()}.lot_description l ";
        cmd += $" join {getSchema()}.immeuble i on (l.immeuble_id = i.id)";
        cmd += " where l.coproprietaire_id=@coproprietaire_id ";
        //cmd += " and type_mouvement = @type_mouvement";
        //cmd += " group by 1, 2, 3, 4, 5";
        var parameters = new List<NpgsqlParameter>
        {
//                new NpgsqlParameter("@immeuble_id", immeuble_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Valide),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@coproprietaire_id", coproprietaire_id)
        };

        //Console.WriteLine(cmd);
        //Console.WriteLine("Copro:{0}", coproprietaire_id);

        var table = getResultSQL(cmd, parameters);
        return table;
    }

    public DataTable getSoldeRepriseCoproprietaire(string coproprietaire_id)
    {
        var cmd =
            "select  concat(i.reference, ' ', i.nom) as immeuble, o.immeuble_id, lot_id, numero_lot, i.comptebanque, ";
        cmd += " (sum(credit)- sum(debit)) as solde , sum(debit) as debit, sum(credit) as credit ";
        cmd += $" from {getSchemaTable()} o ";
        cmd += $" join {getSchema()}.lot_description l on (o.lot_id = l.id)";
        cmd += $" join {getSchema()}.immeuble i on (o.immeuble_id = i.id)";
//            cmd += " where o.coproprietaire_id=@coproprietaire_id and o.statut = @statut ";
        cmd += " where l.coproprietaire_id=@coproprietaire_id and o.statut = @statut ";
        cmd += " and type_mouvement = @type_mouvement";
        cmd += " group by 1, 2, 3, 4, 5";
        var parameters = new List<NpgsqlParameter>
        {
//                new NpgsqlParameter("@immeuble_id", immeuble_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Valide),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@coproprietaire_id", coproprietaire_id)
        };

        //Console.WriteLine(cmd);
        //Console.WriteLine("Copro:{0}", coproprietaire_id);

        var table = getResultSQL(cmd, parameters);
        return table;
    }

    public DataTable getBilanOperationsCoproprietaires(string immeuble_id, DateTime dtDeb, DateTime dtFin,
        string natures = "", bool bPaiement = false)
    {
        var cmd = " select ";
        cmd += " l.numero_lot,   c.nom,   o.libelle,   o.base_repart, ";
        //cmd += " o.debit, o.credit, ";

        cmd += " case when debit < 0 then 0 when credit < 0 then abs(credit) else debit end as debit, ";
        cmd += " case when debit < 0 then abs(debit) when credit <0 then 0 else credit end as credit,";
        //cmd += " sum(case when debit < 0 then 0 when credit < 0 then abs(credit) else debit end) as debit, ";
        //cmd += " sum(case when debit < 0 then abs(debit) when credit <0 then 0 else credit end) as credit,";

        cmd += " n.reference, \n";
        cmd += " case when n.reference = @solde_bilan then 0 else o.debit end as debit_no_solde, \n";
        cmd += " case when n.reference = @solde_bilan then 0 else o.credit end as credit_no_solde, o.type_mouvement \n";
        //cmd += " sum(case when n.reference = @solde_bilan then 0 else o.debit end) as debit_no_solde, \n";
        //cmd += " sum(case when n.reference = @solde_bilan then 0 else o.credit end) as credit_no_solde, o.type_mouvement \n";

        cmd += " FROM  ";
        cmd += $" {getSchema()}.operation o\n";
        cmd += $" join {getSchema()}.coproprietaire c on c.id = o.coproprietaire_id\n";
        cmd += $" join {getSchema()}.lot_description l on l.id = o.lot_id\n";
        cmd += $" join {getSchema()}.nature n on n.id = o.nature_id\n";
        cmd += " where o.immeuble_id = @immeuble_id \n";
        cmd += " AND o.statut != @statut and o.statut != @statut_del \n";
        cmd += " and o.type_mouvement =@mouvement "; // and n.reference != @appel_fond \n";
        cmd += " and o.date_reference >= @dtdeb and o.date_reference <= @dtFin \n";
        if (natures != "")
            cmd += " and " + natures;

        //cmd += " group by 1, 2, 3,4, 7, c.reference, o.date_reference, o.type_mouvement ";

        if (!bPaiement)
            cmd += " ORDER BY  n.reference ASC, l.numero_lot, c.reference ASC,  o.date_reference \n";
        else
            cmd += " ORDER BY  l.numero_lot, c.reference ASC,  o.date_reference \n";

        var statut = (int)GlobalConstantes.StatutOperation.Brouillon;

        var parameters = new List<NpgsqlParameter>
        {
            new("@mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@statut", statut),
            new("@statut_del", (int)GlobalConstantes.StatutOperation.Supprime),
            new("@immeuble_id", immeuble_id),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin),
            new("@appel_fond", ParametresDB.getParam1("NATURE", "APPEL DE FONDS")),
            new("@solde_bilan", ParametresDB.getParam1("NATURE", "SOLDE BILAN"))
        };
        //Console.WriteLine(cmd);
        var table = getResultSQL(cmd, parameters);
        return table;
    }

    public DataTable getListSoldeCoproprietaires(bool bNotDesactive = true)
    {
        var schema = getSchema();
        var cmd = " Select ";

        cmd +=
            "concat(c.nom , ' ', prenom) as coproprietaire, c.reference , i.reference as ref_immeuble, i.nom as immeuble, numero_lot, ";
        cmd += " (sum(credit)- sum(debit)) as solde , "; //sum(debit) as debit, sum(credit) as credit, ";
//            cmd += "da.date_appel, ";
        cmd +=
            "da.date_appel, c.daterel1 as première_relance, c.daterel2 as seconde_relance, c.daterel3 as mise_en_demeure,";
        cmd += " case ";
        cmd += "when c.daterel3 is not null then 3 ";
        cmd += "when c.daterel2 is not null then 2 ";
        cmd += "when c.daterel1 is not null then 1 ";
        cmd += "else null end as type_relance, ";
        //cmd += " case ";
        //cmd += "when c.daterel3 is not null then c.daterel3 ";
        //cmd += "when c.daterel2 is not null then c.daterel2 ";
        //cmd += "when c.daterel1 is not null then c.daterel1 ";
        //cmd += "else null end as date_relance, ";
        //cmd += "i.datecloture as date_cloture, ";
        cmd += " case when coalesce(c.nomcomp,'') != '' then 1 else 0 end as duplicata, ";
        cmd += " o.immeuble_id, lot_id , c.id";
        cmd += $" from {getSchemaTable()} o";
        cmd += $" left join {schema}.lot_description l on (o.lot_id = l.id) ";
        cmd += $" left join {schema}.immeuble i on (o.immeuble_id = i.id) ";
        cmd += $" join {schema}.coproprietaire c on (o.coproprietaire_id = c.id) ";
        cmd += $" join (select immeuble_id, max(date_reference) as date_appel from {schema}.saisie_appel_fond op ";
        cmd += " where op.statut = @statut ";
        cmd += " group by immeuble_id order by immeuble_id ) da on da.immeuble_id = o.immeuble_id";

        cmd += " where o.statut = @statut";
        cmd += " and type_mouvement =@mouvement ";
        if (bNotDesactive)
            cmd += " and C.statut <> @statut_copro ";
        cmd += " Group by 1, 2, 3, 4, 5, 7, 8, 9, 10, 11,  o.immeuble_id, lot_id, c.id";
// TODO Parametrer le tri
        cmd += " order by solde asc";
        var parameters = new List<NpgsqlParameter>
        {
            new("@mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@statut", (int)GlobalConstantes.StatutOperation.Valide),
            new("@statut_copro", (int)GlobalConstantes.StatutData.Supprime)
        };


        var table = getResultSQL(cmd, parameters);
        return table;
    }

    public DataTable GetDataForRelance(string ids, string date_edition, int type_relance)
    {
        var schema = getSchema();
        var cmd = " Select ";

        cmd += " case when coalesce(nomcomp,'')<>'' then x.code else p.code end as Civilite, ";
        cmd +=
            " case when coalesce(nomcomp,'')<>'' then nomcomp else concat(c.nom , ' ', prenom) end as Coproprietaire, ";
        cmd += " c.reference as ReferenceCoproprietaire, ";
        cmd += " case when coalesce(nomcomp,'')<>'' then c.adressecomp else c.adresse end as AdresseCoproprietaire, ";
        cmd += " case when coalesce(nomcomp,'')<>'' then c.villecomp else c.ville end as VilleCoproprietaire, ";
        cmd += " case when coalesce(nomcomp,'')<>'' then c.codecomp else c.codepostal end as CodePostalCoproprietaire,";
        cmd += " i.reference as ReferenceImmeuble, i.nom as NomImmeuble,";
        cmd +=
            " i.rue as AdresseImmeuble, i.ville as VilleImmeuble, i.codepostal as CodePostalImmeuble, l.numero_lot as NumeroLot, ";
        cmd +=
            " case when coalesce(nomcomp,'') <> '' then concat('Copropriétraire:\t', c.nom , ' ', prenom) else '' end as NomCopro,";
        cmd += " (sum(credit)- sum(debit))*-1 as solde , (sum(credit)- sum(debit))*-1 + @montant_relance as Total, ";
//            cmd += " (sum(credit)- sum(debit)) as solde , (sum(credit)- sum(debit)) + @montant_relance as Total, ";
        cmd +=
            " @date_edition as DateEdition, @montant_relance As MontantRelance, @texte_relance as Rappel, case when coalesce(nomcomp,'')<>'' then 1 else 0 end as comp, ";

        cmd +=
            "p.code civ_copro, concat(c.nom , ' ', prenom) as nom_copro, c.adresse as adrs_copro, concat(c.ville, ' ', c.pays) as ville_copro, c.codepostal as cp_copro ,";
        cmd += " c.id as copro_id";
        cmd += $" from {getSchemaTable()} o";
        cmd += $" join {schema}.immeuble i on (o.immeuble_id = i.id) ";
        cmd += $" join {schema}.coproprietaire c on (o.coproprietaire_id = c.id) ";
        cmd += $" join {schema}.lot_description l on (o.coproprietaire_id = l.coproprietaire_id) ";
        cmd +=
            " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) p ON p.iparam_1 = c.codenvoi ";
        cmd +=
            " INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CODEENVOICOMPTE')) x ON x.iparam_1 = c.codenvComp ";

        cmd += $"  where c.id in ({ids}) and o.statut = @statut";
        cmd += " and type_mouvement =@mouvement ";
        cmd += " Group by 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25";
        cmd += " order by c.reference ";

        var parameters = new List<NpgsqlParameter>
        {
            new("@mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@statut", (int)GlobalConstantes.StatutOperation.Valide),
            new("@date_edition", date_edition),
            new("@montant_relance", RelanceController.getMontantRelance(type_relance)),
            new("@texte_relance", RelanceController.getTexteRelance(type_relance))
        };
        Console.WriteLine(cmd);
        var table = getResultSQL(cmd, parameters);
        return table;
    }

    public DataTable GetReleveFiscalCoproprietaire(string coproprietaire_id, DateTime dtDeb, DateTime dtFin)
    {
        var schema = getSchema();
        var cmd = " select ";

        cmd += " n.reference, n.nom, o.libelle, o.debit, o.credit, n.declaration, ";
        cmd += "case when fo.reference <> '999' then trim(fo.nom) else trim(f.comment_fournisseur) end as fournisseur ";
        cmd += $" from {getSchemaTable()} o";
        cmd += $" join {schema}.nature n on (o.nature_id = n.id  and trim(n.declaration) <> '')";
        //
        cmd += $" left join {getSchema()}.saisie_facture f on  ";
//            cmd += " (f.nature_id = o.nature_id and f.immeuble_id = o.immeuble_id and trim(f.libelle) = trim(o.libelle) and o.base_repart = f.base_repart and o.date_reference = f.date_reference )";
        cmd += "f.id = o.saisie_id ";
        cmd += $" left join {getSchema()}.fournisseur fo on (f.fournisseur_id = fo.id)";
        //
        cmd += " where coproprietaire_id = @coproprietaire_id ";
        cmd += " and o.statut = @statut";
        cmd += " and o.date_reference >= @dtDeb and o.date_reference <= @dtFin";

        var parameters = new List<NpgsqlParameter>
        {
            new("@coproprietaire_id", coproprietaire_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Valide),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin)
        };
        //Console.WriteLine(cmd.Replace("@coproprietaire_id", coproprietaire_id));
        var table = getResultSQL(cmd, parameters);
        return table;
    }

    public DataTable getListeOperations(string immeuble_id, string lot_reference, string type, int statut = -1)
    {
        return getListeOperations(immeuble_id, lot_reference, type, statut, DateTime.Parse("01/01/1970"),
            DateTime.Parse("01/01/1970"), "", "");
    }

    public DataTable getListeOperations(string immeuble_id, string lot_reference, string type, int statut,
        DateTime dtDeb, DateTime dtFin, string ref_nature, string base_repart, string libelle = "", string montant = "")
    {
        var schema = getSchema();
        var cmd = "Select ";
        var numlot = 0;

//            cmd += " sf.id, n.reference as ref_nature, n.nom as nature, c.reference as ref_copro, concat(c.prenom, ' ',c .nom) as coproprietaire, date_reference, libelle, debit, credit, global, base_repart, ";
// 1.0.0.11            
        //cmd += " sf.id, n.reference as ref_nature, n.nom as nature, concat(c.prenom, ' ',c .nom) as coproprietaire, c.reference as ref_copro, date_reference, libelle, debit, credit, global, base_repart, ";
        cmd += " sf.id, n.reference as ref_nature, n.nom as nature, ";
        cmd += " coalesce(c .nom, '') as coproprietaire, coalesce(c.reference, ' ') as ref_copro, ";
        cmd += " date_reference, libelle, ";
//            cmd += " debit, credit, ";
        cmd += " case when debit < 0 then 0 when credit < 0 then abs(credit) else debit end as debit, ";
        cmd += " case when debit < 0 then abs(debit) when credit <0 then 0 else credit end as credit,";

        cmd += " global, base_repart, ";

        cmd += " case ";
        cmd += "when c.daterel3 is not null then c.daterel3 ";
        cmd += "when c.daterel2 is not null then c.daterel2 ";
        cmd += "when c.daterel1 is not null then c.daterel1 ";
        cmd += "else null end as date_relance, ";

        cmd += " sf.statut ";

        cmd += $" from {getSchemaTable()} sf";
        cmd += $" left join {schema}.nature n on n.id = nature_id ";
        cmd += $" left join {schema}.lot_description l on l.id = lot_id ";
        cmd += $" left join {schema}.coproprietaire c on c.id = l.coproprietaire_id ";


        cmd += " where sf.immeuble_id = @immeuble_id ";
        if (statut != -1)
            cmd += " and sf.statut = @statut ";
        if (type != "")
            cmd += " and type_mouvement = @type_mouvement";
        if (lot_reference != "")
        {
            numlot = Convert.ToInt32(lot_reference);
            cmd += " and l.numero_lot = @numlot";
        }

        if (dtDeb != DateTime.Parse("01/01/1970"))
        {
            if (dtFin != DateTime.Parse("01/01/1970"))
                cmd += " and date_reference >= @dtDeb";
            else
                cmd += " and date_reference = @dtDeb";
        }

        if (dtFin != DateTime.Parse("01/01/1970"))
            cmd += " and date_reference <= @dtFin";
        if (ref_nature != "")
            cmd += " and n.reference = @ref_nature";
        if (base_repart != "")
            cmd += " and base_repart = @base_repart";
        if (libelle != "")
            cmd += " and trim(libelle) like trim(@libelle)";
        if (montant != "")
            cmd += " and (credit = @montant or debit=@montant or global=@montant)";

        cmd += " order by n.reference ";

        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@numlot", numlot),
            new("@type_mouvement", type),
            new("@ref_nature", ref_nature),
            new("@statut", statut),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin),
            new("@base_repart", base_repart),
            new("@libelle", libelle + "%"),
            new("@montant", Convertir.ToDecimal(montant))
        };
        return getResultSQL(cmd, parameters);
    }

    /*
    public decimal[]  getTotalOperationWithoutSolde(string immeuble_id, DateTime dtDeb, DateTime dtFin)
    {
        decimal[] sum = new decimal[2];
        string nature = "140";

        string cmd = string.Format("select sum(debit) as debit, sum(credit) as credit from {0} f", getSchemaTable());
        cmd += string.Format(" join agence.nature n on n.id = f.nature_id ", getSchema());
        cmd += " where immeuble_id = @immeuble_id and date_reference >= @dtDeb and date_reference <= @dtFin";
        cmd += " and n.reference <> @nature and f.statut = @statut";

        List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
        {
            new NpgsqlParameter("@immeuble_id", immeuble_id),
            new NpgsqlParameter("@nature", nature),
            new NpgsqlParameter("@dtDeb", dtDeb),
            new NpgsqlParameter("@dtFin", dtFin),
            new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Valide),
        };

        DataTable table = getResultSQL(cmd, parameters);

        if (table != null)
            if (table.Rows.Count > 0)
            {
                DataRow row = table.Rows[0];
                sum[0] = Convertir.ToDecimal(row["debit"]);
                sum[1] = Convertir.ToDecimal(row["credit"]);
            }
        return sum;
    }
     * */
    public decimal getOperationDepense(string immeuble_id, DateTime dtDeb, DateTime dtFin, string copro_id = "")
    {
        decimal depense = 0;

        var cmd = $"select coalesce(sum(credit)-sum(debit),0) as depense from {getSchemaTable()} o ";
        cmd += $" left join {getSchema()}.nature n on n.id = nature_id ";
        cmd += $" left join {getSchema()}.coproprietaire c on c.id = coproprietaire_id ";
        cmd += " where immeuble_id = @immeuble_id ";
        if (copro_id != "")
            cmd += " and c.id = @copro_id";

        cmd += " and type_mouvement =@depense ";
        cmd += " and o.statut != @statut and date_reference >= @dtDeb and date_reference <= @dtFin";
        // GVI
        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@copro_id", copro_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime),
            new("@depense", nameof(GlobalConstantes.TypeMouvement.Depense)),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin)
        };

        var table = getResultSQL(cmd, parameters);
        if (table != null && table.Rows.Count > 0) depense = (decimal)table.Rows[0]["depense"];

        return depense;
    }

    public decimal getOperationAppel(string immeuble_id, DateTime dtDeb, DateTime dtFin, string copro_id = "")
    {
        decimal sum = 0;
        var nature = "140";

        var cmd = $"select sum(credit)-sum(debit) as montant from {getSchema()}.operation f";
        cmd += string.Format(" left join agence.nature n on n.id = f.nature_id ", getSchema());
        cmd += " where immeuble_id = @immeuble_id and date_reference >= @dtDeb and date_reference <= @dtFin";
        cmd += " and type_mouvement=@type_mouvement and type_operation = @type_operation";
        cmd += " and n.reference <> @nature ";
        cmd += " and f.statut != @statut";
        if (copro_id != "")
            cmd += " and coproprietaire_id=@copro_id";

        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@nature", nature),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin),
            new("@copro_id", copro_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@type_operation", nameof(GlobalConstantes.TypeOperation.AppelDeFond))
        };

        var table = getResultSQL(cmd, parameters);

        if (table != null)
            if (table.Rows.Count > 0)
            {
                var row = table.Rows[0];
                sum = Convertir.ToDecimal(row["montant"]);
            }

        return sum;
    }

    public decimal getSoldeImmeuble(string immeuble_id, DateTime dtDeb, DateTime dtFin, string copro_id = "")
    {
        decimal depense = 0, solde_ante = 0, reglements = 0;

        depense = getOperationDepense(immeuble_id, dtDeb, dtFin, copro_id);

        var cmd =
            // Solde precedent
            $"select coalesce(sum(credit)-sum(debit),0) as solde_ant from {getSchemaTable()} o ";
        cmd += $" left join {getSchema()}.nature n on n.id = nature_id ";
        cmd += $" left join {getSchema()}.coproprietaire c on c.id = coproprietaire_id ";
        cmd += " where immeuble_id = @immeuble_id ";
        if (copro_id != "")
            cmd += " and c.id = @copro_id";
        cmd += " and n.reference =  '140'";
        cmd += " and o.statut != @statut and date_reference >= @dtDeb and date_reference <= @dtFin";

        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@copro_id", copro_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime),
            new("@depense", nameof(GlobalConstantes.TypeMouvement.Depense)),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin)
        };

        var table = getResultSQL(cmd, parameters);
        if (table != null && table.Rows.Count > 0) solde_ante = (decimal)table.Rows[0]["solde_ant"];

        reglements = SaisieReglementController.getController()
            .getTotalOperationWithoutSolde(immeuble_id, dtDeb, dtFin, copro_id);


        //Console.WriteLine("Soldes {0} + {1} - {2} = {3}", solde_ante, reglements, depense, solde_ante + reglements - depense );

        return solde_ante + reglements + depense;
    }

    public DataTable GetBalanceReglementAppelsDeFond(string immeuble_id)
    {
        var cmd = "select 1 as type, date_reference, libelle, ";
        cmd += " case when debit = 0 then null else debit end as debit, ";
        cmd += " case when credit = 0 then null else credit end as credit ";
        cmd += $" from {getSchemaTable()} o ";
        cmd += " where immeuble_id = @immeuble_id and o.statut = @statut";
        cmd += " and type_mouvement = @type_mouvement";
        cmd += " order by 1, 2 ";

        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@statut", (int)GlobalConstantes.StatutOperation.Valide)
        };

        return getResultSQL(cmd, parameters);
    }

    public DataTable getOperationFromSaisie(string saisie_id)
    {
        var cmd = $"select * from {getSchemaTable()} where saisie_id =@saisie_id and statut != @statut";
        return getResultSQL(cmd,
        [
            new NpgsqlParameter("@saisie_id", saisie_id),
            new NpgsqlParameter("@statut", (int)GlobalConstantes.StatutOperation.Supprime)
        ]);
    }

    public DataTable GetReleveIndividuels(string immeuble_id, DateTime dtDeb, DateTime dtFin)
    {
        var schema = getSchema();
        var cmd = " select ";

        cmd += "c.id as ref_copro, n.reference as ref_nature, sf.base_repart, trim(n.nom) as nom, ";
        cmd += "case when f.reference <> '999' then trim(f.nom) else trim(sf.comment_fournisseur) end as fournisseur, ";
        cmd += "trim(o.Libelle) as libelle, ir.valeur as mill_generaux, lr.valeur as mill_indiv, ";
//            cmd += " sum(global) as global, sum(debit) as debit, sum (credit) as credit, n.charge_locative::numeric as charge_loc, ir.nom as base_nom, 0 as who";
//            cmd += " sum(global) as global, sum(debit) as debit, sum (credit) as credit, ";
        cmd += " sum(global) as global, ";
        cmd += " sum(case when debit < 0 then 0 when credit < 0 then abs(credit) else debit end) as debit, ";
        cmd += " sum(case when debit < 0 then abs(debit) when credit < 0 then 0 else credit end ) as credit, ";
        cmd += " case when commerce then 0 else n.charge_locative::numeric end as charge_loc, ";
        cmd += " ir.nom as base_nom, 0 as who";

        cmd += " , 0 as ancien, 0 as nouveau, o.ref_cpt, o.saisie_id, o.date_reference, o.numero_operation ";

        cmd += $" from {getSchemaTable()} o ";
        cmd += $" join {schema}.nature n on n.id = o.nature_id ";
        cmd += $" join {schema}.coproprietaire c on c.id = o.coproprietaire_id ";
        cmd +=
            $" join {schema}.saisie_facture sf on sf.immeuble_id = o.immeuble_id and sf.nature_id = o.nature_id and sf.date_reference = o.date_reference and o.base_repart=sf.base_repart and o.global = sf.montant and trim(o.libelle)=trim(sf.libelle)";
        cmd += $" left join {schema}.fournisseur f on f.id = sf.fournisseur_id ";

        cmd +=
            $" join {schema}.immeuble_repartition ir on ir.immeuble_id = o.immeuble_id and ir.reference = sf.base_repart";
        cmd +=
            $" join {schema}.lot_repartition lr on  lr.immeuble_id = o.immeuble_id and lr.lot_id = o.lot_id and sf.base_repart = lr.reference ";


        cmd +=
            " where saisie_id = 'Reprise' and o.immeuble_id = @immeuble_id and o.statut in ( @statut, @statut_cloture)";
        cmd += " and n.reference != @solde_bilan ";

        cmd += " and o.date_reference >= @dateDeb and o.date_reference <= @dateFin";
        cmd += " and o.type_mouvement = @type_mouvement";

        cmd +=
            " group by 1, 2, 3, 4, 5, 6, 7, 8, 12, 13, ancien, nouveau, ref_cpt, o.numero_operation, o.saisie_id, o.date_reference";

        var cmd2 = " select ";

        cmd2 += "c.id as ref_copro, n.reference as ref_nature, sf.base_repart , trim(n.nom) as nom, ";
        cmd2 +=
            "case when f.reference <> '999' then trim(f.nom) else trim(sf.comment_fournisseur) end as fournisseur, ";
        //cmd2 += "trim(o.Libelle) as libelle, ir.valeur as mill_generaux, lr.valeur as mill_indiv, sum(global) as global, sum(debit) as debit, sum (credit) as credit, n.charge_locative::numeric as charge_loc, ir.nom as base_nom";
        cmd2 += "trim(o.Libelle) as libelle, ";

        //cmd2 += " case when o.base_repart != '86' and o.base_repart != '87' then ir.valeur else ri.global end as mill_generaux, ";
        //cmd2 += " case when o.base_repart != '86' and o.base_repart != '87' then lr.valeur else ri.index end as mill_indiv, ";

        //cmd2 += " case when o.base_repart != '86' and o.base_repart != '87' then case when ir.valeur <> 0 then ir.valeur else round(ri.global,0) end else ri.global end as mill_generaux,  ";
        //cmd2 += " case when o.base_repart != '86' and o.base_repart != '87' then case when ir.valeur <> 0 then lr.valeur else round(ri.index,0) end else ri.index end as mill_indiv,  ";
        cmd2 +=
            " case when o.base_repart Not like '8%' then case when ir.valeur <> 0 then ir.valeur else round(ri.global,0) end else round(ri.global,0) end as mill_generaux,  ";
        cmd2 +=
            " case when o.base_repart Not like '8%' then case when ir.valeur <> 0 then lr.valeur else round(ri.index,0) end else round(ri.index,0) end as mill_indiv,  ";

//            cmd2 += " sum(o.global) as global, sum(debit) as debit, sum (credit) as credit, ";
        cmd2 += " sum(o.global) as global, ";
        cmd2 += " sum(case when debit < 0 then 0 when credit < 0 then abs(credit) else debit end) as debit, ";
        cmd2 += " sum(case when debit < 0 then abs(debit) when credit < 0 then 0 else credit end ) as credit, ";

        cmd2 += " case when commerce then 0 else n.charge_locative::numeric end as charge_loc, ";
        cmd2 += " ir.nom as base_nom, 1 as who";
        cmd2 += " , ri.ancien,";
        cmd2 += " ri.nouveau , o.ref_cpt, o.saisie_id, o.date_reference, o.numero_operation ";
        cmd2 += $" from {getSchemaTable()} o ";
        cmd2 += $" join {schema}.nature n on n.id = o.nature_id ";
        cmd2 += $" join {schema}.coproprietaire c on c.id = o.coproprietaire_id ";
        cmd2 += $" join {schema}.saisie_facture sf on sf.id = saisie_id";
        cmd2 += $" left join {schema}.fournisseur f on f.id = sf.fournisseur_id ";
        cmd2 += $" left Join {schema}.repart_individuelle ri on ri.operation_id = o.id";

        cmd2 +=
            $" join {schema}.immeuble_repartition ir on ir.immeuble_id = o.immeuble_id and ir.reference = sf.base_repart";
        cmd2 +=
            $" join {schema}.lot_repartition lr on  lr.immeuble_id = o.immeuble_id and lr.lot_id = o.lot_id and sf.base_repart = lr.reference ";


        cmd2 +=
            " where o.saisie_id != 'Reprise' and o.immeuble_id = @immeuble_id and o.statut in ( @statut, @statut_cloture)";
        cmd2 += " and n.reference != @solde_bilan ";

        cmd2 += " and o.date_reference >= @dateDeb and o.date_reference <= @dateFin";
        cmd2 += " and o.type_mouvement = @type_mouvement";

        cmd2 +=
            " group by 1, 2, 3, 4, 5, 6, 7, 8, 12, 13, ancien, nouveau, index, o.ref_cpt, o.saisie_id, o.date_reference, o.numero_operation";

        //            cmd += " order by 1, 2";

        //Console.WriteLine(cmd);
        //Console.WriteLine(cmd2);

        var cmd_all =
            $" select * from ({cmd} union {cmd2}) as x order by 1, 2, 3, date_reference, numero_operation, saisie_id, ref_cpt";
        var trace = cmd_all.Replace("@immeuble_id", "'" + immeuble_id + "'");
        trace = trace.Replace("@type_mouvement", "'" + nameof(GlobalConstantes.TypeMouvement.Depense) + "'");
        trace = trace.Replace("@statut_cloture", ((int)GlobalConstantes.StatutOperation.Cloture).ToString());
        trace = trace.Replace("@statut", ((int)GlobalConstantes.StatutOperation.Valide).ToString());
        trace = trace.Replace("@dateDeb", "'" + dtDeb.ToString("yyyy-MM-dd") + "'");
        trace = trace.Replace("@dateFin", "'" + dtFin.ToString("yyyy-MM-dd") + "'");
        trace = trace.Replace("@solde_bilan", "'140'");

        Console.WriteLine(trace);
#if DEBUG
//            cmd_all = cmd2;
#endif
        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Depense)),
            new("@statut", (int)GlobalConstantes.StatutOperation.Valide),
            new("@statut_cloture", (int)GlobalConstantes.StatutOperation.Cloture),
            new("@dateDeb", dtDeb),
            new("@dateFin", dtFin),
            new("@solde_bilan", ParametresDB.getParam1("NATURE", "SOLDE BILAN"))
        };

        return getResultSQL(cmd_all, parameters);
    }

    public DataTable getSoldesBidon()
    {
        const string cmd =
            "SELECT 'xx' as coproprietaire_id, 0 as  debit, 0 as credit ,1 as ordre, 'test' as libelle from agence.operation limit 1";
        return getResultSQL(cmd);
    }

    public DataTable getSoldesRelevesIndividuels(string immeuble_id, DateTime dtDeb, DateTime dtFin,
        bool bAppelOnly = false)
    {
        var schema = getSchema();

        //, dtDeb.AddDays(-1).ToShortDateString() 

        var cmdSolde =
            $" select coproprietaire_id, 1 as ordre, 'Solde Antérieur au {dtDeb.AddDays(-1).ToShortDateString()} ' as libelle, ";
//            cmdSolde += " debit, credit ";
        cmdSolde += " case when debit < 0 then 0 when credit < 0 then abs(credit) else debit end as debit, ";
        cmdSolde += " case when debit < 0 then abs(debit) when credit <0 then 0 else credit end as credit ";
        cmdSolde += $" from {getSchemaTable()} o ";
        cmdSolde += $" join {schema}.nature n on n.id = o.nature_id and n.reference = @solde_bilan ";
        cmdSolde +=
            " where immeuble_id = @immeuble_id and date_reference >=@dateDeb and date_reference <= @dateFin and o.statut in (@statut, @statut_cloture)";

        var cmdReglements = "select coproprietaire_id , 2 as ordre , 'Règlements de l''exercice' , ";
//            cmdReglements += String.Format(" 0, sum(montant) from {0}.saisie_reglement sr", schema);
        cmdReglements +=
            $" sum(case when montant<0 then abs(montant) else 0 end) as debit, sum(case when montant<0 then 0 else montant end) as credit from {schema}.saisie_reglement sr";
        cmdReglements +=
            $" join {schema}.nature n on n.id = sr.nature_id and n.reference NOT in (@solde_bilan, @appel_fond )";
        cmdReglements +=
            " where immeuble_id = @immeuble_id and date_reference >=@dateDeb and date_reference <= @dateFin and sr.statut in ( @statut, @statut_cloture)";
        cmdReglements += " group by 1";

        //string cmdPaiements = String.Format(" select coproprietaire_id, 3 as ordre,  'Votre Relevé', sum(debit), sum(abs(credit)) from {0} o", getSchemaTable());
        var cmdPaiements =
            $" select coproprietaire_id, 3 as ordre,  'Votre Relevé', sum(debit), abs(sum(credit)) from {getSchemaTable()} o";
        cmdPaiements +=
            $" join {schema}.nature n on n.id = o.nature_id and n.reference NOT in (@solde_bilan, @appel_fond )";
        cmdPaiements +=
            " where immeuble_id = @immeuble_id and date_reference >=@dateDeb and date_reference <= @dateFin and type_mouvement = @type_mouvement and o.statut in ( @statut, @statut_cloture)";
        cmdPaiements += " group by 1";

        var cmdAppel =
            $" select coproprietaire_id, 4 as ordre, 'Appels de fonds de l''exercice' as libelle, sum(debit) as debit, sum(credit) as credit from {getSchemaTable()} o";
        cmdAppel += $" join {schema}.nature n on n.id = o.nature_id and n.reference = @appel_fond ";
        cmdAppel +=
            " where immeuble_id = @immeuble_id and date_reference >=@dateDeb and date_reference <= @dateFin and o.statut in ( @statut, @statut_cloture) ";
        cmdAppel += " group by 1";

        var cmd = " select coproprietaire_id, ordre, libelle, debit, credit from ";
        if (bAppelOnly)
            cmd += $" ( {cmdAppel} ) t order by 2";
        else
            cmd += $" ( {cmdSolde} union {cmdReglements} union {cmdPaiements} ) t order by 2";

        //cmd = cmdSolde;

        //if (bAppelOnly)
        //    Console.WriteLine(cmdAppel);
        //else
        //    Console.WriteLine(cmd);

        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Depense)),
            new("@statut", (int)GlobalConstantes.StatutOperation.Valide),
            new("@statut_cloture", (int)GlobalConstantes.StatutOperation.Cloture),
            new("@dateDeb", dtDeb),
            new("@dateFin", dtFin),
            new("@solde_bilan", ParametresDB.getParam1("NATURE", "SOLDE BILAN")),
            new("@appel_fond", ParametresDB.getParam1("NATURE", "APPEL DE FONDS"))
        };
        return getResultSQL(cmd, parameters);
    }

    public DataTable getFactureOperations(SaisieFactureEntite facture)
    {
        var schema = getSchema();
        var cmd =
            "select o.id, n.reference as ref_nature, n.nom as nature, c.reference as ref_copro, concat ( c.prenom, ' ', c.nom) as coproprietaire, libelle, debit, credit, base_repart, o.statut, o.saisie_id";

        cmd += $" from {getSchemaTable()} o ";
        cmd += $" left join {schema}.nature n on n.id = nature_id ";
        cmd += $" left join {schema}.coproprietaire c on c.id = coproprietaire_id";
        cmd += " where immeuble_id = @immeuble_id and type_mouvement=@type_mouvement and nature_id = @nature_id";
        cmd += " and o.statut != @statut";
        if (facture.liasse_id.StartsWith("Reprise"))
        {
            cmd += " and date_reference = @date_reference and base_repart = @base_repart and global = @montant ";
            cmd += " and trim(libelle) =@libelle";
        }
        else
        {
            cmd += " and o.saisie_id = @saisie_id";
        }

        if (facture.lot_id != null) cmd += " and lot_id = @lot_id";

        //            cmd += " and coproprietaire_id =@coproprietaire_id";
        var parameters = new List<NpgsqlParameter>
        {
            new("@saisie_id", facture.id),
            new("@immeuble_id", facture.immeuble_id),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Depense)),
            new("@nature_id", facture.nature_id),
            new("@date_reference", facture.date_reference),
            new("@base_repart", facture.base_repart),
            new("@libelle", facture.libelle.Trim()),
            new("@montant", facture.montant),
            new("@lot_id", facture.lot_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime)
        };
        return getResultSQL(cmd, parameters);
    }

    public DataTable getNativeFactureOperations(SaisieFactureEntite facture)
    {
        var cmd = $" select * from {getSchemaTable()} o ";

        cmd += " where immeuble_id = @immeuble_id and type_mouvement=@type_mouvement and nature_id = @nature_id ";
        cmd += " and date_reference = @date_reference and base_repart = @base_repart and global = @montant ";
        cmd += " and trim(libelle) = @libelle";
        cmd += " and o.statut != @statut";
        if (facture.lot_id != null) cmd += " and lot_id = @lot_id";
        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", facture.immeuble_id),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Depense)),
            new("@nature_id", facture.nature_id),
            new("@date_reference", facture.date_reference),
            new("@base_repart", facture.base_repart),
            new("@montant", facture.montant),
            new("@libelle", facture.libelle.Trim()),
            new("@lot_id", facture.lot_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime)
        };
        return getResultSQL(cmd, parameters);
    }

    public DataTable getReglementOperations(SaisieReglementEntite reglement)
    {
        var schema = getSchema();
        var cmd =
            "select o.id, n.reference as ref_nature, n.nom as nature, c.reference as ref_copro, concat ( c.prenom, ' ', c.nom) as coproprietaire, libelle, debit, credit, o.statut, base_repart, o.saisie_id";

        cmd += $" from {getSchemaTable()} o ";
        cmd += $" left join {schema}.nature n on n.id = nature_id ";
        cmd += $" join {schema}.coproprietaire c on c.id = coproprietaire_id";
        cmd +=
            " where immeuble_id = @immeuble_id and type_mouvement=@type_mouvement and coproprietaire_id = @coproprietaire_id";
        cmd +=
            " and nature_id = @nature_id and date_reference = @date_reference and trim(libelle) = @libelle"; //and global = @montant ";
        cmd += " and credit = @montant and o.statut != @statut";

        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", reglement.immeuble_id),
            new("@coproprietaire_id", reglement.coproprietaire_id),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@nature_id", reglement.nature_id),
            new("@date_reference", reglement.date_reference),
            new("@libelle", reglement.libelle.Trim()),
            new("@montant", reglement.montant),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime)
        };
        return getResultSQL(cmd, parameters);
    }

    public DataTable getAppelDeFondOperations(SaisieAppelFondEntite appel)
    {
        var schema = getSchema();
        var cmd =
            "select o.id, n.reference as ref_nature, n.nom as nature, c.reference as ref_copro, c.nom as coproprietaire, l.numero_lot, libelle, debit, credit, o.statut, base_repart, o.saisie_id";

        cmd += $" from {getSchemaTable()} o ";
        cmd += $" left join {schema}.nature n on n.id = nature_id ";
        cmd += $" left join {schema}.coproprietaire c on c.id = coproprietaire_id";
        cmd += $" left join {schema}.lot_description l on l.id = lot_id";
        cmd += " where o.immeuble_id = @immeuble_id and type_mouvement=@type_mouvement and nature_id = @nature_id ";
        cmd +=
            " and date_reference = @date_reference and trim(libelle) = @libelle and o.statut!= @statut and base_repart=@base_repart"; //and global = @montant ";
        //if (appel.liasse_id.StartsWith("Reprise"))
        //    cmd += " and saisie_id = 'Reprise'";
        if (appel.base_repart == "80")
        {
            if (appel.lot_id != null)
                cmd += " and lot_id = @lot_id";
            else if (appel.montant < 0)
                cmd += " and credit = @montant";
            else
                cmd += " and debit = @montant";
        }

        cmd += " order by l.numero_lot ";
        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", appel.immeuble_id),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@nature_id", appel.nature_id),
            new("@date_reference", appel.date_reference),
            new("@base_repart", appel.base_repart),
            new("@libelle", appel.libelle.Trim()),
            new("@montant", Math.Abs(appel.montant)),
            new("@lot_id", appel.lot_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime)
        };
//            Console.WriteLine(cmd);

        var table = getResultSQL(cmd, parameters);
        if (table != null)
            if (table.Rows.Count <= 0)
            {
                cmd = cmd.Replace("and base_repart=@base_repart", "");
                table = getResultSQL(cmd, parameters);
            }

        return table;
    }

    public DataTable getSaisieOperations(string saisie_id)
    {
        var schema = getSchema();
        var cmd =
            "select o.id, n.reference as ref_nature, n.nom as nature, c.reference as ref_copro, c.nom as coproprietaire, libelle, l.numero_lot, debit, credit, o.statut, base_repart, o.saisie_id";
        cmd += $" from {getSchemaTable()} o ";
        cmd += $" left join {schema}.nature n on n.id = nature_id ";
        cmd += $" left join {schema}.coproprietaire c on c.id = coproprietaire_id";
        cmd += $" left join {schema}.lot_description l on l.id = lot_id";
        cmd += " where saisie_id = @saisie_id and o.statut!=@statut";
        var parameters = new List<NpgsqlParameter>
        {
            new("@saisie_id", saisie_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime)
        };
        return getResultSQL(cmd, parameters);
    }

    public DataTable getNativeSaisieOperations(string saisie_id)
    {
        var cmd = $" select * from {getSchemaTable()} o ";
        cmd += " where saisie_id = @saisie_id and o.statut!=@statut";
        var parameters = new List<NpgsqlParameter>
        {
            new("@saisie_id", saisie_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime)
        };
        return getResultSQL(cmd, parameters);
    }

    public bool InsertOperationFromSaisie(SaisieAppelFondEntite saisie, OperationEntite currOpe, decimal montant,
        string copro_id, string lot_id, int numligne = 0)
    {
        var rc = false;
        var operation = currOpe;
        if (operation == null)
            if (montant == 0)
                return true;
            else
                operation = new OperationEntite(saisie);

        if (montant == 0)
        {
            if (operation.id == "")
                return true;
            operation.statut = (int)GlobalConstantes.StatutOperation.Supprime;
        }
        else
        {
            operation.statut = (int)GlobalConstantes.StatutOperation.Brouillon;
        }

        operation.base_repart = saisie.base_repart;
        operation.numero_ligne = numligne;
        operation.lot_id = lot_id;
        operation.coproprietaire_id = copro_id;
        operation.debit = montant;


        if (!doInsertOrUpdate(operation))
            throw new Exception("Insert Operation From Saisie");
        rc = true;
        return rc;
    }

    public bool InsertOperationFromSaisie(SaisieFactureEntite saisie, OperationEntite currOpe, decimal montant,
        string copro_id, string lot_id, int numligne = 0)
    {
        var rc = false;
        var operation = currOpe;
        if (operation == null)
            if (montant == 0)
                return true;
            else
                operation = new OperationEntite(saisie);

        if (montant == 0)
        {
            if (operation.id == "")
                return true;
            operation.statut = (int)GlobalConstantes.StatutOperation.Supprime;
        }
        else
        {
            operation.statut = (int)GlobalConstantes.StatutOperation.Brouillon;
        }

        operation.base_repart = saisie.base_repart;
        operation.numero_ligne = numligne;
        operation.lot_id = lot_id;
        operation.coproprietaire_id = copro_id;
        operation.debit = montant;


        if (!doInsertOrUpdate(operation))
            throw new Exception("Insert Operation From Facture");
        rc = true;
        return rc;
    }

    public string getNumeroLotFromSaisie(string saisie_id)
    {
        var lot_num = "";
        var cmd =
            $"select numero_lot from {getSchemaTable()} o join {getSchema()}.lot_description d on d.id = o.lot_id ";
        cmd += " where saisie_id =@saisie_id and o.statut != @statut";
        var parameters = new List<NpgsqlParameter>
        {
            new("@saisie_id", saisie_id),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime)
        };

        var table = getResultSQL(cmd, parameters);
        if (table != null)
            if (table.Rows.Count > 0)
            {
                var row = table.Rows[0];
                lot_num = row["numero_lot"].ToString();
            }

        return lot_num;
    }

    public void DeleteElements(DataTable table)
    {
        foreach (DataRow row in table.Rows)
        {
            var ope = new OperationEntite(row)
            {
                statut = (int)GlobalConstantes.StatutOperation.Supprime
            };
            if (!doInsertOrUpdate(ope))
                throw new Exception("Annulation operation Failed");
        }
    }

    public void DeleteEntite(string id)
    {
        var ope = getEntiteById(id);
        if (ope == null)
            throw new Exception("Operation inexistante");
        ope.statut = (int)GlobalConstantes.StatutOperation.Supprime;
        if (!doInsertOrUpdate(ope))
            throw new Exception("Annulation operation Failed");
    }

    public DataTable getOperationRepriseReglement()
    {
        var cmd =
            "select *, concat('*** ', i.reference) as ref_imm from agence.operation o join agence.immeuble i on i.id = immeuble_id where liasse_id like 'Reprise%'  ";
        cmd += " and type_mouvement = 'Recette' and type_operation = 'Tresorerie' and o.statut=1";
        cmd += " order by i.reference ";
        return getResultSQL(cmd);
    }

    public DataTable getOperationRepriseAppels()
    {
        var cmd =
            "select *, concat('*** ', i.reference) as ref_imm from agence.operation o join agence.immeuble i on i.id = immeuble_id where liasse_id like 'Reprise%'  ";
        cmd += " and type_mouvement = 'Recette' and type_operation = 'AppelDeFond' and o.statut=1";
        cmd += " order by i.reference ";
        return getResultSQL(cmd);
    }

    public DataTable getOperationRepriseFacture()
    {
        var cmd =
            "select *, concat('*** ', i.reference) as ref_imm from agence.operation o join agence.immeuble i on i.id = immeuble_id where liasse_id like 'Reprise%' and type_mouvement = 'Depense' and o.statut = 1";
        cmd += " order by i.reference ";
        return getResultSQL(cmd);
    }

    public DataTable getOperations(OperationEntite entite)
    {
        var schema = getSchema();
        var cmd =
            "select o.id, n.reference as ref_nature, n.nom as nature, c.reference as ref_copro, concat ( c.prenom, ' ', c.nom) as coproprietaire, libelle, debit, credit, base_repart, o.statut, o.saisie_id";

        cmd += $" from {getSchemaTable()} o ";
        cmd += $" left join {schema}.nature n on n.id = nature_id ";
        cmd += $" left join {schema}.coproprietaire c on c.id = coproprietaire_id";

        cmd += " where o.immeuble_id = @immeuble_id and type_mouvement=@type_mouvement and nature_id = @nature_id ";
        cmd +=
            " and date_reference = @date_reference and trim(libelle) = @libelle and o.statut!= @statut and base_repart=@base_repart"; //and global = @montant ";
        cmd += " and o.statut != @statut ";
        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", entite.immeuble_id),
            new("@type_mouvement", entite.type_mouvement),
            new("@nature_id", entite.nature_id),
            new("@date_reference", entite.date_reference),
            new("@base_repart", entite.base_repart),
            new("@libelle", entite.libelle.Trim()),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime)
        };
//            Console.WriteLine(cmd);
        return getResultSQL(cmd, parameters);
    }

    public DataTable getBadOperations()
    {
        return getResultSQL(
            "select o.*, i.reference as ref_imm from agence.operation o join agence.immeuble i on i.id = immeuble_id where lot_id = '0' order by i.reference ");
    }

    public DataTable getAllFactureOperations(string immeuble_id, DateTime dtDeb, DateTime dtFin)
    {
        var cmd =
            $"select * from {getSchemaTable()} where immeuble_id = @immeuble_id and type_mouvement = @type_mouvement and statut != @statut";
        cmd += " and date_reference >= @dtDeb and date_reference <= @dtFin";
        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Depense)),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin)
        };
        return getResultSQL(cmd, parameters);
    }

    public DataTable getAllReglementsOperations(string immeuble_id, DateTime dtDeb, DateTime dtFin)
    {
        var cmd =
            $"select * from {getSchemaTable()} where immeuble_id = @immeuble_id and type_mouvement = @type_mouvement and type_operation =@type_operation and statut != @statut";
        cmd += " and date_reference >= @dtDeb and date_reference <= @dtFin";
        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@type_operation", nameof(GlobalConstantes.TypeOperation.Tresorerie)),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin)
        };
        return getResultSQL(cmd, parameters);
    }

    public DataTable getAllAppelDeFondOperations(string immeuble_id, DateTime dtDeb, DateTime dtFin)
    {
        var cmd =
            $"select * from {getSchemaTable()} where immeuble_id = @immeuble_id and type_mouvement = @type_mouvement and type_operation =@type_operation and statut != @statut";
        cmd += " and date_reference >= @dtDeb and date_reference <= @dtFin";
        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@type_mouvement", nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@type_operation", nameof(GlobalConstantes.TypeOperation.AppelDeFond)),
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin)
        };
        return getResultSQL(cmd, parameters);
    }

    public OperationEntite getOperationFromFacture(SaisieFactureEntite facture, string copro_id)
    {
        var schema = getSchema();
        OperationEntite op = null;
        var sql = $"select * from {schema}.operation o ";
        sql += $" join {schema}.lot_description ld on ld.coproprietaire_id = o.coproprietaire_id";
        sql +=
            " where o.immeuble_id =@immeuble_id and o.liasse_id = @liasse_id and o.coproprietaire_id= @coproprietaire_id and o.statut!= @statut";

        var parameters = new List<NpgsqlParameter>
        {
            new("@statut", (int)GlobalConstantes.StatutOperation.Supprime),
            new("@immeuble_id", facture.immeuble_id),
            new("@coproprietaire_id", copro_id),
            new("@liasse_id", facture.liasse_id)
        };
        var table = getResultSQL(sql, parameters);
        if (table != null)
            if (table.Rows.Count > 0)
                op = new OperationEntite(table.Rows[0]);
        return op;
    }
}