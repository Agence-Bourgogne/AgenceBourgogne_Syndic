using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Utils;
using SyndicData.Entites;
using CommonProjectsPartners.Controller;
namespace SyndicData.Controller
{
    public class AideImmeubleController : AbstractBaseController<AideImmeubleEntite>
    {
        static AideImmeubleController controller = new AideImmeubleController();
        public override string getTable()
        {
            return "aide_immeuble";
        }

        public static AideImmeubleController getController()
        {
//            return new AideImmeubleController();
            return controller;
        }

        public AideImmeubleEntite getAideImmeuble ( string immeuble_id, string code) 
        {
            string cmd = String.Format("select * from {0} where immeuble_id = @immeuble_id and code = @code", getSchemaTable());

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@code", code)
            };
            DataTable table = getResultSQL(cmd, parameters);
            if ( table != null)
                if (table.Rows.Count > 0)
                    return new AideImmeubleEntite(table.Rows[0]);

            return null;
        }
    }
}
