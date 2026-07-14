using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Utils;
using Npgsql;
using SyndicData.Common;
using SyndicData.Entites;

namespace SyndicData.Controller;

public class SaisieFactureController : AbstractBaseController<SaisieFactureEntite>
{
    private static readonly SaisieFactureController controller = new();

    public override string getTable()
    {
        return "saisie_facture";
    }
    public static SaisieFactureController getController()
    {
        return controller;
    }
    public DataTable GetAllElements(string immeuble_id , DateTime dtDeb , DateTime dtFin)
    {
        var cmd = $"select f.*, i.reference as ref_imm from {getSchemaTable()} f ";
        cmd += " join agence.immeuble i on i.id = immeuble_id ";
//            cmd += " where f.statut != @statut ";
        cmd += " where f.statut = 1 ";
        if (Database.NullDate != dtDeb)
            cmd += " and date_reference >= @dtDeb and date_reference <= @dtFin";

        if (immeuble_id != "")
            cmd += " and immeuble_id = @immeuble_id";
        if (dtDeb != Database.NullDate)
            cmd += " and date_reference >= @dtDeb";
        if (dtFin != Database.NullDate)
            cmd += " and date_reference <= @dtFin";
            
            
        cmd += " order by i.reference, date_reference";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@statut", (int) GlobalConstantes.StatutOperation.Supprime),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin)
        };

