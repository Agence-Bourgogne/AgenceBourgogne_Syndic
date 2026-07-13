//using System.Threading.Tasks;
using SyndicData.Controller;
using EspaceSyndic.Formulaires.Common;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Coproprietaire
{
    class FindCoproprietaireImmeubleForm : FindStdForm
    {
//        public CoproprietaireController controller = new CoproprietaireController();
        public ImmeubleEntite immeuble = null;
        public override void FillListFromFilter(string filter)
        {
            source = LotDescriptionController.getController().getListeCoproprietaires(immeuble);
            base.FillListFromFilter(filter);
        }
    }
}
