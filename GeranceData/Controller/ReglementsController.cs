using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Utils;
using GeranceData.Entites;
using GeranceData.Common;
using System.Windows.Forms;

namespace GeranceData.Controller
{
    public class ReglementsController : AbstractBaseController<ReglementEntite>
    {
        static ReglementsController controller = new ReglementsController();
        public override string getTable()
        {
            return "reglements";
        }
        
        public static ReglementsController getController()
        {
            return controller;
        }
        public DataTable getPrintReglements(DateTime dtDeb, DateTime dtFin, int code_reglement= 1)
        {
            var cmd = "select r.date_reglement, l.reference, trim(concat(pa.code, ' ', l.nom,' ', l.prenom)) as locataire, r.credit, r.tire, r.banque_tire";
            cmd += $" from {getSchemaTable()} r";
            cmd += $" join {getSchema()}.locataire l on l.id = r.locataire_id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            cmd += " where date_reglement >= @dtDeb and date_reglement <= @dtFin";
            cmd += " and r.code_reglement = @code_reglement";
            cmd += " and r.statut != @statut_del";
            cmd += " order by 1";
            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("code_reglement", code_reglement),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }

        public DataTable getReglements(DateTime dtDeb, DateTime dtFin, string ref_locataire)
        {
            var cmd = "select r.id, l.reference as ref_locataire,  trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) as locataire, b.reference as ref_immeuble, b.nom as immeuble, r.date_reglement, r.libelle, r.credit";
            cmd += $" from {getSchemaTable()} r ";
            cmd += $" join {getSchema()}.biens b on b.id =  r.bien_id";
            cmd += $" join {getSchema()}.locataire l on l.id =  r.locataire_id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";

            cmd += " where date_reglement >= @date_deb  and date_reglement <= @date_fin";
            if ( ref_locataire != "" )
            {
                cmd += " and l.reference = @ref_locataire";
            }
            cmd += " and r.statut != @statut_del";
            cmd += " order by r.date_reglement desc";

            var date_reg = DateTime.Now;
            //date_reg = date_reg.AddDays(-date_reg.Day + 1);
            date_reg = date_reg.AddDays(-30);

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("date_deb", dtDeb),
                new NpgsqlParameter("date_fin", dtFin),
                new NpgsqlParameter("ref_locataire", ref_locataire),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }

        public DataTable getReglements30DerniersJours()
        {
            var cmd = "select r.id, l.reference as ref_locataire,  trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) as locataire, b.reference as ref_immeuble, b.nom as immeuble, r.date_reglement, r.libelle, r.credit";
            cmd += $" from {getSchemaTable()} r ";
            cmd += $" join {getSchema()}.biens b on b.id =  r.bien_id";
            cmd += $" join {getSchema()}.locataire l on l.id =  r.locataire_id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            
            cmd += " where date_reglement >= @date_reg ";
            cmd += " and r.statut != @statut_del";
            cmd += " order by r.date_reglement desc, r.audit_created desc";

            var date_reg = DateTime.Now;
            //date_reg = date_reg.AddDays(-date_reg.Day + 1);
            date_reg = date_reg.AddDays(-30);

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("date_reg", date_reg),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }

        public DataTable getReleveCompteProprio(DateTime dtDeb, DateTime dtFin, string proprietaire_id = "")
        {
            var cmd = "select r.date_reglement, l.nom as l_nom, l.reference as l_reference, r.libelle, r.base_honoraire, r.charges, r.valeur_taxe, ";
            cmd += " p.reference as p_reference, trim(concat(pa.code, ' ', p.nom, ' ', p.prenom)) as p_nom , p.adresse as p_adresse, p.ville as p_ville, p.codepostal as p_codepostal,";
            cmd += " b.adresse as b_adresse, b.nom as b_nom, b.ville as b_ville, b.codepostal as b_codepostal,";
            cmd += "  r.divers1, r.montant_divers1, r.divers2, r.montant_divers2, r.divers3, r.montant_divers3, r.divers4, r.montant_divers4, r.divers5, r.montant_divers5 ";

            cmd += $" from {getSchemaTable()} r ";
            cmd += $" join {getSchema()}.locataire l on l.id = r.locataire_id";
            cmd += $" join {getSchema()}.proprietaire p on p.id = r.proprietaire_id";
            cmd += $" join {getSchema()}.biens b on b.id = r.bien_id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";

            cmd += " where date_reglement >= @dtDeb and date_reglement <= @dtFin";
            cmd += " and r.statut != @statut_del";
            if (proprietaire_id != "")
                cmd += " and r.proprietaire_id = @proprietaire_id";

// Mantis 271
//            cmd += " order by p.reference, date_reglement ";
            cmd += " order by p.reference, r.audit_created ";

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }

