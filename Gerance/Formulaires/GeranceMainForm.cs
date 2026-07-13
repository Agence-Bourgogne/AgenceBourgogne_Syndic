using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using CommonProjectsPartners.Formulaires.Config;
using Gerance.Formulaires.Config;
using CommonProjectsPartners.Common;
using GeranceData.Common;
using CommonProjectsPartners.Formulaires.Logon;
using Gerance.Formulaires.Syndic;

namespace Gerance.Formulaires
{
    public partial class GeranceMainForm : Form
    {
        private Dictionary<String, Form> dicoForms = new Dictionary<String, Form>();
        public static CommonChangedEvent syndicEvent = new CommonChangedEvent();
        public GeranceMainForm()
        {
            InitializeComponent();
        }

        private void GeranceMainForm_Load(object sender, EventArgs e)
        {
            Text = Text + " 1.0.0.47";
            btnCancel.Width = 0;
            var lbl1 = ParametresDB.getParam1("PRESENTATION", "LABEL1", "AGENCE");
            var lbl2 = ParametresDB.getParam1("PRESENTATION", "LABEL2", "BOURGOGNE");

            label2.Text = lbl1;
            label3.Text = lbl2;

//            aideStripMenuItem1.Visible = false;

//            listeDesQuittancesDuMoisPrecedentToolStripMenuItem.Visible = false;
            Connection();

//            SyndicDatabase.StartLoadSyndicCopro();

            paramètresDeConnexionSyndicToolStripMenuItem.Visible = false;
            reglementsProprietairesSyndicToolStripMenuItem.Visible = false;
            fichiersToolStripMenuItem1.Visible = false;
//            Console.WriteLine("Apres start");
        }

        private void GenericForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var form = (Form)sender;
            var className = sender.GetType().ToString();
            if (dicoForms.ContainsKey(className))
            {
                dicoForms.Remove(className);
                if (form is ICommonChangedListener)
                {
                    var f = (ICommonChangedListener)form;
                    syndicEvent.Changed -= f.ChangedReference;
                }
            }
            Activate();
        }
        private void GenericBtnCancel_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;

            if (btn.Parent != null)
            {
                var parent = (Control)btn.Parent;
                while (parent != null)
                {
                    parent = parent.Parent;
                    if (parent != null)
                        if (parent is Form)
                            ((Form)parent).Close();
                }
            }
        }
        public void ShowForm(string className)
        {
            try
            {
                Form form = null;
                if (!dicoForms.ContainsKey(className))
                {
                    var obj = Activator.CreateInstance("Gerance", className);
                    form = (Form)obj.Unwrap();
                    dicoForms.Add(className, form);
                    form.FormClosed += new FormClosedEventHandler(GenericForm_FormClosed);
                    if (form is ICommonChangedListener)
                    {
                        var f = (ICommonChangedListener)form;
                        syndicEvent.Changed += new CommonChangedEventHandler(f.ChangedReference);
                    }
                }
                else
                    form = dicoForms[className];

                if (form.WindowState == FormWindowState.Minimized)
                    form.WindowState = FormWindowState.Normal;

                form.StartPosition = FormStartPosition.CenterScreen;
                form.ControlBox = true;
                form.ShowInTaskbar = true;
                form.Icon = Icon;
                form.ShowIcon = true;
                if (form.CancelButton != null)
                {
                    var btn = (Button)form.CancelButton;
                    btn.Click += new EventHandler(GenericBtnCancel_Click); ;
                }
                form.Show();
                form.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void proprietairesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Proprietaires.ProprietaireListeForm");
        }

        private void parametresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DatabaseConfigForm(GeranceApplication.CURRENT_APPLICATION);
            try
            {
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void paramètresDeConnexionSyndicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new DatabaseSyndicConfigForm(GeranceApplication.SYNDIC_APPLICATION);
            try
            {
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void naturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Natures.NatureListeForm");
        }

        private void locatairesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Locataires.LocataireListeForm");
        }

        private void comptablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Comptables.ComptableListeForm");
        }

        private void parametresGenerauxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ConfigParamForm();
            try
            {
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void biensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Biens.BienListeForm");
        }

        private void listeDesQuittancesDuMoisPrecedentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.AppelALoyer.ListeQuittanceForm");
        }

        private void appelALoyerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.AppelALoyer.AppelALoyerListeForm");
        }

        private void indicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Indices.IndicesForm");
        }

        private void saisieDesRéglementsLocatairesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Reglements.ReglementLocataireForm");
        }

        private void enregistrementDesFacturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Factures.FactureForm");
        }

        private void fournisseursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Fournisseurs.FournisseurListeForm");
        }

        private void editionDunComptePropriétaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Proprietaires.ComptesProprietairesForm");
        }

        private void calculDesHonorairesCopropriétairesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Proprietaires.ReleveHonorairesProrietairesForm");
        }

        private void régularisationDesChargesPourLesLocatairesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Locataires.ChargesLocataireForm");
        }

        private void quittanceDentréeDunLocataireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Locataires.EntreeLocataireFicheForm");
        }

        private void editionsDesLoyersPourUnePériodeDonnéeDBEtTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Impressions.Loyers.ListeLoyerForm");
        }

        private void editionDesLoyersPourUnePériodeDonnéeImpotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Impressions.EtatsFiscaux.ListeLoyerProprietaireForm");
        }

        private void etatDesRetardsDePaiementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Impressions.Retards.RetardPaiementForm");
        }

        private void editionDunCompteLocataireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Impressions.CompteLocataire.CompteLocataireForm");
        }

        private void editionDunComptePropriétaireToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Impressions.CompteProprietaire.ImpressionCompteProprietaireForm");
        }

        private void impressionRéglementsPropriétairesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Impressions.ReglementsProprietaire.ImpressionsReglementsProprietaireForm");
        }

        private void documentsLocatairesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Documents.DocumentsListeForm");
        }

        private void annulationDuneQuittanceParticulièreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.AppelALoyer.AnnulationQuittanceForm");
        }

        private void deconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connection();
        }
        private void Connection()
        {
            try
            {
                foreach (var item in dicoForms)
                {
                    item.Value.Hide();
                }
                Hide();
                var logonForm = new LogonForm();
                logonForm.ShowDialog();
                if ( BaseApplication.userConnected != null)
                    Show();
                else
                    Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void utilisateursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Utilisateurs.UtilisateursListeForm");

        }

        private void GeranceMainForm_Activated(object sender, EventArgs e)
        {
            foreach (var item in dicoForms)
            {
                item.Value.Show();
            }
        }

        private void tachesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Taches.SuiviTacheMensuelleForm");
        }

        private void reglementsProprietairesSyndicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Reglements.RéglementProprietairesSyndicForm");
        }

        private void règlementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Reglements.ReglementsListeForm");
        }

        private void fichiersToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void listeReglementsLocatairesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Reglements.ReglementsListeForm");
        }

        private void listeFacturesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Factures.FacturesListeForm");
        }

        private void aideStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new AideForm();
            form.ShowDialog();
        }

        private void rechercheMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowForm("Gerance.Formulaires.Common.RechercheMultiForm");
        }

    }
}
