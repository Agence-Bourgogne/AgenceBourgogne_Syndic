using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Controller;
using GeranceData.Entites;

namespace Gerance.Formulaires.Biens
{
    public partial class BienListeForm : Common.CommonListeForm
    {
        public BienListeForm()
        {
            InitializeComponent();
//            dataGridView
            //ckValidOnly.Visible = true;
            //ckValidOnly.CheckedChanged += ckValidOnly_CheckedChanged;
            regKey = "listes\\biens";
        }

        protected override DataTable getFormListe()
        {
           return BienController.getController().GetList();
        }
        protected override void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            //            base.HideAndResizeColumns(cols);
            cols["id"].Visible = false;
            cols["cons"].Visible = false;
            cols["locataire"].MinimumWidth = 140;
            cols["proprietaire"].MinimumWidth = 140;
            cols["nom_immeuble"].MinimumWidth = 140;
//            OrderColumns("biens");
        }
        protected override void ShowFicheForm(string entite_id)
        {
            BienFicheForm form = new BienFicheForm(entite_id);
            ShowForm(form);
        }

        private void btnFiltre_Click(object sender, EventArgs e)
        {
            BienFindForm form = new BienFindForm();
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                BienEntite bien = BienController.getController().getEntiteFromField("reference", form.reference);
                BienFicheForm fiche = new BienFicheForm(bien.id);
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
