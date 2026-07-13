using System;
using System.Data;
using System.Windows.Forms;
using GeranceData.Controller;
using GeranceData.Common;
using CommonProjectsPartners.Utils;

namespace Gerance.Formulaires.Indices
{
    public partial class IndicesForm : Form
    {
        bool bInitialized = false;
        TextBox tbCoeff = null, tbIndice = null;
        public IndicesForm()
        {
            InitializeComponent();
        }
        public IndicesForm(TextBox tbCoeff, TextBox tbIndice)
        {
            InitializeComponent();
            this.tbCoeff = tbCoeff;
            this.tbIndice = tbIndice;
            btnSelect.Enabled = true;
        }

        private void IndicesForm_Load(object sender, EventArgs e)
        {
            ParametresDB.FillComboFromParams(cbIndices, "INDICES", "nom", "code");
            bInitialized = true;
            FillDataGrid();
        }

        private void cbIndices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!bInitialized)
                return;
            FillDataGrid();
        }
        private void FillDataGrid()
        {
            dataGridView.DataSource = IndiceController.getController().getListIndices(cbIndices.SelectedValue.ToString());
            HideAndResizeColumns(dataGridView.Columns);
        }
        protected void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {

            cols["id"].Visible = false;
            cols["reference"].Visible = false;
            cols["audit_created"].Visible = false;
            cols["audit_created_by"].Visible = false;
            cols["audit_updated"].Visible = false;
            cols["audit_updated_by"].Visible = false;
            ControlsWindows.ToTitleCase(cols);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateIndiceForm form = new UpdateIndiceForm(cbIndices.SelectedValue.ToString());
            form.ShowDialog();
            FillDataGrid();
        }
        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            Selection();
        }
        void Selection()
        {

            if ( dataGridView.SelectedRows.Count > 0 )
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                if (row != null) 
                {
                    if (tbCoeff != null)
                        tbCoeff.Text = row["variation"].ToString();
                    if (tbIndice != null)
                        tbIndice.Text = row["indice"].ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Selection();
        }
    }
}
