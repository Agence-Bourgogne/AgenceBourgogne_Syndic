using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Utils;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;

namespace CommonProjectsPartners.Controller
{
    public class UsersController : AbstractBaseController<UserEntite>
    {
        static UsersController controller = new UsersController();

        public override string getTable()
        {
            return "users";
        }
        public static UsersController getController()
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
        public DataTable getListeUsers()
        {
            string cmd = String.Format(" select u.*, r.nom as role from {0} u ", getSchemaTable());
            cmd += " join roles r on r.id  = u.roles_id";
            cmd += " order by reference";

            return getResultSQL(cmd);
        }
    }
}
