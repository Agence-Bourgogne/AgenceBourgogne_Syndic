using System;
using System.Collections.Generic;
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
            var cmd = $"select * from {getSchemaTable()} where montant_loyer > 0 and statut != 9";
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
            var parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@reference", reference), 
                new NpgsqlParameter("@numlot", numlot), 
            };
            return getEntite(" where reference=@reference and numero_lot=@numlot ", parameters);
        }

        public override DataTable GetFindList(string filter)
        {
            var order = " reference ";
            var cmd = $"Select id, reference, nom from {getSchemaTable()} ";
            if (filter != "")
                cmd += " where " + filter;
            cmd += $" order by {order}";
            return getResultSQL(cmd);
        }

        protected override void setListSelectCommand()
        {
//            DefaultOrder = ORDER;
            //base.setListSelectCommand();
            var schema = getSchema();
            var cmd = "select b.id, b.reference, b.nom as nom_immeuble, numero_lot, trim(concat ( pa.code, ' ', p.nom, ' ', p.prenom)) as proprietaire, l.reference as ref_locataire, ";
            cmd += " trim(concat(pa2.code, ' ', l.prenom, ' ', l.nom)) as locataire, ";
            cmd += " batiment as bat, escalier as esc, etage as eta, type_construction as cons, b.statut";
            cmd += $" from {getSchemaTable()} b";
            cmd += $" join {schema}.proprietaire p on p.id = proprietaire_id ";
            cmd += $" left join {schema}.locataire l on l.id = locataire_id ";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa2 on pa2.iparam_1 = l.civilite";
            cmd += " order by " + ORDER;
            adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
        }
        public DataTable getListeQuittances()
        {
            var cmd = "select b.reference as ref_immeuble, numero_lot, l.reference as ref_locataire, b.montant_loyer, b.montant_charges, valeur_taxe, montant_divers1, montant_divers2, montant_divers3";
            cmd += $" from {getSchemaTable()} b";
            cmd += $" join {getSchema()}.locataire l on l.id = b.locataire_id";
            //cmd += " where montant_loyer + montant_charges + valeur_taxe + montant_divers1 + montant_divers2 + montant_divers3 !=0";
            cmd += " where coalesce(locataire_id, '') != '' and montant_loyer != 0";
            cmd += " order by 1";
            return getResultSQL(cmd);
        }
        public DataTable getListeAppelsLoyer(int iMonth = -1, string refLocataire = "", string nomLocataire = "", string refImmeuble= "", string nomImmeuble = "", int typeLoyer = 0, int garantie = 0, bool bLoyer = true)
        {
            var cmd = "select b.id, b.reference as ref_immeuble, l.reference as ref_locataire, trim(concat(pa2.code, ' ', l.nom, ' ', l.prenom)) as locataire, ";
            cmd += " trim(concat(pa.code, ' ',p.nom, ' ', p.prenom)) as proprietaire, b.nom, b.montant_loyer, b.montant_charges, b.montant_augmentation";
            cmd += $" from {getSchemaTable()} b";
            cmd += $" join {getSchema()}.locataire l on l.id = b.locataire_id";
            cmd += $" join {getSchema()}.proprietaire p on p.id = b.proprietaire_id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa2 on pa2.iparam_1 = l.civilite";
            //cmd += " where montant_loyer + montant_charges + valeur_taxe + montant_divers1 + montant_divers2 + montant_divers3 !=0";
            cmd += " where coalesce(locataire_id, '') != '' ";
            if ( bLoyer )
                cmd += " and ( montant_loyer != 0 or frais_bail != 0 )";
            if (iMonth != -1)
                cmd += $" and mois_augmentation = {iMonth}";
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
            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("ref_locataire", refLocataire),
                new NpgsqlParameter("nom_locataire", nomLocataire),
                new NpgsqlParameter("ref_immeuble", refImmeuble),
                new NpgsqlParameter("nom_immeuble", nomImmeuble),
            };

            return getResultSQL(cmd, parameters);
        }
        public DataTable getDetailAppelDeLoyer(string bien_id, DateTime dtDeb)
        {
            var cmd = "select ";
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
            cmd += $" left join {getSchema()}.comptable c on c.id = comptable_id ";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            cmd += " where b.id  = @bien_id";
            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_id", bien_id),
                new NpgsqlParameter("dtDeb", dtDeb),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public DataTable getDetailQuittance(string bien_id)
        {
            var cmd = "select ";
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
            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_id", bien_id),
            };
           Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public DataTable getDetailQuittanceFromQuittance(string bien_id, DateTime dtDeb)
        {
            var dtFin = dtDeb.AddMonths(1);
            var cmd = "select q.montant_loyer, q.montant_augmentation, q.valeur_taxe, q.montant_charge as montant_charges, q.frais_bail, 0 as reste_du, q.honoraire_locataire as honoraires_locataire,";
            cmd += " (q.montant_loyer+ q.montant_augmentation+ q.valeur_taxe+ q.montant_charge+ q.frais_bail + q.montant_divers1 + q.montant_divers2+q.montant_divers3 + q.montant_divers4+ q.montant_divers5+q.honoraire_locataire ) as total_du,";
            cmd += " q.montant_divers1, q.montant_divers2, q.montant_divers3, q.montant_divers4, q.montant_divers5,";
            cmd += " q.divers1, q.divers2, q.divers3, q.divers4, q.divers5,  ";
            cmd += " trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) as nom_loca, l.adresse, l.codepostal, l.ville, l.reference, b.adresse as imm_adress, b.ville as imm_ville, b.codepostal as imm_cp";
            cmd += " , b.periodicite_loyer";
            cmd += String.Format(" from {0}.quittances q join {0}.biens b on q.bien_id = b.id join {0}.locataire l on l.id = q.locataire_id ", getSchema());
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            cmd += " where b.id  = @bien_id and q.date_quittance >= @dtDeb and q.date_quittance < @dtFin";
            var parameters = new List<NpgsqlParameter>{
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
            
            
            var cmd = "Select b.id as b_id, b.reference as bien, b.nom, p.id as p_id, p.reference as proprio , trim(concat(pa.code, ' ', p.nom, ' ', p.prenom)) as nom_proprietaire, ";
            cmd += " l.id as l_id, l.reference as locataire, trim(concat(pa2.code, ' ', l.nom, ' ', l.prenom)) as nom_locataire ";
            cmd += $" from {getSchemaTable()} b ";
            cmd += $" left join {getSchema()}.proprietaire p on p.id = b.proprietaire_id ";
            cmd += $" left join {getSchema()}.locataire l on l.id = b.locataire_id ";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa2 on pa.iparam_1 = l.civilite";

            cmd += " where 1=1 ";
            cmd += " and b.reference like @bien ";
            cmd += " and p.reference like @proprio ";
            cmd += " and l.reference like @locataire ";
            cmd += " and upper(b.nom) like upper(@nomBien) ";
            cmd += " and upper(p.nom) like upper(@nomProprio) ";
            cmd += " and upper(l.nom) like upper(@nomLoca) ";

            var parameters = new List<NpgsqlParameter>{
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
