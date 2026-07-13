using GeranceData.Controller;
namespace Gerance.Formulaires.Proprietaires
{
    public partial class ProprietaireFindForm : Gerance.Formulaires.Common.CommonFindForm
    {
        public ProprietaireFindForm()
        {
            InitializeComponent();
        }
        public override void FillListFromFilter(string filter)
        {
            source = ProprietaireController.getController().GetFindList(filter);
            base.FillListFromFilter(filter);
        }
    }
}