        String QuotedRef(List<String> refProprio)
        {
            var str = "";

            foreach (var s in refProprio)
            {
                str += $"{(str == "" ? "" : ",")}'{s}'";
            }

            return str;
        }

        public DataTable getHdrReleveCompteProprio(DateTime dtDeb, DateTime dtFin, List<String> refProprio)
        {
            var cmd = "select ";
            cmd += " p.reference as p_reference, trim(concat(pa.code, ' ', p.nom, ' ', p.prenom)) as p_nom , p.adresse as p_adresse, concat(p.ville, '\r\n', p.pays)  as p_ville, ";
            cmd += " p.codepostal as p_codepostal,";
            cmd += " b.adresse as b_adresse, b.nom as b_nom, b.ville as b_ville, b.codepostal as b_codepostal";
            cmd += $" from {getSchema()}.biens b ";
            cmd += $" join {getSchema()}.proprietaire p on b.proprietaire_id = p.id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";

            var ref_proprietaire = QuotedRef(refProprio);

            Console.WriteLine(ref_proprietaire);


            cmd += " where p.statut != @statut_del";

            if (ref_proprietaire != "")
                cmd += $" and p.reference in ({ref_proprietaire})";

            cmd += " group by 1,2,3,4,5,6,7,8,9 ";
            cmd += " order by 1";

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("ref_proprietaire", ref_proprietaire),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }

