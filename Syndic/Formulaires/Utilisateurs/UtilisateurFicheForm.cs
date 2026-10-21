using System;
using System.Windows.Forms;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Utils;

namespace EspaceSyndic.Formulaires.Utilisateurs;

public partial class UtilisateurFicheForm : Form
{
    private readonly string entite_id = "";
    private string currentReference;
    private bool modified;
    private UserEntite user;

    public UtilisateurFicheForm()
    {
        InitializeComponent();
    }

    public UtilisateurFicheForm(string entite_id)
    {
        InitializeComponent();
        this.entite_id = entite_id;
    }

    private void InitializeCombos()
    {
        cbRole.DataSource = RolesController.getController().GetComboRoles();
        cbRole.ValueMember = "id";
        cbRole.DisplayMember = "nom";
    }

    private bool saveValue()
    {
        currentReference = tbReference.Text;
        user.reference = tbReference.Text;
        user.Password = tbPassword.Text;
        user.nom = tbNom.Text;
        user.prenom = tbPrenom.Text;
        user.roles_id = cbRole.SelectedValue.ToString();

        return UsersController.getController().InsertOrUpdate(user);
    }

    private void setModified(bool bModified)
    {
        modified = bModified;
        if (!modified)
        {
            if (Text.EndsWith("*"))
                Text = Text.Replace(" *", "");
        }
        else
        {
            if (!Text.EndsWith("*"))
                Text += " *";
        }
    }

    private void setFicheValues(AbstractBaseEntite entite)
    {
        if (entite != null)
            user = (UserEntite)entite;
        else
            user = new UserEntite();

        currentReference = user.reference;

        tbReference.Text = user.reference;
        tbNom.Text = user.nom;
        tbPrenom.Text = user.prenom;
        tbPassword.Text = user.Password;
        if (user.roles_id != null)
            cbRole.SelectedValue = user.roles_id;
        setModified(false);
    }

    private DialogResult saveForm(bool bShowMessage = false, bool bShowResult = true)
    {
        if (!modified)
            return DialogResult.OK;
        if (bShowMessage)
        {
            var result = MessageBox.Show("Des modifications on été apportéees\nVoulez-vous les enregistrer",
                "", MessageBoxButtons.YesNoCancel);
            if (result is DialogResult.Cancel or DialogResult.No)
                return result;
        }

        var rc = saveValue();
        if (rc && !bShowResult)
        {
            modified = false;
            return DialogResult.OK;
        }

        if (rc && bShowResult)
        {
            MessageBox.Show(@"Modification enregistrées");
            modified = false;
            return DialogResult.OK;
        }

        return DialogResult.Cancel;
    }

    private void getNewEntite(string where, string message)
    {
        if (saveForm(true, false) == DialogResult.Cancel)
            return;

        try
        {
            var entite = getEntite(where);
            if (entite != null)
                setFicheValues(entite);
        }
        catch (Exception)
        {
            MessageBox.Show(message);
        }
    }

    private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        setModified(true);
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
        tbPassword.UseSystemPasswordChar = ckPassword.Checked;
    }

    private AbstractBaseEntite getCurrentEntite(string entite_id)
    {
        return UsersController.getController().getEntiteById(entite_id);
    }

    private AbstractBaseEntite getEntite(string where)
    {
        return UsersController.getController().getEntite(where);
    }

    private void btnFirst_Click(object sender, EventArgs e)
    {
        getNewEntite("order by reference", "Début de liste atteint");
    }

    private void btnPrev_Click(object sender, EventArgs e)
    {
        getNewEntite($"where reference < '{currentReference}' order by reference desc", "Début de liste atteint");
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        getNewEntite($"where reference > '{currentReference}' order by reference ", "Fin de liste atteinte");
    }

    private void btnLast_Click(object sender, EventArgs e)
    {
        getNewEntite("order by reference desc", "Fin de liste atteinte");
    }

    private void TbTextChanged(object sender, EventArgs e)
    {
        modified = true;
        if (!Text.EndsWith("*"))
            Text += " *";
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
    }

    private void BaseFicheForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (saveForm(true, false) == DialogResult.Cancel)
            e.Cancel = true;
    }

    private void UtilisateurFicheForm_Load(object sender, EventArgs e)
    {
        btnEnter.Width = 0;
        InitializeCombos();
        setFicheValues(getCurrentEntite(entite_id));
    }
}