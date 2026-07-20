using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using SyndicData.Entites;

namespace EspaceSyndic.UtilsApp;

internal static class RepartitionControlsWindows
{
    public static void initGridRepartition(DataGridView grid, int baseWidth = 50)
    {
        var baseCharge = ParametresDB.getComboData("CODECHARGE");
        var grpCharge = ParametresDB.getComboData("GROUPCHARGE");
        var width = 0;

        ControlsWindows.addColumn(grid, "Bases Charges", baseWidth);

        foreach (DataRow col in grpCharge.Rows)
        {
            ControlsWindows.addColumn(grid, col["nom"].ToString(), baseWidth);
            width += baseWidth;
        }

        grid.Columns[0].Width = grid.Width - (width - 5);
        foreach (DataRow row in baseCharge.Rows)
        {
            var rowGrid = new DataGridViewRow();
            var cell = new DataGridViewTextBoxCell();
            cell.Value = row["nom"];
            cell.Style.BackColor = Color.LightGray;
            rowGrid.Cells.AddRange(cell);
            foreach (DataRow unused in grpCharge.Rows)
            {
                cell = new DataGridViewTextBoxCell();
                cell.Style.BackColor = Color.LightGray;
                rowGrid.Cells.AddRange(cell);
            }

            grid.Rows.Add(rowGrid);
        }
    }

    public static AutoCompleteStringCollection ShowRepartitionImmeuble(DataGridView dataGridView, DataTable repartition)
    {
        var baseAuto = new AutoCompleteStringCollection();
        foreach (DataGridViewRow r in dataGridView.Rows)
        foreach (DataGridViewCell c in r.Cells)
        {
            if (c.ColumnIndex == 0)
                continue;
            c.Style.BackColor = Color.LightGray;
            c.ToolTipText = "";
            c.Value = "";
        }

        if (repartition != null)
            foreach (DataRow row in repartition.Rows)
            {
                var entite = new ImmeubleRepartitionEntite(row);
                var ligne = entite.ligne;
                if (ligne < 1)
                    continue;
                var colonne = entite.colonne;
                if (colonne + 1 > dataGridView.ColumnCount)
                    continue;
                var valeur = entite.valeur;
                dataGridView.Rows[ligne - 1].Cells[colonne + 1].Tag = new ImmeubleRepartitionEntite(row);
                if (valeur > 0 || entite.type_ventilation == (int)GlobalConstantes.TypeRepartition.Individuelle)
                {
                    baseAuto.Add(row["reference"].ToString().Replace(";", ""));
                    dataGridView.Rows[ligne - 1].Cells[colonne + 1].Style.BackColor = Color.White;
                    dataGridView.Rows[ligne - 1].Cells[colonne + 1].ToolTipText = row["nom"].ToString();
                    if (entite.type_ventilation == (int)GlobalConstantes.TypeRepartition.Individuelle)
                        dataGridView.Rows[ligne - 1].Cells[colonne + 1].Value = "*";
                    else
                        dataGridView.Rows[ligne - 1].Cells[colonne + 1].Value = valeur;
                }
                else
                {
                    dataGridView.Rows[ligne - 1].Cells[colonne + 1].Style.BackColor = Color.LightGray;
                }
            }

        return baseAuto;
    }
}