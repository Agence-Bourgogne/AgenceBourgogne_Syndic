using System;
using CommonProjectsPartners.Entites;
using System.Data;
namespace CommonProjectsPartners.Controller
{
    public class RolesController : AbstractBaseController<RoleEntite>
    {
        static RolesController controller = new RolesController();
        
        public override string getTable()
        {
            return "roles";
        }
        public static RolesController getController()
        {
            return controller;
        }
        public override string getSchema()
        {
            return "";
        }
        public override string getSchemaTable()
        {
            return getTable();
        }
        public DataTable GetComboRoles()
        {
            string cmd = String.Format(" select id, nom from {0} ", getSchemaTable());
            return getResultSQL(cmd);
        }
    }
}
