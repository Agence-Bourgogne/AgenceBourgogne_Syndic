//using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Controller;
using EspaceSyndic.Formulaires.Common;

namespace EspaceSyndic.Formulaires.Immeubles
{
    class FindImmeubleForm : FindStdForm
    {
        public ImmeubleController controller = new ImmeubleController();
        public FindImmeubleForm()
            : base()
        {
        }
        public FindImmeubleForm(TextBox tbResult)
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
