//using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Controller;
using EspaceSyndic.Formulaires.Common;

namespace EspaceSyndic.Formulaires.Fournisseur
{
    class FindFournisseurForm : FindStdForm
    {
        public FournisseurController controller = new FournisseurController();


        public FindFournisseurForm()
            : base()
        {

        }

        public FindFournisseurForm(TextBox tbResult)
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
