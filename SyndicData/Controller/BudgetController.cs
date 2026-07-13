using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Controller;
using SyndicData.Common;
using SyndicData.Entites;
namespace SyndicData.Controller
{
    public class BudgetController : AbstractBaseController<BudgetEntite>
    {
        static BudgetController controller = new BudgetController();
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
            string exercice_precedent_id = "", exercice_suivant_id = "", exercice_n_2_id = ""; ;
            string schema = getSchema();
            {
                DataTable table = ExerciceComptableController.getController().getExercicePrecedent(exercice_id);
                if (table != null)
                    if (table.Rows.Count > 0)
                    {
                        ExerciceComptableEntite entite = new ExerciceComptableEntite(table.Rows[0]);
                        exercice_precedent_id = entite.id;
                    }
            }
            {
                DataTable table = ExerciceComptableController.getController().getExerciceSuivant(exercice_id);
                if (table != null)
                    if (table.Rows.Count > 0)
                    {
                        ExerciceComptableEntite entite = new ExerciceComptableEntite(table.Rows[0]);
                        exercice_suivant_id = entite.id;
                    }
            }
            {
                DataTable table = ExerciceComptableController.getController().getExerciceSuivant(exercice_suivant_id);
                if (table != null)
                    if (table.Rows.Count > 0)
                    {
                        ExerciceComptableEntite entite = new ExerciceComptableEntite(table.Rows[0]);
                        exercice_n_2_id = entite.id;
                    }
            }

            string prevu_suivant = "";
            prevu_suivant += " select bl.base_repart as base, n.reference as compte , n.nom as nature, 0 as realise_suivant, 0 as prevu, 0 as realise, sum(bl.montant) as prevu_suivant, 0 as prevu_suivant_1, null as id\n";
            prevu_suivant += String.Format(" from {0}.budget_ligne bl \n", schema);
            prevu_suivant += String.Format(" left join {0}.nature n on n.id = bl.nature_id \n", schema);
            prevu_suivant += String.Format(" join {0}.budget  b on b.id = bl.budget_id \n", schema);
            prevu_suivant += String.Format(" join {0}.exercice_comptable e on b.exercice_id = e.id \n", schema);
            prevu_suivant += String.Format(" join {0}.immeuble i on e.immeuble_id = i.id \n", schema);
            prevu_suivant += " where i.id = @immeuble_id and e.id = @exercice_suivant_id and bl.statut != @statut_del \n";
            prevu_suivant += " group by 1, 2, 3\n";

            string prevu_suivant_1 = "";
            prevu_suivant_1 += " select bl.base_repart as base, n.reference as compte , n.nom as nature, 0 as realise_suivant, 0 as prevu, 0 as realise, 0 as prevu_suivant, sum(bl.montant) as prevu_suivant_1, null as id\n";
            prevu_suivant_1 += String.Format(" from {0}.budget_ligne bl \n", schema);
            prevu_suivant_1 += String.Format(" left join {0}.nature n on n.id = bl.nature_id \n", schema);
            prevu_suivant_1 += String.Format(" join {0}.budget  b on b.id = bl.budget_id \n", schema);
            prevu_suivant_1 += String.Format(" join {0}.exercice_comptable e on b.exercice_id = e.id \n", schema);
            prevu_suivant_1 += String.Format(" join {0}.immeuble i on e.immeuble_id = i.id \n", schema);
            prevu_suivant_1 += " where i.id = @immeuble_id and e.id = @exercice_n_2_id and bl.statut != @statut_del \n";
            prevu_suivant_1 += " group by 1, 2, 3\n";
            
            string realise_n = "";
            realise_n = " select sf.base_repart as base, n.reference as compte, n.nom as nature, 0 as realise_precedent, 0 prevu, sum(montant) as realise , 0 as prevu_suivant, 0 as prevu_suivant_1, null as id\n";
            realise_n += String.Format(" from  {0}.saisie_facture sf  \n", schema);
            realise_n += String.Format(" join {0}.nature n on (n.id = nature_id and n.budgetisable = true) \n", schema);
            realise_n += String.Format(" join {0}.immeuble i on sf.immeuble_id = i.id \n", schema);
            realise_n += String.Format(" join {0}.exercice_comptable e on i.id = e.immeuble_id and e.id = @exercice_id \n", schema);
            realise_n += " where i.id = @immeuble_id and sf.statut not in ( @statut_op_br, @statut_op_del) \n";
            realise_n += " and date_reference >= e.date_deb and date_reference <= e.date_fin \n";
            realise_n += " group by 1, 2, 3 \n";

