using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EspaceSyndic.Formulaires.Immeubles;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using Microsoft.Reporting.WinForms;
using CommonProjectsPartners.Common;
using EspaceSyndic.Formulaires.Coproprietaire;
using EspaceSyndic.Formulaires.Exercice;
using System.IO;
using System.Reflection;

namespace EspaceSyndic.Impressions.RelevesIndividuels
{
    public partial class ReleveIndividuelsPrintForm : Form, ICommonChangedListener
    {
        public ImmeubleEntite immeuble = null;
        BindingSource immeubleSource = new BindingSource();
        AutoCompleteStringCollection lotsString = new AutoCompleteStringCollection();
        String TitreForm;
        private BindingSource immeuble_copro = new BindingSource();
        private BindingSource releve_copro = new BindingSource();
        private BindingSource releve_soldes = new BindingSource();
        private BindingSource releve_appel_fond = new BindingSource();
        private DataTable tableImmeuble_copro, table_soldes, table_appel_fond;
        private BindingSource etat_financier = new BindingSource();
        BindingSource base_descr = new BindingSource();
        DataTable solde_bidon;
        DataTable tableCondense = new DataTable();
        DataTable releve;
        string[] base_compteur;

        public ReleveIndividuelsPrintForm()
        {
            InitializeComponent();
            TitreForm = this.Text;
            if (UtilsApp.ServiceReferenceUtils.ServiceClientIsConfigured())
                btnExport.Visible = true;
        }

