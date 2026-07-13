using System;
using System.Collections.Generic;
using CommonProjectsPartners.Controller;
using GeranceData.Entites;
using System.Data;
using Npgsql;

namespace GeranceData.Controller
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
        //public virtual string getSchemaTable()
        //{
        //    return String.Format(String.Format("{0}.{1}", getSchema(), getTable()));
        //}

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
    }
}
