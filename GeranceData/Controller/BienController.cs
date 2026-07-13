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

        public DataTable GetCompeleteListe()
        {
            string cmd = string.Format("select * from {0} b ", getSchemaTable());
            cmd += String.Format(" order by {0}",  ORDER);
            return getResultSQL(cmd);
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
//            DefaultOrder = ORDER;
            //base.setListSelectCommand();
            string schema = getSchema();
            string cmd = "select b.id, b.reference, b.nom as nom_immeuble, numero_lot, trim(concat ( pa.code, ' ', p.nom, ' ', p.prenom)) as proprietaire, l.reference as ref_locataire, ";
            cmd += " trim(concat(pa2.code, ' ', l.prenom, ' ', l.nom)) as locataire, ";
            cmd += " batiment as bat, escalier as esc, etage as eta, type_construction as cons, b.statut";
            cmd += string.Format( " from {0} b" , getSchemaTable() );
            cmd += String.Format(" join {0}.proprietaire p on p.id = proprietaire_id ", schema );
            cmd += String.Format(" left join {0}.locataire l on l.id = locataire_id ", schema);
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa2 on pa2.iparam_1 = l.civilite";
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
        public DataTable getListeAppelsLoyer(int iMonth = -1, string refLocataire = "", string nomLocataire = "", string refImmeuble= "", string nomImmeuble = "", int typeLoyer = 0, int garantie = 0, bool bLoyer = true)
        {
            string cmd = "select b.id, b.reference as ref_immeuble, l.reference as ref_locataire, trim(concat(pa2.code, ' ', l.nom, ' ', l.prenom)) as locataire, ";
            cmd += " trim(concat(pa.code, ' ',p.nom, ' ', p.prenom)) as proprietaire, b.nom, b.montant_loyer, b.montant_charges, b.montant_augmentation";
            cmd += String.Format(" from {0} b", getSchemaTable());
            cmd += String.Format(" join {0}.locataire l on l.id = b.locataire_id", getSchema());
            cmd += String.Format(" join {0}.proprietaire p on p.id = b.proprietaire_id", getSchema());
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa2 on pa2.iparam_1 = l.civilite";
            //cmd += " where montant_loyer + montant_charges + valeur_taxe + montant_divers1 + montant_divers2 + montant_divers3 !=0";
            cmd += " where coalesce(locataire_id, '') != '' ";
            if ( bLoyer )
                cmd += " and ( montant_loyer != 0 or frais_bail != 0 )";
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
        public DataTable getDetailAppelDeLoyer(string bien_id, DateTime dtDeb)
        {
            string cmd = "select ";
            cmd += "case when coalesce (comptable_id, '') != '' then  concat(c.nom, ' ', c.prenom) else trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) end as nom_loca, ";
            cmd += " case when coalesce (comptable_id, '') != '' then c.adresse else l.adresse end as adresse, ";
            cmd += " case when coalesce (comptable_id, '') != '' then c.codepostal else l.codepostal end as codepostal, ";
            cmd += " case when coalesce (comptable_id, '') != '' then c.ville else l.ville end as ville, ";

            cmd += " l.reference, b.adresse as imm_adress, b.ville as imm_ville, b.codepostal as imm_cp ,";

            cmd += " montant_loyer, montant_augmentation, valeur_taxe, montant_charges, frais_bail, ";
            cmd += " case when date_quittance >= @dtDeb then l.total_du- b.montant_du else l.total_du end as reste_du, ";
            cmd += " honoraires_locataire, ";
            //cmd += " (l.total_du + montant_loyer+ montant_augmentation+ valeur_taxe+ montant_charges+ frais_bail + honoraires_locataire + montant_divers1 + montant_divers2+montant_divers3 + montant_divers4+ montant_divers5 ) as total_du,";
            cmd += " ((case when date_quittance >= @dtdeb then l.total_du- b.montant_du else l.total_du end) + ";
            cmd += " montant_loyer+ montant_augmentation+ valeur_taxe+ montant_charges+ frais_bail + honoraires_locataire + montant_divers1 + montant_divers2+montant_divers3 + montant_divers4+ montant_divers5 ) as total_du,";
            //            cmd += " (montant_loyer+ montant_augmentation+ valeur_taxe+ montant_charges+ frais_bail + montant_divers1 + montant_divers2+montant_divers3 + montant_divers4+ montant_divers5 ) as total_du,";
            cmd += " montant_divers1, montant_divers2, montant_divers3, montant_divers4, montant_divers5,";
            cmd += " divers1, divers2, divers3, divers4, divers5 ";
//            cmd += " concat(l.nom, ' ', l.prenom) as nom_loca, l.adresse, l.codepostal, l.ville, l.reference, b.adresse as imm_adress, b.ville as imm_ville, b.codepostal as imm_cp";
            cmd += String.Format(" from {0}.biens b join {0}.locataire l on (l.id = b.locataire_id) ", getSchema());
            cmd += String.Format(" left join {0}.comptable c on c.id = comptable_id ", getSchema());
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            cmd += " where b.id  = @bien_id";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_id", bien_id),
                new NpgsqlParameter("dtDeb", dtDeb),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public DataTable getDetailQuittance(string bien_id)
        {
            string cmd = "select ";
            cmd += " montant_loyer, montant_augmentation, valeur_taxe, montant_charges, frais_bail, l.total_du as reste_du, honoraires_locataire,";
            cmd += " (montant_loyer+ montant_augmentation+ valeur_taxe+ montant_charges+ frais_bail + montant_divers1 + montant_divers2+montant_divers3 + montant_divers4+ montant_divers5 + honoraires_locataire) as total_du,";
            cmd += " montant_divers1, montant_divers2, montant_divers3, montant_divers4, montant_divers5,";
            cmd += " divers1, divers2, divers3, divers4, divers5, ";
//            cmd += " concat(l.nom, ' ', l.prenom) as nom_loca, l.adresse, l.codepostal, l.ville, l.reference, b.adresse as imm_adress, b.ville as imm_ville, b.codepostal as imm_cp";
            cmd += " trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) as nom_loca, l.adresse, l.codepostal, l.ville, l.reference, b.adresse as imm_adress, b.ville as imm_ville, b.codepostal as imm_cp";
            cmd += " , b.periodicite_loyer";
            cmd += String.Format(" from {0}.biens b join {0}.locataire l on (l.id = b.locataire_id) ", getSchema());
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            cmd += " where b.id  = @bien_id";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_id", bien_id),
            };
           Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public DataTable getDetailQuittanceFromQuittance(string bien_id, DateTime dtDeb)
        {
            DateTime dtFin = dtDeb.AddMonths(1);
            string cmd = "select q.montant_loyer, q.montant_augmentation, q.valeur_taxe, q.montant_charge as montant_charges, q.frais_bail, 0 as reste_du, q.honoraire_locataire as honoraires_locataire,";
            cmd += " (q.montant_loyer+ q.montant_augmentation+ q.valeur_taxe+ q.montant_charge+ q.frais_bail + q.montant_divers1 + q.montant_divers2+q.montant_divers3 + q.montant_divers4+ q.montant_divers5+q.honoraire_locataire ) as total_du,";
            cmd += " q.montant_divers1, q.montant_divers2, q.montant_divers3, q.montant_divers4, q.montant_divers5,";
            cmd += " q.divers1, q.divers2, q.divers3, q.divers4, q.divers5,  ";
            cmd += " trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) as nom_loca, l.adresse, l.codepostal, l.ville, l.reference, b.adresse as imm_adress, b.ville as imm_ville, b.codepostal as imm_cp";
            cmd += " , b.periodicite_loyer";
            cmd += String.Format(" from {0}.quittances q join {0}.biens b on q.bien_id = b.id join {0}.locataire l on l.id = q.locataire_id ", getSchema());
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            cmd += " where b.id  = @bien_id and q.date_quittance >= @dtDeb and q.date_quittance < @dtFin";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_id", bien_id),
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
            };
//            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public DataTable FindElement(string bien, string proprio, string locataire, string nomBien, String nomProprio, String nomLoca)
        {
            bien += "%";
            proprio += "%";
            locataire += "%";

            nomBien += "%";
            nomProprio += "%";
            nomLoca += "%";
            
            
            string cmd = "Select b.id as b_id, b.reference as bien, b.nom, p.id as p_id, p.reference as proprio , trim(concat(pa.code, ' ', p.nom, ' ', p.prenom)) as nom_proprietaire, ";
            cmd += " l.id as l_id, l.reference as locataire, trim(concat(pa2.code, ' ', l.nom, ' ', l.prenom)) as nom_locataire ";
            cmd += string.Format(" from {0} b ", getSchemaTable());
            cmd += string.Format(" left join {0}.proprietaire p on p.id = b.proprietaire_id ", getSchema());
            cmd += string.Format(" left join {0}.locataire l on l.id = b.locataire_id ", getSchema());
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa2 on pa.iparam_1 = l.civilite";

            cmd += " where 1=1 ";
            cmd += " and b.reference like @bien ";
            cmd += " and p.reference like @proprio ";
            cmd += " and l.reference like @locataire ";
            cmd += " and upper(b.nom) like upper(@nomBien) ";
            cmd += " and upper(p.nom) like upper(@nomProprio) ";
            cmd += " and upper(l.nom) like upper(@nomLoca) ";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien", bien),
                new NpgsqlParameter("proprio", proprio),
                new NpgsqlParameter("locataire", locataire),
                new NpgsqlParameter("nomBien", nomBien),
                new NpgsqlParameter("nomProprio", nomProprio),
                new NpgsqlParameter("nomLoca", nomLoca),
            };
            return getResultSQL(cmd, parameters);
        }

    }
}
