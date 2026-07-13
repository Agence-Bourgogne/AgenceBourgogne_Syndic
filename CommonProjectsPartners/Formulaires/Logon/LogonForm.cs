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
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Common;
namespace CommonProjectsPartners.Formulaires.Logon
{
    public partial class LogonForm : Form
    {
//        public string user = "";
        bool bClose = false;
        UserEntite userConnected;
        public LogonForm()
        {
            InitializeComponent();
        }

        private void LogonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bClose)
            {
                if (!ValidUser())
                    e.Cancel = true;
            }
        }
        private bool ValidUser(bool bShowMessage = true)
        {
            userConnected = UsersController.getController().getEntiteFromField("reference", tbUser.Text);
            if (userConnected != null)
            {
                string encryptPassword = tbPassword.Text;
                if (userConnected.Password == encryptPassword )
                {
                    BaseApplication.userConnected = userConnected;
                    return true;
                }
            }
            if ( bShowMessage)
                tbMessage.Text = "Utilisateur ou Mot de passe Invalide";
            return false;
        }

        private void IDOK_Click(object sender, EventArgs e)
        {
            if (tbUser.Focused)
            {
                if (!ValidUser(false))
                    tbPassword.Focus();
                else
                    this.Close();
            }
            else
                this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bClose = true;
            this.Close();
        }

        private void LogonForm_Load(object sender, EventArgs e)
        {
            btnCancel.Width = 0;
            BaseApplication.userConnected = null;
        }

        private void tbUser_TextChanged(object sender, EventArgs e)
        {
            tbMessage.Text = "";
        }
    }
}
