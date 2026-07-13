

using System.Windows.Forms;
using EspaceSyndic.Formulaires.Common;
using SyndicData.Controller;

namespace EspaceSyndic.Formulaires.Nature;

internal class FindNatureForm : FindStdForm
{
    public readonly NatureController controller = new();

    public FindNatureForm()
    {

    }

    public FindNatureForm(TextBox tbResult)
        : base(tbResult)
    {

    }
    public override void FillListFromFilter(string filter)
    {
        source = controller.GetFindList(filter);
        base.FillListFromFilter(filter);
    }
}