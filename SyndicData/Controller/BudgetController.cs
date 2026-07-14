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

public class BudgetController : AbstractBaseController<BudgetEntite>
{
    private static readonly BudgetController controller = new();
    public override string getTable()
    {
        return "budget";
    }
    public static BudgetController getController()
    {
        return controller;
//            return new BudgetController();
    }
    public BudgetController()
    {
        DefaultOrder = "reference";
    }

    public DataTable getViewBudgets( string immeuble_id, string exercice_id)
    {
        string exercice_precedent_id = "", exercice_suivant_id = "", exercice_n_2_id = "";
        var schema = getSchema();
        {
            var table = ExerciceComptableController.getController().getExercicePrecedent(exercice_id);
            if (table != null)
                if (table.Rows.Count > 0)
                {
                    var entite = new ExerciceComptableEntite(table.Rows[0]);
                    exercice_precedent_id = entite.id;
                }
        }
        {
            var table = ExerciceComptableController.getController().getExerciceSuivant(exercice_id);
            if (table != null)
                if (table.Rows.Count > 0)
                {
                    var entite = new ExerciceComptableEntite(table.Rows[0]);
                    exercice_suivant_id = entite.id;
                }
        }
        {
            var table = ExerciceComptableController.getController().getExerciceSuivant(exercice_suivant_id);
            if (table != null)
                if (table.Rows.Count > 0)
                {
                    var entite = new ExerciceComptableEntite(table.Rows[0]);
                    exercice_n_2_id = entite.id;
                }
        }

        var prevu_suivant = "";
        prevu_suivant += " select bl.base_repart as base, n.reference as compte , n.nom as nature, 0 as realise_suivant, 0 as prevu, 0 as realise, sum(bl.montant) as prevu_suivant, 0 as prevu_suivant_1, null as id\n";
        prevu_suivant += $" from {schema}.budget_ligne bl \n";
        prevu_suivant += $" left join {schema}.nature n on n.id = bl.nature_id \n";
        prevu_suivant += $" join {schema}.budget  b on b.id = bl.budget_id \n";
        prevu_suivant += $" join {schema}.exercice_comptable e on b.exercice_id = e.id \n";
        prevu_suivant += $" join {schema}.immeuble i on e.immeuble_id = i.id \n";
        prevu_suivant += " where i.id = @immeuble_id and e.id = @exercice_suivant_id and bl.statut != @statut_del \n";
        prevu_suivant += " group by 1, 2, 3\n";

        var prevu_suivant_1 = "";
        prevu_suivant_1 += " select bl.base_repart as base, n.reference as compte , n.nom as nature, 0 as realise_suivant, 0 as prevu, 0 as realise, 0 as prevu_suivant, sum(bl.montant) as prevu_suivant_1, null as id\n";
        prevu_suivant_1 += $" from {schema}.budget_ligne bl \n";
        prevu_suivant_1 += $" left join {schema}.nature n on n.id = bl.nature_id \n";
        prevu_suivant_1 += $" join {schema}.budget  b on b.id = bl.budget_id \n";
        prevu_suivant_1 += $" join {schema}.exercice_comptable e on b.exercice_id = e.id \n";
        prevu_suivant_1 += $" join {schema}.immeuble i on e.immeuble_id = i.id \n";
        prevu_suivant_1 += " where i.id = @immeuble_id and e.id = @exercice_n_2_id and bl.statut != @statut_del \n";
        prevu_suivant_1 += " group by 1, 2, 3\n";
            
        var realise_n = "";
        realise_n = " select sf.base_repart as base, n.reference as compte, n.nom as nature, 0 as realise_precedent, 0 prevu, sum(montant) as realise , 0 as prevu_suivant, 0 as prevu_suivant_1, null as id\n";
        realise_n += $" from  {schema}.saisie_facture sf  \n";
        realise_n += $" join {schema}.nature n on (n.id = nature_id and n.budgetisable = true) \n";
        realise_n += $" join {schema}.immeuble i on sf.immeuble_id = i.id \n";
        realise_n += $" join {schema}.exercice_comptable e on i.id = e.immeuble_id and e.id = @exercice_id \n";
        realise_n += " where i.id = @immeuble_id and sf.statut not in ( @statut_op_br, @statut_op_del) \n";
        realise_n += " and date_reference >= e.date_deb and date_reference <= e.date_fin \n";
        realise_n += " group by 1, 2, 3 \n";

        var prevu_n = "";
        prevu_n += " select bl.base_repart as base, n.reference as compte , n.nom as nature, 0, sum(bl.montant) as prevu, 0 as realise, 0 as prevu_suivant, 0 as prevu_suivant_1, bl.id\n";
        prevu_n += $" from {schema}.budget_ligne bl \n";
        prevu_n += $" left join {schema}.nature n on n.id = bl.nature_id \n";
        prevu_n += $" join {schema}.budget  b on b.id = bl.budget_id \n";
        prevu_n += $" join {schema}.exercice_comptable e on b.exercice_id = e.id \n";
        prevu_n += $" join {schema}.immeuble i on e.immeuble_id = i.id \n";
        prevu_n += " where i.id = @immeuble_id and e.id = @exercice_id and bl.statut != @statut_del \n";
        prevu_n += " group by 1, 2, 3, 4, bl.id\n";

        var realise_precedent = "";
        realise_precedent = " select sf.base_repart, n.reference as compte, n.nom as nature, sum(sf.montant) as realise_precedent, 0, 0 , 0 as prevu_suivant, 0 as prevu_suivant_1, null as id\n";
        realise_precedent += $" from  {schema}.saisie_facture sf  \n";
        realise_precedent += $" join {schema}.nature n on (n.id = nature_id and n.budgetisable = true) \n";
        realise_precedent += $" join {schema}.immeuble i on sf.immeuble_id = i.id \n";
        realise_precedent +=
            $" join {schema}.exercice_comptable e on i.id = e.immeuble_id and e.id = @exercice_precedent_id \n";
        realise_precedent += " where i.id = @immeuble_id and sf.statut not in ( @statut_op_br, @statut_op_del) \n";
        realise_precedent += " and date_reference >= e.date_deb and date_reference <= e.date_fin \n";
        realise_precedent += " group by 1, 2, 3 \n";

        var cmd = " Select base, compte, nature, sum(realise_precedent) as realise_precedent, sum(prevu) as prevu, sum(realise ) as realise, sum(prevu_suivant) as prevu_suivant, sum(prevu_suivant_1) as prevu_suivant_1, id";
        cmd +=
            $" from ( \n{realise_n} union \n{realise_precedent} union \n{prevu_n} union\n {prevu_suivant} union\n {prevu_suivant_1}\n) as tot group by 1, 2, 3, id order by 2, 1, id  "; 

        var brouillon = (int) GlobalConstantes.StatutOperation.Brouillon;
        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeuble_id),
            new("@exercice_id", exercice_id),
            new("@exercice_precedent_id", exercice_precedent_id),
            new("@exercice_n_2_id", exercice_n_2_id),
            new("@exercice_suivant_id", exercice_suivant_id),
            new("@statut_del", (int) GlobalConstantes.StatutBudget.Supprime),
            new("@statut_op_br", brouillon),
            new("@statut_op_del", (int) GlobalConstantes.StatutOperation.Supprime)
        };

        //string debugCmd = cmd.Replace("@immeuble_id", "'" + immeuble_id + "'").Replace("@exercice_id", "'" + exercice_id + "'").Replace("@exercice_precedent_id", "'" + exercice_precedent_id + "'").Replace("@exercice_suivant_id", "'" + exercice_suivant_id + "'").Replace("@exercice_n_2_id", "'" + exercice_n_2_id + "'");
        //           string debugCmd = prevu_suivant_1.Replace("@immeuble_id", "'" + immeuble_id + "'").Replace("@exercice_n_2_id", "'" + exercice_n_2_id + "'");
            
        var budget = getResultSQL(cmd, parameters);
        var budgetPresent = new DataTable();
        budgetPresent.Clear();

        if (budgetPresent.Columns.Count <= 0)
            foreach (DataColumn col in budget.Columns)
            {
                budgetPresent.Columns.Add(col.ColumnName, col.DataType);
            }

        var nature = "";
        var base_repart = "";
        foreach (DataRow row in budget.Rows)
        {
            if (row["compte"].ToString() != nature || row["base"].ToString() != base_repart)
            {
                nature = row["compte"].ToString();
                base_repart = row["base"].ToString();
                budgetPresent.Rows.Add(row.ItemArray);
            }
            else
            {
                var current = budgetPresent.Rows.Count - 1;
                var oldItem = budgetPresent.Rows[current].ItemArray;
                oldItem[3] = (decimal)oldItem[3] + (decimal)row[3];
                oldItem[4] = (decimal)oldItem[4] + (decimal)row[4];
                oldItem[5] = (decimal)oldItem[5] + (decimal)row[5];
                oldItem[6] = (decimal)oldItem[6] + (decimal)row[6];
                oldItem[7] = (decimal)oldItem[7] + (decimal)row[7];
                budgetPresent.Rows[current].ItemArray = oldItem;
            }
        }
        return budgetPresent;
    }

    public void UpdateStatus(string budget_id, GlobalConstantes.StatutBudget new_statut)
    {
        var rc = false;

        var cnx = Database.GetInstance();
        var trx = cnx.BeginTransaction();


        try 
        {
            TimestampServer = Database.GetTimestampServer();
            var ctlLines = BudgetLigneController.getController();
            ctlLines.setTimestampServer(TimestampServer);
            var budget_lines = ctlLines.getLinesBudget(budget_id); 
            var budget = getEntiteById(budget_id);
            var updateLineOk = true;

            if ( budget_lines != null && budget_lines.Rows.Count > 0 )
            {
                foreach (DataRow row in budget_lines.Rows)
                {
                    var budget_line = new BudgetLigneEntite(row)
                    {
                        statut = (int) new_statut
                    };
                    if ( !ctlLines.doInsertOrUpdate(budget_line))
                    {
                        updateLineOk = false;
                        break;
                    }
                }
            }
            if (updateLineOk)
            {
                budget.statut = (int) new_statut;
                if (doInsertOrUpdate(budget))
                    rc = true;
            }
            if (rc)
                trx.Commit();
            else
                trx.Rollback();
        }
        catch (Exception ex)
        {
            trx.Rollback();
            MessageBox.Show(ex.Message);
        }
    }
}