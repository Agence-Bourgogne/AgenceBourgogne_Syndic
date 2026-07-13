using SyndicData.Entites;
using CommonProjectsPartners.Controller;

namespace SyndicData.Controller
{
    public class FournisseurController : AbstractBaseController<FournisseurEntite>
    {
        static FournisseurController controller = new FournisseurController();
        public override string getTable()
        {
            return "fournisseur";
        }
        public static FournisseurController getController()
        {
            return controller;
            //return new FournisseurController();
        }
        public FournisseurController()
        {
            DefaultOrder = "reference";
        }
    }
}
