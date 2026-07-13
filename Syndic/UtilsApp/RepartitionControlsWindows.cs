using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Data;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using SyndicData.Common;

namespace EspaceSyndic.UtilsApp
{
    class RepartitionControlsWindows
    {
        public static void initGridRepartition(DataGridView grid,  int baseWidth = 50)
        {
            DataTable baseCharge = ParametresDB.getComboData("CODECHARGE");
            DataTable grpCharge = ParametresDB.getComboData("GROUPCHARGE");
            int width = 0;

            ControlsWindows.addColumn(grid, "Bases Charges", baseWidth);

            foreach (DataRow col in grpCharge.Rows)
            {
                ControlsWindows.addColumn(grid, col["nom"].ToString(), baseWidth);
                width += baseWidth;
            }
            grid.Columns[0].Width =  grid.Width - (width - 5); 
            foreach (DataRow row in baseCharge.Rows)
            {
                DataGridViewRow rowGrid = new DataGridViewRow();
                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                cell.Value = row["nom"];
                cell.Style.BackColor = Color.LightGray;
                rowGrid.Cells.AddRange(cell);
                foreach (DataRow col in grpCharge.Rows)
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
            AutoCompleteStringCollection baseAuto = new AutoCompleteStringCollection();
            foreach (DataGridViewRow r in dataGridView.Rows)
                foreach (DataGridViewCell c in r.Cells)
                {
                    if (c.ColumnIndex == 0)
                        continue;
                    c.Style.BackColor = Color.LightGray;
                    c.ToolTipText = "";
                    c.Value = "";
                }
            if ( repartition != null )
                foreach (DataRow row in repartition.Rows)
                {
                    ImmeubleRepartitionEntite entite = new ImmeubleRepartitionEntite(row);
                    int ligne = entite.ligne;
                    if (ligne < 1)
                        continue;
                    int colonne = entite.colonne;
                    if (colonne + 1 > dataGridView.ColumnCount)
                        continue;
                    int valeur = entite.valeur;
                    dataGridView.Rows[ligne - 1].Cells[colonne + 1].Tag = new ImmeubleRepartitionEntite(row);
                    if (valeur > 0 || entite.type_ventilation == (int) GlobalConstantes.TypeRepartition.Individuelle)
                    {
                        baseAuto.Add(row["reference"].ToString().Replace(";", ""));
                        dataGridView.Rows[ligne - 1].Cells[colonne + 1].Style.BackColor = Color.White;
                        dataGridView.Rows[ligne - 1].Cells[colonne + 1].ToolTipText = row["nom"].ToString();
                        if ( entite.type_ventilation == (int) GlobalConstantes.TypeRepartition.Individuelle )
                            dataGridView.Rows[ligne - 1].Cells[colonne + 1].Value = "*";
                        else
                            dataGridView.Rows[ligne - 1].Cells[colonne + 1].Value = valeur;
                    }
                    else
                        dataGridView.Rows[ligne - 1].Cells[colonne + 1].Style.BackColor = Color.LightGray;
                }
            return baseAuto;
        }

    }
}
