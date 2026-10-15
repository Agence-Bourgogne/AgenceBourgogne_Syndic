using System.Collections.Generic;
using System.Data;
using CommonProjectsPartners.Controller;
using Npgsql;
using SyndicData.Common;
using SyndicData.Entites;

namespace SyndicData.Controller;

public class BudgetLigneController : AbstractBaseController<BudgetLigneEntite>
{
    private static readonly BudgetLigneController controller = new();

    protected override string GetTable()
    {
        return "budget_ligne";
    }

    public static BudgetLigneController getController()
    {
        return controller;
    }

    public DataTable getDescriptionLignesBudgetPrevu(string exercice_id)
    {
        var schema = GetSchema();
        var cmd = "Select ";
        cmd += " nature_id, base_repart, sum(montant) as montant\n";
        cmd += $" from {GetSchemaTable()} bl\n";
        cmd += string.Format(" join {0}.budget b on (b.id = budget_id and b.exercice_id = @exercice_id )\n", schema,
            exercice_id);
        cmd += $" join {schema}.nature n on (n.id = nature_id and n.budgetisable = true) \n";
        cmd += " where bl.statut != @statut \n";
        cmd += " group by 1, 2";
        var parameters = new List<NpgsqlParameter>
        {
            new("@exercice_id", exercice_id),
            new("@statut", (int)GlobalConstantes.StatutBudget.Supprime)
        };
        return getResultSQL(cmd, parameters);
    }

    public DataTable getLinesBudget(string budget_id)
    {
        var cmd = $"select * from {GetSchemaTable()} where budget_id = @budget_id and statut!=@statut";
        var parameters = new List<NpgsqlParameter>
        {
            new("@budget_id", budget_id),
            new("@statut", (int)GlobalConstantes.StatutBudget.Supprime)
        };
        return getResultSQL(cmd, parameters);
    }
}