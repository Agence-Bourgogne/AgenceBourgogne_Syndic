using System;
using System.Windows.Forms;
using EspaceSyndic.UtilsApp;
using CommonProjectsPartners.Utils;

namespace EspaceSyndic.Formulaires.Utilisateurs
{
    public partial class NewUserWebForm : Form
    {
        ServiceReference.UserEntitie usr = null;
        //-----
        public NewUserWebForm()
        {
            InitializeComponent();
        }
        //------
        public NewUserWebForm(ServiceReference.UserEntitie usr, string title = "")
        {
            InitializeComponent();
            this.usr = usr;
            if (!string.IsNullOrEmpty(title))
                Text = title;
            tbCode.Text = usr.Code;
            tbPassword.Text = usr.Password;
        }
        //------
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!RegexUtils.IsValidEmail(tbCode.Text))
                MessageBox.Show("Format Email Invalide");
            else
            {
                if (usr != null)
                {
                    var msg = ServiceReferenceUtils.UpdateUser(usr.Guid, tbCode.Text, tbPassword.Text);
                    if(msg == "0")
                    {
                        if (ckSendMail.Checked)
                        {
                            MailUtils.SendEMail(tbCode.Text, tbPassword.Text);
                            // SendEMail(tbCode.Text, tbPassword.Text);
                        }
                        MessageBox.Show(this, "Utilisateur modifié avec succès");
                    }
                    else
                    {
                        MessageBox.Show(this, msg);
                    }
                }
                //else
                //    MessageBox.Show(ServiceReferenceUtils.CreateUser(tbCode.Text, tbPassword.Text));
                DialogResult = DialogResult.OK;
            }
        }
        //------
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            tbPassword.Text = CryptoUtils.CreatePassword(8);
        }
        //------
        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    FindUser searchUserForm = new FindUser();
        //    if (searchUserForm.ShowDialog() == DialogResult.OK)
        //    {
        //        tbCode.Text = searchUserForm.email;
        //    }
        //}
    }
}
