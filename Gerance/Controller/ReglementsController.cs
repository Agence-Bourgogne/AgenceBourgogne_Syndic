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
            string cmd = "select r.date_reglement, l.reference, concat(l.nom,' ', l.prenom) as locataire, r.credit, r.tire, r.banque_tire";
            cmd += string.Format(" from {0} r", getSchemaTable());
            cmd += string.Format(" join {0}.locataire l on l.id = r.locataire_id", getSchema());
            cmd += " where date_reglement >= @dtDeb and date_reglement <= @dtFin";
            cmd += " and r.code_reglement = @code_reglement";
            cmd += " and r.statut != @statut_del";
            cmd += " order by 1";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
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
            string cmd = "select r.id, l.reference as ref_locataire,  concat(l.nom, ' ', l.prenom) as locataire, b.reference as ref_immeuble, b.nom as immeuble, r.date_reglement, r.libelle, r.credit";
            cmd += String.Format(" from {0} r ", getSchemaTable());
            cmd += String.Format(" join {0}.biens b on b.id =  r.bien_id", getSchema());
            cmd += String.Format(" join {0}.locataire l on l.id =  r.locataire_id", getSchema());

            cmd += " where date_reglement >= @date_deb  and date_reglement <= @date_fin";
            if ( ref_locataire != "" )
            {
                cmd += " and l.reference = @ref_locataire";
            }
            cmd += " and r.statut != @statut_del";
            cmd += " order by r.date_reglement desc";

            DateTime date_reg = DateTime.Now;
            //date_reg = date_reg.AddDays(-date_reg.Day + 1);
            date_reg = date_reg.AddDays(-30);

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
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
            string cmd = "select r.id, l.reference as ref_locataire,  concat(l.nom, ' ', l.prenom) as locataire, b.reference as ref_immeuble, b.nom as immeuble, r.date_reglement, r.libelle, r.credit";
            cmd += String.Format ( " from {0} r ", getSchemaTable());
            cmd += String.Format(" join {0}.biens b on b.id =  r.bien_id", getSchema());
