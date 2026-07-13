

using System.Windows.Forms;
using EspaceSyndic.Formulaires.Common;
using SyndicData.Controller;

namespace EspaceSyndic.Formulaires.Immeubles;

internal class FindImmeubleForm : FindStdForm
{
    public readonly ImmeubleController controller = new();
    public FindImmeubleForm()
    {
    }
    public FindImmeubleForm(TextBox tbResult)
        : base(tbResult)
    {

    }
    public override void FillListFromFilter(string filter)
    {
        source = controller.GetFindList(filter);
        base.FillListFromFilter(filter);
    }
}