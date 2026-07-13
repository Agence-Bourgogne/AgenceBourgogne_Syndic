using System;
using System.Collections.Generic;
using CommonProjectsPartners.Controller;
using GeranceData.Entites;
using Npgsql;
using System.Data;
using CommonProjectsPartners.Utils;

namespace GeranceData.Controller
{
    public class ProprietaireController : AbstractBaseController<ProprietaireEntite>
    {
        static ProprietaireController controller = new ProprietaireController();
        public override string getTable()
        {
            return "proprietaire";
        }
        public static ProprietaireController getController()
        {
            return controller;
        }

        public override DataTable GetFindList(string filter)
        {
            String order = DefaultOrder;
            string cmd = String.Format("Select id, reference, trim(concat(pa.code, ' ', nom)) as nom from {0} p ", getSchemaTable());
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += " where statut != @statut_del";

            if (filter != "")
                cmd += " and " + filter;
            cmd += String.Format(" order by {0}", order);

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@statut_del", (int) ProprietaireEntite.StatutEntite.Supprime),
            };

            return getResultSQL(cmd, parameters);
        }

        public DataTable GetConfigList()
        {
            DefaultOrder = "reference";
            String cmd = String.Format("select id, reference, trim(concat(pa.code, ' ', nom)) as nom, prenom, adresse, codepostal, ville,  rib, banque, statut from {0} p", getSchemaTable());
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += String.Format(" order by {0}", DefaultOrder);
            return getResultSQL(cmd);
        }

        protected override void setListSelectCommand()
        {
            DefaultOrder = "reference";

            string cmd = String.Format("select id, reference, trim(concat(pa.code, ' ', nom)) as nom, prenom, adresse, codepostal, ville,  rib, banque from {0} p", getSchemaTable());
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += String.Format(" where statut = 1 order by {0}", DefaultOrder);

            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
        }
        public DataTable getHdrFiscalProprietaire(string proprietaire_id)
        {
            String cmd = "select  ";
            cmd += " p.reference as p_reference, trim(concat (pa.code, ' ', p.nom, ' ', p.prenom)) as p_nom, p.adresse as p_adresse, concat(p.ville, '\r\n',p.pays) as p_ville, p.codepostal as p_codepostal, ";
            cmd += " b.adresse, concat(b.codepostal, ' ', b.ville) as ville";
            cmd += string.Format(" from {0} p ", getSchemaTable());
            cmd += string.Format(" join {0}.biens b on p.id = b.proprietaire_id", getSchema());
            //" INNER JOIN(SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) t ON t.iparam_1 = c.codenvoi "; 
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += " where p.id = @proprietaire_id";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
            };

            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeCompteProprietaire(string ref_proprio)
        {
            String cmd = "select  ";

            cmd += " p.id, p.reference as reference, trim(concat (pa.code, ' ', p.nom, ' ', p.prenom)) as nom, p.adresse as adresse, p.ville as ville, p.debit, p.credit";
            cmd += string.Format(" from {0} p ", getSchemaTable());
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            //cmd += string.Format(" join {0}.biens b on p.id = b.proprietaire_id", getSchema());
            if ( ref_proprio != "")
                cmd += " where p.reference = @ref_proprio";

            cmd += " order by p.reference ";
            
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("ref_proprio", ref_proprio),
            };

            return getResultSQL(cmd, parameters);

        }
        public DataTable getListePaiementsLoyers(int paiement_type , DateTime dtDeb, DateTime dtFin)
        {
            String cmd = "select  ";

            cmd += "trim(concat(pa.code, ' ', nom, ' ', prenom)) as nom, regexp_replace(adresse, E'[\\n\\r]+', ' ', 'g' ) as adresse, concat(codepostal, ' ',ville) as ville , rib as num_compte, banque as Banque, credit-debit as montant, 'Loyer' as motif , id, reference, debit";

            cmd += String.Format(" from {0} p ", getSchemaTable());
            cmd += String.Format(" join (select proprietaire_id from {0}.reglements where date_reglement >= @dtDeb and date_reglement <= @dtFin group by 1) r", getSchema());
            cmd += " on r.proprietaire_id = p.id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += " where dernier_cheque > 0 and coalesce(paiement_type,0) = @paiement_type";
//            cmd += " group by 1, 2, 3, 4, 5";
            cmd += " order by nom ";

            Console.WriteLine(cmd);
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("paiement_type", paiement_type),
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public DataTable getImpressionListePaiementsLoyers(int paiement_type, DateTime dtDeb, DateTime dtFin)
        {
            String cmd = "select  ";

            cmd += "trim(concat(pa.code, ' ', nom, ' ', prenom)) as nom, regexp_replace(adresse, E'[\\n\\r]+', ' ', 'g' ) as adresse, concat(codepostal, ' ',ville) as ville , rib as num_compte, banque as Banque, ";
            cmd += " r.credit-r.debit +f.credit-f.debit as montant, 'Loyer' as motif , id, reference";

            cmd += String.Format(" from {0} p ", getSchemaTable());
            // Avoir si on rajoute dans les comptes propio le champs honoraire_locataire
            cmd += String.Format(" join (select proprietaire_id,sum(debit)  + sum(honoraire_locataire) + sum(etat_lieux) as debit, sum(credit)as credit   from {0}.reglements where date_reglement >= @dtDeb and date_reglement <= @dtFin and statut <> @statut_del group by 1 ) r", getSchema());
            cmd += " on r.proprietaire_id = p.id";

            cmd += String.Format(" left join (select proprietaire_id, sum(debit)as debit, sum(abs(credit))as credit  from agence.factures where date_facture >= @dtDeb and date_facture <= @dtFin and statut <> @statut_del group by 1) f ", getSchema());
            cmd += " on f.proprietaire_id = p.id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += " where dernier_cheque > 0 and coalesce(paiement_type,0) = @paiement_type";
            cmd += " order by nom ";

            Console.WriteLine(cmd);
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("paiement_type", paiement_type),
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("statut_del", 9),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
    }
}
