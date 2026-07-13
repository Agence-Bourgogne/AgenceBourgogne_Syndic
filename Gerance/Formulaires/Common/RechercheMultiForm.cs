using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using GeranceData.Controller;
using GeranceData.Entites;
using Gerance.Formulaires.Biens;
using Gerance.Formulaires.Proprietaires;
using Gerance.Formulaires.Locataires;
using Gerance.Formulaires.Common;

namespace Gerance.Formulaires.Common
{
    public partial class RechercheMultiForm : Form
    {
        public RechercheMultiForm()
        {
            InitializeComponent();
        }

        private void RechercheMultiForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
            FillDataGrid();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void tbReference_Validating(object sender, CancelEventArgs e)
        {
            FillDataGrid();
        }

        private void tbRefProprio_Validating(object sender, CancelEventArgs e)
        {
            FillDataGrid();
        }

        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            FillDataGrid();
        }
        void FillDataGrid()
        {
            dataGridView.DataSource = BienController.getController().FindElement(tbReference.Text, tbRefProprio.Text, tbRefLocataire.Text, tbNomBien.Text, tbNomProprio.Text, tbNomLoca.Text);
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                cols["b_id"].Visible = false;
                cols["p_id"].Visible = false;
                cols["l_id"].Visible = false;
                cols["bien"].Width = 40;
                cols["proprio"].Width = 60;
                cols["locataire"].Width = 60;
                ControlsWindows.ToTitleCase(cols);
            }
        }

        private void btnBien_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView) dataGridView.SelectedRows[0].DataBoundItem;
                string reference = row["b_id"].ToString();
                BienEntite bien = BienController.getController().getEntiteById(reference);
                if (bien != null)
                {
                    BienFicheForm form = new BienFicheForm(bien.id);
                    form.ShowDialog();
                }
            }
        }

        private void btnPropri_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                string reference = row["p_id"].ToString();
                ProprietaireEntite proprio = ProprietaireController.getController().getEntiteById(reference);
                if (proprio != null)
                {
                    ProprietaireFicheForm form = new ProprietaireFicheForm(proprio.id);
                    form.ShowDialog();
                }
            }
        }

        private void btnLoca_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                string reference = row["l_id"].ToString();
                LocataireEntite locataire = LocataireController.getController().getEntiteById(reference);
                if (locataire != null)
                {
                    LocataireFicheForm form = new LocataireFicheForm(locataire.id);
                    form.ShowDialog();
                }
            }
        }

        private void tbNomBien_Validating(object sender, CancelEventArgs e)
        {
            FillDataGrid();
        }

        protected DialogResult ShowFindForm(CommonFindForm form, Control tbResult)
        {
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
                tbResult.Text = form.reference;
            return res;
        }
        private void lblReference_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new BienFindForm(), tbReference) == DialogResult.OK)
            {
                tbReference_Validating(null, null);
            }
        }

        private void lblLocataire_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new LocataireFindForm(), tbRefLocataire) == DialogResult.OK)
            {
                tbRefLocataire_Validating(null, null);
            }
        }

        private void lblProprio_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new ProprietaireFindForm(), tbRefProprio) == DialogResult.OK)
            {
                tbRefProprio_Validating(null, null);
            }
        }
        private void tbReference_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.KeyCode == Keys.Space)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    if (sender == tbReference || sender == tbNomBien )
                        lblReference_Click(null, null);
                    if (sender == tbRefProprio || sender == tbNomProprio)
                        lblProprio_Click(null, null);
                    if (sender == tbNomLoca || sender == tbRefLocataire)
                        lblLocataire_Click(null, null);
                }
        }

    }
}
