using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Controller;
using GeranceData.Entites;
using Npgsql;
using CommonProjectsPartners.Utils;
namespace Gerance.Formulaires.Proprietaires
{
    public partial class CreationFactureHonorairesFraisForm : Form
    {
        public CreationFactureHonorairesFraisForm()
        {
            InitializeComponent();
        }

        DateTime dtDebut, dtFin;
        string proprietaire_id;
        public CreationFactureHonorairesFraisForm(DateTime dtDebut, DateTime dtFin, string proprietaire_id)
        {
            InitializeComponent();
            this.dtDebut = dtDebut;
            this.dtFin = dtFin;
            this.proprietaire_id = proprietaire_id;
        }

        private void CreationFactureHonorairesFrais_Load(object sender, EventArgs e)
        {
            tbMessage.Text =
                $"Vous allez générer les factures\r\nd'Honoraires et de Frais\r\nPour la période du {dtDebut.ToShortDateString()} au {dtFin.ToShortDateString()}";
            tbMessage.Select(tbMessage.Text.Length+1, -1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ValidationFacture();
        }
        private void createFactureFromReglement(ReglementEntite reglement, WorkflowEntite workflow, string nature_id, string libelle, decimal montant)
        {
            montant = Math.Round(montant, 2);
// Mantis 000224
//            if (montant > 0)
            if (montant != 0)
            {
                var facture = FacturesController.getController().getFactureHonoraire(reglement, nature_id, libelle, montant);
                var msg = $"\r\n{libelle} : {montant} €";

                if (facture != null)
                {
                    if (facture.id != "")
                        msg += " déja facturée ( Mise à jour) ";
                    if (!FacturesController.getController().InsertOrUpdate(facture))
                        throw new Exception("Factures");
                    WorkflowDetailController.getController().WriteRecord(workflow, facture.id, facture.Proprietaire.reference);
                }
                tbMessage.Text += msg;
                tbMessage.Update();
            }

        }
        const int REFERENCE_TACHE = 1;
        private bool ValidationFacture()
        {
            var rc = false;

            var libelleHono = "Honoraires Agence";
            var libelleTvaHono = "TVA sur Honoraires";
            var libelleFraisBail = "Frais Administratifs";
            var libelleEtatLieux = "Etats des Lieux";

            // TODO Paramétrer Taux TVA
            var tauxTva = (decimal)0.2;

            //TODO Paramétrer Natures
            var natureHono = NatureController.getController().getEntiteFromField("reference", "020");
            var natureBail = NatureController.getController().getEntiteFromField("reference", "011");
            var natureNlle = NatureController.getController().getEntiteFromField("reference", "010");

            // TODO Quid de plusieurs réglements locataire sur la période 
            var reglements = ReglementsController.getController().getReleveHonorairesProprietairesForFacture(dtDebut, dtFin, proprietaire_id);
            
            var cnx = Database.GetInstance();
            var trx = cnx.BeginTransaction();
            var dtWorkflow = new DateTime(dtDebut.Year, dtDebut.Month, 1);
            var dtServer = FacturesController.getController().setTimestampServer();
            WorkflowController.getController().setTimestampServer(dtServer);
            WorkflowDetailController.getController().setTimestampServer(FacturesController.getController().getTimestampServer());
            try
            {
                var workflow = WorkflowController.getController().WriteRecord(REFERENCE_TACHE, dtWorkflow);

                foreach (DataRow row in reglements.Rows)
                {
                    var reglement = new ReglementEntite(row);
                    var tauxHono = Convertir.ToDecimal(row["taux_honoraire"].ToString()) / 100;
//                    if (reglement.base_honoraire > 0)
                    {
                        tbMessage.Text +=
                            $"\r\n*** Proprietaire: {reglement.Proprietaire.NomPrenom} <= {reglement.Locataire.NomPrenom}";
                        tbMessage.Update();

                        Console.WriteLine(reglement.Locataire.reference);

//                        if (reglement.base_honoraire > 0)
                        if (reglement.base_honoraire != 0)
                        {
                            createFactureFromReglement(reglement, workflow, natureHono.id, libelleHono, reglement.base_honoraire * tauxHono);
                            createFactureFromReglement(reglement, workflow, natureHono.id, libelleTvaHono, reglement.base_honoraire * tauxHono * tauxTva);
                        }

                        // Mantis 272
                        //if (reglement.frais_bail != 0)
                        //    createFactureFromReglement(reglement, workflow, natureBail.id, libelleFraisBail, reglement.frais_bail);
                        if (reglement.frais_bail != 0)
                            createFactureFromReglement(reglement, workflow, natureBail.id, libelleFraisBail, reglement.frais_bail );

                        if (reglement.etat_lieux != 0)
                            createFactureFromReglement(reglement, workflow, natureBail.id, libelleEtatLieux, reglement.etat_lieux);

                        //if (reglement.honoraire_locataire * 2 != 0)
                        //    createFactureFromReglement(reglement, workflow, natureNlle.id, reglement.tire, reglement.honoraire_locataire * 2);
                        if (reglement.honoraire_locataire  != 0)
                            createFactureFromReglement(reglement, workflow, natureNlle.id, reglement.tire, reglement.honoraire_locataire );
                    }
                }
                trx.Commit();
                WorkflowController.FireWorkflowChanged();
                rc = true;
                tbMessage.BackColor = Color.LightGreen;
            }
            catch (Exception ex)
            {
                tbMessage.BackColor = Color.Red;
                MessageBox.Show(ex.Message);
                trx.Rollback();
            }
            return rc;
        }
    }
}
