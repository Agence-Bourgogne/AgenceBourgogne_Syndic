using System;
using System.Collections.Generic;
using CommonProjectsPartners.Controller;
using SyndicData.Entites;
using System.Data;
using Npgsql;
using SyndicData.Common;

namespace SyndicData.Controller
{
    public class RepartIndividuelleController : AbstractBaseController<RepartIndividuelleEntite>
    {
        static RepartIndividuelleController controller = new RepartIndividuelleController();
        public override string getTable()
        {
            return "repart_individuelle";
        }

        public static RepartIndividuelleController getController()
        {
            return controller;
            //return new RepartIndividuelleController();
        }
        public DataTable getRepartFromSaisie(string saisie_id)
        {
            string cmd = string.Format("select * from {0} where saisie_id = @saisie_id and statut!= @statut", getSchemaTable());
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@saisie_id", saisie_id),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }

        public DataTable getFactureRepartFromAppel(String immeuble_id, string reference, DateTime date_reference) 
        {
            string cmd = string.Format("select * from {0} where immeuble_id = @immeuble_id and type_saisie = {1} and reference = @reference and date_reference = @date_reference and statut!= @statut", getSchemaTable(), (int) GlobalConstantes.TypeSaisie.AppelDeFond);
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@reference", reference),
                new NpgsqlParameter("@date_reference", date_reference),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }

        public DataTable getLastRepartFromSaisie(string immeuble_id, string base_repart, GlobalConstantes.TypeSaisie saisie)
        {
            string where = string.Format("select saisie_id from {0} where immeuble_id = @immeuble_id and reference = @base_repart and type_saisie = @saisie order by audit_created desc limit 1", getSchemaTable());
            string cmd = string.Format("select * from {0} where statut != @statut and saisie_id = ({1})", getSchemaTable(), where);
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@base_repart", base_repart),
                new NpgsqlParameter("@saisie", (int) saisie),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }

        public bool InsertRepartIndividuelleFromSaisie(OperationEntite operation, RepartIndividuelleEntite oldRepart, decimal index, decimal ancien, decimal nouveau, decimal global, GlobalConstantes.TypeSaisie type, int ref_cpt = 1)
        {
            bool rc = false;

            RepartIndividuelleEntite repart = RepartIndividuelleEntite.setData(operation, oldRepart, type);
            decimal montant = operation.debit;
            repart.global = operation.global;
            repart.global = global;
            repart.ref_cpt = ref_cpt;
            if (montant == 0)
            {
                if (repart.id == "")
                    return true;
                repart.statut = (int)GlobalConstantes.StatutOperation.Supprime;
            }
            else
                repart.statut = (int)GlobalConstantes.StatutOperation.Brouillon;
            
            if (operation.base_repart == "80")
            {
                repart.index = montant != 0 ? repart.global : 0;
                repart.nouveau = repart.ancien = 0;
            }
            else
            {
                repart.index = index;
                repart.ancien = ancien;
                repart.nouveau = nouveau;
            }
            repart.montant = montant;
            rc = doInsertOrUpdate(repart);

            return rc;
        }
        public bool DeleteElements(DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                RepartIndividuelleEntite ope = new RepartIndividuelleEntite(row);
                ope.statut = (int)GlobalConstantes.StatutOperation.Supprime;
                if (!doInsertOrUpdate(ope))
                    throw new Exception("Annulation Repartition");
            }
            return true;
        }
    }
}
