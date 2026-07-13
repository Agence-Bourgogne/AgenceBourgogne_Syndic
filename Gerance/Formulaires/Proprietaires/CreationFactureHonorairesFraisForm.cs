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
            tbMessage.Text = String.Format("Vous allez générer les factures\r\nd'Honoraires et de Frais\r\nPour la période du {0} au {1}", dtDebut.ToShortDateString(), dtFin.ToShortDateString());
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
                FactureEntite facture = FacturesController.getController().getFactureHonoraire(reglement, nature_id, libelle, montant);
                string msg = String.Format("\r\n{0} : {1} €", libelle, montant);

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
            bool rc = false;

            String libelleHono = "Honoraires Agence";
            String libelleTvaHono = "TVA sur Honoraires";
            string libelleFraisBail = "Frais Administratifs";
            string libelleEtatLieux = "Etats des Lieux";

            // TODO Paramétrer Taux TVA
            decimal tauxTva = (decimal)0.2;

            //TODO Paramétrer Natures
            NatureEntite natureHono = NatureController.getController().getEntiteFromField("reference", "020");
            NatureEntite natureBail = NatureController.getController().getEntiteFromField("reference", "011");
            NatureEntite natureNlle = NatureController.getController().getEntiteFromField("reference", "010");

            // TODO Quid de plusieurs réglements locataire sur la période 
            DataTable reglements = ReglementsController.getController().getReleveHonorairesProprietairesForFacture(dtDebut, dtFin, proprietaire_id);
            
            NpgsqlConnection cnx = Database.GetInstance();
            NpgsqlTransaction trx = cnx.BeginTransaction();
            DateTime dtWorkflow = new DateTime(dtDebut.Year, dtDebut.Month, 1);
            DateTime dtServer = FacturesController.getController().setTimestampServer();
            WorkflowController.getController().setTimestampServer(dtServer);
            WorkflowDetailController.getController().setTimestampServer(FacturesController.getController().getTimestampServer());
            try
            {
                WorkflowEntite workflow = WorkflowController.getController().WriteRecord(REFERENCE_TACHE, dtWorkflow);

                foreach (DataRow row in reglements.Rows)
                {
                    ReglementEntite reglement = new ReglementEntite(row);
                    decimal tauxHono = Convertir.ToDecimal(row["taux_honoraire"].ToString()) / 100;
//                    if (reglement.base_honoraire > 0)
                    {
                        tbMessage.Text += String.Format("\r\n*** Proprietaire: {0} <= {1}", reglement.Proprietaire.NomPrenom, reglement.Locataire.NomPrenom);
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
