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
