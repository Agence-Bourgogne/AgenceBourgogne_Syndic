using System.Windows.Forms;
using EspaceSyndic.Formulaires.Common;
using SyndicData.Controller;

namespace EspaceSyndic.Formulaires.Immeubles;

internal class FindImmeubleForm : FindStdForm
{
    private readonly ImmeubleController controller = new();

    public FindImmeubleForm()
    {
    }

    public FindImmeubleForm(TextBox tbResult)
        : base(tbResult)
    {
    }

    protected override void FillListFromFilter(string filter)
    {
        source = controller.GetFindList(filter);
        base.FillListFromFilter(filter);
    }
}