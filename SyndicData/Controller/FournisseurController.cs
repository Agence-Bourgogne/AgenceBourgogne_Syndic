using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Windows.Forms;
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