        private void ReleveIndividuelsPrintForm_Load(object sender, EventArgs e)
        {
            btnRapport.Enabled = false;
            btnExport.Enabled = false;
            btnEnter.Width = 0;
            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
        }
        private void lblImmeuble_Click(object sender, EventArgs e)
        {
            FindImmeubleForm form = new FindImmeubleForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbRefImmeuble.Text = form.reference;
                tbRefImmeuble_Validating(null, null);
            }
        }

        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            if (tbRefImmeuble.Enabled)
                immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null)
            {
                tbRefImmeuble.BackColor = Color.White;
                DataTable lots = LotDescriptionController.getController().getListeLot(immeuble.id);

                this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);

                ExerciceComptableEntite exercice = immeuble.ExerciceCourant;//ExerciceComptableController.getController().getExerciceCourant(immeuble.id);
                if (exercice != null)
                {
                    dtDebut.Value = exercice.date_deb;
                    dtFin.Value = exercice.date_fin;
                }

                // Milliemes de chaque Copro

                lotsString.Clear();
                foreach (DataRow row in lots.Rows)
                {
                    lotsString.Add(row["numero_lot"].ToString());
                }
                ControlsWindows.setAutoControle(tbLot, lotsString);
                btnRapport.Enabled = true;
                btnExport.Enabled = true;
            }
            else
            {
                this.Text = TitreForm;
                if (!"".Equals(tbRefImmeuble.Text))
                    tbRefImmeuble.BackColor = Color.Red;
                btnRapport.Enabled = false;
                btnExport.Enabled = false;
            }
        }

        private void tbRefImmeuble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                    if (sender.Equals(tbRefImmeuble))
                        lblImmeuble_Click(null, null);
                    if (sender.Equals(tbLot))
                        lblLot_Click(null, null);
                }
        }

        private void tbLot_Validating(object sender, CancelEventArgs e)
        {
            if (tbLot.Text != "")
                if (lotsString.Contains(tbLot.Text))
                    tbLot.BackColor = Color.White;
                else
                    tbLot.BackColor = Color.Red;
            else
                tbLot.BackColor = Color.White;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

      
        // TODO Parametrer ces éléments
        string[] noCumulable = new String[] { "042", "043", "050", "051", "113", "123" };
        private bool isCumulable( string refNature)
        {
            bool rc = true;
            if (noCumulable.Contains(refNature))
                return false;
            return rc;
        }
        
        protected void getBasesCompteurs()
        {
            string bases = SyndicData.Common.ParametresDB.getParam1("BASES", "COMPTEURS");
            if (bases != null)
            {
                base_compteur = bases.Replace(" ", "").Split(',');
            }
        }
        //------------------------------------------
        bool IsBaseCompteur(string base_repart)
        {
            if ( base_compteur == null)
                getBasesCompteurs();
            return base_compteur.Contains(base_repart);
        }
        //------------------------------------------
        private void loadDataReleve()
        {
            releve = OperationController.getController().GetReleveIndividuels(immeuble.id, dtDebut.Value, dtFin.Value);
            string copro_id = "", nature_id = "", base_repart = "", fournisseur = "";

            tableCondense.Clear();

            if (tableCondense.Columns.Count <= 0)
                foreach (DataColumn col in releve.Columns)
                {
                    Console.WriteLine(col.ColumnName);
                    tableCondense.Columns.Add(col.ColumnName, col.DataType);
                }

            bool bDetail = ckDetail.Checked;
            try
            {
                int row2Update = -1;
                foreach (DataRow row in releve.Rows)
                {
                    decimal debit = (decimal)row["debit"];

                    if (debit != 0)
                        row["charge_loc"] = (decimal)row["debit"] * (decimal)row["charge_loc"] / 100;
                    else
                        row["charge_loc"] = (decimal)row["credit"] * -1 * (decimal)row["charge_loc"] / 100;

                    //string base_ref = row["base_repart"].ToString();
                    object[] rowItem = row.ItemArray;
                    rowItem[10] = Math.Abs((decimal)rowItem[10]);

                    if (bDetail)
                        copro_id = "";
                    int ref_cpt = Convertir.ToInt(row["ref_cpt"].ToString());
                    if (copro_id != row["ref_copro"].ToString() )
                    {
                        tableCondense.Rows.Add(rowItem);
                        copro_id = row["ref_copro"].ToString();
                        fournisseur = row["fournisseur"].ToString();
                        nature_id = row["ref_nature"].ToString();
                        base_repart = row["base_repart"].ToString();
                        row2Update = -1;
                    }
                    else
                        if (fournisseur != row["fournisseur"].ToString())
                        {
                            tableCondense.Rows.Add(rowItem);
                            nature_id = row["ref_nature"].ToString();
                            fournisseur = row["fournisseur"].ToString();
                            base_repart = row["base_repart"].ToString();
                            row2Update = -1;
                        }
                        else
                            if (nature_id != row["ref_nature"].ToString() || !isCumulable(row["ref_nature"].ToString()))
                            {
                                tableCondense.Rows.Add(rowItem);
                                nature_id = row["ref_nature"].ToString();
                                base_repart = row["base_repart"].ToString();
                                row2Update = -1;
                            }
                            else
                                if (base_repart != row["base_repart"].ToString())
                                {
                                    tableCondense.Rows.Add(rowItem);
                                    base_repart = row["base_repart"].ToString();
                                    row2Update = -1;
                                }
                                else
                                    {
                                        int current = tableCondense.Rows.Count - 1;
                                        object[] oldItem = tableCondense.Rows[current].ItemArray;
                                        //                                    if (!IsBaseCompteur(base_repart))
                                        if (!IsBaseCompteur(oldItem[2].ToString())&&!IsBaseCompteur(base_repart))
                                        {
                                            oldItem[5] = ".";
                                            object[] newItem = rowItem;
                                            decimal value = Convertir.ToDecimal(oldItem[8]) + Convertir.ToDecimal(newItem[8]);

                                            oldItem[8] = value;
                                            oldItem[9] = Convertir.ToDecimal(oldItem[9]) + Convertir.ToDecimal(newItem[9]);
                                            oldItem[10] = Convertir.ToDecimal(oldItem[10]) + Convertir.ToDecimal(newItem[10]);
                                            oldItem[11] = Convertir.ToDecimal(oldItem[11]) + Convertir.ToDecimal(newItem[11]);
                                            tableCondense.Rows[current].ItemArray = oldItem;
                                            row2Update = -1;
                                        }
                                        else
                                            if (row2Update != -1)
                                            {
                                                DataRow oldRow = tableCondense.Rows[row2Update];
                                                if ( oldRow["saisie_id"].ToString() != row["saisie_id"].ToString())
                                                {
                                                    row2Update = -1;
                                                    tableCondense.Rows.Add(rowItem);
                                                }
                                                //Console.WriteLine("..");
                                            }
                                    }
                    if (IsBaseCompteur (base_repart))
                    {
                        bool bCumul = true;
                        if (row2Update == -1)
                        {
                            row2Update = tableCondense.Rows.Count - 1;
                            bCumul = false;
                        }
                        if ( row2Update != -1 && bCumul)
                        {
                            object[] oldItem = tableCondense.Rows[row2Update].ItemArray;
                            object[] newItem = rowItem;
                            oldItem[7] = Convertir.ToDecimal(oldItem[7]) + Convertir.ToDecimal(newItem[7]);
//                            oldItem[8] = Convertir.ToDecimal(oldItem[8]) + Convertir.ToDecimal(newItem[9]);
                            oldItem[9] = Convertir.ToDecimal(oldItem[9]) + Convertir.ToDecimal(newItem[9]);
                            oldItem[10] = Convertir.ToDecimal(oldItem[10]) + Convertir.ToDecimal(newItem[10]);
                            oldItem[11] = Convertir.ToDecimal(oldItem[11]) + Convertir.ToDecimal(newItem[11]);
                            tableCondense.Rows[row2Update].ItemArray = oldItem;
                        }
                        double ancien = Convertir.ToFloat(row["ancien"].ToString());
                        double nouveau = Convertir.ToFloat(row["nouveau"].ToString());
                        if (nouveau != 0)
                        {
                            for (int i = 1; i < rowItem.Length; i++)
                                rowItem[i] = null;
                            rowItem[5] = String.Format("Cpt {2} : Ancien Index {0}   -   Nouvel Index {1} ", ancien, nouveau, ref_cpt);
                            tableCondense.Rows.Add(rowItem);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show(ex.Message);
            } 
            Console.WriteLine("---");
        }
        //------------------------------------------
        private void btnRapport_Click(object sender, EventArgs e)
        {
            try
            {
                loadDataReleve();
                table_soldes = OperationController.getController().getSoldesRelevesIndividuels(immeuble.id, dtDebut.Value, dtFin.Value);
                table_appel_fond = OperationController.getController().getSoldesRelevesIndividuels(immeuble.id, dtDebut.Value, dtFin.Value, true);
                solde_bidon = OperationController.getController().getSoldesBidon();
              //  LoadReport();
                CreateReport(tbLot.Text);

                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        //------------------------------------------
        void LoadReport()
        {
     
            string resourceName = "EspaceSyndic.Impressions.RelevesIndividuels.ReleveIndivMasterReport.rdlc";
            Assembly assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    this.reportViewer1.LocalReport.LoadReportDefinition(stream);
                    Console.WriteLine($"La ressource '{resourceName}' existe.");
                }
                else
                {
                    Console.WriteLine($"La ressource '{resourceName}' n'existe pas.");
                }
            }
        }

        //------------------------------------------
        void CreateReport( String num_lot)
        {
            tableImmeuble_copro = ImmeubleController.getController().GetDescriptionCoproprietairesImmeubleReleveIndividuel(immeuble.id, num_lot);


            List<EtatFinancier> finance = new List<EtatFinancier>();
            foreach (DataRow row in table_appel_fond.Rows)
            {
                finance.Add(new EtatFinancier(row["coproprietaire_id"].ToString(), (decimal)row["credit"] - (decimal)row["debit"]));
            }


            decimal avance = 0, sommes = 0, excedents = 0, solde = 0;

            avance = LotDescriptionController.getController().getAvanceImmeuble(immeuble.id);
            foreach (DataRow row in table_soldes.Rows)
            {
                int ordre = (int)row["ordre"];
                EtatFinancier etat = getIndiceCopro(finance, row["coproprietaire_id"].ToString());
                if (etat == null)
                {
                    etat = new EtatFinancier(row["coproprietaire_id"].ToString());
                    finance.Add(etat);
                }
                switch (ordre)
                {
                    case 1:
                        if ((decimal)row["credit"] - (decimal)row["debit"] == 0)
                        {
                            foreach (DataRow row_copro in tableImmeuble_copro.Rows)
                            {
                                int statut = (int)row_copro["statut"];
                                if (statut != 1)
                                    if (row_copro["copro_id"].ToString() == row["coproprietaire_id"].ToString())
                                    {
                                        tableImmeuble_copro.Rows.Remove(row_copro);
                                        break;
                                    }
                            }
                        }
                        etat.solde += (decimal)row["credit"] - (decimal)row["debit"];
                        break;
                    case 2:
                        etat.reglement += (decimal)row["credit"] - (decimal)row["debit"];
                        break;
                    case 3:
                        etat.releve += (decimal)row["credit"] - (decimal)row["debit"];
                        break;
                    default:
                        break;
                }
            }
            decimal soldes = 0, reglement = 0, releve = 0, appel = 0;
            foreach (EtatFinancier etat in finance)
            {
                decimal cumul = etat.solde + etat.reglement + etat.releve;

                soldes += etat.solde;
                reglement += etat.reglement;
                releve += etat.releve;
                appel += etat.appel;
                if (cumul < 0)
                    sommes += cumul;
                else
                    excedents += cumul;
            }

            solde = Math.Abs(sommes) - excedents - avance;
            //Console.WriteLine("{0}", solde);
            //Console.WriteLine("{0} {1} {2}", sommes, excedents, avance);
            //Console.WriteLine("{0} {1} {2} {3}",  soldes, reglement, releve, appel);

            DataTable table_etat = new DataTable();
            table_etat.Columns.Add("code");
            table_etat.Columns.Add("libelle");
            table_etat.Columns.Add("dettes", typeof(System.Decimal));
            table_etat.Columns.Add("creances", typeof(System.Decimal));


            table_etat.Rows.Add(new object[] { "1033", "Avance fond de roulement", 0.0, avance });
            table_etat.Rows.Add(new object[] { "45", "Sommes exigibles restant à recevoir", sommes, 0.0 });
            table_etat.Rows.Add(new object[] { "45", "Excédents Versés", 0.0, excedents });
            if (solde < 0)
                table_etat.Rows.Add(new object[] { "43", "Solde de banque créditeur", solde, 0.0 });
            if (solde > 0)
                table_etat.Rows.Add(new object[] { "43", "Solde de banque débiteur", 0.0, solde });

            string hdr_descr = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            string hdr_agence = SyndicData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");

            ReportParameter[] parameters = new ReportParameter[]{
                new ReportParameter("DateDebut", dtDebut.Value.ToShortDateString()),
                new ReportParameter("DateFin", dtFin.Value.ToShortDateString()),
                new ReportParameter("DateEdition", dtEdition.Value.ToShortDateString()),
                new ReportParameter("Header_Description", hdr_descr),
                new ReportParameter("Header_Agence", hdr_agence),
            };
       //     this.reportViewer1.LocalReport.ReportEmbeddedResource = "EspaceSyndic.Impressions.RelevesIndividuels.ReleveIndivMasterReport.rdlc";
            Console.WriteLine(" test " + this.reportViewer1.LocalReport.ReportEmbeddedResource);
           
            this.reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("immeuble_copro", tableImmeuble_copro));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("etat_financier", table_etat));
            reportViewer1.RefreshReport();
        }
        //------------------------------------------
        DataTable getTableBase()
        {
            DataView tv = (DataView)releve_copro.List;
            DataTable tb = tv.ToTable();
            List<string> base_def = new List<string>();
            DataTable table = new DataTable();

            table.Columns.Add("base_ref");
            table.Columns.Add("base_nom");
            foreach (DataRow row in tb.Rows)
            {
                string base_ref = row["base_repart"].ToString();
                if (base_ref != "")
                {
                   if (!base_def.Contains(base_ref))
                    {
                        base_def.Add(base_ref);
                        table.Rows.Add(base_ref, row["base_nom"].ToString());
                    }
                }
            }
            return table;
        }
        //------------------------------------------
        EtatFinancier getIndiceCopro(List<EtatFinancier> finance, string copro)
        {
            foreach (EtatFinancier etat in finance )
            {
                if ( etat.copro_id == copro )
                    return etat;
            }
            return null;
        }
        //-----------------------------------------
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            string coproprietaire_id = e.Parameters[0].Values[0];
            releve_copro.DataSource  = tableCondense;
            releve_copro.Filter = String.Format("ref_copro = '{0}'", coproprietaire_id);

            base_descr.DataSource = getTableBase();
            base_descr.Sort = "base_ref";
            
            releve_soldes.DataSource = table_soldes;
            releve_appel_fond.DataSource = table_appel_fond;

            immeuble_copro.DataSource = tableImmeuble_copro;
            immeuble_copro.Filter = String.Format("copro_id = '{0}'", coproprietaire_id) ;
            releve_soldes.Filter = String.Format("coproprietaire_id = '{0}'", coproprietaire_id);
            releve_appel_fond.Filter = String.Format("coproprietaire_id = '{0}'", coproprietaire_id);

            e.DataSources.Clear();
            e.DataSources.Add(new ReportDataSource("base_description", base_descr));
            e.DataSources.Add(new ReportDataSource("releve_indiv", releve_copro));
            e.DataSources.Add(new ReportDataSource("immeuble_copro", immeuble_copro));
            e.DataSources.Add(new ReportDataSource("soldes_releve_indiv", releve_soldes));
            e.DataSources.Add(new ReportDataSource("soldes_appel_fond", releve_appel_fond));
            e.DataSources.Add(new ReportDataSource("soldes_bidon", solde_bidon));
        }
        public void ChangedReference(object send, CommonEventArgs e)
        {
            tbRefImmeuble.Text = e.newRef;
            tbRefImmeuble_Validating(null, null);
            tbLot.Text = e.newRef2;
            tbLot_Validating(null, null);
            btnRapport_Click(null, null);
        }

        private void lblLot_Click(object sender, EventArgs e)
        {
            FindLotCoproprietaireImmeubleForm form = new FindLotCoproprietaireImmeubleForm();
            form.immeuble = immeuble;
            form.ShowDialog();
            if (form.reference != "")
            {
                tbLot.Text = form.reference;
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (immeuble == null)
                return;
            ReferenceExerciceForm form = new ReferenceExerciceForm(immeuble);
            form.ShowDialog();
            tbRefImmeuble_Validating(null, null);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (immeuble == null) return;
            List<LotDescriptionEntite> lots = LotDescriptionController.getController().getListeLotDescription(immeuble.id);
            if(lots == null || lots.Count == 0) return;
            loadDataReleve();
            table_soldes = OperationController.getController().getSoldesRelevesIndividuels(immeuble.id, dtDebut.Value, dtFin.Value);
            table_appel_fond = OperationController.getController().getSoldesRelevesIndividuels(immeuble.id, dtDebut.Value, dtFin.Value, true);
            solde_bidon = OperationController.getController().getSoldesBidon();
            this.Enabled = false;
            ExportCopro dlg = new ExportCopro();
            try
            {
                //string serveur = SyndicData.Common.ParametresDB.getParam1("SERVEUR", "ADDRESSE");
                //ServiceReference.ServiceClient sc = new ServiceReference.ServiceClient("BasicHttpBinding_IService", serveur);
                dlg.Show(this);
                dlg.Activate();
                if (!string.IsNullOrEmpty(tbLot.Text) && lots.Exists(x=>x.numero_lot.ToString() == tbLot.Text))
                {
                    LotDescriptionEntite lot = lots.FirstOrDefault(x=>x.numero_lot.ToString() == tbLot.Text);
                    if(lot.Coproprietaire != null)
                    {
                        CoproprietaireEntite copro = CoproprietaireController.getController().getEntiteById(lot.coproprietaire_id);
                        string monthName = new DateTime(2010, 8, 1).ToString("MMM", System.Globalization.CultureInfo.CurrentCulture);
                        string rapportName = "Releve Individuel " + copro.nom + "_" + monthName + "-" + dtFin.Value.Year.ToString();
                        dlg.textBox1.Text = String.Format("Export releve individuel lot : {0}", lot.numero_lot);
                        dlg.textBox1.Refresh();
                        CreateReport(lot.numero_lot.ToString());
                        UtilsApp.ServiceReferenceUtils.SendReportPDF(reportViewer1, rapportName, Guid.NewGuid().ToString(), lot.immeuble_id, lot.coproprietaire_id);
                    }
                }
                else
                {
                  //  CreateReport("");
                    foreach (LotDescriptionEntite lot in lots)
                    {
                        if(lot != null && lot.Coproprietaire != null)
                        {
                            CoproprietaireEntite copro = CoproprietaireController.getController().getEntiteById(lot.coproprietaire_id);
                            string monthName = new DateTime(2010, 8, 1).ToString("MMM", System.Globalization.CultureInfo.InvariantCulture);
                            string rapportName = "Releve Individuel " + copro.nom + "_" + lot.numero_lot + "_" + monthName + "-" + dtFin.Value.Year.ToString();
                            dlg.textBox1.Text = String.Format("Export releve individuel lot : {0}", lot.numero_lot);
                            dlg.textBox1.Refresh();
                            CreateReport(lot.numero_lot.ToString());
                            UtilsApp.ServiceReferenceUtils.SendReportPDF(reportViewer1, rapportName, Guid.NewGuid().ToString(), lot.immeuble_id, lot.coproprietaire_id);
                        }
                    }
                    CreateReport("");
                }
               
                dlg.Close();
            }
            catch (Exception ex)
            {
                dlg.Close();
                MessageBox.Show(ex.Message);
            }
            this.Enabled = true;
            this.Activate();
        }
    }
    class BaseDescription
    {
        public string base_ref;
        public string base_nom;
        public BaseDescription(string base_ref, string base_nom)
        {
            this.base_ref = base_ref;
            this.base_nom = base_nom;
        }
    }
    class EtatFinancier
    {
        public string copro_id;

        public decimal appel;
        public decimal solde;
        public decimal reglement;
        public decimal releve;

        public EtatFinancier(string copro)
        {
            copro_id = copro;
        }

        public EtatFinancier(string copro, decimal appel)
        {
            copro_id = copro;
            this.appel = appel;
        }
    }
}
