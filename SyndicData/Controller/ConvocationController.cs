using System.Collections.Generic;
using System.Data;
using CommonProjectsPartners.Controller;
using Npgsql;
using SyndicData.Entites;

namespace SyndicData.Controller;

internal class ConvocationController : AbstractBaseController<ConvocationEntite>
{
    private static readonly ConvocationController controller = new();

    public override string getTable()
    {
        return "convocation";
    }

    public static ConvocationController getController()
    {
        return controller;
    }

    public List<ConvocationDescriptionEntite> getListeDescription(string convocation_id)
    {
        List<ConvocationDescriptionEntite> list = null;

        var cmd = $" select * from {getSchema()}.convocation_description where convocation_id = @convocation_id";

        var parameters = new List<NpgsqlParameter>
        {
            new("@convocation_id", convocation_id)
        };

        var table = getResultSQL(cmd, parameters);
        if (table != null)
            if (table.Rows.Count > 0)
            {
                list = [];
                foreach (DataRow row in table.Rows) list.Add(new ConvocationDescriptionEntite(row));
            }

        return list;
    }
}