//            cmd += String.Format(" join {0}.proprietaire p on p.id =  r.proprietaire_id", getSchema());
            cmd += String.Format(" join {0}.locataire l on l.id =  r.locataire_id", getSchema());
            cmd += " where date_reglement >= @date_reg ";
            cmd += " and r.statut != @statut_del";
            cmd += " order by r.date_reglement desc";

            DateTime date_reg = DateTime.Now;
            //date_reg = date_reg.AddDays(-date_reg.Day + 1);
            date_reg = date_reg.AddDays(-30);

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("date_reg", date_reg),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public DataTable getReleveCompteProprio(DateTime dtDeb, DateTime dtFin, string proprietaire_id = "")
        {
            string cmd = "select r.date_reglement, l.nom as l_nom, l.reference as l_reference, r.libelle, r.base_honoraire, r.charges, r.valeur_taxe, ";
            cmd += " p.reference as p_reference, concat(p.nom, ' ', p.prenom) as p_nom , p.adresse as p_adresse, p.ville as p_ville, p.codepostal as p_codepostal,";
            cmd += " b.adresse as b_adresse, b.nom as b_nom, b.ville as b_ville, b.codepostal as b_codepostal,";
            cmd += "  r.divers1, r.montant_divers1, r.divers2, r.montant_divers2, r.divers3, r.montant_divers3, r.divers4, r.montant_divers4, r.divers5, r.montant_divers5 ";

            cmd += string.Format(" from {0} r ", getSchemaTable());
            cmd += string.Format(" join {0}.locataire l on l.id = r.locataire_id", getSchema());
            cmd += string.Format(" join {0}.proprietaire p on p.id = r.proprietaire_id", getSchema());
            cmd += string.Format(" join {0}.biens b on b.id = r.bien_id", getSchema());

            cmd += " where date_reglement >= @dtDeb and date_reglement <= @dtFin";
            cmd += " and r.statut != @statut_del";
            if (proprietaire_id != "")
                cmd += " and r.proprietaire_id = @proprietaire_id";

            cmd += " order by p.reference, date_reglement ";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };

            return getResultSQL(cmd, parameters);
        }

        private string QuotedRef(List<string> refProprio)
        {
            string str1 = "";
            foreach (string str2 in refProprio)
                str1 += $"{(str1 == "" ? (object) "" : (object) ",")}'{str2}'";
            return str1;
        }

        public DataTable getHdrReleveCompteProprio(
            DateTime dtDeb,
            DateTime dtFin,
            List<string> refProprio)
        {
            string str1 = "select " + " p.reference as p_reference, trim(concat(pa.code, ' ', p.nom, ' ', p.prenom)) as p_nom , p.adresse as p_adresse, concat(p.ville, '\r\n', p.pays)  as p_ville, " + " p.codepostal as p_codepostal," + " b.adresse as b_adresse, b.nom as b_nom, b.ville as b_ville, b.codepostal as b_codepostal" + $" from {this.getSchema()}.biens b " + $" join {this.getSchema()}.proprietaire p on b.proprietaire_id = p.id" + " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite";
            string str2 = this.QuotedRef(refProprio);
            Console.WriteLine(str2);
            string str3 = str1 + " where p.statut != @statut_del";
            if (str2 != "")
                str3 += $" and p.reference in ({str2})";
            return this.getResultSQL(str3 + " group by 1,2,3,4,5,6,7,8,9 " + " order by 1", new List<NpgsqlParameter>()
            {
                new NpgsqlParameter(nameof (dtDeb), (object) dtDeb),
                new NpgsqlParameter(nameof (dtFin), (object) dtFin),
                new NpgsqlParameter("ref_proprietaire", (object) str2),
                new NpgsqlParameter("statut_del", (object) 9)
            });
        }
        public DataTable getReleveHonorairesProprietaires(DateTime dtDeb, DateTime dtFin, string proprietaire_id = "")
        {
            // TODO Parametrage Nature
            // TODO Parametrage TVA
            string nature = "020";
            decimal tva_hono = (decimal) 0.2;
         
            string cmd = "select ";
            cmd += "b.reference as b_reference, b.nom as b_nom, b.numero_lot, r.date_reglement, @nature as nature, r.base_honoraire, p.taux_honoraire, r.tire,";
            cmd += " round(r.base_honoraire*p.taux_honoraire/100, 2) as honoraire,";
            cmd += " round(r.base_honoraire*p.taux_honoraire/100*@tva_hono, 2) as tva_debit_hono,";

            cmd += " r.frais_bail, r.honoraire_locataire * 2 as hono_nlle, p.reference as p_reference,l.reference as l_reference, ";
            cmd += " r.proprietaire_id, r.locataire_id";
            cmd += string.Format(" from {0} r ", getSchemaTable());
            cmd += string.Format(" join {0}.locataire l on l.id = r.locataire_id", getSchema());
            cmd += string.Format(" join {0}.proprietaire p on p.id = r.proprietaire_id", getSchema());
            cmd += string.Format(" join {0}.biens b on b.id = r.bien_id", getSchema());

            cmd += " where date_reglement >= @dtDeb and date_reglement <= @dtFin";

            if (proprietaire_id != "")
                cmd += " and r.proprietaire_id = @proprietaire_id ";
            cmd += " and r.statut != @statut_del";

            cmd += " order by p.reference, date_reglement ";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
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
            string cmd = "select r.* , p.taux_honoraire";
            cmd += string.Format(" from {0} r ", getSchemaTable());
            cmd += string.Format(" join {0}.proprietaire p on p.id = r.proprietaire_id", getSchema());
            cmd += string.Format(" join {0}.locataire l on l.id = r.locataire_id", getSchema());
            cmd += " where date_reglement >= @dtDeb and date_reglement <= @dtFin";

            if (proprietaire_id != "")
                cmd += " and proprietaire_id = @proprietaire_id ";
            cmd += " and r.statut != @statut_del";
            
            cmd += " order by p.reference, l.reference, date_reglement ";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
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
            String cmd = "select date_reglement, libelle, base_honoraire, valeur_taxe";
            cmd += String.Format(" from {0} r ", getSchemaTable());
            cmd += " where locataire_id = @locataire_id";
            cmd += " and date_reglement >= @dtDeb and date_reglement <= @dtFin";
            cmd += " and r.statut != @statut_del";
            cmd += " order by date_reglement ";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("locataire_id", locataire_id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getReleveFiscalProprietaire(string proprietaire_id, DateTime dtDeb, DateTime dtFin)
        {
            string cmd = " select ";
            cmd += " date_reglement, l.reference, libelle, base_honoraire, charges, valeur_taxe, montant_divers1+montant_divers2+montant_divers3+montant_divers4+montant_divers5 as divers ";
            cmd += string.Format(" from {0} r", getSchemaTable());
            cmd += string.Format(" join {0}.locataire l on l.id=r.locataire_id ", getSchema());
            cmd += " where proprietaire_id = @proprietaire_id and date_reglement >= @dtDeb and date_reglement <= @dtFin";
            cmd += " and r.statut != @statut_del";
            cmd += " order by date_reglement";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeReglements(DateTime dtDeb, string locataires_ids)
        {
            string cmd = "select r.id, date_reglement, concat ( l.nom, ' ', l.prenom) as locataire, l.reference as ref_loc, concat(p.nom, ' ', p.prenom) as proprietaire, p.reference as ref_prop, r.libelle, r.credit as montant";
            cmd += string.Format(" from {0} r ", getSchemaTable());
            cmd += string.Format(" join {0}.locataire l on l.id = r.locataire_id ", getSchema());
            cmd += string.Format(" join {0}.proprietaire p on p.id = r.proprietaire_id ", getSchema());
            cmd += string.Format(" join {0}.biens b on b.id = r.bien_id ", getSchema());
            cmd += " where date_reglement >= @dtDeb and date_reglement<=@dtFin";
            cmd += " and r.statut != @statut_del";
            cmd += string.Format(" and r.locataire_id in ({0})", locataires_ids);

            DateTime dtFin = dtDeb.AddMonths(1).AddDays(-1);

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            return getResultSQL(cmd, parameters);

        }
        public static bool DeleteReglement( string reglement_id)
        {
            bool rc = false;
            ReglementEntite reglement = ReglementsController.getController().getEntiteById(reglement_id);

            if (reglement == null)
                throw new Exception("Reglement Invalide");
            if (reglement.Locataire == null)
            {
                throw new Exception("Loctaire Invalide");
            }
            LocataireEntite locataire = reglement.Locataire;
            Decimal oldTotal_du = 0;

            oldTotal_du = reglement.credit;

            if (DialogResult.Yes != MessageBox.Show("Cette Opération est irréversible\r\nVoulez-vous continuer", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
                return true;
            decimal total_du = locataire.total_du + oldTotal_du;
            NpgsqlConnection cnx = Database.GetInstance();
            NpgsqlTransaction trx = cnx.BeginTransaction();

            try
            {
                reglement.statut = (int)GlobalConstantes.StatutOperation.Supprime;
                if (!ReglementsController.getController().InsertOrUpdate(reglement))
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
