using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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
