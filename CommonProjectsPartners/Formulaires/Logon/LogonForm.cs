using System;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Entites;

namespace CommonProjectsPartners.Formulaires.Logon;

public partial class LogonForm : Form
{
    private bool _bClose;
    private UserEntite _userConnected;

    public LogonForm()
    {
        InitializeComponent();
    }

    private void LogonForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!_bClose)
            if (!ValidUser())
                e.Cancel = true;
    }

    private bool ValidUser(bool bShowMessage = true)
    {
        _userConnected = UsersController.getController().getEntiteFromField("reference", tbUser.Text);
        if (_userConnected != null)
        {
            var encryptPassword = tbPassword.Text;
            if (_userConnected.Password == encryptPassword)
            {
                BaseApplication.userConnected = _userConnected;
                return true;
            }
        }

        if (bShowMessage)
            labelMessage.Text = "Utilisateur ou Mot de passe Invalide";
        return false;
    }

    private void IDOK_Click(object sender, EventArgs e)
    {
        if (tbUser.Focused)
        {
            if (!ValidUser(false))
                tbPassword.Focus();
            else
                Close();
        }
        else
        {
            Close();
        }
    }

    private void pictureBox1_Click(object sender, EventArgs e)
    {
        _bClose = true;
        Close();
    }

    private void LogonForm_Load(object sender, EventArgs e)
    {
        BaseApplication.userConnected = null;
        BringToFront();
        Activate();
    }

    private void tbUser_TextChanged(object sender, EventArgs e)
    {
        labelMessage.Text = "";
    }
}