        return getResultSQL(cmd, parameters);
    }
    /*
    public DataTable GetAllControlElements(string immeuble_id = "")
    {
        string cmd = String.Format("select f.*, i.reference as ref_imm, c.reference as ref_copro, n.reference as ref_nature from {0} f ", getSchemaTable());
        cmd += " join agence.immeuble i on i.id = immeuble_id ";
        cmd += " join agence.coproprietaire c on c.id = coproprietaire_id ";
        cmd += " join agence.nature n on n.id = nature_id ";
        cmd += " where f.statut = 1 ";
        if (immeuble_id != "")
            cmd += " and immeuble_id = @immeuble_id";
        cmd += " order by i.reference";
        List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
        {
            new NpgsqlParameter("@immeuble_id", immeuble_id),
            new NpgsqlParameter("@statut",(int) GlobalConstantes.StatutOperation.Valide),
        };

        return getResultSQL(cmd, parameters);
    }
     * */
    public DataTable getListeFactures(string liasse_id)
    {
        var schema = getSchema();
        var cmd = " Select ";
        cmd += " i.reference as ref_immeuble, ";
        cmd += " i.nom as immeuble, ";
        cmd += " n.reference as ref_nature, ";
        cmd += " n.nom as nature, ";
        cmd += " f.reference as ref_fournisseur, ";
        cmd += " case when f.reference <> '999' then f.nom else e.comment_fournisseur end as fournisseur, ";
        cmd += " e.comment_fournisseur, ";
        cmd += " e.libelle , e.montant, ";
        cmd += " e.base_repart as Base, ";
        cmd += " e.date_reference ,  ";
        cmd += " e.date_operation,  ";
        cmd += " e.reglement, ";
            
        cmd += " e.liasse_id, e.immeuble_id, e.fournisseur_id, e.nature_id, ";
        cmd += " e.id";
        cmd += $" from {getSchemaTable()} e ";

        cmd += $" left join {schema}.immeuble i on i.id = e.immeuble_id";
        cmd += $" left join {schema}.fournisseur f on f.id = e.fournisseur_id";
        cmd += $" left join {schema}.nature n on n.id = e.nature_id";
            
        cmd += " where liasse_id = @liasse_id and e.statut = @statut ";

        cmd += " order by date_reference desc, coalesce (e.audit_updated, e.audit_created) desc";

        adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
        adapter.SelectCommand.Parameters.AddWithValue("@liasse_id", liasse_id);
        adapter.SelectCommand.Parameters.AddWithValue("@statut", (int)GlobalConstantes.StatutOperation.Brouillon);
        var table = new DataTable();
        try
        {
            adapter.Fill(table);
        }
        catch (NpgsqlException e)
        {
            MessageBox.Show(e.Message);
            return null;
        }

        return table;
    }

    private static string listToCotedString(List<string> list)
    {
        var strList = "";

        foreach (var str in list)
        {
            strList += (strList == "" ? "" : ", ") + $"'{str}'";
        }
        return strList;
    }
    public DataTable getMasterListeFacturation(List<string> liasses)
    {
        var cmd = "Select ";
        cmd += " p.nom as nom, iparam_1 as code, fo.reference, case when fo.reference <> '999' then fo.nom else f.comment_fournisseur end as nom_four";
        cmd += $" from {getSchema()}.saisie_facture f  ";
        cmd += $" join {getSchema()}.fournisseur fo on fo.id = f.fournisseur_id ";
        cmd += " join ( select  groupe, nom, iparam_1 from parametres where groupe='FACTURE_REGLEMENT' ) p on coalesce(f.reglement, 0 ) = iparam_1 ";

        cmd += $" where liasse_id in ({listToCotedString(liasses)}) ";
        cmd += " group by 1, 2, 3, 4 order by 2 ";

        return getResultSQL(cmd);
    }

    public DataTable getListeFacturation(List<string> liasses, string codereg, string reference, string nom_four )
    {
        var schema = getSchema();
        var cmd = "Select ";
        cmd += " i.reference as immeuble, e.date_reference , n.reference as nature, e.base_repart, ";
        cmd += " f.reference as num_fournisseur, ";
        cmd += " case when f.reference <> '999' then f.nom else e.comment_fournisseur end as fournisseur, ";
        cmd += " e.libelle,  e.montant, e.comment_fournisseur ";

        cmd += $" from {schema}.saisie_facture e ";
        cmd += $" left join {schema}.immeuble i on i.id = e.immeuble_id  ";
        cmd += string.Format(" left join agence.fournisseur f on f.id = e.fournisseur_id  ", schema );
        cmd += string.Format(" left join agence.nature n on n.id = e.nature_id  ", schema);
            
        cmd += $" where liasse_id in ({listToCotedString(liasses)}) ";
        cmd += "and e.reglement = @reglement ";
        if (reference != "999")
            cmd += " and f.nom = @nom_four";
        else
            cmd += " and e.comment_fournisseur = @nom_four";

        cmd += " order by e.date_reference ";
        adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
        adapter.SelectCommand.Parameters.AddWithValue("@statut", (int)GlobalConstantes.StatutOperation.Cloture);
        adapter.SelectCommand.Parameters.AddWithValue("@reglement", codereg);
        adapter.SelectCommand.Parameters.AddWithValue("@nom_four", nom_four);
        var table = new DataTable();
        try
        {
            adapter.Fill(table);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            return null;
        }

        return table;
    }
    public DataTable getCompteGestionGeneral(string immeuble_id, DateTime dtDeb, DateTime dtFin)
    {
        var schema = getSchema();
        var cmd = "Select ";

        cmd += "n.reference, n.nom as nature, ";
        cmd += " case when f.reference <> '999' then f.nom else sf.comment_fournisseur end as fournisseur, ";
        cmd += " sf.libelle, sf.date_reference, sf.base_repart, ";
        cmd += " case when sf.montant >0 then sf.montant else 0 end as debit, ";
        cmd += " case when sf.montant <0 then sf.montant*-1 else 0 end as credit ";

        cmd += $"from {getSchemaTable()} sf ";
        cmd += $"left join {schema}.nature n on ( n.id = nature_id) ";
        cmd += $"left join {schema}.fournisseur f on ( f.id = fournisseur_id )";
        cmd += " where immeuble_id = @immeuble_id ";
        cmd += " and sf.date_reference >= @dtdeb and sf.date_reference <= @dtFin";
        cmd += " and n.reference <> @solde_bilan and sf.statut != @statut and sf.statut != @statut_del";
        cmd += " order by 1, date_reference";

        var statut = (int) GlobalConstantes.StatutOperation.Brouillon;

        var  parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@statut", statut),
            new("@statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            new("@appel_fond", ParametresDB.getParam1("NATURE", "APPEL DE FONDS")),
            new("@solde_bilan", ParametresDB.getParam1("NATURE", "SOLDE BILAN")),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin)
        };

        return getResultSQL(cmd, parameters);
    }
    public DataTable getListeOperations(string immeuble, string nature, DateTime dtDeb , DateTime dtFin, string fournisseur="", string libelle = "", string montant="", bool bValidOnly = true, string base_repart = "")
    {
        var schema = getSchema();
        var cmd = "Select ";

        cmd += " sf.id, i.reference as ref_immeuble, date_reference, n.reference as ref_nature, n.nom as nature, base_repart, libelle, montant, f.reference as ref_fourn, ";
        cmd += " case when f.reference <> '999' then f.nom else sf.comment_fournisseur end as fournisseur, ";
        cmd += " sf.statut ";

        cmd += $" from {getSchemaTable()} sf";
        cmd += $" left join {schema}.fournisseur f on f.id = fournisseur_id ";
        cmd += $" left join {schema}.nature n on n.id = nature_id ";
        cmd += $" join {schema}.immeuble i on i.id = immeuble_id ";

        cmd += " where 1=1";
        if ( immeuble != "")
            cmd += " and i.reference = @immeuble";
        if (nature != "")
            cmd += " and n.reference = @nature";
        if (dtDeb != DateTime.Parse("01/01/1970"))
        {
            if (dtFin != DateTime.Parse("01/01/1970"))
                cmd += " and date_reference >= @dtDeb";
            else
                cmd += " and date_reference = @dtDeb";
        }
        if (dtFin != DateTime.Parse("01/01/1970"))
            cmd += " and date_reference <= @dtFin";
        if (fournisseur != "")
            cmd += " and f.reference = @fournisseur";
        if (libelle != "")
            cmd += " and libelle like (@libelle)";
        if (montant != "")
            cmd += " and montant = @montant";
        if (bValidOnly)
            cmd += " and sf.statut = @statut";
        if (base_repart != "")
            cmd += " and base_repart = @base_repart";

        cmd += " order by n.reference, date_reference";

        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble", immeuble),
            new("@nature", nature),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin),
            new("@fournisseur", fournisseur),
            new("@libelle", "%"+libelle+"%"),
            new("@montant", Convertir.ToDecimal(montant)),
            new("@statut", (int) GlobalConstantes.StatutOperation.Valide),
            new("@base_repart", base_repart)
        };

        return getResultSQL(cmd, parameters);
    }

    public decimal getTotalOperationWithoutSolde(string immeuble_id, DateTime dtDeb, DateTime dtFin )
    {
        decimal sum = 0;
        var nature = "140";

        var cmd = $"select sum(montant) as montant from {getSchemaTable()} f";
        cmd += string.Format(" join agence.nature n on n.id = f.nature_id ", getSchema() );
        cmd += " where immeuble_id = @immeuble_id and date_reference >= @dtDeb and date_reference <= @dtFin";
        cmd += " and n.reference <> @nature and f.statut != @statut";

        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@nature", nature),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin),
            new("@statut", (int) GlobalConstantes.StatutOperation.Supprime)
        };

        var table = getResultSQL(cmd, parameters);

        if ( table != null )
            if (table.Rows.Count > 0)
            {
                var row = table.Rows[0];
                sum = Convertir.ToDecimal(row["montant"]);
            }

        return sum;
    }
    public DataTable getBudgetRealise(string immeuble_id, DateTime dtDeb, DateTime dtFin)
    {
        var schema = getSchema();
        var cmd = "Select ";

        cmd += " sf.nature_id, sf.base_repart, sum(montant) as montant";
        cmd += $" from {getSchemaTable()} sf";
        cmd += $" join {schema}.nature n on (n.id = nature_id and n.budgetisable = true) ";

        cmd += " where immeuble_id = @immeuble_id";
        cmd += " and sf.statut = @statut and date_reference >= @dtDeb and date_reference <= @dtFin";
        cmd += " group by 1, 2";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@statut", (int) GlobalConstantes.StatutOperation.Valide),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin)
        };
        //Console.WriteLine(cmd);
        return getResultSQL(cmd, parameters);
    }

    public DataTable getCurrentSoldeImmeuble(string immeuble_id, DateTime dtDeb, DateTime dtFin)
    {
        var cmd = $"select * from {getSchemaTable()} sf ";
        cmd += $" join {getSchema()}.nature n on n.id = nature_id";
        cmd += " where immeuble_id = @immeuble_id and sf.statut != @statut and n.reference = @solde_bilan";
        cmd += " and date_reference >= @dtDeb and date_reference <= @dtFin";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@statut", (int) GlobalConstantes.StatutOperation.Supprime),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin),
            new("@solde_bilan", ParametresDB.getParam1("NATURE", "SOLDE BILAN"))
        };
        //Console.WriteLine(cmd);
        //Console.WriteLine(immeuble_id);
        return getResultSQL(cmd, parameters);
    }

    public decimal getSoldeAnterieurImmeuble(string immeuble_id, DateTime dtDeb, DateTime dtFin)
    {
        var table = getCurrentSoldeImmeuble(immeuble_id, dtDeb, dtFin);
        decimal solde = 0;

        if ( table != null )
            if ( table.Rows.Count > 0 )
            {
                solde = Convertir.ToDecimal(table.Rows[0]["montant"]);
            }
        return solde;
    }
    public DataTable GetBalanceReglementsFactures(string immeuble_id)
    {
        var cmdFacture = " select 1 as type, date_reference, libelle, ";
        cmdFacture += " case when montant < 0 then null else montant end as debit , ";
        cmdFacture += " case when montant < 0 then (montant*-1) else null end as credit ";
        cmdFacture += $" from {getSchemaTable()} sf ";
        cmdFacture += $" join {getSchema()}.nature n on n.id = sf.nature_id and n.reference != @appel_fond";
        cmdFacture += " where immeuble_id = @immeuble_id and sf.statut=@statut";
            
        var cmdReglement = " select 2 as type, date_reference, libelle, null, montant ";
        cmdReglement += $" from {getSchema()}.saisie_reglement sr "; 
        cmdReglement += " where immeuble_id = @immeuble_id and sr.statut =@statut";
            
        var cmd = $" select * from ({cmdFacture} union {cmdReglement} ) t order by 1, date_reference";

        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@statut", (int) GlobalConstantes.StatutOperation.Valide),
            new("@appel_fond", ParametresDB.getParam1("NATURE", "SOLDE BILAN"))
        };

        return getResultSQL(cmd, parameters);
    }
    public DataTable getSaisieFacture(OperationEntite operation)
    {
        var cmd = $"select o.*, i.reference as ref_imm from {getSchemaTable()} o";
        cmd += " join agence.immeuble i on i.id = o.immeuble_id ";
        cmd += " where immeuble_id = @immeuble_id and date_reference = @date_reference and nature_id = @nature_id and trim(libelle) = trim(@libelle)";
        cmd += " and montant = @montant and o.statut != @statut ";
        cmd += " and base_repart = @base_repart";
        //cmd += " and o.liasse_id like 'Reprise%'";
        var montant = operation.global;

        //if (operation.debit != 0)
        //    montant = operation.debit;

        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", operation.immeuble_id),
            new("@coproprietaire_id", operation.coproprietaire_id),
            new("@nature_id", operation.nature_id),
            new("@date_reference", operation.date_reference),
            new("@libelle", operation.libelle),
            new("@base_repart", operation.base_repart),
            new("@montant", montant),
            new("@statut", (int) GlobalConstantes.StatutOperation.Supprime)
        };
        return getResultSQL(cmd, parameters);
    }
    public bool DeleteEntite(SaisieFactureEntite saisie)
    {
        var rc = false;

        var trx = Database.BeginTransaction();
        try
        {
            var opeCtl = OperationController.getController();
            var repartCtl = RepartIndividuelleController.getController();
            TimestampServer = Database.GetTimestampServer();

            repartCtl.setTimestampServer(TimestampServer);
            opeCtl.setTimestampServer(TimestampServer);

            var tbOpe = opeCtl.getOperationFromSaisie(saisie.id);
            var tbRepart = repartCtl.getRepartFromSaisie(saisie.id);

            opeCtl.DeleteElements(tbOpe);
            repartCtl.DeleteElements(tbRepart);

            saisie.statut = (int)GlobalConstantes.StatutOperation.Supprime;
            if (!doInsertOrUpdate(saisie))
                throw new Exception("Annulation Appel de fond");
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
    public void UpdateSaisieAndLot(SaisieFactureEntite saisie, string immeuble_id, string refLot, decimal montant)
    {
        OperationController.getController().getNumeroLotFromSaisie(saisie.id);
        var lot = LotDescriptionController.getController().getLotFromReference(immeuble_id, refLot);
        if (lot == null)
            MessageBox.Show(@"Lot Invalide");
        else
        {
            var trx = Database.BeginTransaction();
            try
            {
                var opeCtl = OperationController.getController();
                var repartCtl = RepartIndividuelleController.getController();
                TimestampServer = Database.GetTimestampServer();

                repartCtl.setTimestampServer(TimestampServer);
                opeCtl.setTimestampServer(TimestampServer);

                var tbOpe = opeCtl.getOperationFromSaisie(saisie.id);
                var tbRepart = repartCtl.getRepartFromSaisie(saisie.id);

                OperationEntite operation = null;
                RepartIndividuelleEntite repartition = null;

                if (tbOpe.Rows.Count == 1)
                    operation = new OperationEntite(tbOpe.Rows[0]);
                else
                    opeCtl.DeleteElements(tbOpe);
                saisie.lot_id = lot.id;
                if (tbRepart.Rows.Count == 1)
                    repartition = new RepartIndividuelleEntite(tbRepart.Rows[0]);
                else
                    repartCtl.DeleteElements(tbRepart);

                if (!doInsertOrUpdate(saisie))
                    throw new Exception("SaisieAppel de Fond");

                if (operation == null)
                    operation = new OperationEntite(saisie);

                if (!opeCtl.InsertOperationFromSaisie(saisie, operation, montant, lot.coproprietaire_id, lot.id, 1))
                    throw new Exception("Creation operation");

                if (!repartCtl.InsertRepartIndividuelleFromSaisie(operation, repartition, 0, 0, 0, 0, GlobalConstantes.TypeSaisie.Facture))
                    throw new Exception("Creation repartition Individuelle");

                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show(ex.Message);
            }
        }
    }

    public static void RecalcRepartitionBilan(SaisieFactureEntite entite, bool bUseTransaction)
    {
        var repart = LotDescriptionController.getController().getListeLot(entite.immeuble_id);
        var numero_ligne = 0;
        var dtDeb= entite.date_reference;
        var exercice = ExerciceComptableController.getController().getExerciceFromDate(entite.immeuble_id, dtDeb);
        if (exercice == null) return;
        NpgsqlTransaction trx = null;
        if (bUseTransaction)
            trx = Database.BeginTransaction();

        try
        {
            foreach (DataRow row in repart.Rows)
            {
                var repimm = new LotDescriptionEntite(row);
                    
                Console.WriteLine(repimm.numero_lot);

                if (repimm.statut == (int)GlobalConstantes.StatutData.Supprime || repimm.coproprietaire_id == "")
                    //if (repimm.statut != (int)GlobalConstantes.StatutData.Actif || repimm.coproprietaire_id == "")
                {
                    Console.WriteLine("{0}", repimm.numero_lot);
                    continue;
                }
                if (repimm.statut == (int)GlobalConstantes.StatutData.Inactif)
                {
                    var soldeCopro = OperationController.getController().getSoldeImmeuble(entite.immeuble_id, exercice.date_deb, exercice.date_fin, repimm.coproprietaire_id);
                    var operation = OperationController.getController().getOperationFromFacture(entite, repimm.coproprietaire_id);
                    if ( operation == null)
                    {
                        Console.WriteLine("Pas Trouvé");
                        operation = new OperationEntite(entite);
                    }
                    operation.numero_ligne = numero_ligne++;
                    operation.coproprietaire_id = repimm.coproprietaire_id;
                    operation.lot_id = repimm.id;
                    operation.libelle = entite.libelle;
                    operation.type_mouvement = nameof(GlobalConstantes.TypeMouvement.Recette);
                    operation.type_operation = nameof(GlobalConstantes.TypeOperation.SoldeBilan);
                    Console.WriteLine("Avt : {0} {1}", operation.credit, operation.debit);
                    if (soldeCopro <= 0)
                        operation.debit = Math.Abs(soldeCopro);
                    else
                        operation.credit = Math.Abs(soldeCopro);
                    Console.WriteLine("Avt : {0} {1}", operation.credit, operation.debit);
                    operation.statut = (int)GlobalConstantes.StatutOperation.Valide;
                    if (!OperationController.getController().InsertOrUpdate(operation))
                        throw new Exception("Creation Operation");
                }
            }

            trx?.Commit();
        }
        catch (Exception ex)
        {
            trx?.Rollback();
            MessageBox.Show(ex.Message);
        }
    }
    public void RecalcRepartition(SaisieFactureEntite entite, bool bUseTransaction)
    {
        if (entite.base_repart == "0") return;
        var repartImm = ImmeubleRepartitionController.getController().getRepartFromImmeubleBase(entite.immeuble_id, entite.base_repart);
        if (entite.base_repart == "0") return;
        var repart = LotRepartitionController.getController().GetLotsRepartitionFromBase(entite.immeuble_id, entite.base_repart);
        DataTable operations;

        if (entite.liasse_id.StartsWith("Reprise"))
            operations = OperationController.getController().getNativeFactureOperations(entite);
        else
            operations = OperationController.getController().getNativeSaisieOperations(entite.id);

        decimal valeur_imm = repartImm.valeur;
        if (valeur_imm == 0) return;
        var montant = entite.montant;

        NpgsqlTransaction trx = null;
        if (bUseTransaction)
            trx = Database.BeginTransaction();
        try
        {
            foreach (DataRow row in repart.Rows)
            {
                var lotRepart = new LotRepartitionEntite(row);
                var copro_id = row["copro_id"].ToString();
                OperationEntite operation = null;
                var montant_ope = montant * lotRepart.valeur / valeur_imm;

                foreach (DataRow rowOpe in operations.Rows)
                {
                    var ope = new OperationEntite(rowOpe);
                    if (ope.lot_id == lotRepart.lot_id)
                    {
                        operation = ope;
                        break;
                    }
                }
                if (operation == null)
                    operation = new OperationEntite(entite);
                else
                    operation.setValue(entite);
                operation.lot_id = lotRepart.lot_id;
                operation.coproprietaire_id = copro_id;
                operation.debit = montant_ope > 0 ? montant_ope : (decimal)0.0;
                operation.credit = montant_ope < 0 ? montant_ope * (decimal)-1.0 : (decimal)0.0;
                operation.global = montant;
                if (!OperationController.getController().doInsertOrUpdate(operation))
                    throw new Exception("Operation update");
            }
            foreach (DataRow rowOpe in operations.Rows)
            {
                var operation = new OperationEntite(rowOpe);
                var bDeleteOpe = true;
                foreach (DataRow row in repart.Rows)
                {
                    var lotRepart = new LotRepartitionEntite(row);
                    if (operation.lot_id == lotRepart.lot_id)
                    {
                        bDeleteOpe = false;
                        break;
                    }
                }
                if (bDeleteOpe)
                {
                    operation.statut = (int)GlobalConstantes.StatutOperation.Supprime;
                    if (!OperationController.getController().doInsertOrUpdate(operation))
                        throw new Exception("Operation Delete");
                }
            }
            if (entite.liasse_id.StartsWith("Reprise"))
            {
                entite.liasse_id = "Recalcul";
                if (!InsertOrUpdate(entite))
                    throw new Exception("Mise à jour Facture");
            }

            trx?.Commit();
        }
        catch (Exception ex)
        {
            trx?.Rollback();
            MessageBox.Show(ex.Message);
        }
    }
}