using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Controller;
using GeranceData.Entites;
using GeranceData.Common;
using CommonProjectsPartners.Utils;
using Gerance.Formulaires.Common;
using Gerance.Formulaires.Locataires;
namespace Gerance.Formulaires.AppelALoyer
{
    public partial class UpdateDossierForm : Form
    {
        public UpdateDossierForm()
        {
            InitializeComponent();
        }
        private void InitializeCombos()
        {

            var dt = new DateTime(DateTime.Now.Year, DateTime.Now.AddMonths(1).Month, 1);
            dateDebut.Value = dt;

            cbType.Items.Add("Mensuel");
            cbType.Items.Add("Mensuel et Trimestriel");
            cbType.SelectedIndex = 0;
        }

        private void UpdateDossierForm_Load(object sender, EventArgs e)
        {
            InitializeCombos();
            btnEnter.Width = 0;
        }

        const int REFERENCE_TACHE = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            var tb_biens = BienController.getController().GetTableList();
            var biens = new BindingSource();
            biens.DataSource = tb_biens;
            if (tbRefLocataire.Text != "")
            {
                var locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
                if (locataire == null)
                {
                    MessageBox.Show("Référence locataire Invalide");
                    return;
                }
                    
                biens.Filter = $"locataire_id = '{locataire.id}'";
            }            
            
            // TODO à Paramétrer
            decimal taux_tva = 20, taux_bail = (decimal) 0;

            var type_maj = cbType.SelectedIndex;

            var dtServer = QuittancesController.getController().setTimestampServer();
            BienController.getController().setTimestampServer(dtServer);
            LocataireController.getController().setTimestampServer(dtServer);
            WorkflowController.getController().setTimestampServer(dtServer);
            WorkflowDetailController.getController().setTimestampServer(dtServer);

            var trx = Database.BeginTransaction();
            try
            {
                tbMessage.BackColor = Color.White;
                var dtQuittance = new DateTime(dateDebut.Value.Year, dateDebut.Value.Month, 1);
                var workflow = WorkflowController.getController().WriteRecord(REFERENCE_TACHE, dtQuittance);

                foreach (DataRowView rowView in biens.List)
                {
                    var row = rowView.Row;
                    var bien = new BienEntite(row);
                    if (bien != null)
                        if (bien.Locataire != null)
                            if (bien.MontantDu > 0)
                                if  (type_maj == 1 || (type_maj == 0 && bien.periodicite_loyer == 12) ) 
                                {
                                    var msg =
                                        $"Mise à jour dossier de {bien.Locataire.reference} : {bien.Locataire.NomPrenom}\r\n\t\tImmeuble {bien.reference} : {bien.nom}\r\n\r\n";
                                    var quittance = QuittancesController.getController().GetQuittance(bien.Locataire, dtQuittance);
                                    if ( quittance.statut == (int) GlobalConstantes.StatutQuittance.Genere)
                                    {
                                        var oldMontant = quittance.montant_quittance;
                                        tbMessage.Text += msg;
                                        tbMessage.Update();

                                        var newTaxe = Math.Round((bien.montant_loyer + bien.montant_augmentation) * ((bien.taxe == 1) ? taux_tva : taux_bail) / 100, 2);
                                        bien.valeur_taxe = newTaxe;
                                        bien.montant_du = bien.MontantDu;
                                        bien.date_quittance = dtQuittance;
                                        bien.frais_bail = bien.honoraires_locataire = 0;
                                        if (!BienController.getController().doInsertOrUpdate(bien))
                                            throw new Exception("Update Bien");

                                        quittance.setValuesFromBien(bien, dtQuittance);
                                        if (!QuittancesController.getController().doInsertOrUpdate(quittance))
                                            throw new Exception("Update Quittance");

                                        var totalDu = Math.Round(bien.MontantDu + bien.Locataire.total_du - oldMontant, 2);
                                        bien.Locataire.total_du = totalDu;

                                        if (!LocataireController.getController().doInsertOrUpdate(bien.Locataire))
                                            throw new Exception("Update Solde locataire " + bien.Locataire.reference);

                                        WorkflowDetailController.getController().WriteRecord(workflow, bien.locataire_id, bien.Locataire.reference);
                                    }
                                }
                }
                tbMessage.BackColor = Color.LightGreen;
                WorkflowController.FireWorkflowChanged();
//                bUpdated = true;
                trx.Commit();
            }
            catch (Exception ex)
            {
                tbMessage.BackColor = Color.Red;
                MessageBox.Show(ex.Message);
                trx.Rollback();
            }
        }

        private void lblLocataire_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new LocataireFindForm(), tbRefLocataire) == DialogResult.OK)
            {
                tbRefLocataire_Validating(null, null);
            }
        }

        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            tbRefLocataire.BackColor = Color.White;
            if (tbRefLocataire.Text != "")
            {
                var locataire = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
                if (locataire != null)
                {
                    tbNomLocataire.Text = locataire.NomPrenom;
                }
                else
                    tbRefLocataire.BackColor = Color.Red;
            }

        }
        protected virtual DialogResult ShowFindForm(CommonFindForm form, Control tbResult)
        {
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
                tbResult.Text = form.reference;
            return res;
        }
        protected bool bFromEnter;
        private void btnEnter_Click(object sender, EventArgs e)
        {
            bFromEnter = true;
            ControlsWindows.FocusNextTabbedControl(this);
            bFromEnter = false;
        }
        private void tbRefLocataire_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control == true)
                if (e.KeyCode == Keys.Space)
                {
                    e.Handled = true;
                    if (sender == tbRefLocataire)
                        lblLocataire_Click(sender, null);
                }
        }

    }
}
