using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Common;
using SyndicData.Common;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.Impressions.RetardsPaiements;

namespace EspaceSyndic.Impressions.RelevesComptes
{
    public partial class ReleveCompteCoproPrintForm : Form, ICommonChangedListener
    {
        ImmeubleEntite immeuble;
        AutoCompleteStringCollection lotsString = new AutoCompleteStringCollection();
        BindingSource sourceData = new BindingSource();
        String TitreForm;
        public ReleveCompteCoproPrintForm()
        {
            InitializeComponent();
            TitreForm = this.Text;
        }
        public void RefreshImmeuble(string ref_immeuble)
        {
            tbRefImmeuble.Text = ref_immeuble;
            tbRefImmeuble_Validating(null, null);
        }
        private void ReleveIndividuelPrintForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
            btnRapport.Enabled = false;
        }
        private void tbRefImmeuble_DoubleClick(object sender, EventArgs e)
        {
            FindImmeubleForm form = new FindImmeubleForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbRefImmeuble.Text = form.reference;
                tbRefImmeuble_Validating(null, null);
            }
        }
        bool bLoading;
        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            if (tbRefImmeuble.Text != "")
            {
                tbRefImmeuble.BackColor = Color.White;
                FillComboLot();
                commonValidating();
            }
            else
                if (!"".Equals(tbRefImmeuble.Text))
                    tbRefImmeuble.BackColor = Color.Red;
            btnRapport.Enabled = false;
        }
        private void FillComboLot()
        {
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            bLoading = true;
            cbLot.DataSource = LotDescriptionController.getController().getComboListeLotCoproprietaires(immeuble);
            cbLot.DisplayMember = "nom";
            cbLot.ValueMember = "reference";
            bLoading = false;
        }
        private void commonValidating()
        {
            if ( immeuble != null)
            {
                btnRapport.Enabled = true;
                this.Text = String.Format("{0} pour l'immeuble : {1} ({2})", TitreForm, immeuble.nom, immeuble.DateExercice);
                fillRapport();
            }
        }
        private void btnRapport_Click(object sender, EventArgs e)
        {
            commonValidating();
        }
        private void fillRapport()
        {
            string type_ope = GlobalConstantes.TypeMouvement.Recette.ToString();
            int statut = (int) GlobalConstantes.StatutOperation.Valide;
            string refLot = cbLot.SelectedValue.ToString();
            string Huissier = "";
            string Gerant = "";

            DataTable table = OperationController.getController().getListeOperations(immeuble.id, refLot, type_ope, statut);
            if (sourceData != null && table.Rows.Count > 0 )
            {
                sourceData.DataSource = table;
                DataRow row = table.Rows[0];
                CoproprietaireEntite copro = CoproprietaireController.getController().getEntiteFromField("reference", row["ref_copro"].ToString());
                if (copro != null)
                {
                    Huissier = copro.huissier ? "Dossier remis à l'huissier" : "";
                    Gerant = copro.nomcomp;
                }
                ReportParameter[] parameters = new ReportParameter[]{
                    new ReportParameter("ref_immeuble", tbRefImmeuble.Text),
                    new ReportParameter("nom_copro", row["coproprietaire"].ToString()),
                    new ReportParameter("ref_copro", row["ref_copro"].ToString()),
                    new ReportParameter("Gerant", Gerant),
                    new ReportParameter("Huissier", Huissier),
                    
                };

                try
                {
                    this.reportViewer1.LocalReport.SetParameters(parameters);

                    sourceData.Sort = "date_reference asc";
                    this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ReleveCompteCopro", sourceData));
                    this.reportViewer1.RefreshReport();

                }
                catch (Exception ex )
                {
                }
            }
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }
        public void ChangedReference(object sender, CommonEventArgs e)
        {
            tbRefImmeuble.Text = e.newRef;
            FillComboLot();
            cbLot.SelectedValue = e.newRef2;
            commonValidating();
//            tbRefImmeuble_Validating(null, null);
        }
        private void cbLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( !bLoading )
                commonValidating();
        }

        private void btnRetard_Click(object sender, EventArgs e)
        {
            RetardsPaiementsForm form = new RetardsPaiementsForm();
            form.immeuble_ref = tbRefImmeuble.Text;
            form.ShowDialog();
        }
    }
}
