using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeranceData.Controller;
namespace Gerance.Formulaires.Fournisseurs
{
    public partial class FournisseurFindForm : Gerance.Formulaires.Common.CommonFindForm
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
