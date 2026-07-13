//using System.Threading.Tasks;
using SyndicData.Controller;
using EspaceSyndic.Formulaires.Common;
using SyndicData.Entites;


namespace EspaceSyndic.Formulaires.Immeubles
{
    class FindImmeubleCoproprietaireForm : FindStdForm
    {
        public CoproprietaireEntite coproprietaire = null;
        public override void FillListFromFilter(string filter)
        {
            source = LotDescriptionController.getController().getImmeublesCoproprietaire(coproprietaire.id);
            base.FillListFromFilter(filter);
        }

    }
}
