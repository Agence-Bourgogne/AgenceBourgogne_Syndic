

using EspaceSyndic.Formulaires.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Coproprietaire;

internal class FindCoproprietaireImmeubleForm : FindStdForm
{
//        public CoproprietaireController controller = new CoproprietaireController();
    public readonly ImmeubleEntite immeuble = null;
    public override void FillListFromFilter(string filter)
    {
        source = LotDescriptionController.getController().getListeCoproprietaires(immeuble);
        base.FillListFromFilter(filter);
    }
}