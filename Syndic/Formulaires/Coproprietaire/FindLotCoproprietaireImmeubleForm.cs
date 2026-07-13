using SyndicData.Controller;
using EspaceSyndic.Formulaires.Common;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Coproprietaire
{
    class FindLotCoproprietaireImmeubleForm : FindStdForm
    {
        public ImmeubleEntite immeuble = null;
        public CoproprietaireEntite coproprietaire = null;
        public override void FillListFromFilter(string filter)
        {
            source = LotDescriptionController.getController().getListeLotCoproprietaires(immeuble, coproprietaire);
            base.FillListFromFilter(filter);
        }
    }
}
