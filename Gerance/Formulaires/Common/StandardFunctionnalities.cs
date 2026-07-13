using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using GeranceData.Common;

namespace Gerance.Formulaires.Common
{
    class StandardFunctionnalities
    {

        public static string GetKeyPressText(string keyValue)
        {
            string keyString = "";
            DataRow row = ParametresDB.get("KEY_CODE", keyValue);
            if (row != null)
                keyString = row["param_1"].ToString();
            return keyString;
        }
        public static void Standard_KeyPress(object sender, KeyEventArgs e, bool bClear = true)
        {
            if (sender is TextBox)
            {
                string keyText = GetKeyPressText(e.KeyCode.ToString());
                if (keyText != "")
                {
                    TextBox tb = ((TextBox)sender);
                    if ( bClear )
                        tb.Text = keyText;
                    else
                        tb.Text += keyText;
                    tb.Select(tb.Text.Length, tb.Text.Length);
                    e.Handled = true;
                }
            }
        }
    }
}
