using System;
using System.Collections.Generic;
using CommonProjectsPartners.Controller;
using SyndicData.Entites;
using System.Data;
using Npgsql;

namespace SyndicData.Controller
{
    public class ParametreController : AbstractBaseController<ParametreEntite>
    {
        public static ParametreController controller = new ParametreController();

        public override string getTable()
        {
            return "parametres";
        }
        public override string getSchema()
        {
            return "public";
        }

        public DataTable getListFromEntiteGroupe(ParametreEntite groupe)
        {
            if (groupe.param_1 == "" || groupe.param_1 == null )
                return null;
            var cmd = $" select * from {getSchemaTable()} ";

            cmd += " where groupe = @code ";
            if ( groupe.param_2 != null)
                if ( groupe.param_2.Trim() != "")
                    cmd += " order by "+ groupe.param_2;
            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter ("@code", groupe.code),
            };

            return getResultSQL(cmd, parameters);
        }
        public ParametreEntite getGroupeEntite(string code)
        {
            var cmd = $" select * from {getSchemaTable()} ";

            cmd += " where groupe = 'HDR_GROUPE' and code = @code ";
            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter ("@code", code),
            };
            ParametreEntite groupe = null;
            var table = getResultSQL(cmd, parameters);
            if (table != null)
                if (table.Rows.Count > 0)
                    groupe = new ParametreEntite(table.Rows[0]);
            return groupe;
        } 
    }
}
