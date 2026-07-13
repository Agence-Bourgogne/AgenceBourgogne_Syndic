using System.Globalization;
using System.Windows.Forms;

namespace CommonProjectsPartners.Utils;

public static class ControlsWindows
{
    public static void addColumn(DataGridView grid, string title, int width=80)
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

        ctl?.Focus();
    }
}