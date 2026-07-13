using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Utils;
using GeranceData.Entites;
using System.Windows.Forms;

namespace GeranceData.Controller
{
    public class BienController : AbstractBaseController<BienEntite>
    {
//        public const string ORDER = " concat (b.reference, '-', trim(to_char(numero_lot,'0000'))) ";
        public const string ORDER = " concat (b.reference, '-', b.id ) ";
        static BienController controller = new BienController();
        
        public override string getTable()
        {
            return "biens";
        }
        public static BienController getController()
        {
//            return new BienController ();
            return controller;
        }
        public DataTable getListeBienLocatif()
        {
            string cmd = string.Format("select * from {0} where montant_loyer > 0 and statut != 9", getSchemaTable());
            cmd += " order by reference, numero_lot";
            return getResultSQL(cmd);
        }
        public bool ErrorMessage(string message)
        {
            MessageBox.Show(message);
            return false;
        }
        public override bool InsertOrUpdate(BienEntite entite, NpgsqlConnection cnx = null)
        {
            if (entite.reference == null || entite.reference == "")
                return ErrorMessage("Réference invalide");

            if (entite.proprietaire_id == null)
                return ErrorMessage("Proprietaire invalide");

            if (entite.locataire_id == null)
                return ErrorMessage("Locataire invalide");

            return base.InsertOrUpdate(entite, cnx);
        }

        public BienEntite getBien(string reference, int numlot)
        {
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@reference", reference), 
                new NpgsqlParameter("@numlot", numlot), 
            };
            return getEntite(" where reference=@reference and numero_lot=@numlot ", parameters);
        }

        public override DataTable GetFindList(string filter)
        {
            string order = " reference ";
            string cmd = String.Format("Select id, reference, nom from {0} ", getSchemaTable());
            if (filter != "")
                cmd += " where " + filter;
            cmd += String.Format(" order by {0}", order);
            return getResultSQL(cmd);
        }

        protected override void setListSelectCommand()
        {
            DefaultOrder = ORDER;
            //base.setListSelectCommand();
            string schema = getSchema();
            string cmd = "select b.id, b.reference, b.nom as nom_immeuble, numero_lot, concat ( p.nom, ' ', p.prenom) as proprietaire, l.reference as ref_locataire, concat(l.prenom, ' ', l.nom) as locataire, ";
            cmd += " batiment as bat, escalier as esc, etage as eta, type_construction as cons";
            cmd += string.Format( " from {0} b" , getSchemaTable() );
            cmd += String.Format(" join {0}.proprietaire p on p.id = proprietaire_id ", schema );
            cmd += String.Format(" left join {0}.locataire l on l.id = locataire_id ", schema);
            cmd += " order by " + ORDER;
            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
        }
        public DataTable getListeQuittances()
        {
            string cmd = "select b.reference as ref_immeuble, numero_lot, l.reference as ref_locataire, b.montant_loyer, b.montant_charges, valeur_taxe, montant_divers1, montant_divers2, montant_divers3";
            cmd += String.Format(" from {0} b", getSchemaTable());
            cmd += String.Format(" join {0}.locataire l on l.id = b.locataire_id", getSchema());
            //cmd += " where montant_loyer + montant_charges + valeur_taxe + montant_divers1 + montant_divers2 + montant_divers3 !=0";
            cmd += " where coalesce(locataire_id, '') != '' and montant_loyer != 0";
            cmd += " order by 1";
            return getResultSQL(cmd);
        }
        public DataTable getListeAppelsLoyer(int iMonth = -1, string refLocataire = "", string nomLocataire = "", string refImmeuble= "", string nomImmeuble = "", int typeLoyer = 0, int garantie = 0)
        {
            string cmd = "select b.id, b.reference as ref_immeuble, l.reference as ref_locataire, concat(l.nom, ' ', l.prenom) as locataire, concat(p.nom, ' ', p.prenom) as proprietaire, b.nom, b.montant_loyer, b.montant_charges, b.montant_augmentation";
            cmd += String.Format(" from {0} b", getSchemaTable());
            cmd += String.Format(" join {0}.locataire l on l.id = b.locataire_id", getSchema());
            cmd += String.Format(" join {0}.proprietaire p on p.id = b.proprietaire_id", getSchema());
            //cmd += " where montant_loyer + montant_charges + valeur_taxe + montant_divers1 + montant_divers2 + montant_divers3 !=0";
            cmd += " where coalesce(locataire_id, '') != '' and ( montant_loyer != 0 or frais_bail != 0 )";
            if (iMonth != -1)
                cmd += String.Format(" and mois_augmentation = {0}", iMonth);
            if (refLocataire != "")
                cmd += " and l.reference = @ref_locataire";
            if (nomLocataire != "")
            {
                if ( !nomLocataire.EndsWith("%"))
                    nomLocataire += "%";
                cmd += " and l.nom like @nom_locataire";
            }
            if (refImmeuble != "")
                cmd += " and b.reference = @ref_immeuble";
            if (nomImmeuble != "")
            {
                if (!nomImmeuble.EndsWith("%"))
                    nomImmeuble += "%";
                cmd += " and b.nom like @nom_immeuble";
            }
            if (typeLoyer != 0)
                if (typeLoyer == 1)
                    cmd += " and periodicite_loyer = 12";
                else
                    cmd += " and periodicite_loyer = 4";
            if (garantie == 1)
                cmd += " and garantie_universelle=1";

//            cmd += " order by b.reference";
            cmd += " order by l.reference";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("ref_locataire", refLocataire),
                new NpgsqlParameter("nom_locataire", nomLocataire),
                new NpgsqlParameter("ref_immeuble", refImmeuble),
                new NpgsqlParameter("nom_immeuble", nomImmeuble),
            };

