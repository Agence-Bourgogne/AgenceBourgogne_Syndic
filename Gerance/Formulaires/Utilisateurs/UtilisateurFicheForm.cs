using System;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Controller;
namespace Gerance.Formulaires.Utilisateurs
{
    public partial class UtilisateurFicheForm : Common.BaseFicheForm
    {
        UserEntite user;

        public UtilisateurFicheForm()
        {
            InitializeComponent();
        }
        public UtilisateurFicheForm(string entite_id)
        {
            InitializeComponent();
            this.entite_id = entite_id;
        }
        private void tbReference_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.KeyCode == Keys.Space)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    lblReference_Click(null, null);
                }

        }
        protected override void InitializeCombos()
        {
            cbRole.DataSource = RolesController.getController().GetComboRoles();
            cbRole.ValueMember = "id";
            cbRole.DisplayMember = "nom";
            
        }
        private void lblReference_Click(object sender, EventArgs e)
        {

        }

        protected override bool saveValue()
        {
//            bool rc = true;

            currentReference = tbReference.Text;
            user.reference = tbReference.Text;
            user.Password = tbPassword.Text;
            user.nom = tbNom.Text;
            user.prenom = tbPrenom.Text;
            user.roles_id = cbRole.SelectedValue.ToString();

            return UsersController.getController().InsertOrUpdate(user);
        }

        protected override void setFicheValues(AbstractBaseEntite entite)
        {
            if (entite != null)
                user = (UserEntite) entite;
            else
                user = new UserEntite();

            currentReference = user.reference;

            tbReference.Text = user.reference;
            tbNom.Text = user.nom;
            tbPrenom.Text = user.prenom;
            tbPassword.Text = user.Password;
            if (user.roles_id != null )
                cbRole.SelectedValue = user.roles_id;
            base.setFicheValues(entite);
        }
        protected override AbstractBaseEntite getCurrentEntite(string entite_id)
        {
            return UsersController.getController().getEntiteById(entite_id);
        }
        protected override AbstractBaseEntite getEntite(string where)
        {
            return UsersController.getController().getEntite(where);
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            setModified(true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = ckPassword.Checked;
        }
    }
}
