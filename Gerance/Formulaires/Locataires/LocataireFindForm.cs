using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeranceData.Controller;
namespace Gerance.Formulaires.Locataires
{
    public partial class LocataireFindForm : Gerance.Formulaires.Common.CommonFindForm
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
