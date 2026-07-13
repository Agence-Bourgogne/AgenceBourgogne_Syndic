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
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Immeubles;
using SyndicData.Entites;
using SyndicData.Controller;
namespace EspaceSyndic.Impressions
{
    public partial class FeuillePresencePrintForm : Form
    {
        ImmeubleEntite immeuble = null;
        public FeuillePresencePrintForm()
        {
            InitializeComponent();
            btnRapport.Enabled = false;
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportParameter[] parameters = new ReportParameter[]{
                new ReportParameter("TypeAssemblee", cbAssemblee.SelectedItem.ToString()),
                new ReportParameter("DateAssemblee", dtAssemblee.Value.ToShortDateString())
            };

//            this.tableCoproImmeubleBindingSource.DataSource = CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id, true);
            //this.tableCoproImmeubleBindingSource.DataSource = CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id, dtAssemblee.Value.ToShortDateString(), cbAssemblee.SelectedItem.ToString());
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CoproImmeubleDSet", CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id)));
            reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }

        private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
        {
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null &cbAssemblee.SelectedIndex >= 0)
            {
                btnRapport.Enabled = true;
            }
            else
                btnRapport.Enabled = false;
        }

        private void FeuillePresencePrintForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
        }

        private void cbAssemblée_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbRefImmeuble_Validating(null, null);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }
    }
}
