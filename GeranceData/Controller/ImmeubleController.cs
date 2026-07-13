using System;
using System.Collections.Generic;
using Npgsql;

using System.Data;
using GeranceData.Entites;
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
            string cmd = String.Format(" select numero_lot from {0} where reference = @bien_reference order by 1", getSchemaTable());

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_reference", bien_reference),
            };

            return getResultSQL(cmd, parameters);
        }
        public DataTable getReferencesLocataires(string bien_reference)
        {
            string cmd = String.Format(" select l.reference from {0} b join {1}.locataire l on l.id = b.locataire_id where b.reference = @bien_reference order by 1", getSchemaTable(), getSchema());

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_reference", bien_reference),
            };

            return getResultSQL(cmd, parameters);
        }
        public DataTable getFindLocatairesImmeuble(string bien_reference)
        {
            string cmd = String.Format(" select l.id, l.reference, l.nom from {0} b join {1}.locataire l on l.id = b.locataire_id where b.reference = @bien_reference order by l.reference", getSchemaTable(), getSchema());
            
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_reference", bien_reference),
            };
            return getResultSQL(cmd, parameters);
        }
        public LocataireEntite getLocataire(string bien_reference, int numero_lot)
        {
            string cmd = String.Format(" select l.* from {0} b join {1}.locataire l on l.id = b.locataire_id where b.reference = @bien_reference and b.numero_lot = @numero_lot order by 1", getSchemaTable(), getSchema());
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_reference", bien_reference),
                new NpgsqlParameter("numero_lot", numero_lot),
            };
            DataTable table = getResultSQL(cmd, parameters);
            if (table != null)
            {
                return new LocataireEntite(table.Rows[0]);
            }
            return null;
        }
    }
}
