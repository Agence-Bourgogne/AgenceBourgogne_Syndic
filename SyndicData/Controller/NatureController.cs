using SyndicData.Entites;
using CommonProjectsPartners.Controller;

namespace SyndicData.Controller
{
    public class NatureController : AbstractBaseController<NatureEntite>
    {
        static NatureController controller = new NatureController();
        public override string getTable()
        {
            return "nature";
        }
        public static NatureController getController()
        {
//            return new NatureController();
            return controller;
        }
        public NatureController()
        {
            DefaultOrder = "reference";
        }
    }
}
