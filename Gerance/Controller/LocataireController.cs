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
using GeranceData.Common;

namespace GeranceData.Controller
{
    public class LocataireController : AbstractBaseController<LocataireEntite>
    {
        static LocataireController controller = new LocataireController();
        public override string getTable()
        {
            return "locataire";
        }

        public static LocataireController getController()
        {
            return controller;
        }
        protected override void setListSelectCommand()
        {
            DefaultOrder = "l.reference";
            string cmd = String.Format("select l.*, c.reference as ref_comptable from {0} l left join {1}.comptable c on c.id = comptable_id order by {2}", getSchemaTable(), getSchema(), DefaultOrder);
            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
        }
        public override DataTable GetFindList(string filter)
        {
            DefaultOrder = "reference";
            return base.GetFindList(filter);
        }
        public DataTable GetFindLotList(string ref_immeuble)
        {
            string cmd = "select b.id, numero_lot as reference, concat(l.prenom, ' ', l.nom ) as nom ";
            cmd += String.Format(" from {0}.biens b", getSchema());
            cmd += String.Format(" join {0} l on b.locataire_id = l.id ", getSchemaTable());
            cmd += String.Format(" where b.reference = @ref_immeuble");

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
               new NpgsqlParameter("@ref_immeuble", ref_immeuble),
            };
            return getResultSQL(cmd, parameters);
        }

        public DataTable getListeLocataireFromBiens()
        {
            string cmd = " select ";
            cmd += "l.id, l.reference as locataire, concat(l.nom, ' ', l.prenom) as nom_locataire, l.adresse adresse_loca,  concat( l.codepostal, ' ', l.ville) as ville_loca, ";
            cmd += "b.reference as ref_bien, b.nom as nom_bien";

            cmd += String.Format(" from {0} l", getSchemaTable());
            cmd += String.Format(" join {0}.biens b on l.id = b.locataire_id", getSchema());
            cmd += " order by l.reference";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                //new NpgsqlParameter("dtDeb", dtDeb),
                //new NpgsqlParameter("dtFin", dtFin),
                //new NpgsqlParameter("proprietaire_id", proprietaire_id),
            };
            return getResultSQL(cmd, parameters);
        }
        public LocataireEntite getFirstLocataireFromBiens()
        {
            string cmd = " select l.* ";
            cmd += String.Format(" from {0} l", getSchemaTable());
            cmd += String.Format(" join {0}.biens b on l.id = b.locataire_id", getSchema());
            cmd += " order by l.reference limit 1";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                //new NpgsqlParameter("dtDeb", dtDeb),
                //new NpgsqlParameter("dtFin", dtFin),
                //new NpgsqlParameter("proprietaire_id", proprietaire_id),
            };
            Console.WriteLine(cmd);
            LocataireEntite entite = null;
            DataTable table = getResultSQL(cmd, parameters);
            if (table != null)
                if (table.Rows.Count > 0)
                    entite = new LocataireEntite(table.Rows[0]);

            return entite;
        }
        public LocataireEntite getLocataireBien(string where, List<NpgsqlParameter> parameters = null)
        {
            LocataireEntite entite = default(LocataireEntite);
            String cmd = String.Format("select * from {0} l", getSchemaTable());
            cmd += String.Format(" join (select locataire_id from {0}.biens) b on l.id = b.locataire_id {1} limit 1", getSchema(), where);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
            if (parameters != null)
            {
                foreach (NpgsqlParameter parameter in parameters)
                {
                    adapter.SelectCommand.Parameters.AddWithValue(parameter.ParameterName, parameter.NpgsqlValue);
                }
            }
            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    entite = new LocataireEntite();
                    entite.setValues(row);
                    return entite;
                }
                return null;
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return entite;
        }
        public DataTable getListLocatairesCharge(string locataire_id )
        {
            string cmd = String.Format("select id from {0} where id =@locataire_id", getSchemaTable());
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("locataire_id", locataire_id),
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getHdrLocataireCharge(string locataire_id)
        {
            string cmd = "select concat(l.nom, ' ', l.prenom) as nom, l.reference, l.adresse, concat(l.codepostal, ' ', l.ville ) as ville, b.date_entree ";
            cmd += String.Format(" from {0} l join {1}.biens b on b.locataire_id =l.id ", getSchemaTable(), getSchema());
            cmd += " where l.id = @locataire_id";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("locataire_id", locataire_id),
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeRetardPaiements(decimal seuil, string ref_locataire = "")
        {
            string cmd = "select id, reference, concat(nom, ' ', prenom) as locataire, total_du, date_reglement, adresse, concat(codepostal, ' ', ville) as ville ";
            cmd += String.Format(" from {0} l", getSchemaTable());
            cmd += string.Format(" join (select max(date_reglement) as date_reglement, locataire_id from {0}.reglements group by locataire_id) r on r.locataire_id = l.id", getSchema());
            cmd += " where total_du > @seuil ";
            
            if (ref_locataire != "")
                cmd += " and reference = @ref_locataire";

            cmd += " order by reference";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("seuil", seuil),
                new NpgsqlParameter("ref_locataire", ref_locataire),
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getSoldeLocataire(string ref_locataire="")
        {
            string cmd = " select ";

            cmd += " l.id, l.reference, concat(l.nom, ' ', l.prenom) as locataire, l.adresse, sum(debit)as debit, sum(credit) as credit, sum(debit) - sum(credit) as solde";
            cmd += " from ( ";
            cmd += string.Format(" select id, locataire_id, montant_quittance as debit, 0 as credit from {0}.quittances q where statut != @statut_del", getSchema());
            cmd += " union ";
            cmd += string.Format(" select id, locataire_id, debit as debit, credit as credit from {0}.reglements r where statut != @statut_del", getSchema());
            cmd += " ) c";
            cmd += string.Format(" join {0} l on l.id = c.locataire_id", getSchemaTable());
            if (ref_locataire != "")
                cmd += " where l.reference = @ref_locataire";
            cmd += " group by 1, 2, 3 ";
            cmd += " order by reference";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("ref_locataire", ref_locataire),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getDetailCompteLocataire(string ref_locataire)
        {
            string cmd = "select l.reference, l.nom, date_ecriture, libelle, debit, credit ";
            cmd += " from ( ";
            cmd += String.Format("select id, locataire_id, date_quittance as date_ecriture, 'MONTANT DU LOYER' as libelle, montant_quittance as debit, 0 as credit from {0}.quittances q where statut!= @statut_del", getSchema());
            cmd += " union ";
            cmd += String.Format("select id, locataire_id , date_reglement, libelle, debit as debit, credit as credit from {0}.reglements r where statut!= @statut_del", getSchema() );
            cmd += " ) c ";
            cmd += string.Format(" join {0} l on l.id = c.locataire_id", getSchemaTable());
            if (ref_locataire != "")
                cmd += " where l.reference = @ref_locataire";

            cmd += " order by date_ecriture";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("ref_locataire", ref_locataire),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }
    }
}
