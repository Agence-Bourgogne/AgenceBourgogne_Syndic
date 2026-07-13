using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Controller;
using GeranceData.Entites;
using Npgsql;
using CommonProjectsPartners.Utils;

namespace Gerance.Impressions.ReglementsProprietaire
{
    public partial class UpdateHonoraireProprioForm : Form
    {
        DateTime dtPaiement, dtDebut, dtFin ;
        public UpdateHonoraireProprioForm()
        {
            InitializeComponent();
        }

        public UpdateHonoraireProprioForm(DateTime dtDebut, DateTime dtFin, DateTime dtPaiement)
        {
            InitializeComponent();
            this.dtPaiement = dtPaiement;
            this.dtDebut = dtDebut;
            this.dtFin = dtFin;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteHonoraires();
        }

        private void UpdateHonoraireProprioForm_Load(object sender, EventArgs e)
        {
            tbMessage.Text =
                $"Enregistrements Honoraire en date du {dtPaiement.ToShortDateString()} pour la période du {dtDebut.ToShortDateString()} au {dtFin.ToShortDateString()} ";
        }

        private bool writeEcriture(CompteProprioController controller, string libelle, DateTime dtPaiement, ProprietaireEntite proprio)
        {
            var compte = CompteProprioController.getController().getEcriture(proprio.id, dtPaiement);
            if ( compte == null)
                compte = new CompteProprioEntite();

            compte.date_ecriture = dtPaiement;
            compte.libelle = libelle;
            compte.proprietaire_id = proprio.id;
            compte.credit = proprio.credit;
            compte.debit = proprio.debit;
            compte.statut = 1;
            return controller.doInsertOrUpdate(compte);
        }
        const int REFERENCE_TACHE = 6;
        private void WriteHonoraires()
        {
            var virements = ProprietaireController.getController().getListePaiementsLoyers(1, dtDebut, dtFin);
            var loyers = ProprietaireController.getController().getListePaiementsLoyers(0, dtDebut, dtFin);
            var controller = CompteProprioController.getController();
            var ctlProprio = ProprietaireController.getController();
            var dtServer = controller.setTimestampServer();
            var dtWorkflow = dtPaiement; //new DateTime(dtPaiement.Year, dtPaiement.Month, 1);
            ctlProprio.setTimestampServer(dtServer);
            WorkflowController.getController().setTimestampServer(dtServer);
            WorkflowDetailController.getController().setTimestampServer(dtServer);

            var trx = Database.BeginTransaction();
            tbMessage.TextAlign = HorizontalAlignment.Left;
            
            try
            {
                var workflow = WorkflowController.getController().WriteRecord(REFERENCE_TACHE, dtWorkflow);
                foreach (DataRow row in virements.Rows)
                {
                    var libelle = "Somme Payée par virement le " + dtPaiement.ToShortDateString();
                    var proprio = ctlProprio.getEntiteById(row["id"].ToString());

                    Console.WriteLine("{0} {1} ", proprio.id, proprio.credit);

                    tbMessage.Text += $"\r\n*** {proprio.NomPrenom} ";
                    tbMessage.Text += $"\r\n {libelle} {proprio.credit} ";
                    tbMessage.Update();
                    if (!writeEcriture(controller, libelle, dtPaiement, proprio))
                        throw new Exception("Virement erreur " + row["reference"].ToString());
                    proprio.libelle = libelle;
                    if (!ctlProprio.doInsertOrUpdate(proprio))
                        throw new Exception("Virement Erreur " + proprio.NomPrenom);
                    WorkflowDetailController.getController().WriteRecord(workflow, proprio.id, proprio.reference);
                }
                tbMessage.Text += "\r\n";
                foreach (DataRow row in loyers.Rows)
                {
                    var libelle = "Règlement du " + dtPaiement.ToShortDateString();
                    var proprio = ctlProprio.getEntiteById(row["id"].ToString());
                    tbMessage.Text += $"\r\n*** {proprio.NomPrenom} ";
                    tbMessage.Text += $"\r\n {libelle} {proprio.credit} ";
                    tbMessage.Update();
                    if (!writeEcriture(controller, libelle, dtPaiement, proprio))
                        throw new Exception("Règlement erreur " + row["reference"].ToString());
                    proprio.libelle = libelle;
                    if (!ctlProprio.doInsertOrUpdate(proprio))
                        throw new Exception("Règlement Erreur " + proprio.NomPrenom);
                    WorkflowDetailController.getController().WriteRecord(workflow, proprio.id, proprio.reference);
                }

                trx.Commit();
                WorkflowController.FireWorkflowChanged();
                tbMessage.BackColor = Color.LightGreen;
//                MessageBox.Show("Mise à jour terminée");
            }
            catch (Exception ex)
            {
                trx.Rollback();
                tbMessage.BackColor = Color.Red;
                MessageBox.Show(ex.Message);
            }
        }
    }
}
