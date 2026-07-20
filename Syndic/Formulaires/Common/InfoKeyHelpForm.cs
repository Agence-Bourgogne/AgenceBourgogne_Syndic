using System.Data;
using System.Windows.Forms;
using SyndicData.Common;

namespace EspaceSyndic.Formulaires.Common;

internal class InfoKeyHelpForm : HelpForm
{
    public InfoKeyHelpForm(string keyName)
        : base(keyName)
    {
        Text = @"Raccourcis Claviers";
    }

    public void DoFormText(Form parent)
    {
        var table = ParametresDB.getComboData("KEY_CODE");
        var note = "";
        foreach (DataRow row in table.Rows)
        {
            var str = $"{row["code"]}\t{row["param_1"]}";
            note += (note == "" ? "" : "\n") + str;
        }

        if (!"".Equals(note))
        {
            base.DoFormText(parent, note);
            const int height = 13 * 15;
            tbHelp.Height = height + 10;
            Height = height;
            parent.Activate();
        }
        else
        {
            Visible = false;
        }
    }

    public override void DoFormText(Form parent, string note)
    {
        if (!"".Equals(note))
        {
            base.DoFormText(parent, note);
            var height = 13 * 15;
            tbHelp.Height = height + 10;
            Height = height;
            parent.Activate();
        }
        else
        {
            Visible = false;
        }
    }
}