using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
//using EspaceSyndic.Utils;
using System.Drawing;
using SyndicData.Common;

namespace EspaceSyndic.Formulaires.Common
{
    class InfoKeyHelpForm : HelpForm
    {
        public InfoKeyHelpForm(string keyName)
            : base(keyName)
        {
            //InitializeComponent();
            //this.helpKey = keyName;
            //this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HelpForm_FormClosing);
            this.Text = "Raccourcis Claviers";
        }
        public void DoFormText(Form parent)
        {
            DataTable table = ParametresDB.getComboData("KEY_CODE");
            string note = "";
            foreach (DataRow row in table.Rows)
            {
                string str = String.Format("{0}\t{1}", row["code"], row["param_1"]);
                note += (note == "" ? "": "\n") + str;
            }
            if (!"".Equals(note))
            {
                base.DoFormText(parent, note);
                int height = 13 * 15;
                this.tbHelp.Height = height + 10;
                this.Height = height;
                parent.Activate();
            }
            else
                this.Visible = false;
        }
        public override void DoFormText(Form parent, string note)
        {
            //DataTable table = ParametresDB.getComboData("KEY_CODE");
            //string note = "";
            //foreach (DataRow row in table.Rows)
            //{
            //    string str = String.Format("{0}\t{1}", row["code"], row["param_1"]);
            //    note += (note == "" ? "" : "\n") + str;
            //}
            if (!"".Equals(note))
            {
                base.DoFormText(parent, note);
                int height = 13 * 15;
                this.tbHelp.Height = height + 10;
                this.Height = height;
                parent.Activate();
            }
            else
                this.Visible = false;
        }
    }
}
