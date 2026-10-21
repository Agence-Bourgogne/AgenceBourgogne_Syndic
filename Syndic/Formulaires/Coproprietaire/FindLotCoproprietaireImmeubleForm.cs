using EspaceSyndic.Formulaires.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Coproprietaire;

internal class FindLotCoproprietaireImmeubleForm : FindStdForm
{
    private readonly CoproprietaireEntite coproprietaire = null;
    public ImmeubleEntite immeuble = null;

    protected override void FillListFromFilter(string filter)
    {
        source = LotDescriptionController.getController().getListeLotCoproprietaires(immeuble, coproprietaire);
        base.FillListFromFilter(filter);
    }
}