        public DataTable getReleveHonorairesProprietaires(DateTime dtDeb, DateTime dtFin, string proprietaire_id = "")
        {
            // TODO Parametrage Nature
            // TODO Parametrage TVA
            var nature = "020";
            var tva_hono = (decimal) 0.2;
         
            var cmd = "select ";
            cmd += "b.reference as b_reference, b.nom as b_nom, b.numero_lot, r.date_reglement, @nature as nature, r.base_honoraire, p.taux_honoraire, ";
//            cmd += " case when trim(r.tire) = '' then l.nom else r.tire end as tire,";
            cmd += " l.nom as tire,";
            cmd += " round(r.base_honoraire*p.taux_honoraire/100, 2) as honoraire,";
            cmd += " round(r.base_honoraire*p.taux_honoraire/100*@tva_hono, 2) as tva_debit_hono,";

//            cmd += " r.frais_bail as frais_bail, r.etat_lieux, r.honoraire_locataire as hono_nlle, p.reference as p_reference,l.reference as l_reference, ";
            cmd += " r.frais_bail as frais_bail, r.etat_lieux * 2 as etat_lieux, r.honoraire_locataire * 2 as hono_nlle, p.reference as p_reference,l.reference as l_reference, ";
            cmd += " r.proprietaire_id, r.locataire_id";
            cmd += $" from {getSchemaTable()} r ";
            cmd += $" join {getSchema()}.locataire l on l.id = r.locataire_id";
            cmd += $" join {getSchema()}.proprietaire p on p.id = r.proprietaire_id";
            cmd += $" join {getSchema()}.biens b on b.id = r.bien_id";

            cmd += " where date_reglement >= @dtDeb and date_reglement <= @dtFin";

            if (proprietaire_id != "")
                cmd += " and r.proprietaire_id = @proprietaire_id ";
            cmd += " and r.statut != @statut_del";

            cmd += " order by p.reference, date_reglement ";
            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("nature", nature),
                new NpgsqlParameter("tva_hono", tva_hono),
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public DataTable getReleveHonorairesProprietairesForFacture(DateTime dtDeb, DateTime dtFin, string proprietaire_id = "")
        {
            var cmd = "select r.* , p.taux_honoraire";
            cmd += $" from {getSchemaTable()} r ";
            cmd += $" join {getSchema()}.proprietaire p on p.id = r.proprietaire_id";
            cmd += $" join {getSchema()}.locataire l on l.id = r.locataire_id";
            cmd += " where date_reglement >= @dtDeb and date_reglement <= @dtFin";

            if (proprietaire_id != "")
                cmd += " and proprietaire_id = @proprietaire_id ";
            cmd += " and r.statut != @statut_del";
            
            cmd += " order by p.reference, l.reference, date_reglement ";
            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };

            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public DataTable getReglementLocataire(string locataire_id, DateTime dtDeb, DateTime dtFin)
        {
            var cmd = "select date_reglement, libelle, base_honoraire, valeur_taxe";
            cmd += $" from {getSchemaTable()} r ";
            cmd += " where locataire_id = @locataire_id";
            cmd += " and date_reglement >= @dtDeb and date_reglement <= @dtFin";
            cmd += " and r.statut != @statut_del";
            cmd += " order by date_reglement ";
            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("locataire_id", locataire_id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getReleveFiscalProprietaire(string proprietaire_id, DateTime dtDeb, DateTime dtFin)
        {
            var cmd = " select ";
            cmd += " date_reglement, l.reference, libelle, base_honoraire, charges, valeur_taxe, ";
            cmd += " montant_divers1+montant_divers2+montant_divers3+montant_divers4+montant_divers5 as divers ";
            cmd += $" from {getSchemaTable()} r";
            cmd += $" join {getSchema()}.locataire l on l.id=r.locataire_id ";
            cmd += " where proprietaire_id = @proprietaire_id and date_reglement >= @dtDeb and date_reglement <= @dtFin";
            cmd += " and r.statut != @statut_del";
            cmd += " order by date_reglement";

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeReglements(DateTime dtDeb, string locataires_ids)
        {
            var cmd = "select r.id, date_reglement, trim(concat ( pa2.code, ' ', l.nom, ' ', l.prenom) as locataire, l.reference as ref_loc, ";
            cmd += " trim(concat(pa.code, ' ',p.nom, ' ', p.prenom)) as proprietaire, p.reference as ref_prop, r.libelle, r.credit as montant";
            cmd += $" from {getSchemaTable()} r ";
            cmd += $" join {getSchema()}.locataire l on l.id = r.locataire_id ";
            cmd += $" join {getSchema()}.proprietaire p on p.id = r.proprietaire_id ";
            cmd += $" join {getSchema()}.biens b on b.id = r.bien_id ";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa2 on pa2.iparam_1 = l.civilite";
            cmd += " where date_reglement >= @dtDeb and date_reglement<=@dtFin";
            cmd += " and r.statut != @statut_del";
            cmd += $" and r.locataire_id in ({locataires_ids})";

            var dtFin = dtDeb.AddMonths(1).AddDays(-1);

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);

        }
        public static bool DeleteReglement( string reglement_id)
        {
            var rc = false;
            var reglement = getController().getEntiteById(reglement_id);

            if (reglement == null)
                throw new Exception("Reglement Invalide");
            if (reglement.Locataire == null)
            {
                throw new Exception("Loctaire Invalide");
            }
            var locataire = reglement.Locataire;
            Decimal oldTotal_du = 0;

            oldTotal_du = reglement.credit;

            if (DialogResult.Yes != MessageBox.Show("Cette Opération est irréversible\r\nVoulez-vous continuer", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
                return true;
            var total_du = locataire.total_du + oldTotal_du;
            var cnx = Database.GetInstance();
            var trx = cnx.BeginTransaction();

            try
            {
                reglement.statut = (int)GlobalConstantes.StatutOperation.Supprime;
                if (!getController().InsertOrUpdate(reglement))
                    throw new Exception("Erreur Reglement");

                locataire.total_du = total_du;

                if (!LocataireController.getController().InsertOrUpdate(locataire))
                    throw new Exception("Erreur Locataire");

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
