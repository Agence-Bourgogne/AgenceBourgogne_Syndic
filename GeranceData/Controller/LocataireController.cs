using System;
using System.Collections.Generic;
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
            var cmd =
                $"select l.*, c.reference as ref_comptable from {getSchemaTable()} l left join {getSchema()}.comptable c on c.id = comptable_id order by {DefaultOrder}";
            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
        }
        /*
        public override DataTable GetFindList(string filter)
        {
            DefaultOrder = "reference";
            return base.GetFindList(filter);
        }
         */
        public override DataTable GetFindList(string filter)
        {
            var order = DefaultOrder;
            var cmd = $"Select id, reference, trim(concat(pa.code, ' ', nom)) as nom from {getSchemaTable()} l ";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            cmd += " where statut != @statut_del";

            if (filter != "")
                cmd += " and " + filter;
            cmd += $" order by {order}";

            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@statut_del", (int) ProprietaireEntite.StatutEntite.Supprime),
            };

            return getResultSQL(cmd, parameters);
        }

        public DataTable GetFindLotList(string ref_immeuble)
        {
            var cmd = "select b.id, numero_lot as reference, trim(concat(pa.code, ' ', l.prenom, ' ', l.nom )) as nom ";
            cmd += $" from {getSchema()}.biens b";
            cmd += $" join {getSchemaTable()} l on b.locataire_id = l.id ";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            cmd += String.Format(" where b.reference = @ref_immeuble");

            var parameters = new List<NpgsqlParameter>
            {
               new NpgsqlParameter("@ref_immeuble", ref_immeuble),
            };
            return getResultSQL(cmd, parameters);
        }

        public LocataireEntite getLocataireBien(string where, List<NpgsqlParameter> parameters = null)
        {
            var entite = default(LocataireEntite);
            var cmd = $"select * from {getSchemaTable()} l";
            cmd += $" join (select locataire_id from {getSchema()}.biens) b on l.id = b.locataire_id {where} limit 1";
            var adapter = new NpgsqlDataAdapter();
            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    adapter.SelectCommand.Parameters.AddWithValue(parameter.ParameterName, parameter.NpgsqlValue);
                }
            }
            var table = new DataTable();
            try
            {
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    var row = table.Rows[0];
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
            var cmd = $"select id from {getSchemaTable()} where id =@locataire_id";
            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("locataire_id", locataire_id),
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getHdrLocataireCharge(string locataire_id)
        {
            var cmd = "select trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) as nom, l.reference, l.adresse, concat(l.codepostal, ' ', l.ville ) as ville, b.date_entree ";
            cmd += $" from {getSchemaTable()} l join {getSchema()}.biens b on b.locataire_id =l.id ";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            cmd += " where l.id = @locataire_id";
            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("locataire_id", locataire_id),
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeRetardPaiements(decimal seuil, string ref_locataire = "")
        {
            //string cmd = "select id, reference, concat(nom, ' ', prenom) as locataire,  total_du, date_reglement, adresse, concat(codepostal, ' ', ville) as ville ";
            //cmd += String.Format(" from {0} l", getSchemaTable());
            //cmd += string.Format(" join (select max(date_reglement) as date_reglement, locataire_id from {0}.reglements group by locataire_id) r on r.locataire_id = l.id", getSchema());
            //cmd += " where total_du > @seuil ";
            var cmd = "select l.id, l.reference, ";
            cmd += " trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) as locataire,  ";
            cmd += " sum(debit) - sum(credit) as total_du , date_reglement, ";
            cmd += " case when coalesce (l.comptable_id, '') != '' then concat(ct.nom, ' ', ct.prenom) else trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) end as comptable, ";
            cmd += " case when coalesce (l.comptable_id, '') != '' then ct.adresse else l.adresse end as adresse, ";
            cmd += " case when coalesce (l.comptable_id, '') != '' then concat(ct.codepostal, ' ', ct.ville) else concat(l.codepostal, ' ', l.ville) end as ville ";
            //            cmd += " l.adresse, concat(l.codepostal, ' ', l.ville) as ville ";
            cmd += " from ( ";
            cmd +=
                $" select id, locataire_id, montant_quittance as debit, 0 as credit from {getSchema()}.quittances q where statut != @statut_del";
            cmd += " union ";
            cmd +=
                $" select id, locataire_id, debit as debit, credit as credit from {getSchema()}.reglements r where statut != @statut_del";
            cmd += " ) c";
            cmd += $" join {getSchemaTable()} l on l.id = c.locataire_id";
            cmd += $" left join {getSchema()}.comptable ct on ct.id = l.comptable_id";
            cmd += $" join {getSchema()}.biens b on b.locataire_id = l.id and b.montant_loyer >0";
//            cmd += string.Format(" join (select max(date_reglement) as date_reglement, locataire_id from {0}.reglements group by locataire_id) r on r.locataire_id = l.id", getSchema());
            cmd +=
                $" left join (select max(date_reglement) as date_reglement, locataire_id from {getSchema()}.reglements group by locataire_id) r on r.locataire_id = l.id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            
            if (ref_locataire != "")
                cmd += " where l.reference = @ref_locataire";
//                cmd += " and l.reference = @ref_locataire";
            cmd += " group by 1, 2, 3, 5, 6, 7, 8";
            cmd += " order by reference";
            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("seuil", seuil),
                new NpgsqlParameter("ref_locataire", ref_locataire),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            Console.WriteLine(cmd);

            return getResultSQL(cmd, parameters);
        }
        public DataTable getSoldeLocataire(string ref_locataire="")
        {
            var cmd = " select ";

            cmd += " l.id, l.reference, trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) as locataire, l.adresse, sum(debit)as debit, sum(credit) as credit, sum(debit) - sum(credit) as solde";
            cmd += " from ( ";
            cmd +=
                $" select id, locataire_id, montant_quittance as debit, 0 as credit from {getSchema()}.quittances q where statut != @statut_del";
            cmd += " union ";
            cmd +=
                $" select id, locataire_id, debit as debit, credit as credit from {getSchema()}.reglements r where statut != @statut_del";
            cmd += " ) c";
            cmd += $" join {getSchemaTable()} l on l.id = c.locataire_id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            if (ref_locataire != "")
                cmd += " where l.reference = @ref_locataire";
            cmd += " group by 1, 2, 3 ";
            cmd += " order by reference";
            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("ref_locataire", ref_locataire),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getDetailCompteLocataire(string ref_locataire)
        {
            var cmd = "select l.reference, trim(concat(pa.code, ' ', l.nom, ' ', l.prenom))as nom, date_ecriture, libelle, debit, credit ";
            cmd += " from ( ";
            cmd +=
                $"select id, locataire_id, date_quittance as date_ecriture, 'MONTANT DU LOYER' as libelle, montant_quittance as debit, 0 as credit from {getSchema()}.quittances q where statut!= @statut_del";
            cmd += " union ";
            cmd +=
                $"select id, locataire_id , date_reglement, libelle, debit as debit, credit as credit from {getSchema()}.reglements r where statut!= @statut_del";
            cmd += " ) c ";
            cmd += $" join {getSchemaTable()} l on l.id = c.locataire_id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            if (ref_locataire != "")
                cmd += " where l.reference = @ref_locataire";

            cmd += " order by date_ecriture";
            var parameters = new List<NpgsqlParameter>
            {
                new NpgsqlParameter("ref_locataire", ref_locataire),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);
            // update agence.reglements set statut = 9 where bien_id like '*%'
        }
    }
}
