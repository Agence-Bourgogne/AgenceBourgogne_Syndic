using System;
using System.Collections.Generic;
//using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Windows.Forms;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using CommonProjectsPartners.Controller;

namespace SyndicData.Controller
{
    public class SaisieReglementController : AbstractBaseController<SaisieReglementEntite>
    {
        static SaisieReglementController controller = new SaisieReglementController();
        public override string getTable()
        {
            return "saisie_reglement";
        }
        public static SaisieReglementController getController()
        {
            //return new SaisieReglementController();
            return controller;
        }

        public DataTable GetAllElements(string immeuble_id , DateTime dtDeb, DateTime dtFin)
        {
            string cmd = String.Format("select r.*, c.reference as ref_copro, i.reference as ref_imm from {0} r ", getSchemaTable());
            cmd += " join agence.coproprietaire c on c.id = r.coproprietaire_id ";
            cmd += " join agence.immeuble i on i.id = r.immeuble_id ";
            cmd += " where r.statut!=@statut";

            if (immeuble_id != "")
                cmd += " and immeuble_id = @immeuble_id";

            if (dtDeb != Database.NullDate)
                cmd += " and date_reference >= @dtDeb";
            if (dtFin != Database.NullDate)
                cmd += " and date_reference <= @dtFin";
            
            cmd += " order by i.reference";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Supprime),
                new NpgsqlParameter("@dtDeb", dtDeb),
                new NpgsqlParameter("@dtFin", dtFin)
            };

