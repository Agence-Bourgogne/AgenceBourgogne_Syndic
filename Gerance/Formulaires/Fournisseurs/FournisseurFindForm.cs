using GeranceData.Controller;
namespace Gerance.Formulaires.Fournisseurs
{
    public partial class FournisseurFindForm : Common.CommonFindForm
    {
        public FournisseurFindForm()
        {
            InitializeComponent();
        }
        public override void FillListFromFilter(string filter)
        {
            source = FournisseurController.getController().GetFindList(filter);
            base.FillListFromFilter(filter);
        }

    }
}
