using System;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Controller;

namespace Gerance.Formulaires.Utilisateurs
{
    public partial class UtilisateursListeForm : Gerance.Formulaires.Common.CommonListeForm
    {
        public UtilisateursListeForm()
        {
            InitializeComponent();
        }
        protected override DataTable getFormListe()
        {
            return UsersController.getController().getListeUsers();
        }
        protected override void HideAndResizeColumns(DataGridViewColumnCollection cols)
        {
            base.HideAndResizeColumns(cols);
            cols["statut"].Visible = false;
            cols["roles_id"].Visible = false;
            cols["password"].Visible = false;
            cols["resources_id"].Visible = false;
        }
        protected override void ShowFicheForm(string entite_id)
        {
            UtilisateurFicheForm form = new UtilisateurFicheForm(entite_id);
            ShowForm(form);
        }

        private void UtilisateursListeForm_Load(object sender, EventArgs e)
        {
            btnEdit.Visible = btnSave.Visible = false;
            btnExport.Location = btnNew.Location;
            btnNew.Location = btnEdit.Location;
            btnFiche.Location = btnSave.Location;
        }
    }
}
