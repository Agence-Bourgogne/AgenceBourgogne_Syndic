using System.Windows.Forms;
using SyndicData.Common;

namespace EspaceSyndic.Formulaires.Common;

internal static class StandardFunctionnalities
{
    public static string GetKeyPressText(string keyValue)
    {
        var keyString = "";
        var row = ParametresDB.get("KEY_CODE", keyValue);
        if (row != null)
            keyString = row["param_1"].ToString();
        return keyString;
    }

    public static void Standard_KeyPress(object sender, KeyEventArgs e, bool bClear = true)
    {
        if (sender is TextBox tb)
        {
            var keyText = GetKeyPressText(e.KeyCode.ToString());
            if (keyText != "")
            {
                if (bClear)
                    tb.Text = keyText;
                else
                    tb.Text += keyText;
                tb.Select(tb.Text.Length, tb.Text.Length);
                e.Handled = true;
            }
        }
    }
}