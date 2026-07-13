using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeranceData.Controller;
namespace Gerance.Formulaires.Fournisseurs
{
    public partial class FournisseurListeForm : Gerance.Formulaires.Common.CommonListeForm
    {
        public FournisseurListeForm()
        {
            InitializeComponent();
        }
        protected override DataTable getFormListe()
        {
            return FournisseurController.getController().GetList();
        }
        protected override void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            base.HideAndResizeColumns(cols);
            dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            cols["id"].Visible = false;
            cols["audit_created"].Visible = false;
            cols["audit_created_by"].Visible = false;
            cols["audit_updated"].Visible = false;
            cols["audit_updated_by"].Visible = false;
            cols["statut"].Visible = false;
        }
        protected override void ShowFicheForm(string entite_id)
        {
            FournisseurFicheForm form = new FournisseurFicheForm(entite_id);
            ShowForm(form);
        }
    }
}
