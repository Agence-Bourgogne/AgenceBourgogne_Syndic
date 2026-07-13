using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Common;
using EspaceSyndic.Formulaires.Nature;
using EspaceSyndic.Formulaires.Fournisseur;

namespace EspaceSyndic.Formulaires.OperationsGestion
{
    public partial class DetailOperationForm : Form
    {
        protected string entite_id;
        protected NatureEntite nature = null;
        protected FournisseurEntite fournisseur = null;
        
        public DetailOperationForm()
        {
            InitializeComponent();
        }
        public DetailOperationForm(string facture_id)
        {
            InitializeComponent();
            this.entite_id = facture_id;
        }
        private void DetailOperationForm_Load(object sender, EventArgs e)
        {
            ShowDetail();
        }
        protected virtual void ShowDetail()
        {

        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void lblNature_Click(object sender, EventArgs e)
        {
            if (!tbNature.Enabled)
                return;
            FindNatureForm form = new FindNatureForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbNature.Text = form.reference;
                tbNature_Validating(null, null);
            }
        }
        private void lblFournisseur_Click(object sender, EventArgs e)
        {
            if (!tbFournisseur.Enabled)
                return;
            FindFournisseurForm form = new FindFournisseurForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbFournisseur.Text = form.reference;
                tbFournisseur_Validating(null, null);
            }
        }

        protected void setRowIndicators()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                int statut = (int)row.Cells["statut"].Value;
                Color color = Color.White;
                switch (statut)
                {
                    case 0: color = Color.Gray; break;
                    case 8: color = Color.LightGreen; break;
                    case 9: color = Color.Red; break;
                }
                row.DefaultCellStyle.BackColor = color;
            }
        }
        protected virtual void FillDataGridView()
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteEntite();
        }
        protected virtual void DeleteEntite()
        {
        }
        private void AnnulationFactureForm_Shown(object sender, EventArgs e)
        {
            //dataGridView.ClearSelection();
        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            ValidModification();
        }

        private void tbNature_Validating(object sender, CancelEventArgs e)
        {
            nature = NatureController.getController().getEntiteFromField("reference", tbNature.Text);
            if (nature != null)
            {
                tbNature.BackColor = Color.White;
                tbLibNature.Text = nature.nom;
            }
            else
            {
                tbNature.BackColor = tbNature.Text != "" ? Color.Red : Color.White;
                tbLibNature.Text = "";
            }
        }
        private void tbFournisseur_Validating(object sender, CancelEventArgs e)
        {
            fournisseur = FournisseurController.getController().getEntiteFromField("reference", tbFournisseur.Text);
            if (fournisseur != null)
            {
                tbFournisseur.BackColor = Color.White;
                tbNomFournisseur.Text = fournisseur.nom;
                tbAdresseFournisseur.Text = fournisseur.adresse;
                tbVilleFournisseur.Text = fournisseur.ville;
                tbCpFournisseur.Text = fournisseur.codepostal;
            }
            else
            {
                tbFournisseur.BackColor = tbFournisseur.Text != "" ? Color.Red : Color.White;
                tbNomFournisseur.Text = "";
                tbAdresseFournisseur.Text = "";
                tbVilleFournisseur.Text = "";
                tbCpFournisseur.Text = "";
            }

        }
        protected virtual void ValidModification()
        {

        }
        protected virtual void fillFormFromMaster()
        {
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            List<string> colsToHide = new List<string> { "id" };
            BaseApplication.DataGridToExcel(dataGridView, colsToHide);
        }

        protected virtual void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        protected virtual void dataGridView_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
