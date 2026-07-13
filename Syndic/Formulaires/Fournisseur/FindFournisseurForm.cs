

using System.Windows.Forms;
using EspaceSyndic.Formulaires.Common;
using SyndicData.Controller;

namespace EspaceSyndic.Formulaires.Fournisseur;

internal class FindFournisseurForm : FindStdForm
{
    public readonly FournisseurController controller = new();


    public FindFournisseurForm()
    {

    }

    public FindFournisseurForm(TextBox tbResult)
        : base(tbResult)
    {

    }


    public override void FillListFromFilter(string filter)
    {
        source = controller.GetFindList(filter);
        base.FillListFromFilter(filter);
    }
}