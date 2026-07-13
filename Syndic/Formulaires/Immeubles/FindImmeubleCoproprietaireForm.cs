using EspaceSyndic.Formulaires.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Immeubles;

internal class FindImmeubleCoproprietaireForm : FindStdForm
{
    public readonly CoproprietaireEntite coproprietaire = null;
    public override void FillListFromFilter(string filter)
    {
        source = LotDescriptionController.getController().getImmeublesCoproprietaire(coproprietaire.id);
        base.FillListFromFilter(filter);
    }

}