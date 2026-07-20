using System;
using System.Windows.Forms;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Utils;

namespace EspaceSyndic.Formulaires.Utilisateurs;

public partial class UtilisateurFicheForm : Form
{
    protected readonly string entite_id = "";
    protected bool bFromEnter;
    protected string currentReference;
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

    protected void InitializeCombos()
    {
        cbRole.DataSource = RolesController.getController().GetComboRoles();
        cbRole.ValueMember = "id";
        cbRole.DisplayMember = "nom";
    }

    protected bool saveValue()
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

    protected void setModified(bool bModified)
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

    protected void setFicheValues(AbstractBaseEntite entite)
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

    protected DialogResult saveForm(bool bShowMessage = false, bool bShowResult = true)
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

    protected void getNewEntite(string where, string message)
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

    protected AbstractBaseEntite getCurrentEntite(string entite_id)
    {
        return UsersController.getController().getEntiteById(entite_id);
    }

    protected AbstractBaseEntite getEntite(string where)
    {
        return UsersController.getController().getEntite(where);
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        getNewEntite("order by reference", "Début de liste atteint");
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        getNewEntite($"where reference < '{currentReference}' order by reference desc", "Début de liste atteint");
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        getNewEntite($"where reference > '{currentReference}' order by reference ", "Fin de liste atteinte");
    }

    protected void btnLast_Click(object sender, EventArgs e)
    {
        getNewEntite("order by reference desc", "Fin de liste atteinte");
    }

    protected void tbTextChanged(object sender, EventArgs e)
    {
        modified = true;
        if (!Text.EndsWith("*"))
            Text += " *";
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        bFromEnter = true;
        ControlsWindows.FocusNextTabbedControl(this);
        bFromEnter = false;
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