            string prevu_n = "";
            prevu_n += " select bl.base_repart as base, n.reference as compte , n.nom as nature, 0, sum(bl.montant) as prevu, 0 as realise, 0 as prevu_suivant, 0 as prevu_suivant_1, bl.id\n";
            prevu_n += String.Format( " from {0}.budget_ligne bl \n", schema);
            prevu_n += String.Format( " left join {0}.nature n on n.id = bl.nature_id \n", schema);
            prevu_n += String.Format( " join {0}.budget  b on b.id = bl.budget_id \n", schema);
            prevu_n += String.Format( " join {0}.exercice_comptable e on b.exercice_id = e.id \n", schema);
            prevu_n += String.Format( " join {0}.immeuble i on e.immeuble_id = i.id \n", schema);
            prevu_n += " where i.id = @immeuble_id and e.id = @exercice_id and bl.statut != @statut_del \n";
            prevu_n += " group by 1, 2, 3, 4, bl.id\n";

            string realise_precedent = "";
            realise_precedent = " select sf.base_repart, n.reference as compte, n.nom as nature, sum(sf.montant) as realise_precedent, 0, 0 , 0 as prevu_suivant, 0 as prevu_suivant_1, null as id\n";
            realise_precedent += String.Format( " from  {0}.saisie_facture sf  \n", schema);
            realise_precedent += String.Format( " join {0}.nature n on (n.id = nature_id and n.budgetisable = true) \n", schema);
            realise_precedent += String.Format( " join {0}.immeuble i on sf.immeuble_id = i.id \n", schema);
            realise_precedent += String.Format( " join {0}.exercice_comptable e on i.id = e.immeuble_id and e.id = @exercice_precedent_id \n", schema);
            realise_precedent += " where i.id = @immeuble_id and sf.statut not in ( @statut_op_br, @statut_op_del) \n";
            realise_precedent += " and date_reference >= e.date_deb and date_reference <= e.date_fin \n";
            realise_precedent += " group by 1, 2, 3 \n";

            string cmd = " Select base, compte, nature, sum(realise_precedent) as realise_precedent, sum(prevu) as prevu, sum(realise ) as realise, sum(prevu_suivant) as prevu_suivant, sum(prevu_suivant_1) as prevu_suivant_1, id";
            cmd += String.Format(" from ( \n{0} union \n{1} union \n{2} union\n {3} union\n {4}\n) as tot group by 1, 2, 3, id order by 2, 1, id  ", realise_n, realise_precedent, prevu_n, prevu_suivant, prevu_suivant_1); 

            int brouillon = (int) GlobalConstantes.StatutOperation.Brouillon;
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter ("@immeuble_id", immeuble_id),
                new NpgsqlParameter ("@exercice_id", exercice_id),
                new NpgsqlParameter ("@exercice_precedent_id", exercice_precedent_id),
                new NpgsqlParameter ("@exercice_n_2_id", exercice_n_2_id),
                new NpgsqlParameter ("@exercice_suivant_id", exercice_suivant_id),
                new NpgsqlParameter ("@statut_del", (int) GlobalConstantes.StatutBudget.Supprime),
                new NpgsqlParameter ("@statut_op_br", brouillon),
                new NpgsqlParameter ("@statut_op_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };

            //string debugCmd = cmd.Replace("@immeuble_id", "'" + immeuble_id + "'").Replace("@exercice_id", "'" + exercice_id + "'").Replace("@exercice_precedent_id", "'" + exercice_precedent_id + "'").Replace("@exercice_suivant_id", "'" + exercice_suivant_id + "'").Replace("@exercice_n_2_id", "'" + exercice_n_2_id + "'");
 //           string debugCmd = prevu_suivant_1.Replace("@immeuble_id", "'" + immeuble_id + "'").Replace("@exercice_n_2_id", "'" + exercice_n_2_id + "'");
            
            DataTable budget = getResultSQL(cmd, parameters);
            DataTable budgetPresent = new DataTable();
            budgetPresent.Clear();

            if (budgetPresent.Columns.Count <= 0)
                foreach (DataColumn col in budget.Columns)
                {
                    budgetPresent.Columns.Add(col.ColumnName, col.DataType);
                }

            string nature = "";
            string base_repart = "";
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
                    int current = budgetPresent.Rows.Count - 1;
                    object[] oldItem = budgetPresent.Rows[current].ItemArray;
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

        public bool UpdateStatus(string budget_id, GlobalConstantes.StatutBudget new_statut)
        {
            bool rc = false;

            NpgsqlConnection cnx = Database.GetInstance();
            NpgsqlTransaction trx = cnx.BeginTransaction();


            try 
	        {
                TimestampServer = Database.GetTimestampServer();
                BudgetLigneController ctlLines = BudgetLigneController.getController();
                ctlLines.setTimestampServer(TimestampServer);
                DataTable budget_lines = ctlLines.getLinesBudget(budget_id); 
                BudgetEntite budget = getEntiteById(budget_id);
                bool updateLineOk = true;

                if ( budget_lines != null && budget_lines.Rows.Count > 0 )
                {
                    foreach (DataRow row in budget_lines.Rows)
                    {
                        BudgetLigneEntite budget_line = new BudgetLigneEntite(row);
                        budget_line.statut = (int) new_statut;
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
            return rc;
        }
    }
}
