using GeranceData.Controller;
namespace Gerance.Formulaires.Locataires
{
    public partial class LocataireFindForm : Common.CommonFindForm
    {
        public LocataireFindForm()
        {
            InitializeComponent();
        }
        public override void FillListFromFilter(string filter)
        {
            source = LocataireController.getController().GetFindList(filter);
            base.FillListFromFilter(filter);
        }

    }
}
