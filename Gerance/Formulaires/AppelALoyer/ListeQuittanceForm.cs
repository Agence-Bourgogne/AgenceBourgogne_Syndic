using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Controller;
using CommonProjectsPartners.Utils;
using Gerance.Formulaires.Locataires;
using Gerance.Formulaires.Proprietaires;
namespace Gerance.Formulaires.AppelALoyer
{
    public partial class ListeQuittanceForm : Common.CommonGridviewForm
    {
        public ListeQuittanceForm()
        {
            InitializeComponent();
        }

        protected override DataTable getFormListe()
        {
            return QuittancesController.getController().getListQuittances(dateDebut.Value, tbRefLocataire.Text, tbRefProprio.Text);
        }

        private void ListeQuittanceForm_Load(object sender, EventArgs e)
        {
            dataGridView.MultiSelect = true;
        }

        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            tbRefLocataire.BackColor = Color.White;
            tbNomLocataire.Text = "";
            if ( tbRefLocataire.Text != "")
            {
                var locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
                if (locataire != null)
                {
                    tbNomLocataire.Text = locataire.NomPrenom;
                }
                else
                    tbRefLocataire.BackColor = Color.Red;
            }
            FillDataGrid();
        }

        private void tbRefProprio_Validating(object sender, CancelEventArgs e)
        {
            tbRefProprio.BackColor = Color.White;
            tbNomProprio.Text = "";
            if (tbRefProprio.Text != "")
            {
                var proprio = ProprietaireController.getController().getEntiteFromField("reference", tbRefProprio.Text);
                if (proprio != null)
                {
                    tbNomProprio.Text = proprio.NomPrenom;
                }
                else
                    tbRefProprio.BackColor = Color.Red;
            }
            FillDataGrid();
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
        protected override void ShowFicheForm(string entite_id)
        {
            var form = new AnnulationQuittanceForm(entite_id);//, dataGridView);
            form.ShowDialog();
            FillDataGrid();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != MessageBox.Show("Opération irréversible\r\nVoulez-vous Continuer", "Attention", MessageBoxButtons.YesNo))
                return;
            var trx = Database.BeginTransaction();
            var dt = QuittancesController.getController().setTimestampServer();
            LocataireController.getController().setTimestampServer(dt);
            try
            {
                foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
                {
                    var row = (DataRowView)rowGrid.DataBoundItem;
                    var quittance = QuittancesController.getController().getEntiteById(row["id"].ToString());
                    if (!QuittancesController.DeleteQuittance(quittance))
                        throw new Exception("");
                }
                trx.Commit();
            }
            catch (Exception)
            {
                trx.Rollback();
            }
            FillDataGrid();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                var quittance = QuittancesController.getController().getEntiteById(row["id"].ToString());
                var form = new ImprimerQuittanceForm(quittance);
                form.ShowDialog();
            }
        }
    }
}
