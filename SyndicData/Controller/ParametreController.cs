using System.Collections.Generic;
using System.Data;
using CommonProjectsPartners.Controller;
using Npgsql;
using SyndicData.Entites;

namespace SyndicData.Controller;

public class ParametreController : AbstractBaseController<ParametreEntite>
{
    public static readonly ParametreController controller = new();

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
        if (string.IsNullOrEmpty(groupe.param_1) )
            return null;
        var cmd = $" select * from {getSchemaTable()} ";

        cmd += " where groupe = @code ";
        if ( groupe.param_2 != null)
            if ( groupe.param_2.Trim() != "")
                cmd += " order by "+ groupe.param_2;
        var parameters = new List<NpgsqlParameter>
        {
            new("@code", groupe.code)
        };

        return getResultSQL(cmd, parameters);
    }
    public ParametreEntite getGroupeEntite(string code)
    {
        var cmd = $" select * from {getSchemaTable()} ";

        cmd += " where groupe = 'HDR_GROUPE' and code = @code ";
        var parameters = new List<NpgsqlParameter>
        {
            new("@code", code)
        };
        ParametreEntite groupe = null;
        var table = getResultSQL(cmd, parameters);
        if (table != null)
            if (table.Rows.Count > 0)
                groupe = new ParametreEntite(table.Rows[0]);
        return groupe;
    } 
}