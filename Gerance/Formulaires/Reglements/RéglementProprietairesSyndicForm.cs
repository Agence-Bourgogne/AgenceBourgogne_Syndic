using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using GeranceData.Controller;
using Gerance.Formulaires.Syndic;
using System.Globalization;
using CommonProjectsPartners.Common;

namespace Gerance.Formulaires.Reglements
{
    public partial class RéglementProprietairesSyndicForm : Gerance.Formulaires.Common.CommonGridviewForm
    {
        string locataires_id;
        public RéglementProprietairesSyndicForm()
        {
            InitializeComponent();
            locataires_id = SyndicDatabase.getListLocatairesId();
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reglement});
            dataGridView.CellContentClick += dataGridView_CellContentClick;
        }

        void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        protected override void InitializeCombos()
        {
            DateTime dt = DateTime.Parse("01/01/2000");
            TextInfo textInfo = new CultureInfo("fr-FR", false).TextInfo;

            for (int i = 0; i < 12; i++)
            {
                String[] lDate = dt.ToLongDateString().Split(' ');
                cbMonth.Items.Add(textInfo.ToTitleCase(lDate[2]));
                dt = dt.AddMonths(1);
            }
            cbMonth.SelectedIndex = DateTime.Now.AddMonths(-1).Month;
            dataGridView.Height -= 10;
        }

        private void cbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDataGrid();
        }
        protected override DataTable getFormListe()
        {
            DateTime dtDeb = new DateTime(DateTime.Now.Year, cbMonth.SelectedIndex+1, 1);
            return ReglementsController.getController().getListeReglements(dtDeb, locataires_id);
        }
        protected override void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            cols["ref_loc"].Width = 50;
            cols["ref_prop"].Width = 50;
            cols["montant"].Width = 50;
            cols["date_reglement"].Width = 70;
            cols["reglement"].Width = 20;
            base.HideAndResizeColumns(cols);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                row.Cells["reglement"].Value = ckAll.Checked;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<string> colsToHide = new List<string> { "id", "reglement" };
            BaseApplication.DataGridToExcel(dataGridView, colsToHide);

        }
    }
}
