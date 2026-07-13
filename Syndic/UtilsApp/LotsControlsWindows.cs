using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Entites;
using System.Data;
namespace EspaceSyndic.UtilsApp
{
    public class LotsControlsWindows
    {
        public static AutoCompleteStringCollection getLotsAutocomplete(ImmeubleEntite immeuble)
        {
            AutoCompleteStringCollection lotAuto = new AutoCompleteStringCollection();
            DataTable table = immeuble.getListeLots();
            foreach (DataRow row in table.Rows)
            {
                lotAuto.Add(row["numero_lot"].ToString());
            }
            return lotAuto;
        }
    }
}
