using System;
using GeranceData.Controller;

namespace Gerance.Formulaires.Locataires
{
    public partial class LocataireLotFindForm : Gerance.Formulaires.Common.CommonFindForm
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
            string filter = " 1=1 ";
            if (tbRef.Text != "")
                filter += String.Format(" and reference like '{0}%' ", tbRef.Text);
            if (tbNom.Text != "")
                filter += String.Format(" and nom like '{0}%' ", tbNom.Text);
            FillListFromFilter(filter);
        }

    }
}
