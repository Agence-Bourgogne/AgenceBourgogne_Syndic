using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Controller;
using CommonProjectsPartners.Utils;

namespace Gerance.Formulaires.Proprietaires
{
    public partial class UpdateSoldeProprietairesForm : Form
    {
        DateTime dtDebut, dtFin;
        string proprietaire_id;

        public UpdateSoldeProprietairesForm()
        {
            InitializeComponent();
        }
        public UpdateSoldeProprietairesForm(DateTime dtDebut, DateTime dtFin, string proprietaire_id)
        {
            InitializeComponent();
            this.dtDebut = dtDebut;
            this.dtFin = dtFin;
            this.proprietaire_id = proprietaire_id;
        }

        private void UpdateSoldeProprietairesForm_Load(object sender, EventArgs e)
        {
            tbMessage.Text =
                $"Mise à jour les comptes Proprietaires\r\nPour la période du {dtDebut.ToShortDateString()} au {dtFin.ToShortDateString()}";
            tbMessage.SelectionStart = tbMessage.Text.Length;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MiseAJourCompteProprio();
        }

        void SetReferenceProprio(List<String> list, DataTable table)
        {
            foreach (DataRow row in table.Rows)
            {
                var reference = row["p_reference"].ToString();
                if (!list.Contains(reference))
                {
                    list.Add(reference);
                    Console.WriteLine(reference);                            
                }
            }
        }

        List<SoldeProprio> getSoldes()
        {
            var soldes = new List<SoldeProprio>();
            var releve_compte = new BindingSource();
            var facture_compte = new BindingSource();

            //DataTable tableHdr = ReglementsController.getController().getHdrReleveCompteProprio(dtDebut, dtFin, proprietaire_id);
            var idsProprio = new List<string>();

            releve_compte.DataSource = ReglementsController.getController().getReleveCompteProprio(dtDebut, dtFin);
            facture_compte.DataSource = FacturesController.getController().getDeductionProprio(dtDebut, dtFin);
            SetReferenceProprio(idsProprio, (DataTable) releve_compte.DataSource);
            SetReferenceProprio(idsProprio, (DataTable) facture_compte.DataSource);
            var tableHdr = ReglementsController.getController().getHdrReleveCompteProprio(dtDebut, dtFin, idsProprio);

            soldes.Clear();

            tbMessage.TextAlign = HorizontalAlignment.Left;

            foreach (DataRow row in tableHdr.Rows)
            {
                var refProprio = row["p_reference"].ToString();

                releve_compte.Filter = $"p_reference = '{refProprio}'";
                facture_compte.Filter = $"p_reference = '{refProprio}'";

                var loyers = ComptesProprietairesForm.getSomme(releve_compte, 0);
//                decimal deduction = Math.Abs(ComptesProprietairesForm.getSomme(facture_compte, 1));
                var deduction = ComptesProprietairesForm.getSomme(facture_compte, 1);
                soldes.Add(new SoldeProprio(refProprio, loyers, deduction));
            }
            return soldes;
        }
        const int REFERENCE_TACHE = 2; 
        private void MiseAJourCompteProprio()
        {
            var soldes = getSoldes();

            var dtServer = ProprietaireController.getController().setTimestampServer();
            var dtWorkflow = new DateTime(dtDebut.Year, dtDebut.Month, 1);
            WorkflowController.getController().setTimestampServer(dtServer);
            WorkflowDetailController.getController().setTimestampServer(dtServer);

            var trx = Database.BeginTransaction();
            try
            {
                var workflow = WorkflowController.getController().WriteRecord(REFERENCE_TACHE, dtWorkflow);
                var proprios = new List<String>();
                foreach (var soldeProp in soldes)
                {
                    var proprio = ProprietaireController.getController().getEntiteFromField("reference", soldeProp.reference);
                    if (proprio != null)
                        if ( !proprios.Contains( proprio.id))
                        {
                            var solde = soldeProp.loyers + soldeProp.deductions;
                            //decimal solde = soldeProp.loyers - soldeProp.deductions;
                            //if (soldeProp.deductions > 0)
                            //    solde = soldeProp.loyers + soldeProp.deductions;

                            var msg =
                                $"\r\n*** Mise à jour compte de {proprio.reference} {proprio.NomPrenom} : {solde} €";
                            proprio.dernier_cheque = solde;
                            proprios.Add(proprio.id);
                            if (solde < 0)
                            {
                                proprio.debit = Math.Abs(solde);
                                proprio.credit = 0;
                            }
                            else
                            {
                                proprio.debit = 0;
                                proprio.credit = solde;
                            }
                            if (!ProprietaireController.getController().doInsertOrUpdate(proprio))
                                throw new Exception("Erreur mise à jour " + proprio.reference);

                            WorkflowDetailController.getController().WriteRecord(workflow, proprio.id, proprio.reference);

                            tbMessage.Text += msg;
                            tbMessage.Update();
                        }
                }
                trx.Commit();
                WorkflowController.FireWorkflowChanged();
                tbMessage.BackColor = Color.LightGreen;
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
