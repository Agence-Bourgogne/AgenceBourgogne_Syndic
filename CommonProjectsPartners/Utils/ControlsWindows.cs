using System;
using System.Windows.Forms;
using System.Globalization;
using System.Data;

namespace CommonProjectsPartners.Utils
{
    public static class ControlsWindows
    {
        public static void addColumn(DataGridView grid, String title, int width=80)
        {
            var column = new DataGridViewColumn();
            column.HeaderText = title;
            column.Width = width;
            grid.Columns.Add(column);

        }
        public static void ToTitleCase(DataGridViewColumnCollection cols)
        {
            var textInfo = new CultureInfo("fr-FR", false).TextInfo;
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
            var source = new AutoCompleteStringCollection();
            foreach (DataRow row in table.Rows)
                source.Add(row[0].ToString());

            tb.AutoCompleteCustomSource = source;
            tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public static void setTooltip(Control ctl, string txt)
        {
            var tt = new ToolTip();
            tt.InitialDelay = 10;
            tt.SetToolTip(ctl, txt);

        }
        public static void FocusNextTabbedControl(Form parent)
        {
            var current = parent.ActiveControl;
            if (current == null)
                return;
            var ctl = parent.GetNextControl(current, true);
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
            var rc = false;
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
            var str = "";
            if (value != null)
            {
                var s = value.Split(new string[] { "][" }, StringSplitOptions.None);
                if (s.Length > 1)
                    str = $"{s[1].Replace("]", "")} => {s[0].Replace("[", "")}";
                else
                    str = s[0];
            }
            return str;
        }

    }
}
