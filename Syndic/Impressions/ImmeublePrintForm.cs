using System;
using System.Data;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using CommonProjectsPartners.Datasets.CoproprietaireImmeubleTableAdapters;
using SyndicData.Controller;

namespace EspaceSyndic.Impressions
{
    public partial class ImmeublePrintForm : Form
    {
        public ImmeublePrintForm()
        {
            InitializeComponent();
        }

        private void ImmeublePrintForm_Load(object sender, EventArgs e)
        {

            //DateTime dt = DateTime.Parse("01/01/2014");
            //for (int i = 0; i < 12; i++)
            //{
            //    string[] datStr = dt.ToLongDateString().ToString().Split(' ');
            //    cbMonth.Items.Add(datStr[2]);
            //    dt = dt.AddMonths(1);
            //}
        }



        private void btnRapport_Click(object sender, EventArgs e)
        {
            DataTable source = ImmeubleController.getController().GetListeFromMonthCloture(tbMonth.Text.Replace(".",","));
            this.immeubleBindingSource.DataSource = source;
            this.reportViewer1.RefreshReport();
        }
    }
}
