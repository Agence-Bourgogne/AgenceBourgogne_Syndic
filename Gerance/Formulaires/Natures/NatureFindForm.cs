using GeranceData.Controller;

namespace Gerance.Formulaires.Natures
{
    public partial class NatureFindForm : Gerance.Formulaires.Common.CommonFindForm
    {
        public NatureFindForm()
        {
            InitializeComponent();
        }
        public override void FillListFromFilter(string filter)
        {
            source = NatureController.getController().GetFindList(filter);
            base.FillListFromFilter(filter);
        }

    }
}
