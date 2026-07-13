using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonProjectsPartners.Controller;
using GeranceData.Entites;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Utils;
using System.Windows.Forms;

namespace GeranceData.Controller
{
    public class IndiceController : AbstractBaseController<IndiceEntite>
    {
        static IndiceController controller = new IndiceController();
        public override string getTable()
        {
            return "indices";
        }
        public static IndiceController getController()
        {
            return controller;
            //return new IndiceController();
        }
        public DataTable getListIndices(string reference)
        {
            string cmd = String.Format("select * from {0} where reference = @reference order by annee desc, trimestre desc", getSchemaTable());
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter ("@reference", reference),
            };
            return getResultSQL(cmd, parameters);
        }
        public bool updateIndices ( string code, DataTable table)
        {
            bool rc = false;
            NpgsqlConnection cnx = Database.GetInstance();
            NpgsqlTransaction trx = cnx.BeginTransaction();

            try
            {
                //foreach (DataRow row in table.Rows)
                for (int index = 0; index < table.Rows.Count; index++ )
                {
                    DataRow row = table.Rows[index];

                    int annee = Int16.Parse(row[0].ToString());
                    int trimestre = Int16.Parse(row[1].ToString());
                    decimal valeur = Decimal.Parse(row[2].ToString());
                    decimal variation = 0;
                    if ( index < table.Rows.Count -4)
                    {
                        DataRow rowAncien = table.Rows[index+4];
                        decimal ancien = Decimal.Parse(rowAncien[2].ToString());
                        variation = ((valeur / ancien) - 1) * 100;
                    }

                    List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                        new NpgsqlParameter( "@reference", code),
                        new NpgsqlParameter( "@annee", annee),
                        new NpgsqlParameter( "@trimestre", trimestre),
                    };
                    IndiceEntite indice = getEntite(" where reference = @reference and annee = @annee and trimestre = @trimestre", parameters);
                    if (indice == null)
                        indice = new IndiceEntite();
                    indice.reference = code;
                    indice.annee = annee;
                    indice.trimestre = trimestre;
                    indice.indice = valeur;
                    indice.variation = variation;

                    if (!doInsertOrUpdate(indice))
                        throw new Exception("Erreur indice");
                }
                trx.Commit();
                rc = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trx.Rollback();
            }
            return rc;
        }
    }
}