            return getResultSQL(cmd, parameters);
        }
        public DataTable getDetailAppelDeLoyer(string bien_id)
        {
            string cmd = "select montant_loyer, montant_augmentation, valeur_taxe, montant_charges, frais_bail, l.total_du as reste_du,";
            cmd += " (l.total_du + montant_loyer+ montant_augmentation+ valeur_taxe+ montant_charges+ frais_bail + montant_divers1 + montant_divers2+montant_divers3 + montant_divers4+ montant_divers5 ) as total_du,";
//            cmd += " (montant_loyer+ montant_augmentation+ valeur_taxe+ montant_charges+ frais_bail + montant_divers1 + montant_divers2+montant_divers3 + montant_divers4+ montant_divers5 ) as total_du,";
            cmd += " montant_divers1, montant_divers2, montant_divers3, montant_divers4, montant_divers5,";
            cmd += " divers1, divers2, divers3, divers4, divers5, ";
            cmd += " concat(l.nom, ' ', l.prenom) as nom_loca, l.adresse, l.codepostal, l.ville, l.reference, b.adresse as imm_adress, b.ville as imm_ville, b.codepostal as imm_cp";
            cmd += String.Format(" from {0}.biens b join {0}.locataire l on (l.id = b.locataire_id) ", getSchema());
            cmd += " where b.id  = @bien_id";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_id", bien_id),
            };
//            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public DataTable getDetailQuittance(string bien_id)
        {
            string cmd = "select montant_loyer, montant_augmentation, valeur_taxe, montant_charges, frais_bail, l.total_du as reste_du,";
            cmd += " (montant_loyer+ montant_augmentation+ valeur_taxe+ montant_charges+ frais_bail + montant_divers1 + montant_divers2+montant_divers3 + montant_divers4+ montant_divers5 ) as total_du,";
            cmd += " montant_divers1, montant_divers2, montant_divers3, montant_divers4, montant_divers5,";
            cmd += " divers1, divers2, divers3, divers4, divers5, ";
            cmd += " concat(l.nom, ' ', l.prenom) as nom_loca, l.adresse, l.codepostal, l.ville, l.reference, b.adresse as imm_adress, b.ville as imm_ville, b.codepostal as imm_cp";
            cmd += String.Format(" from {0}.biens b join {0}.locataire l on (l.id = b.locataire_id) ", getSchema());
            cmd += " where b.id  = @bien_id";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_id", bien_id),
            };
//            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public DataTable getDetailQuittanceFromQuittance(string bien_id, DateTime dtDeb)
        {
            DateTime dtFin = dtDeb.AddMonths(1);
            string cmd = "select q.montant_loyer, q.montant_augmentation, q.valeur_taxe, q.montant_charge as montant_charges, q.frais_bail, 0 as reste_du,";
            cmd += " (q.montant_loyer+ q.montant_augmentation+ q.valeur_taxe+ q.montant_charge+ q.frais_bail + q.montant_divers1 + q.montant_divers2+q.montant_divers3 + q.montant_divers4+ q.montant_divers5 ) as total_du,";
            cmd += " q.montant_divers1, q.montant_divers2, q.montant_divers3, q.montant_divers4, q.montant_divers5,";
            cmd += " q.divers1, q.divers2, q.divers3, q.divers4, q.divers5, ";
            cmd += " concat(l.nom, ' ', l.prenom) as nom_loca, l.adresse, l.codepostal, l.ville, l.reference, b.adresse as imm_adress, b.ville as imm_ville, b.codepostal as imm_cp";
            cmd += String.Format(" from {0}.quittances q join {0}.biens b on q.bien_id = b.id join {0}.locataire l on l.id = q.locataire_id ", getSchema());
            cmd += " where b.id  = @bien_id and q.date_quittance >= @dtDeb and q.date_quittance < @dtFin";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_id", bien_id),
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
            };
//            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
    }
}
