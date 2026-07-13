using EspaceSyndic.Formulaires.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Coproprietaire;

internal class FindLotCoproprietaireImmeubleForm : FindStdForm
{
    public ImmeubleEntite immeuble = null;
    public readonly CoproprietaireEntite coproprietaire = null;
    public override void FillListFromFilter(string filter)
    {
        source = LotDescriptionController.getController().getListeLotCoproprietaires(immeuble, coproprietaire);
        base.FillListFromFilter(filter);
    }
}