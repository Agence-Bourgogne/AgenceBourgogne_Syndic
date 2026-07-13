using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        protected override void setListSelectCommand()
        {
            DefaultOrder = "reference";
            adapter.SelectCommand = new NpgsqlCommand(String.Format("select id, reference, nom, prenom, adresse, codepostal, ville,  rib, banque from {0} where statut = 1 order by {1}", getSchemaTable(), DefaultOrder), Database.GetInstance());
        }
        public DataTable getHdrFiscalProprietaire(string proprietaire_id)
        {
            String cmd = "select  ";
            cmd += " p.reference as p_reference, concat (p.nom, ' ', p.prenom) as p_nom, p.adresse as p_adresse, p.ville as p_ville, p.codepostal as p_codepostal,b.adresse";
            cmd += string.Format(" from {0} p ", getSchemaTable());
            cmd += string.Format(" join {0}.biens b on p.id = b.proprietaire_id", getSchema());
            cmd += " where p.id = @proprietaire_id";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
            };

            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeCompteProprietaire(string ref_proprio)
        {
            String cmd = "select  ";

            cmd += " p.id, p.reference as reference, concat (p.nom, ' ', p.prenom) as nom, p.adresse as adresse, p.ville as ville, p.debit, p.credit";
            cmd += string.Format(" from {0} p ", getSchemaTable());
            //cmd += string.Format(" join {0}.biens b on p.id = b.proprietaire_id", getSchema());
            if ( ref_proprio != "")
                cmd += " where p.reference = @ref_proprio";

            cmd += " order by p.reference ";
            
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("ref_proprio", ref_proprio),
            };

            return getResultSQL(cmd, parameters);

        }
        public DataTable getListePaiementsLoyers(int paiement_type)
        {
            String cmd = "select  ";

            cmd += "concat(nom, ' ', prenom) as nom, adresse, concat(codepostal, ' ',ville) as ville , rib as num_compte, banque as Banque, credit as montant, 'Loyer' as motif , id, reference, debit";

            cmd += String.Format(" from {0} ", getSchemaTable());
            cmd += " where dernier_cheque > 0 and coalesce(paiement_type,0) = @paiement_type";
            cmd += " order by reference";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("paiement_type", paiement_type),
            };

            return getResultSQL(cmd, parameters);
        }
    }
}
