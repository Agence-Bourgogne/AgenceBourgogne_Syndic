using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProjectsPartners.Controller;
using GeranceData.Entites;

namespace GeranceData.Controller
{
    public class ComptableController : AbstractBaseController<ComptableEntite>
    {
        static ComptableController controller = new ComptableController();
        public override string getTable()
        {
            return "comptable";
        }

        public static ComptableController getController()
        {
            return controller;
//            return new ComptableController();
        }
        protected override void setListSelectCommand()
        {
            DefaultOrder = "reference";
            base.setListSelectCommand();
        }

    }
}
