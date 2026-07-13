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
                DataGridViewColumnCollection cols = dataGridView.Columns;
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

        private void cancel_Click(object sender, EventArgs e)
        {
            reference = "";
            this.DialogResult = DialogResult.Cancel;
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
            DataRowView row = (DataRowView) dataGridView.Rows[index].DataBoundItem;
            reference = row["reference"].ToString();
            this.DialogResult = DialogResult.OK;
            this.Close();
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
            string filter = " 1=1 ";
            if (tbRef.Text != "")
                filter += String.Format(" and reference like '{0}%' ", tbRef.Text);
            if (tbNom.Text != "")
                filter += String.Format(" and nom like '{0}%' ", tbNom.Text);
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
