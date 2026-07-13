using System;using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Common;
using EspaceSyndic.Formulaires.Immeubles;
using SyndicData.Common;
using EspaceSyndic.Formulaires;
namespace EspaceSyndic.Impressions.RetardsPaiements
{
    public partial class RetardsPaiementsForm : Form
    {
        public string immeuble_ref = "";

        public RetardsPaiementsForm()
        {
            InitializeComponent();
        }
        BindingSource sourceData = new BindingSource();
        int type_rel = 0;
        private void RetardsPaiementsForm_Load(object sender, EventArgs e)
        {
            cbFiltre.SelectedIndex = 0;
            tbRefImmeuble.Text = immeuble_ref;
            FilldataGrid();
            commonValidating();
        }
        void FilldataGrid()
        {
            CoproprietaireController.getController().resetDatesRelance();

            sourceData.DataSource = OperationController.getController().getListSoldeCoproprietaires(ckActif.Checked);
            if (sourceData != null)
            {
                sourceData.Filter = getFiltre();
                dataGridView.DataSource = sourceData;
                DataGridViewColumnCollection cols = dataGridView.Columns;
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
            this.reportViewer1.Visible = false;
            this.reportViewer2.Visible = false;

        }

        private string getFiltre()
        {
            string filtre = "1=1";
            if (tbRefImmeuble.Text != "")
                filtre += String.Format(" and ref_immeuble = '{0}'", tbRefImmeuble.Text);
            if ( tbSeuil.Text != "" )
                filtre += String.Format(" and solde < -{0}", tbSeuil.Text);
            if (cbFiltre.SelectedIndex > 0)
                filtre += String.Format(" and type_relance = {0}", cbFiltre.SelectedIndex);
            return filtre;
        }
        private void tbRefImmeuble_DoubleClick(object sender, EventArgs e)
        {
            FindImmeubleForm form = new FindImmeubleForm();
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
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                if (row.Cells[e.ColumnIndex].Value == null)
                    row.Cells[e.ColumnIndex].Value = false;
                row.Cells[e.ColumnIndex].Value = !((bool)row.Cells[e.ColumnIndex].Value);
                dataGridView.ClearSelection();
            }
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            ReportParameter[] reportParams = new ReportParameter[]{
                    new ReportParameter("DateEdition", dtEdition.Value.ToShortDateString()),
                    new ReportParameter("Immeuble", tbRefImmeuble.Text),
                    new ReportParameter("Seuil", tbSeuil.Text),
                    new ReportParameter("Sort", dataGridView.SortedColumn.Name),
                };
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("retardPaiements", sourceData));
            this.reportViewer1.LocalReport.SetParameters(reportParams);
            this.reportViewer1.RefreshReport();

            this.reportViewer1.Visible = true;
            this.reportViewer2.Visible = false;
            this.dataGridView.Visible = false;
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
                string sortedCol = dataGridView.SortedColumn.Name ;
                DataGridViewColumn col = dataGridView.SortedColumn;
                string sortOrder = dataGridView.SortOrder.ToString();
                DataGridViewColumnCollection cols = dataGridView.Columns;
                sourceData.DataSource = OperationController.getController().getListSoldeCoproprietaires(ckActif.Checked);
                sourceData.Filter = getFiltre();
                dataGridView.DataSource = sourceData;

                if (sortOrder == ListSortDirection.Ascending.ToString())
                    dataGridView.Sort(cols[sortedCol], ListSortDirection.Ascending);
                else
                    dataGridView.Sort(cols[sortedCol], ListSortDirection.Descending);
                this.reportViewer1.Visible = false;
                this.reportViewer2.Visible = false;
                this.dataGridView.Visible = true;
                dataGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewColumn col = dgv.Columns[e.ColumnIndex];

            try
            {
                if (col.Name == "mise_en_demeure")
                    if (dgv["type_relance", e.RowIndex].Value.ToString() != "")
                    {
                        int type_retard = (int)dgv["type_relance", e.RowIndex].Value;
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
            List<string> colsToHide = new List<string> { "immeuble_id", "lot_id", "relance"};
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
            string modele = ParametresDB.getParam1("MODELES", "RELANCE1");

            List<RelanceEntite> [] relances = new List<RelanceEntite>[] {new List<RelanceEntite>(), new List<RelanceEntite>(), new List<RelanceEntite>(), new List<RelanceEntite>()} ;
            List<RelanceEntite>[] relancesRetard = new List<RelanceEntite>[] { new List<RelanceEntite>(), new List<RelanceEntite>(), new List<RelanceEntite>(), new List<RelanceEntite>() };
            
            try
            {
                bool bHaveSelection = false;
                List<String> duplicatas = new List<string>();
                foreach (DataGridViewRow rowGrid in dataGridView.Rows)
                {
                    if (rowGrid.Cells["relance"].Value != null)
                        if (true == (bool)rowGrid.Cells["relance"].Value)
                        {
                            DataRowView row = (DataRowView)rowGrid.DataBoundItem;

                            int type_retard = 0;
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

                int type = 0;

                DateTime dt = DateTime.Parse(dtEdition.Value.ToShortDateString());

                if (!bHaveSelection)
                {
                    MessageBox.Show("Vous devez Cocher les éléments à relancer");
                    return;
                }
                if (MessageBox.Show("Voulez vous mettre à jour les dates de Relances\r\nEt Générer les écritures correspondantes", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (RelanceController.GenerateRelance(relancesRetard, dt))
                        MessageBox.Show("Mise à jour effectuée");
                    btnGrid_Click(null, null);
                }

                foreach ( List <RelanceEntite> relance in relances )
                {
                    string copros_ids = RelanceController.getQuotedCoproprietaireId(relance);
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
                    string copros_ids = RelanceController.getQuotedCoproprietaireId(duplicatas);
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
            MainForm frm = new MainForm();
            frm.ShowForm("EspaceSyndic.Impressions.RelevesComptes.ReleveCompteCoproPrintForm");
           
            DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
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
                    rowGrid.Cells["première_relance"].Value = System.DBNull.Value;
                    rowGrid.Cells["seconde_relance"].Value = System.DBNull.Value;
                    rowGrid.Cells["mise_en_demeure"].Value = System.DBNull.Value;
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
                    rowGrid.Cells["seconde_relance"].Value = System.DBNull.Value;
                    rowGrid.Cells["mise_en_demeure"].Value = System.DBNull.Value;
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
                    rowGrid.Cells["mise_en_demeure"].Value = System.DBNull.Value;
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
}
