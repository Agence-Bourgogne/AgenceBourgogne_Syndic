using System;
using CommonProjectsPartners.Controller;
using GeranceData.Entites;
using System.Data;

namespace GeranceData.Controller
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
            return controller;
            //return new NatureController();
        }
        protected override void setListSelectCommand()
        {
            DefaultOrder = "reference";
            base.setListSelectCommand();
        }
        public DataTable getFromChargeLocative()
        {
            //String cmd = " select id, reference, nom, reference_comptabilite, charge_locative, 0 as montant_charge ";
            String cmd = " select id, reference, nom, 0 as montant_charge, 0 as credit, reference_comptabilite";
            cmd += String.Format(" from {0}", getSchemaTable());
            cmd += " where charge_locative > 0";
            
            return getResultSQL(cmd);
        }
    }
}
