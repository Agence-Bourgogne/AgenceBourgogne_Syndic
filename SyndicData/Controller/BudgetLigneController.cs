using System;
using System.Collections.Generic;
using Npgsql;
using System.Data;
using CommonProjectsPartners.Controller;
using SyndicData.Entites;
using SyndicData.Common;

namespace SyndicData.Controller
{
    public class BudgetLigneController : AbstractBaseController<BudgetLigneEntite>
    {
        static BudgetLigneController controller = new BudgetLigneController();
        public override string getTable()
        {
            return "budget_ligne";
        }
        public static BudgetLigneController getController()
        {
            return controller;
//            return new BudgetLigneController();
        }
        //public BudgetLigneController()
        //{
        //    //DefaultOrder = "reference";
        //}
        public DataTable getDescriptionBudget(string budget_id)
        {
            string cmd = "select ";

            cmd += " b.id, b.base_repart as base, n.reference as compte, n.nom as nature, ";
            //cmd += " 0 as precedent_approuve, 0 as clos_vote, 0 as clos_realise,";
            cmd += " b.montant as prevu ";
            cmd += String.Format(" from {0} b ", getSchemaTable());
            cmd += String.Format(" left join {0}.nature n on n.id = b.nature_id ", getSchema() );
            cmd += " where budget_id = @budget_id and b.statut != @statut ";
            cmd += " order by n.reference, b.base_repart";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter ("@budget_id", budget_id),
                new NpgsqlParameter ("@statut", (int) GlobalConstantes.StatutBudget.Supprime),
            };

            return getResultSQL(cmd, parameters);
        }
        public DataTable getDescriptionLignesBudgetPrevu(string exercice_id)
        {
            String schema = getSchema();
            string cmd = "Select ";
            cmd += " nature_id, base_repart, sum(montant) as montant\n";
            cmd += String.Format(" from {0} bl\n", getSchemaTable());
            cmd += String.Format(" join {0}.budget b on (b.id = budget_id and b.exercice_id = @exercice_id )\n", schema, exercice_id);
            cmd += String.Format(" join {0}.nature n on (n.id = nature_id and n.budgetisable = true) \n", schema);
            cmd += " where bl.statut != @statut \n";
            cmd += " group by 1, 2";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@exercice_id", exercice_id),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutBudget.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getLinesBudget(string budget_id)
        {
            string cmd = String.Format("select * from {0} where budget_id = @budget_id and statut!=@statut", getSchemaTable());
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@budget_id", budget_id),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutBudget.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }
    }
}
