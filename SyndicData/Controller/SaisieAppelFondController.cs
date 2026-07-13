using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using System.Windows.Forms;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using CommonProjectsPartners.Controller;

namespace SyndicData.Controller
{
    public class SaisieAppelFondController :AbstractBaseController<SaisieAppelFondEntite>
    {
        static SaisieAppelFondController controller = new SaisieAppelFondController();
        public override string getTable()
        {
            return "saisie_appel_fond";
        }
        public static SaisieAppelFondController getController()
        {
            return controller;
            //return new SaisieAppelFondController();
        }
        public DataTable GetAllElements(string immeuble_id, DateTime dtDeb, DateTime dtFin)
        {
            var cmd = $"select r.*, i.reference as ref_imm from {getSchemaTable()} r ";
            cmd += " join agence.immeuble i on i.id = r.immeuble_id ";
            cmd += " where r.statut!=@statut";

            if (immeuble_id != "")
                cmd += " and immeuble_id = @immeuble_id";

            if (dtDeb != Database.NullDate)
                cmd += " and date_reference >= @dtDeb";
            if (dtFin != Database.NullDate)
                cmd += " and date_reference <= @dtFin";

            cmd += " order by i.reference";
            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Supprime),
                new NpgsqlParameter("@dtDeb", dtDeb),
                new NpgsqlParameter("@dtFin", dtFin)
            };

