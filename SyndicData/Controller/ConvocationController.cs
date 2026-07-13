using System.Collections.Generic;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Controller;
using SyndicData.Entites;

namespace SyndicData.Controller
{
    class ConvocationController : AbstractBaseController<ConvocationEntite>
    {
        static ConvocationController controller = new ConvocationController();
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

            string cmd = string.Format(" select * from {0}.convocation_description where convocation_id = @convocation_id", getSchema());

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter ("@convocation_id", convocation_id),
            };

            DataTable table = getResultSQL(cmd, parameters);
            if ( table != null)
                if (table.Rows.Count > 0)
                {
                    list = new List<ConvocationDescriptionEntite>();
                    foreach (DataRow row in table.Rows)
                    {
                        list.Add(new ConvocationDescriptionEntite(row));
                    }
                }
            return list;
        }
    }
}
