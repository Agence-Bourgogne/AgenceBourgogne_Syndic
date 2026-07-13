using GeranceData.Controller;
namespace Gerance.Formulaires.Biens
{
    public partial class BienFindForm : Gerance.Formulaires.Common.CommonFindForm
    {
        public BienFindForm()
        {
            InitializeComponent();
        }
        public override void FillListFromFilter(string filter)
        {
            source = BienController.getController().GetFindList(filter);
            base.FillListFromFilter(filter);
        }
    }
}
