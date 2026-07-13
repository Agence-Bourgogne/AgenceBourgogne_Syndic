using GeranceData.Controller;
using Gerance.Formulaires.Common;
namespace Gerance.Formulaires.Biens
{
    class LocatairesImmeubleFindForm : CommonFindForm
    {
        private string bien_ref = "";

        public LocatairesImmeubleFindForm(string bien_ref)
        {
            this.bien_ref = bien_ref;
        }

        public override void FillListFromFilter(string filter)
        {
            source = ImmeubleController.getImmeubleController().getFindLocatairesImmeuble(bien_ref);
            base.FillListFromFilter(filter);
        }
    }
}
