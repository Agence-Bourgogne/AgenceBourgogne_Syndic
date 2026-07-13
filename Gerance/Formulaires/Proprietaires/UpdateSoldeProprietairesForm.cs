using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using GeranceData.Controller;
using GeranceData.Entites;
using CommonProjectsPartners.Utils;
using Npgsql;

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
            tbMessage.Text = String.Format("Mise à jour les comptes Proprietaires\r\nPour la période du {0} au {1}", dtDebut.ToShortDateString(), dtFin.ToShortDateString());
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
                string reference = row["p_reference"].ToString();
                if (!list.Contains(reference))
                {
                    list.Add(reference);
                    Console.WriteLine(reference);                            
                }
            }
        }

        List<SoldeProprio> getSoldes()
        {
            List<SoldeProprio> soldes = new List<SoldeProprio>();
            BindingSource releve_compte = new BindingSource();
            BindingSource facture_compte = new BindingSource();

            //DataTable tableHdr = ReglementsController.getController().getHdrReleveCompteProprio(dtDebut, dtFin, proprietaire_id);
            List<String> idsProprio = new List<string>();

            releve_compte.DataSource = ReglementsController.getController().getReleveCompteProprio(dtDebut, dtFin);
            facture_compte.DataSource = FacturesController.getController().getDeductionProprio(dtDebut, dtFin);
            SetReferenceProprio(idsProprio, (DataTable) releve_compte.DataSource);
            SetReferenceProprio(idsProprio, (DataTable) facture_compte.DataSource);
            DataTable tableHdr = ReglementsController.getController().getHdrReleveCompteProprio(dtDebut, dtFin, idsProprio);

            soldes.Clear();

            tbMessage.TextAlign = HorizontalAlignment.Left;

            foreach (DataRow row in tableHdr.Rows)
            {
                string refProprio = row["p_reference"].ToString();

                releve_compte.Filter = String.Format("p_reference = '{0}'", refProprio);
                facture_compte.Filter = String.Format("p_reference = '{0}'", refProprio);

                decimal loyers = ComptesProprietairesForm.getSomme(releve_compte, 0);
//                decimal deduction = Math.Abs(ComptesProprietairesForm.getSomme(facture_compte, 1));
                decimal deduction = ComptesProprietairesForm.getSomme(facture_compte, 1);
                soldes.Add(new SoldeProprio(refProprio, loyers, deduction));
            }
            return soldes;
        }
        const int REFERENCE_TACHE = 2; 
        private void MiseAJourCompteProprio()
        {
            List<SoldeProprio> soldes = getSoldes();

            DateTime dtServer = ProprietaireController.getController().setTimestampServer();
            DateTime dtWorkflow = new DateTime(dtDebut.Year, dtDebut.Month, 1);
            WorkflowController.getController().setTimestampServer(dtServer);
            WorkflowDetailController.getController().setTimestampServer(dtServer);

            NpgsqlTransaction trx = Database.BeginTransaction();
            try
            {
                WorkflowEntite workflow = WorkflowController.getController().WriteRecord(REFERENCE_TACHE, dtWorkflow);
                List<string> proprios = new List<String>();
                foreach (SoldeProprio soldeProp in soldes)
                {
                    ProprietaireEntite proprio = ProprietaireController.getController().getEntiteFromField("reference", soldeProp.reference);
                    if (proprio != null)
                        if ( !proprios.Contains( proprio.id))
                        {
                            decimal solde = soldeProp.loyers + soldeProp.deductions;
                            //decimal solde = soldeProp.loyers - soldeProp.deductions;
                            //if (soldeProp.deductions > 0)
                            //    solde = soldeProp.loyers + soldeProp.deductions;

                            string msg = String.Format("\r\n*** Mise à jour compte de {0} {1} : {2} €", proprio.reference, proprio.NomPrenom, solde);
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
