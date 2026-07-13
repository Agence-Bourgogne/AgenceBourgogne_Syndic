using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Controller;
using GeranceData.Entites;

namespace Gerance.Formulaires.Proprietaires
{
    public partial class ProprietaireListeForm : Common.CommonListeForm
    {
        public ProprietaireListeForm()
        {
            InitializeComponent();
            regKey = "listes\\proprietaires";
        }
        protected override DataTable getFormListe()
        {

//            String cmd = String.Format("select id, reference, nom, prenom, adresse, codepostal, ville,  rib, banque from {0} order by {1}", ProprietairegetSchemaTable(), DefaultOrder);

            return ProprietaireController.getController().GetConfigList();
        }
        protected override void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
//            base.HideAndResizeColumns(cols);
            cols["id"].Visible = false;
            //cols["comptable_id"].Visible = false;
            //cols["statut"].Visible = false;
            //cols["pays"].Visible = false;
            cols["nom"].Width = 140;
            cols["prenom"].Width = 120;
            cols["adresse"].Width = 140;
            cols["ville"].Width = 80;
        }
        protected override void ShowFicheForm( string entite_id)
        {
            var form = new ProprietaireFicheForm(entite_id);
            ShowForm(form);
        }

        private void btnFiltre_Click(object sender, EventArgs e)
        {
            var form = new ProprietaireFindForm();
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                var proprio = ProprietaireController.getController().getEntiteFromField("reference", form.reference);
                var fiche = new ProprietaireFicheForm(proprio.id);
                fiche.ShowDialog();
            }
        }
        protected override void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var col = dgv.Columns[e.ColumnIndex];

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