            return getResultSQL(cmd, parameters);
        }
        public DataTable getGridRowSaisieReglement(string liasse_id)
        {
            String schema = getSchema();
            String cmd = " Select ";
            cmd += " concat(c.reference, ':',  c.nom, ' ', c.prenom) as \"Coproprietaire\", ";
            cmd += " concat(i.reference, ':',  i.nom) as \"Immeuble\", ";
            cmd += " concat ( n.reference, ':', n.nom) as \"Nature\", ";
            cmd += " e.montant, e.libelle as \"Libellé Ecriture\", ";
            cmd += " e.date_reference as \"Date Ecriture\", ";
            cmd += " c.reference as coproprietaire_ref, ";
            cmd += " i.reference as immeuble_ref, ";
            cmd += " n.reference as nature_ref, ";

            //            cmd += " l.numero_lot as \"Lot\", e.lot_id, " 
            cmd += " e.emetteur, e.banque, ";
            cmd += " e.liasse_id, e.immeuble_id, e.nature_id, e.coproprietaire_id, ";
            cmd += "  e.id";
            cmd += String.Format(" from {0} e ", getSchemaTable());
            cmd += String.Format(" left join {0}.immeuble i on i.id = e.immeuble_id", schema);
            cmd += String.Format(" left join {0}.coproprietaire c on c.id = e.coproprietaire_id", schema);
            //cmd += String.Format(" left join {0}.lot_description l on l.id = e.lot_id", schema);
            cmd += String.Format(" left join {0}.nature n on n.id = e.nature_id", schema);

            cmd += " where liasse_id = @liasse_id and e.statut = @statut ";

            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
            adapter.SelectCommand.Parameters.AddWithValue("@liasse_id", liasse_id);
            adapter.SelectCommand.Parameters.AddWithValue("@statut", (int)GlobalConstantes.StatutOperation.Brouillon);
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
        public DataTable GetListeReglementValideFromNature(string liasse_id, String ref_nature)
        {
            string cmd = String.Format(" select * from {0} r", getSchemaTable());
            if (ref_nature != "" && ref_nature != "0")
            {
                cmd += String.Format(" join {0}.nature n on n.id = nature_id ", getSchema());
            }
            cmd += " where liasse_id = @liasse_id and r.statut = @statut ";
            if (ref_nature != "" && ref_nature != "0")
                cmd += " and n.reference = @nature_ref ";
            cmd += " order by nature_id, comptebanque";


            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
            adapter.SelectCommand.Parameters.AddWithValue("@liasse_id", liasse_id);
            adapter.SelectCommand.Parameters.AddWithValue("@nature_ref", ref_nature);
            adapter.SelectCommand.Parameters.AddWithValue("@statut", (int)GlobalConstantes.StatutOperation.Valide);
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
        public DataTable GetListeReglementValideFromCompteBanque(string liasse_id, string nature_id, string comptebanque)
        {
            string cmd = "SELECT date_reference, montant, emetteur, banque, reference ";
            cmd += String.Format(" FROM {0} f", getSchemaTable());
            cmd += String.Format(" join {0}.coproprietaire c ON f.coproprietaire_id = c.id", getSchema());
            cmd += " where liasse_id = @liasse_id and nature_id = @nature_id and comptebanque = @comptebanque and f.statut = @statut";

            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
            adapter.SelectCommand.Parameters.AddWithValue("@liasse_id", liasse_id);
            adapter.SelectCommand.Parameters.AddWithValue("@nature_id", nature_id);
            adapter.SelectCommand.Parameters.AddWithValue("@comptebanque", comptebanque);
            adapter.SelectCommand.Parameters.AddWithValue("@statut", (int)GlobalConstantes.StatutOperation.Valide);
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
        public DataTable getListeOperations(string immeuble, string lot_reference, DateTime dtDeb, DateTime dtFin, string ref_nature = "", string libelle = "", string montant="", bool bValidOnly = true)
        {
            String schema = getSchema();
            string cmd = "Select ";
            int numlot = 0;

            cmd += " sf.id, i.reference as ref_immeuble, date_reference, n.reference as ref_nature, libelle, montant, c.reference as ref_copro, concat(c.prenom, ' ',c .nom) as coproprietaire, banque, sf.statut ";
            cmd += String.Format(" from {0} sf", getSchemaTable());
            cmd += String.Format(" join {0}.immeuble i on i.id = immeuble_id ", schema);
            cmd += String.Format(" left join {0}.nature n on n.id = nature_id ", schema);
            cmd += String.Format(" left join {0}.coproprietaire c on c.id = coproprietaire_id ", schema);
            cmd += String.Format(" left join {0}.lot_description l on l.coproprietaire_id = sf.coproprietaire_id", schema);


            cmd += String.Format(" where 1=1" );
            if ( immeuble != "")
                cmd += " and i.reference = @immeuble";
            if (ref_nature != "")
                cmd += " and n.reference = @ref_nature";
            if (lot_reference != "")
            {
                numlot = Convert.ToInt32(lot_reference);
                cmd += " and l.numero_lot = @numlot";
            }
            if (dtDeb != DateTime.Parse("01/01/1970"))
                if (dtFin != DateTime.Parse("01/01/1970"))
                    cmd += " and date_reference >= @dtDeb";
                else
                    cmd += " and date_reference = @dtDeb";
            if (dtFin != DateTime.Parse("01/01/1970"))
                cmd += " and date_reference <= @dtFin";

            if (libelle != "")
                cmd += " and libelle like (@libelle)";
            if (montant != "")
                cmd += " and montant = @montant";
            if (bValidOnly)
                cmd += " and sf.statut = @statut";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble", immeuble),
                new NpgsqlParameter("@numlot", numlot),
                new NpgsqlParameter("@ref_nature", ref_nature),
                new NpgsqlParameter("@dtDeb", dtDeb),
                new NpgsqlParameter("@dtFin", dtFin),
                new NpgsqlParameter("@libelle", "%"+libelle+"%"),
                new NpgsqlParameter("@montant", Convertir.ToDecimal(montant)),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Valide),
            };

            return getResultSQL(cmd, parameters);

        }
        public decimal getSumReglements(string immeuble_id, DateTime dtDeb, DateTime dtFin)
        {
            decimal sum = 0;
            string cmd = String.Format("Select sum(montant) as montant from {0}", getSchemaTable());
            cmd += " where immeuble_id = @immeuble_id and date_reference >= @dtDeb and date_reference <= @dtFin ";
            cmd += " and statut != @statut";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@dtDeb", dtDeb),
                new NpgsqlParameter("@dtFin", dtFin),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Supprime),
            };

            DataTable table = getResultSQL(cmd, parameters);

            if (table != null)
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    sum = Convertir.ToDecimal(row["montant"]);
                }

            return sum;
        }

        public decimal getTotalOperationWithoutSolde(string immeuble_id, DateTime dtDeb, DateTime dtFin, string copro_id = "")
        {
            decimal sum = 0;
            string nature = "140";

            string cmd = string.Format("select coalesce(sum(credit)-sum(debit),0) as montant from {0}.operation f", getSchema());
            cmd += string.Format(" left join agence.nature n on n.id = f.nature_id ", getSchema());
            cmd += " where immeuble_id = @immeuble_id and date_reference >= @dtDeb and date_reference <= @dtFin";
            cmd += " and type_mouvement=@type_mouvement and type_operation = @type_operation";
            cmd += " and n.reference <> @nature ";
            cmd += " and f.statut != @statut";
            if ( copro_id != "")
                cmd += " and coproprietaire_id=@copro_id";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@nature", nature),
                new NpgsqlParameter("@dtDeb", dtDeb),
                new NpgsqlParameter("@dtFin", dtFin),
                new NpgsqlParameter("@copro_id", copro_id),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutOperation.Supprime),
                new NpgsqlParameter("@type_mouvement",  GlobalConstantes.TypeMouvement.Recette.ToString()),
                new NpgsqlParameter("@type_operation",  GlobalConstantes.TypeOperation.Tresorerie.ToString()),
            };

            DataTable table = getResultSQL(cmd, parameters);

            if (table != null)
                if (table.Rows.Count > 0)
                {
                    DataRow row = table.Rows[0];
                    sum = Convertir.ToDecimal(row["montant"]);
                }

            return sum;
        }
        public bool AnnuleElement(SaisieReglementEntite entite, DataTable table)
        {
            bool rc = false;
            NpgsqlConnection cnx = Database.GetInstance();
            NpgsqlTransaction trx = cnx.BeginTransaction();
            try
            {
                TimestampServer = Database.GetTimestampServer();

                OperationController ctl = OperationController.getController();
                ctl.setTimestampServer(TimestampServer);
                if (table != null)
                {
                    foreach (DataRow row in table.Rows)
                    {
                        OperationEntite operation = new OperationEntite(row);
                        operation.statut = (int)GlobalConstantes.StatutOperation.Supprime;
                        if (!ctl.doInsertOrUpdate(operation))
                            throw new Exception("Annulation Operation");
                    }
                }
                entite.statut = (int)GlobalConstantes.StatutOperation.Supprime;
                if (!doInsertOrUpdate(entite))
                    throw new Exception("Annulation reglement");
                rc = true;
                trx.Commit();
            }
            catch (Exception ex)
            {
                trx.Rollback();
                MessageBox.Show(ex.Message);
            }
            return rc;
        }

        public bool AnnuleElement(string element_id)
        {
            SaisieReglementEntite entite = getController().getEntiteById(element_id);
            if ( entite != null )
                return AnnuleElement(entite);
            return false;
        }

        public bool AnnuleElement(SaisieReglementEntite entite)
        {
            string cmd = String.Format("Select * from {0}.operation where saisie_id = @saisie_id", getSchema());
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
                {
                    new NpgsqlParameter("@saisie_id", entite.id),
                };

            DataTable table = getResultSQL(cmd, parameters);
            return AnnuleElement(entite, table);
        }
        public DataTable getSaisieReglement(OperationEntite operation)
        {
            String cmd = String.Format("select o.*, c.reference as ref_copro from {0} o", getSchemaTable());
            cmd += " join agence.coproprietaire c on c.id = o.coproprietaire_id ";
            cmd += " where immeuble_id = @immeuble_id and coproprietaire_id =@coproprietaire_id and date_reference = @date_reference and nature_id = @nature_id and trim(libelle) = trim(@libelle)";
            cmd += " and montant = @montant";
            decimal montant = operation.credit;

            if (operation.debit != 0)
                montant = operation.debit;

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
                {
                    new NpgsqlParameter("@immeuble_id", operation.immeuble_id),
                    new NpgsqlParameter("@coproprietaire_id", operation.coproprietaire_id),
                    new NpgsqlParameter("@nature_id", operation.nature_id),
                    new NpgsqlParameter("@date_reference", operation.date_reference),
                    new NpgsqlParameter("@libelle", operation.libelle),
                    new NpgsqlParameter("@montant", montant),

                };
            return getResultSQL(cmd, parameters);
        }
    }
}
