using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
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
            var cmd = $"select * from {getSchemaTable()} where immeuble_id = @immeuble_id and code = @code";

            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@code", code)
            };
            var table = getResultSQL(cmd, parameters);
            if ( table != null)
                if (table.Rows.Count > 0)
                    return new AideImmeubleEntite(table.Rows[0]);

            return null;
        }
    }
}
