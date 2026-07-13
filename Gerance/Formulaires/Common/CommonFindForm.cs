using System;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;

namespace Gerance.Formulaires.Common
{
    public partial class CommonFindForm : Form
    {
        public string reference = "";
        public string filter = "";
        protected DataTable source = null;
        public CommonFindForm()
        {
            InitializeComponent();
        }

        public virtual void FillListFromFilter( string filter)
        {
            if ( source != null)
            {
                dataGridView.DataSource = source;
                var cols = dataGridView.Columns;
                cols["id"].Visible = false;
                cols["nom"].Width = 250;
                ControlsWindows.ToTitleCase(cols);
            }
            dataGridView.ReadOnly = true;
        }

        private void valid_Click(object sender, EventArgs e)
        {
            setReferenceFromRow(dataGridView.SelectedRows[0].Index);
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            setReferenceFromRow(dataGridView.SelectedRows[0].Index);
        }

        private void FindStdForm_Load(object sender, EventArgs e)
        {
            FillListFromFilter(filter);
        }
        private void setReferenceFromRow(int index)
        {
            var row = (DataRowView) dataGridView.Rows[index].DataBoundItem;
            reference = row["reference"].ToString();
            DialogResult = DialogResult.OK;
            Close();
        }
        private void dataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0D)
            {
                e.Handled = true;
                setReferenceFromRow(dataGridView.SelectedRows[0].Index-1);
            }
        }
        protected virtual void FillListFromTbFilter()
        {
            var filter = " 1=1 ";
            if (tbRef.Text != "")
                filter += $" and reference like '{tbRef.Text}%' ";
            if (tbNom.Text != "")
                filter += $" and nom like '{tbNom.Text}%' ";
            FillListFromFilter(filter);
        }

        private void tbRef_TextChanged(object sender, EventArgs e)
        {
            FillListFromTbFilter();
        }

        private void tbNom_TextChanged(object sender, EventArgs e)
        {
            FillListFromTbFilter();
        }
    }
}
