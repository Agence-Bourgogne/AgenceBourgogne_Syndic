using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Data;
//using EspaceSyndic.Controller;
//using EspaceSyndic.Entites;

namespace CommonProjectsPartners.Utils
{
    public class ControlsWindows
    {
        public static void addColumn(DataGridView grid, String title, int width=80)
        {
            DataGridViewColumn column = new DataGridViewColumn();
            column.HeaderText = title;
            column.Width = width;
            grid.Columns.Add(column);

        }
        public static void ToTitleCase(DataGridViewColumnCollection cols)
        {
            TextInfo textInfo = new CultureInfo("fr-FR", false).TextInfo;
            foreach (DataGridViewColumn col in cols)
            {
                col.HeaderText = textInfo.ToTitleCase(col.HeaderText.Replace("_", " "));
            }
        }
        public static void setAutoControle(TextBox tb, AutoCompleteStringCollection source)
        {
            tb.AutoCompleteCustomSource = source;
            tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public static void setAutoControle(TextBox tb, DataTable table)
        {
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            foreach (DataRow row in table.Rows)
                source.Add(row[0].ToString());

            tb.AutoCompleteCustomSource = source;
            tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public static void setTooltip(Control ctl, string txt)
        {
            ToolTip tt = new ToolTip();
            tt.InitialDelay = 10;
            tt.SetToolTip(ctl, txt);

        }
        //public static void FocusNextTabbedControl(Control current)
        //{
            
        //    Control ctl = current.Parent.GetNextControl(current, true);
        //    while (ctl != null)
        //    {
        //        if (!ctl.TabStop || !ctl.Enabled )
        //            ctl = ctl.Parent.GetNextControl(ctl, true);
        //        else
        //            break;
        //    }
        //    if (ctl != null)
        //        ctl.Focus();
        //}
        public static void FocusNextTabbedControl(Form parent)
        {
            Control current = parent.ActiveControl;
            if (current == null)
                return;
            Control ctl = parent.GetNextControl(current, true);
            while (ctl != null)
            {
                if (!ctl.TabStop || !ctl.Enabled || !ctl.Visible)
                    ctl = parent.GetNextControl(ctl, true);
                else
                    break;
            }
            if (ctl != null)
                ctl.Focus();
        }
        public static bool IsCtrlSpace(KeyEventArgs e) 
        {
            bool rc = false;
            if (e.Control)
                if (e.KeyCode == Keys.Space)
                {
                    e.SuppressKeyPress = e.Handled = true;
                    rc = true;
                }
            return rc;
        }
        public static string userComputer(string value)
        {
            string str = "";
            if (value != null)
            {
                string[] s = value.Split(new string[] { "][" }, StringSplitOptions.None);
                if (s.Length > 1)
                    str = String.Format("{0} => {1}", s[1].Replace("]", ""), s[0].Replace("[", ""));
                else
                    str = s[0];
            }
            return str;
        }

    }
}
