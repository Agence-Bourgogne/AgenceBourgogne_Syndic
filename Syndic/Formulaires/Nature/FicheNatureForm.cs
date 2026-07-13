using System;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Nature;

public partial class FicheNatureForm : Form
{
    public NatureEntite entite;
    public readonly NatureController controller = new();
    private bool modified;
        
    public FicheNatureForm(bool bShowNav = true)
    {
        InitializeComponent();
        btnFirst.Visible = btnLast.Visible = btnNext.Visible = btnPrev.Visible = bShowNav;
        tbNomCompta.Visible = false;
        lblNomCompta.Visible = false;
    }
    private void FicheNatureForm_Load(object sender, EventArgs e)
    {
        btnEnter.Width = 0;
        ParametresDB.FillComboFromParams(cbTypeCharge,"TYPECHARGE", "Nom");
        setFicheValues(null);
    }
    private void setFicheValues(NatureEntite newEntite)
    {
        if (newEntite != null)
            entite = newEntite;

        tbRef.Text = entite.reference;
        tbNom.Text = entite.nom;
        tbPart.Text = entite.charge_locative.ToString();
        tbDeclaration.Text = entite.declaration;
        tbRefComptable.Text = entite.reference_comptabilite;
        cbTypeCharge.SelectedValue = entite.type_charge;
        ckBudget.Checked = entite.budgetisable;
        ckDesactiv.Checked = entite.statut == (int) AbstractBaseEntite.StatutEntite.Supprime;
//            tbNomCompta.Text = entite.nom_comptabilite;
        modified = false;
    }


    private void btnQuit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        saveForm();
    }
    private bool saveForm(bool bShowMessage = false, bool bShowResult = true)
    {
        if (bShowMessage)
        {
            var result = MessageBox.Show("Des modifications on été apportéees\nVoulez-vous les enregistrer",
                "", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Cancel)
                return false;
            if (result == DialogResult.No)
            {
                return true;
            }
        }

        entite.reference = tbRef.Text;
        entite.nom = tbNom.Text;
        entite.charge_locative = tbPart.Text.Equals("") ? 0 : Convert.ToInt32(tbPart.Text);
        entite.declaration = tbDeclaration.Text;
        entite.reference_comptabilite = tbRefComptable.Text;
        entite.type_charge = (int) cbTypeCharge.SelectedValue;
        entite.budgetisable = ckBudget.Checked;
        entite.statut = ckDesactiv.Checked ? (int) AbstractBaseEntite.StatutEntite.Supprime : (int) AbstractBaseEntite.StatutEntite.Actif;
//            entite.nom_comptabilite = tbNomCompta.Text;

        if (controller.InsertOrUpdate(entite))
        {
            if (bShowResult)
                MessageBox.Show(@"Modifications entregistrées");
            modified = false;
            return true;
        }
        return false;
    }
    private void getNewEntite(string where, string message)
    {
        if (modified)
            if (!saveForm(true, false))
                return;

        try
        {
            var newEntite = controller.getEntite(where);
            if (newEntite != null)
                setFicheValues(newEntite);
        }
        catch (Exception)
        {
            MessageBox.Show(message);
        }
    }

    protected void btnFirst_Click(object sender, EventArgs e)
    {
        getNewEntite("order by reference", "Début de liste atteint");
    }

    protected void btnPrev_Click(object sender, EventArgs e)
    {
        getNewEntite($"where reference < '{entite.reference}' order by reference desc", "Début de liste atteint");
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        getNewEntite($"where reference > '{entite.reference}' order by reference ", "Fin de liste atteinte");
    }
    protected void btnLast_Click(object sender, EventArgs e)
    {
        getNewEntite("order by reference desc", "Fin de liste atteinte");
    }

    private void FicheNatureForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (modified)
            if (!saveForm(true))
                e.Cancel = true;
    }
    private void tbTextChanged(object sender, EventArgs e)
    {
        modified = true;
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        //            btnEnter.Width = 0;
        ControlsWindows.FocusNextTabbedControl(this);
    }

    private void cbTypeCharge_SelectedIndexChanged(object sender, EventArgs e)
    {
        modified = true;
    }

    private void ckBudget_CheckedChanged(object sender, EventArgs e)
    {
        modified = true;
    }

    private void lblReference_Click(object sender, EventArgs e)
    {
        var form = new FindNatureForm(tbRef);
        if (DialogResult.Cancel != form.ShowDialog())
        {
            entite = controller.getEntiteFromField("reference", tbRef.Text);
            setFicheValues(entite);
        }
    }

}