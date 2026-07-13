using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
