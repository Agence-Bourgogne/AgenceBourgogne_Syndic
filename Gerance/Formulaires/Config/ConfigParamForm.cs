using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeranceData.Common;
using GeranceData.Controller;
using GeranceData.Entites;
using CommonProjectsPartners.Utils;
namespace Gerance.Formulaires.Config
{
    public partial class ConfigParamForm : Form
    {
        bool initialized = false;
        ParametreEntite groupe = null;

        public ConfigParamForm()
        {
            InitializeComponent();
        }

        private void tabPage1_Enter(object sender, EventArgs e)
        {
            //Console.WriteLine(tabControl.SelectedIndex);
        }

        private void cbGroupe_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Console.WriteLine(cbGroupe.SelectedValue);
            if (!initialized)
                return;
            if (cbGroupe.SelectedIndex < 0)
                return;
            DataRow row = ((DataRowView)cbGroupe.SelectedItem).Row;
            ParametreController.controller.SaveList((DataTable)dataGridView.DataSource, true);
            groupe = new ParametreEntite(row);
            dataGridView.DataSource = ParametreController.controller.getListFromEntiteGroupe(groupe);
            DataGridViewColumnCollection cols = dataGridView.Columns;
            cols["id"].Visible = false;
            cols["groupe"].Visible = false;
            cols["code"].Visible = false;
            cols["nom"].Visible = false;
            cols["param_1"].Visible = false;
            cols["param_2"].Visible = false;
            cols["param_3"].Visible = false;
            cols["iparam_1"].Visible = false;
            cols["iparam_2"].Visible = false;
            cols["iparam_3"].Visible = false;
            cols["audit_created"].Visible = false;
            cols["audit_created_by"].Visible = false;
            cols["audit_updated"].Visible = false;
            cols["audit_updated_by"].Visible = false;
            string[] columnsDef = groupe.param_1.Split(',');
            foreach (string coldef in columnsDef)
            {
                string[] paramCol = coldef.Replace(" as ", ":").Split(':');
                string colName = paramCol[0].ToLower().Trim();
                cols[colName].Visible = true;
                if (paramCol.Length > 1)
                    cols[colName].HeaderText = paramCol[1];
                else
                    cols[colName].HeaderText = colName;
            }
            ControlsWindows.ToTitleCase(cols);
        }

        private void ConfigParamForms_Load(object sender, EventArgs e)
        {
            ParametresDB.FillComboFromParams(cbGroupe, "HDR_GROUPE", "nom", "code");
            initialized = true;
            cbGroupe_SelectedIndexChanged(null, null);
        }

        private void dataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["groupe"].Value = groupe.code;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ParametreController.controller.SaveList((DataTable)dataGridView.DataSource, false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {

        }
    }
}
