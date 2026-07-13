using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using SyndicData.Entites;
using Npgsql;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Controller;

namespace SyndicData.Controller
{
    public class LotRepartitionController : AbstractBaseController<LotRepartitionEntite>
    {
        static LotRepartitionController controller = new LotRepartitionController();
        public override string getTable()
        {
            return "lot_repartition";
        }

        public static LotRepartitionController getController()
        {
            return controller;
            //return new LotRepartitionController();
        }
        public DataTable GetLotsRepartition(ImmeubleEntite immeuble)
        {
            return GetLotsRepartition(immeuble.id);
        }

        public DataTable GetLotRepartitionHaveMultiCompteur(string immeuble_id, string base_repart)
        {
            string cmd = String.Format("select * from {0} ", getSchemaTable());
            cmd += " where immeuble_id = @immeuble_id ";
            cmd += "and reference = @reference and valeur > 1 ";
            cmd += "order by ligne, colonne";
            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
            adapter.SelectCommand.Parameters.AddWithValue("@immeuble_id", immeuble_id);
            adapter.SelectCommand.Parameters.AddWithValue("@reference", base_repart);
            //            adapter.SelectCommand.Parameters.AddWithValue("@lot_id", lot_id);

            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            return table;

        }

        public DataTable GetLotsRepartition(string immeuble_id)
        {
            string cmd = String.Format("select * from {0} ", getSchemaTable());
            cmd += " where immeuble_id = @immeuble_id order by ligne, colonne";

            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
            adapter.SelectCommand.Parameters.AddWithValue("@immeuble_id", immeuble_id);
//            adapter.SelectCommand.Parameters.AddWithValue("@lot_id", lot_id);

            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            return table;
        }
        public DataTable GetLotsRepartitionFromBase(string immeuble_id, string base_repart)
        {
            string cmd = String.Format("select lr.*, ld.coproprietaire_id as copro_id from {0} lr", getSchemaTable());

            cmd += String.Format(" join {0}.immeuble i on i.id = lr.immeuble_id ", getSchema());
            cmd += String.Format(" join {0}.lot_description ld on ld.id = lr.lot_id ", getSchema());
            cmd += " where lr.immeuble_id = @immeuble_id and lr.reference = @base_repart ";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@base_repart", base_repart),

            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable GetListLotsDescription(string immeuble_id, string base_repart)
        {
            string cmd = "select s.cpt as Compteur, ref_cpt, null as ancien, null as nouveau, null as index, null as montant, l.id , c.id as coproprietaire_id, l.numero_lot, c.reference as coproprietaire, c.nom, c.prenom from ";
            cmd += "( \n";

            cmd += String.Format("select 'cpt 5' as cpt, 5 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 5 union \n", getSchemaTable());
            cmd += String.Format("select 'cpt 4' as cpt, 4 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 5 union \n", getSchemaTable());
            cmd += String.Format("select 'cpt 3' as cpt, 3 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 5 union \n", getSchemaTable());
            cmd += String.Format("select 'cpt 2' as cpt, 2 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 5 union \n", getSchemaTable());
            cmd += String.Format("select 'cpt 1' as cpt, 1 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 5 union \n", getSchemaTable());

            cmd += String.Format("select 'cpt 4' as cpt, 4 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 4 union \n", getSchemaTable());
            cmd += String.Format("select 'cpt 3' as cpt, 3 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 4 union \n", getSchemaTable());
            cmd += String.Format("select 'cpt 2' as cpt, 2 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 4 union \n", getSchemaTable());
            cmd += String.Format("select 'cpt 1' as cpt, 1 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 4 union \n", getSchemaTable());

            cmd += String.Format("select 'cpt 3' as cpt, 3 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 3 union \n", getSchemaTable());
            cmd += String.Format("select 'cpt 2' as cpt, 2 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 3 union \n", getSchemaTable());
            cmd += String.Format("select 'cpt 1' as cpt, 1 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 3 union \n", getSchemaTable());

            cmd += String.Format("select 'cpt 2' as cpt, 2 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 2 union \n", getSchemaTable());
            cmd += String.Format("select 'cpt 1' as cpt, 1 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 2 union \n", getSchemaTable());
            
//            cmd += String.Format("select 'cpt 1' as cpt, 1 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur = 1 union \n", getSchemaTable());

            cmd += String.Format("select '' as cpt, 1 as ref_cpt, * from {0} where immeuble_id = @immeuble_id and reference = @base_repart and valeur <= 1 \n", getSchemaTable());

            cmd += " ) s ";
            cmd += "join agence.lot_description l on l.id = lot_id ";
            cmd += "join agence.coproprietaire c on c.id = l.coproprietaire_id " ;
            cmd += "order by l.numero_lot, cpt ";

            Console.WriteLine(cmd);
            
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@base_repart", base_repart),
            };
            return getResultSQL(cmd, parameters);
        }
    }
}
