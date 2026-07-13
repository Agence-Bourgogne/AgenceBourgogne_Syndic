using System;
using GeranceData.Controller;

namespace Gerance.Formulaires.Locataires
{
    public partial class LocataireLotFindForm : Common.CommonFindForm
    {
        public string ref_immeuble;
        public LocataireLotFindForm()
        {
            InitializeComponent();
        }
        public override void FillListFromFilter(string filter)
        {
            source = LocataireController.getController().GetFindLotList(ref_immeuble);
            base.FillListFromFilter(filter);
        }
        protected override void FillListFromTbFilter()
        {
            var filter = " 1=1 ";
            if (tbRef.Text != "")
                filter += $" and reference like '{tbRef.Text}%' ";
            if (tbNom.Text != "")
                filter += $" and nom like '{tbNom.Text}%' ";
            FillListFromFilter(filter);
        }

    }
}
