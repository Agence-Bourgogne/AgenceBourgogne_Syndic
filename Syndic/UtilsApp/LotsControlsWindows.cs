using System.Data;
using System.Windows.Forms;
using SyndicData.Entites;

namespace EspaceSyndic.UtilsApp;

public static class LotsControlsWindows
{
    public static AutoCompleteStringCollection getLotsAutocomplete(ImmeubleEntite immeuble)
    {
        var lotAuto = new AutoCompleteStringCollection();
        var table = immeuble.getListeLots();
        foreach (DataRow row in table.Rows)
        {
            lotAuto.Add(row["numero_lot"].ToString());
        }
        return lotAuto;
    }
}