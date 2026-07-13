using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Controller;
using EspaceSyndic.Formulaires.Common;

namespace EspaceSyndic.Formulaires.Nature
{
    class FindNatureForm : FindStdForm
    {
        public NatureController controller = new NatureController();

        public FindNatureForm()
            : base()
        {

        }

        public FindNatureForm(TextBox tbResult)
            : base(tbResult)
        {

        }
        public override void FillListFromFilter(string filter)
        {
            source = controller.GetFindList(filter);
            base.FillListFromFilter(filter);
        }
    }
}
