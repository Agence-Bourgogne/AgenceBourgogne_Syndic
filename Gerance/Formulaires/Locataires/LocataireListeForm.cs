using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Controller;
using GeranceData.Entites;

namespace Gerance.Formulaires.Locataires
{
    public partial class LocataireListeForm : Gerance.Formulaires.Common.CommonListeForm
    {
        public LocataireListeForm()
        {
            InitializeComponent();
            regKey = "listes\\locataires";
        }
        protected override DataTable getFormListe()
        {
            return LocataireController.getController().GetList();
        }
        protected override void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            base.HideAndResizeColumns(cols);
            cols["id"].Visible = false;
            cols["comptable_id"].Visible = false;
            cols["note"].Visible = false;
//            cols["statut"].Visible = false;
            cols["pays"].Visible = false;
            cols["nom"].MinimumWidth = 120;
            cols["adresse"].MinimumWidth = 120;
            cols["ville"].MinimumWidth = 120;
        }
        protected override void ShowFicheForm(string entite_id)
        {
            LocataireFicheForm form = new LocataireFicheForm(entite_id);
            ShowForm(form);
        }

        private void btnFiltre_Click(object sender, EventArgs e)
        {
            LocataireFindForm form = new LocataireFindForm();
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                LocataireEntite proprio = LocataireController.getController().getEntiteFromField("reference", form.reference);
                LocataireFicheForm fiche = new LocataireFicheForm(proprio.id);
                fiche.ShowDialog();
            }
        }
        protected override void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            DataGridViewColumn col = dgv.Columns[e.ColumnIndex];

            try
            {
                if (col.Name == "statut")
                    if (dgv["statut", e.RowIndex].Value.ToString() == "9")
                    {
                        dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(255, 128, 0);
                    }
            }
            catch (Exception)
            {
            }

        }

    }
}
