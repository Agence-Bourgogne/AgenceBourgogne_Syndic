using System;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Fournisseur;

public partial class FicheFournisseurForm : Form
{
    private readonly FournisseurController _controller = new();
    public FournisseurEntite Entite;
    private bool _modified;

    public FicheFournisseurForm(bool bShowNav = true)
    {
        InitializeComponent();
        btnFirst.Visible = btnLast.Visible = btnNext.Visible = btnPrev.Visible = bShowNav;
    }

    private void FicheFournisseurForm_Load(object sender, EventArgs e)
    {
        ParametresDB.FillComboFromParams(cbReglement, "FACTURE_REGLEMENT");
        SetFicheValues(null);
    }

    private void SetFicheValues(FournisseurEntite newEntite)
    {
        if (newEntite != null)
            Entite = newEntite;

        tbRef.Text = Entite.reference;
        tbNom.Text = Entite.nom;
        tbInterlocuteur.Text = Entite.interlocuteur;
        tbTel.Text = Entite.telephone;
        tbAdresse.Text = Entite.adresse;
        tbCodePostal.Text = Entite.codepostal;
        tbVille.Text = Entite.ville;
        cbReglement.SelectedValue = Entite.reglement;
        tbComment.Text = Entite.commentaire;
        tbSiret.Text = Entite.siret;
        tbSecu.Text = Entite.numsecu;
        tbApe.Text = Entite.codeape;
        tbUrsaff.Text = Entite.numurs;
        ckDesactiv.Checked = Entite.statut == (int)AbstractBaseEntite.StatutEntite.Supprime;

        _modified = false;
    }

    private void GetNewEntite(string where, string message)
    {
        if (_modified)
            if (!SaveForm(true))
                return;

        try
        {
            var newEntite = _controller.getEntite(where);
            if (newEntite != null)
                SetFicheValues(newEntite);
        }
        catch (Exception)
        {
            MessageBox.Show(message);
        }
    }

    private void btnQuit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        SaveForm();
    }

    private bool SaveForm(bool bShowMessage = false, bool bShowResult = true)
    {
        if (bShowMessage)
        {
            var result = MessageBox.Show("Des modifications on été apportéees\nVoulez-vous les enregistrer",
                "", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Cancel)
                return false;
            if (result == DialogResult.No) return true;
        }


        Entite.reference = tbRef.Text;
        if (Entite.reference == "")
        {
            MessageBox.Show(@"Référence invalide");
            return false;
        }

        Entite.nom = tbNom.Text;
        Entite.interlocuteur = tbInterlocuteur.Text;
        Entite.telephone = tbTel.Text;
        Entite.adresse = tbAdresse.Text;
        Entite.ville = tbVille.Text;
        Entite.codepostal = tbCodePostal.Text;
        Entite.reglement = Convert.ToInt32(cbReglement.SelectedValue);
//            entite.codereg = tbCodeRegion.Text.Equals("") ? 0 : Convert.ToInt32(tbCodeRegion.Text);
        Entite.commentaire = tbComment.Text;
        Entite.siret = tbSiret.Text;
        Entite.numsecu = tbSecu.Text;
        Entite.codeape = tbApe.Text;
        Entite.numurs = tbUrsaff.Text;
        Entite.statut = ckDesactiv.Checked
            ? (int)AbstractBaseEntite.StatutEntite.Supprime
            : (int)AbstractBaseEntite.StatutEntite.Actif;
        if (_controller.InsertOrUpdate(Entite))
        {
            if (bShowResult)
                MessageBox.Show(@"Modifications entregistrées");
            _modified = false;
            return true;
        }

        return false;
    }

    private void btnFirst_Click(object sender, EventArgs e)
    {
        GetNewEntite("order by reference::integer", "Début de liste atteint");
    }

    private void btnPrev_Click(object sender, EventArgs e)
    {
        GetNewEntite($"where reference::integer < {Entite.reference} order by reference::integer desc",
            "Début de liste atteint");
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
        GetNewEntite($"where reference::integer > {Entite.reference} order by reference::integer ",
            "Fin de liste atteinte");
    }

    private void btnLast_Click(object sender, EventArgs e)
    {
        GetNewEntite("order by reference::integer desc", "Fin de liste atteinte");
    }

    private void FicheFournisseurForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (_modified)
            if (!SaveForm(true))
                e.Cancel = true;
    }

    private void TbTextChanged(object sender, EventArgs e)
    {
        _modified = true;
    }

    private void lblRef_Click(object sender, EventArgs e)
    {
        var form = new FindFournisseurForm(tbRef);
        if (DialogResult.Cancel != form.ShowDialog())
        {
            Entite = _controller.getEntiteFromField("reference", tbRef.Text);
            SetFicheValues(Entite);
        }
    }
}