            return getResultSQL(cmd, parameters);
        }

        public DataTable getGridRowSaisieAppelFond(string liasse_id)
        {
            var schema = getSchema();
            var cmd = " Select concat(i.reference, ':',  i.nom) as \"Immeuble\", ";

//            cmd += " concat ( n.reference, ':', n.nom) as \"Nature\", ";
            cmd += " n.reference as \"Nature\", ";
            cmd += " e.base_repart as \"Base\", ";
            cmd += " numero_lot as lot , ";
            cmd += " e.libelle as \"Libellé Ecriture\", ";
            cmd += " e.montant As \"Montant\", ";
            cmd += " e.date_reference as \"Date Ecriture\", ";
            cmd += " i.reference as immeuble_ref, ";
            cmd += " n.reference as nature_ref, ";
            cmd += " e.liasse_id, e.immeuble_id, e.nature_id, ";
//            cmd += " when e.base = '80' then ld.numero_lot::character else '' end as lot, ";
            //TODO Gerer le lot
            cmd += " e.id";
            cmd += $" from {getSchemaTable()} e ";
            cmd += $" left join {schema}.immeuble i on i.id = e.immeuble_id";
            cmd += $" left join {schema}.nature n on n.id = e.nature_id";
            cmd += $" left Join {schema}.operation o on e.id = o.saisie_id and e.base_repart='80' ";
            cmd += $" left join {schema}.lot_description l on o.lot_id = l.id and e.base_repart ='80'";

            cmd += " where e.liasse_id = @liasse_id and e.statut = @statut ";
            cmd += " order by e.date_reference, e.numero_operation";
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
        public DataTable getListeOperations(string immeuble, DateTime dtDeb , DateTime dtFin, string libelle = "", string montant="", bool bValidOnly = true, string base_repart="")
        {
            var schema = getSchema();
            var cmd = "Select ";

//            cmd += " sf.id, i.reference as ref_immeuble, n.reference as ref_nature, n.nom as nature, date_reference, libelle, montant, base_repart, sf.statut ";
            cmd += " sf.id, i.reference as ref_immeuble, date_reference, n.reference as ref_nature, base_repart, libelle, montant, sf.statut, sf.liasse_id ";
            cmd += $" from {getSchemaTable()} sf";
            cmd += $" left join {schema}.nature n on n.id = nature_id ";
            cmd += $" join {schema}.immeuble i on i.id = immeuble_id ";

            cmd += String.Format(" where 1=1");

            if (immeuble != "")
                cmd += " and i.reference = @immeuble";

            if (dtDeb != DateTime.Parse("01/01/1970"))
            {
                if (dtFin != DateTime.Parse("01/01/1970"))
                    cmd += " and date_reference >= @dtDeb";
                else
                    cmd += " and date_reference = @dtDeb";
            }
            if (dtFin != DateTime.Parse("01/01/1970"))
                cmd += " and date_reference <= @dtFin";

            if (libelle != "")
                cmd += " and libelle like (@libelle)";
            if (montant != "")
                cmd += " and montant = @montant";
            if (bValidOnly)
                cmd += " and sf.statut = @statut";
            if (base_repart != "")
                cmd += " and base_repart = @base_repart";
            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble", immeuble),
                new NpgsqlParameter("@dtDeb", dtDeb),
                new NpgsqlParameter("@dtFin", dtFin),
                new NpgsqlParameter("@libelle", "%"+libelle+"%"),
                new NpgsqlParameter("@montant", Convertir.ToDecimal(montant)),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Valide),
                new NpgsqlParameter("@base_repart", base_repart),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeViewOperations(string immeuble, DateTime dtDeb, DateTime dtFin, string libelle = "", string montant = "", bool bValidOnly = true, string base_repart = "")
        {
            var schema = getSchema();
            var cmd = "Select ";

            //            cmd += " sf.id, i.reference as ref_immeuble, n.reference as ref_nature, n.nom as nature, date_reference, libelle, montant, base_repart, sf.statut ";
            cmd += " sf.id, i.reference as ref_immeuble, date_reference, n.reference as ref_nature, base_repart, ";
            cmd += " case when base_repart = '80' then (select numero_lot::character varying from agence.lot_description where id in (select lot_id from agence.operation where saisie_id = sf.id)) else '' end as lot, ";
            cmd += " libelle, montant, sf.statut, sf.liasse_id ";
            cmd += $" from {getSchemaTable()} sf";
            cmd += $" left join {schema}.nature n on n.id = nature_id ";
            cmd += $" join {schema}.immeuble i on i.id = immeuble_id ";

            cmd += String.Format(" where 1=1");

            if (immeuble != "")
                cmd += " and i.reference = @immeuble";

            if (dtDeb != DateTime.Parse("01/01/1970"))
            {
                if (dtFin != DateTime.Parse("01/01/1970"))
                    cmd += " and date_reference >= @dtDeb";
                else
                    cmd += " and date_reference = @dtDeb";
            }
            if (dtFin != DateTime.Parse("01/01/1970"))
                cmd += " and date_reference <= @dtFin";

            if (libelle != "")
                cmd += " and libelle like (@libelle)";
            if (montant != "")
                cmd += " and montant = @montant";
            if (bValidOnly)
                cmd += " and sf.statut = @statut";
            if (base_repart != "")
                cmd += " and base_repart = @base_repart";
            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble", immeuble),
                new NpgsqlParameter("@dtDeb", dtDeb),
                new NpgsqlParameter("@dtFin", dtFin),
                new NpgsqlParameter("@libelle", "%"+libelle+"%"),
                new NpgsqlParameter("@montant", Convertir.ToDecimal(montant)),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Valide),
                new NpgsqlParameter("@base_repart", base_repart),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }

        public decimal getTotalOperationWithoutSolde(string immeuble_id, DateTime dtDeb, DateTime dtFin)
        {
            decimal sum = 0;
            var nature = "140";

            var cmd = $"select sum(montant) as montant from {getSchemaTable()} f";
            cmd += string.Format(" join agence.nature n on n.id = f.nature_id ", getSchema());
            cmd += " where immeuble_id = @immeuble_id and date_reference >= @dtDeb and date_reference <= @dtFin";
            cmd += " and n.reference <> @nature and f.statut != @statut";

            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@nature", nature),
                new NpgsqlParameter("@dtDeb", dtDeb),
                new NpgsqlParameter("@dtFin", dtFin),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Supprime),
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

        public DataTable GetAllElements()
        {
            var cmd =
                $"select a.*, i.reference as ref_imm from {getSchemaTable()} a join agence.immeuble i on i.id = immeuble_id where a.statut = 1 order by i.reference";
            return getResultSQL(cmd);
        }

        public bool DeleteEntite(SaisieAppelFondEntite saisie)
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

                saisie.statut = (int) GlobalConstantes.StatutOperation.Supprime;
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
        public bool UpdateSaisieAndLot( SaisieAppelFondEntite saisie, string immeuble_id, string refLot, decimal montant)
        {
            var rc=false;
            var oldRefLot = OperationController.getController().getNumeroLotFromSaisie(saisie.id);
            var lot = LotDescriptionController.getController().getLotFromReference(immeuble_id, refLot);
            if (lot == null)
                MessageBox.Show("Lot Invalide");
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

                    if (tbRepart.Rows.Count == 1)
                        repartition = new RepartIndividuelleEntite(tbRepart.Rows[0]);
                    else
                        repartCtl.DeleteElements(tbRepart);
                    //
                    saisie.lot_id = lot.id;
                    if (!doInsertOrUpdate(saisie))
                        throw new Exception("SaisieAppel de Fond");

                    if (operation == null)
                        operation = new OperationEntite(saisie);
                    
                    if ( !opeCtl.InsertOperationFromSaisie(saisie, operation, montant, lot.coproprietaire_id, lot.id, 1))
                        throw new Exception("Creation operation");

                    if (!repartCtl.InsertRepartIndividuelleFromSaisie(operation, repartition, 0, 0, 0, 0, GlobalConstantes.TypeSaisie.AppelDeFond ))
                        throw new Exception("Creation repartition Individuelle");

                    trx.Commit();
                    rc = true;
                }
                catch (Exception ex)
                {
                    trx.Rollback();
                    MessageBox.Show(ex.Message);
                }
            } 
            return rc;
        }
        public bool RecalcRepartition(SaisieAppelFondEntite entite, bool bUseTransaction)
        {
            var rc = false;

            var repartImm = ImmeubleRepartitionController.getController().getRepartFromImmeubleBase(entite.immeuble_id, entite.base_repart);
            var repart = LotRepartitionController.getController().GetLotsRepartitionFromBase(entite.immeuble_id, entite.base_repart);
            DataTable operations;

            //if (entite.liasse_id.StartsWith("Reprise"))
            //    operations = OperationController.getController().getNativeAppelDeFondOperations(entite);
            //else
            //    operations = OperationController.getController().getNativeSaisieOperations(entite.id);
            if (entite.liasse_id.StartsWith("Reprise"))
                operations = OperationController.getController().getAppelDeFondOperations(entite);
            else
                operations = OperationController.getController().getSaisieOperations(entite.id);

            decimal valeur_imm = repartImm.valeur;
            if (valeur_imm == 0)
                return false ;
            var montant = entite.montant;

            NpgsqlTransaction trx  = null; 
            if ( bUseTransaction ) 
                trx = Database.BeginTransaction();
            try
            {
                foreach (DataRow rowOpe in operations.Rows)
                {
                    var ope = OperationController.getController().getEntiteById(rowOpe["id"].ToString() );
                    ope.statut = (int)GlobalConstantes.StatutOperation.Supprime;
                    if (!OperationController.getController().doInsertOrUpdate(ope))
                        throw new Exception("Operation Delete");
                }
                foreach (DataRow row in repart.Rows)
                {
                    var lotRepart = new LotRepartitionEntite(row);
                    var copro_id = row["copro_id"].ToString();
                    OperationEntite operation = null;
                    var montant_ope = montant * lotRepart.valeur / valeur_imm;

                    operation = new OperationEntite(entite);
                    operation.lot_id = lotRepart.lot_id;
                    operation.coproprietaire_id = copro_id;

                    operation.debit = montant_ope > 0 ? montant_ope : (decimal)0.0;
                    operation.credit = montant_ope < 0 ? montant_ope * (decimal)(-1.0) : (decimal)0.0;
                    operation.global = montant;

                    if (montant_ope == 0 && !operation.isNew)
                        operation.statut = (int) GlobalConstantes.StatutOperation.Supprime;

                    if ( montant_ope != 0 || !operation.isNew )
                        if (!OperationController.getController().doInsertOrUpdate(operation))
                            throw new Exception("Operation update");
                }
                if ( entite.liasse_id.StartsWith("Reprise"))
                {
                    entite.liasse_id = "Recalcul";
                    if (!InsertOrUpdate(entite))
                        throw new Exception("Mise à jour Appel de Fond");
                }
                rc = true;
                if ( trx != null )
                    trx.Commit();
            }
            catch (Exception ex)
            {
                if (trx != null)
                    trx.Rollback();
                MessageBox.Show(ex.Message);
            }
            return rc;
        }
        public DataTable getSaisieAppel(OperationEntite operation)
        {
            var cmd = $"select o.* from {getSchemaTable()} o";
            //cmd += " join agence.coproprietaire c on c.id = o.coproprietaire_id ";
            cmd += " where immeuble_id = @immeuble_id and date_reference = @date_reference and nature_id = @nature_id and trim(libelle) = trim(@libelle)";
            //cmd += " and montant = @montant";
            var montant = operation.credit;

            if (operation.debit != 0)
                montant = operation.debit;

            var parameters = new List<NpgsqlParameter> 
                {
                    new NpgsqlParameter("@immeuble_id", operation.immeuble_id),
                    new NpgsqlParameter("@coproprietaire_id", operation.coproprietaire_id),
                    new NpgsqlParameter("@nature_id", operation.nature_id),
                    new NpgsqlParameter("@date_reference", operation.date_reference),
                    new NpgsqlParameter("@libelle", operation.libelle),
                    new NpgsqlParameter("@montant", montant),

                };
            return getResultSQL(cmd, parameters);
        }
    }
}
