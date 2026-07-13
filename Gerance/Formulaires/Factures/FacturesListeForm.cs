using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeranceData.Controller;
using GeranceData.Entites;
using GeranceData.Common;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Common;
using Gerance.Formulaires.Locataires;
using Gerance.Formulaires.Common;

namespace Gerance.Formulaires.Factures
{
    public partial class FacturesListeForm : Form
    {
        public FacturesListeForm()
        {
            InitializeComponent();
        }

        private void FacturesListeForm_Load(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            DateTime dt = new DateTime(dtNow.Year, dtNow.Month, 1);
            dtDebut.Value = dt;
            dtFin.Value = dt.AddMonths(1).AddDays(-1);
            btnEnter.Width = 0;
            FillDataGrid();
        }
//        private bool bLoading;
        private void FillDataGrid()
        {
            //bLoading = true;
            dataGridView.DataSource = FacturesController.getController().getListeFactures(dtDebut.Value, dtFin.Value, tbRefLocataire.Text);
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                cols["locataire"].MinimumWidth = 120;
                cols["libelle"].MinimumWidth = 120;
                cols["immeuble"].MinimumWidth = 120;
                cols["ref_immeuble"].Width = 40;
                cols["ref_locataire"].Width = 60;
                cols["date_facture"].Width = 70;
                cols["id"].Visible = false;
                ControlsWindows.ToTitleCase(cols);
                dataGridView.ClearSelection();
            }
            //bLoading = false;
        }

        private void btnGrid_Click(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<string> colsToHide = new List<string> { "id" };
            BaseApplication.DataGridToExcel(dataGridView, colsToHide);
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                FactureDetailForm form = new FactureDetailForm(row["id"].ToString());
                form.ShowDialog();
                FillDataGrid();
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                FactureEntite facture = FacturesController.getController().getEntiteById(row["id"].ToString());
                if (facture != null)
                {
                    facture.statut = (int)GlobalConstantes.StatutOperation.Supprime;
                    FacturesController.getController().InsertOrUpdate(facture);
                }
            }
            FillDataGrid();
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            btnDetail_Click(null, null);
        }
        protected DialogResult ShowFindForm(CommonFindForm form, Control tbResult)
        {
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
                tbResult.Text = form.reference;
            return res;
        }

        private void lblRefLocataire_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new LocataireFindForm(), tbRefLocataire) == DialogResult.OK)
            {
//                tbRefLocataire_Validating(null, null);
            }
        }
    }
}
