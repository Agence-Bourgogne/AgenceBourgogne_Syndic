using System.Collections.Generic;
using Npgsql;

using System.Data;

namespace GeranceData.Controller
{
    public class ImmeubleController :BienController
    {
        static ImmeubleController controller = new ImmeubleController();
        public static ImmeubleController getImmeubleController()
        {
            return controller;
            //return new ImmeubleController();
        }

        public DataTable getLots(string bien_reference)
        {
            var cmd = $" select numero_lot from {getSchemaTable()} where reference = @bien_reference order by 1";

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_reference", bien_reference),
            };

            return getResultSQL(cmd, parameters);
        }
        public DataTable getReferencesLocataires(string bien_reference)
        {
            var cmd =
                $" select l.reference from {getSchemaTable()} b join {getSchema()}.locataire l on l.id = b.locataire_id where b.reference = @bien_reference order by 1";

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_reference", bien_reference),
            };

            return getResultSQL(cmd, parameters);
        }
        public DataTable getFindLocatairesImmeuble(string bien_reference)
        {
            var cmd =
                $" select l.id, l.reference, l.nom from {getSchemaTable()} b join {getSchema()}.locataire l on l.id = b.locataire_id where b.reference = @bien_reference order by l.reference";
            
            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_reference", bien_reference),
            };
            return getResultSQL(cmd, parameters);
        }
    }
}
