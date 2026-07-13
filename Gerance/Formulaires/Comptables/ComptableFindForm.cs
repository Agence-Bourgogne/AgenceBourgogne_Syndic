using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using GeranceData.Controller;
namespace Gerance.Formulaires.Comptables
{
    public partial class ComptableFindForm : Gerance.Formulaires.Common.CommonFindForm
    {
        public ComptableFindForm()
        {
            InitializeComponent();
        }
        public override void FillListFromFilter(string filter)
        {
            source = ComptableController.getController().GetFindList(filter);
            base.FillListFromFilter(filter);
        }
    }
}
