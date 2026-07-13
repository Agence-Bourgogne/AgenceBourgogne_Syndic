using System;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
namespace EspaceSyndic.Formulaires.Common
{
    public partial class FindStdForm : Form
    {
        //public BaseController<BaseEntite> controller;
        public string reference = "";
        public string filter = "";
        protected DataTable source = null;

        TextBox tbResult = null;

        public FindStdForm()
        {
            InitializeComponent();
        }
        public FindStdForm(TextBox tbResult)
        {
            InitializeComponent();
            this.tbResult = tbResult;
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
            //DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            //reference =  row["reference"].ToString();
            //this.Close();
            setReferenceFromRow(dataGridView.SelectedRows[0].Index);
        }

        private void dataGridView_DoubleClick(object sender, EventArgs e)
        {
            //DataRowView row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
            //reference = row["reference"].ToString();
            //this.Close();
            setReferenceFromRow(dataGridView.SelectedRows[0].Index);
        }

        private void FindStdForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
            FillListFromFilter(filter);
        }

        private void setReferenceFromRow(int index)
        {
            DataRowView row = (DataRowView) dataGridView.Rows[index].DataBoundItem;
            if (row != null)
            {
                reference = row["reference"].ToString();
                if (tbResult != null)
                    tbResult.Text = reference;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void dataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0D)
            {
                e.Handled = true;
                setReferenceFromRow(dataGridView.SelectedRows[0].Index-1);
            }
        }

        private void tbRef_TextChanged(object sender, EventArgs e)
        {
            FillListFromTbFilter();
        }

        protected virtual void FillListFromTbFilter()
        {
            filter = " 1=1 ";
            if (tbRef.Text != "")
                filter += String.Format(" and reference like '{0}%' ", tbRef.Text);
            if (tbNom.Text != "")
                filter += String.Format(" and LOWER(nom) like LOWER('{0}%') ", tbNom.Text);
            FillListFromFilter(filter);
        }

        private void tbNom_TextChanged(object sender, EventArgs e)
        {
            FillListFromTbFilter();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }
    }
}
