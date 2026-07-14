using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Impressions.RelevesComptes;
using Microsoft.Reporting.WinForms;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions.RetardsPaiements;

public partial class RetardsPaiementsForm : Form
{
    public string immeuble_ref = "";

    public RetardsPaiementsForm()
    {
        InitializeComponent();
    }

    private readonly BindingSource sourceData = new();
    private int type_rel;
    private void RetardsPaiementsForm_Load(object sender, EventArgs e)
    {
        cbFiltre.SelectedIndex = 0;
        tbRefImmeuble.Text = immeuble_ref;
        FilldataGrid();
        commonValidating();
    }

    private void FilldataGrid()
    {
        CoproprietaireController.getController().resetDatesRelance();

        sourceData.DataSource = OperationController.getController().getListSoldeCoproprietaires(ckActif.Checked);
        if (sourceData != null)
        {
            sourceData.Filter = getFiltre();
            dataGridView.DataSource = sourceData;
            var cols = dataGridView.Columns;
            dataGridView.Sort(cols["solde"], ListSortDirection.Ascending);
            cols["immeuble_id"].Visible = false;
            cols["lot_id"].Visible = false;
            cols["numero_lot"].Visible = false;
            cols["immeuble"].Visible = false;
            cols["type_relance"].Visible = false;
            cols["id"].Visible = false;
            type_rel = cols["type_relance"].Index;
            ControlsWindows.ToTitleCase(cols);
            cols["relance"].Width = 40;
            cols["coproprietaire"].MinimumWidth = 180;
            //cols["immeuble"].MinimumWidth = 120;
            cols["reference"].Width = 80;
            cols["numero_lot"].Width = 40;
            cols["solde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.ClearSelection();
        }
        btnEnter.Height = 0;
        reportViewer1.Visible = false;
        reportViewer2.Visible = false;

    }

    private string getFiltre()
    {
        var filtre = "1=1";
        if (tbRefImmeuble.Text != "")
            filtre += $" and ref_immeuble = '{tbRefImmeuble.Text}'";
        if ( tbSeuil.Text != "" )
            filtre += $" and solde < -{tbSeuil.Text}";
        if (cbFiltre.SelectedIndex > 0)
            filtre += $" and type_relance = {cbFiltre.SelectedIndex}";
        return filtre;
    }
    private void tbRefImmeuble_DoubleClick(object sender, EventArgs e)
    {
        var form = new FindImmeubleForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbRefImmeuble.Text = form.reference;
            tbRefImmeuble_Validating(null, null);
        }

    }
    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        commonValidating();
    }

    private void tbSeuil_Validating(object sender, CancelEventArgs e)
    {
        commonValidating();
    }

    private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex == 0)
        {
            var row = dataGridView.Rows[e.RowIndex];
            if (row.Cells[e.ColumnIndex].Value == null)
                row.Cells[e.ColumnIndex].Value = false;
            row.Cells[e.ColumnIndex].Value = !(bool)row.Cells[e.ColumnIndex].Value;
            dataGridView.ClearSelection();
        }
    }
    private void btnList_Click(object sender, EventArgs e)
    {
        var reportParams = new ReportParameter[]{
            new("DateEdition", dtEdition.Value.ToShortDateString()),
            new("Immeuble", tbRefImmeuble.Text),
            new("Seuil", tbSeuil.Text),
            new("Sort", dataGridView.SortedColumn.Name)
        };
        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("retardPaiements", sourceData));
        reportViewer1.LocalReport.SetParameters(reportParams);
        reportViewer1.RefreshReport();

        reportViewer1.Visible = true;
        reportViewer2.Visible = false;
        dataGridView.Visible = false;
    }


    private void commonValidating()
    {
        sourceData.Filter = getFiltre();
        dataGridView.DataSource = sourceData;

        if (reportViewer1.Visible)
        {
            btnList_Click(null, null);
        }
        if (reportViewer2.Visible)
        {
            btnRelance_Click(null, null);
        }

    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
        commonValidating();
    }

    private void btnGrid_Click(object sender, EventArgs e)
    {
        try
        {
            var sortedCol = dataGridView.SortedColumn.Name ;
            var sortOrder = dataGridView.SortOrder.ToString();
            var cols = dataGridView.Columns;
            sourceData.DataSource = OperationController.getController().getListSoldeCoproprietaires(ckActif.Checked);
            sourceData.Filter = getFiltre();
            dataGridView.DataSource = sourceData;

            if (sortOrder == nameof(ListSortDirection.Ascending))
                dataGridView.Sort(cols[sortedCol], ListSortDirection.Ascending);
            else
                dataGridView.Sort(cols[sortedCol], ListSortDirection.Descending);
            reportViewer1.Visible = false;
            reportViewer2.Visible = false;
            dataGridView.Visible = true;
            dataGridView.ClearSelection();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        var dgv = (DataGridView)sender;
        var col = dgv.Columns[e.ColumnIndex];

        try
        {
            if (col.Name == "mise_en_demeure")
                if (dgv["type_relance", e.RowIndex].Value.ToString() != "")
                {
                    var type_retard = (int)dgv["type_relance", e.RowIndex].Value;
                    //if (type_retard == 1)
                    //    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = lblRel1.BackColor;
                    //if (type_retard == 2)
                    //    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = lblRel2.BackColor;
                    //if (type_retard == 3)
                    //    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = lblRel3.BackColor;
                    setLineColor(type_retard, e.RowIndex);
                    //e.FormattingApplied = true;
                }
        }
        catch (Exception)
        {
        }
    }
    private void setLineColor (int type_retard, int rowIndex )
    {
        if (type_retard == 0)
            dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = Color.White;
        if (type_retard == 1)
            dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = lblRel1.BackColor;
        if (type_retard == 2)
            dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = lblRel2.BackColor;
        if (type_retard == 3)
            dataGridView.Rows[rowIndex].DefaultCellStyle.BackColor = lblRel3.BackColor;

    }
    private void btnExport_Click(object sender, EventArgs e)
    {
        var colsToHide = new List<string> { "immeuble_id", "lot_id", "relance"};
        BaseApplication.DataGridToExcel(dataGridView, colsToHide, "relance");
    }

    //private void ckAll_CheckedChanged(object sender, EventArgs e)
    //{
    //    foreach (DataGridViewRow row in dataGridView.Rows)
    //    {
    //        row.Cells["relance"].Value = ckAll.Checked;
    //    }
    //}
    private void btnRelance_Click(object sender, EventArgs e)
    {
        var modele = ParametresDB.getParam1("MODELES", "RELANCE1");

        var relances = new List<RelanceEntite>[] { [], [], [], [] } ;
        var relancesRetard = new List<RelanceEntite>[] { [], [], [], [] };
            
        try
        {
            var bHaveSelection = false;
            var duplicatas = new List<string>();
            foreach (DataGridViewRow rowGrid in dataGridView.Rows)
            {
                if (rowGrid.Cells["relance"].Value != null)
                    if ((bool)rowGrid.Cells["relance"].Value)
                    {
                        var row = (DataRowView)rowGrid.DataBoundItem;

                        var type_retard = 0;
                        if (rowGrid.Tag != null)
                            type_retard = (int) rowGrid.Tag;
                        else
                        if (row["type_relance"] != null)
                            type_retard = Convertir.ToInt(row["type_relance"]);
                        if (row["duplicata"].ToString() == "1" && type_retard == 3)
                            duplicatas.Add(row["id"].ToString());
                        else
                            relances[type_retard].Add(new RelanceEntite(row["immeuble_id"].ToString(), row["id"].ToString(), row["lot_id"].ToString(), type_retard));
                        relancesRetard[type_retard].Add(new RelanceEntite(row["immeuble_id"].ToString(), row["id"].ToString(), row["lot_id"].ToString(), type_retard));
                        bHaveSelection = true;
                    }
            }

            var type = 0;

            var dt = DateTime.Parse(dtEdition.Value.ToShortDateString());

            if (!bHaveSelection)
            {
                MessageBox.Show(@"Vous devez Cocher les éléments à relancer");
                return;
            }
            if (MessageBox.Show("Voulez vous mettre à jour les dates de Relances\r\nEt Générer les écritures correspondantes", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (RelanceController.GenerateRelance(relancesRetard, dt))
                    MessageBox.Show(@"Mise à jour effectuée");
                btnGrid_Click(null, null);
            }

            foreach ( var relance in relances )
            {
                var copros_ids = RelanceController.getQuotedCoproprietaireId(relance);
                if (copros_ids != "")
                {  
                    DataTable table = null;
                    table = OperationController.getController().GetDataForRelance(copros_ids, dt.ToShortDateString(), type);
                        
                    if (table != null)
                    {
                        BaseApplication.PublipostageLettreWord(table, modele);
                    }
                }
                type++;
                if ( type >= 2)
                    modele = ParametresDB.getParam1("MODELES", "RELANCE3");
            }
            if (duplicatas.Count > 0)
            {
                var copros_ids = RelanceController.getQuotedCoproprietaireId(duplicatas);
                if (copros_ids != "")
                {
                    DataTable table = null;
                    table = OperationController.getController().GetDataForRelance(copros_ids, dt.ToShortDateString(), type);

                    if (table != null)
                    {
                        modele = ParametresDB.getParam1("MODELES", "RELANCE4");
                        BaseApplication.PublipostageLettreWord(table, modele);
                    }
                }
            }
        }
        catch (Exception ex )
        {
            MessageBox.Show(ex.Message);    
        }            
    }

    private void dataGridView_DoubleClick(object sender, EventArgs e)
    {
        var frm = new MainForm();
        frm.ShowForm<ReleveCompteCoproPrintForm>();
           
        var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
        MainForm.syndicEvent.FireChanged(this, new CommonEventArgs(row["ref_immeuble"].ToString(), row["numero_lot"].ToString()));
    }

    private void nePasRelancerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if ( dataGridView.SelectedRows.Count > 0 )
        {
            foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
            {
                rowGrid.Cells["relance"].Value = false;
                rowGrid.Cells["type_relance"].Value = 0;
                rowGrid.Cells["première_relance"].Value = DBNull.Value;
                rowGrid.Cells["seconde_relance"].Value = DBNull.Value;
                rowGrid.Cells["mise_en_demeure"].Value = DBNull.Value;
                rowGrid.Tag = 0;
            }
            dataGridView.ClearSelection();
        }
    }

    private void générer1ereRelanceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
            {
                rowGrid.Cells["relance"].Value = true;
                rowGrid.Cells["type_relance"].Value = 1;
                rowGrid.Cells["première_relance"].Value = DateTime.Now.Date;
                rowGrid.Cells["seconde_relance"].Value = DBNull.Value;
                rowGrid.Cells["mise_en_demeure"].Value = DBNull.Value;
                setLineColor(1, rowGrid.Index);
                rowGrid.Tag = 0;
            }
            dataGridView.ClearSelection();
        }

    }

    private void générer2ndeRelnceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
            {
                rowGrid.Cells["relance"].Value = true;
                rowGrid.Cells["type_relance"].Value = 2;
                rowGrid.Cells["seconde_relance"].Value = DateTime.Now.Date;
                rowGrid.Cells["mise_en_demeure"].Value = DBNull.Value;
                setLineColor(2, rowGrid.Index);
                rowGrid.Tag = 1;
            }
            dataGridView.ClearSelection();
        }

    }

    private void envoyerMiseEnDemeureToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (dataGridView.SelectedRows.Count > 0)
        {
            foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
            {
                rowGrid.Cells["relance"].Value = true;
                rowGrid.Cells["type_relance"].Value = 3;
                rowGrid.Cells["mise_en_demeure"].Value = DateTime.Now.Date;
                rowGrid.Tag = 3;
                setLineColor(3, rowGrid.Index);
            }
            dataGridView.ClearSelection();
        }
    }

    private void cbFiltre_SelectedIndexChanged(object sender, EventArgs e)
    {
        FilldataGrid();
    }

    private void effacerLaRelanceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
        {
            Console.WriteLine(rowGrid.Cells["reference"].Value);
            CoproprietaireController.getController().resetDatesRelance(rowGrid.Cells["reference"].Value.ToString());
        }
        btnGrid_Click(null, null);
    }
}