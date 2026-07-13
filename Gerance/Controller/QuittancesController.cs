using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Controller;
using GeranceData.Entites;
using System.Data;
using System.Windows.Forms;

namespace GeranceData.Controller
{
    public class QuittancesController : AbstractBaseController<QuittanceEntite>
    {
        static QuittancesController controller = new QuittancesController();
        public override string getTable()
        {
            return "quittances";
        }
        public static QuittancesController getController()
        {
            return controller;
        }

        public QuittanceEntite GetQuittance(LocataireEntite locataire, DateTime dtQuittance)
        {
            DateTime dt = new DateTime(dtQuittance.Year, dtQuittance.Month, 1);
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@locataire_id", locataire.id),
                new NpgsqlParameter("@date_quittance", dt),
            };
            String cmd = " where locataire_id = @locataire_id and date_quittance = @date_quittance ";
            QuittanceEntite quittance = getEntite(cmd, parameters);
            
            if (quittance == null)
                quittance = new QuittanceEntite();

            return quittance;
        }
        public decimal getChargesReglees(string locataire_id, DateTime dtDebut, DateTime dtFin)
        {
            decimal charges = 0;
            string cmd = "select sum(montant_charge) as charges";
            cmd += String.Format(" from {0} ", getSchemaTable());
            cmd += " where locataire_id = @locataire_id and date_quittance >= @dtDebut and date_quittance <= @dtFin";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("locataire_id", locataire_id),
                new NpgsqlParameter("dtDebut", dtDebut),
                new NpgsqlParameter("dtFin", dtFin),
            };

            DataTable table = getResultSQL(cmd, parameters);
            if (table != null & table.Rows.Count > 0)
            {
                Console.WriteLine("Charges : {0}", table.Rows[0]["charges"]);
                charges = Convertir.ToDecimal(table.Rows[0]["charges"].ToString());
            }

            return charges;
        }
        public QuittanceEntite getDerniereQuittance(string locataire_id)
        {
            QuittanceEntite quittance = null;
            string cmd = String.Format(" select * from {0}", getSchemaTable());
            cmd += " where locataire_id = @locataire_id order by date_quittance desc limit 1";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("locataire_id", locataire_id),
            };
            DataTable table = getResultSQL(cmd, parameters);
            if (table != null & table.Rows.Count > 0)
            {
                quittance = new QuittanceEntite(table.Rows[0]);
            }
            return quittance;
        }
        public DataTable getListQuittances(DateTime dt, string locataire_id = "", string proprietaire_id = "")
        {
            DateTime dtDeb = new DateTime(dt.Year, dt.Month, 1);
            DateTime dtFin = dtDeb.AddMonths(1).AddDays(-1);

            string cmd = "select q.id, date_quittance, montant_quittance, l.reference as ref_locataire, concat(l.nom, ' ', l.prenom) as locataire, p.reference as ref_proprio, concat(p.nom, ' ', p.prenom) as proprietaire ";
            cmd += string.Format("from {0} q", getSchemaTable() );
            cmd += string.Format(" join {0}.locataire l on l.id = locataire_id", getSchema());
            cmd += string.Format(" join {0}.proprietaire p on p.id = proprietaire_id", getSchema());

            cmd += " where date_quittance >= @dtDeb and date_quittance <= @dtFin";

            if (locataire_id != "")
                cmd += " and l.reference = @locataire_id";
            if (proprietaire_id != "")
                cmd += " and p.reference = @proprietaire_id";
            cmd += " order by date_quittance desc";


            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
                new NpgsqlParameter("locataire_id", locataire_id),
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
            };


            return getResultSQL(cmd, parameters);
        }

        public static bool DeleteQuittance(QuittanceEntite quittance)
        {
            bool bResult = false;
            decimal old_montant = quittance.montant_quittance;
            LocataireEntite locataire = quittance.Locataire;
            try
            {
                if (locataire == null)
                    throw new Exception("Locataire invalide");
                // TODO C'est moins ou Plus ??
                //                locataire.total_du += old_montant;
                locataire.total_du -= old_montant;
                if (!QuittancesController.getController().deleteEntite(quittance))
                    throw new Exception("Annulation Quittance");
                if (!LocataireController.getController().InsertOrUpdate(locataire))
                    throw new Exception("Mise à jour locataire");
                bResult = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return bResult;
        }

        public DataTable getDetailQuittanceForImpression(string quittance_id)
        {
            return this.getResultSQL("select q.montant_loyer, q.montant_augmentation, q.valeur_taxe, q.montant_charge as montant_charges, q.frais_bail as frais_bail, q.etat_lieux  as etat_lieux, 0 as reste_du, q.honoraire_locataire as honoraires_locataire, " + " (q.montant_loyer+ q.montant_augmentation+ q.valeur_taxe+ q.montant_charge+ q.frais_bail + q.etat_lieux + q.montant_divers1 + q.montant_divers2+q.montant_divers3 + q.montant_divers4+ q.montant_divers5 + honoraire_locataire) as total_du," + " q.montant_divers1, q.montant_divers2, q.montant_divers3, q.montant_divers4, q.montant_divers5," + " q.divers1, q.divers2, q.divers3, q.divers4, q.divers5, " + " trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) as nom_loca, l.adresse, l.codepostal, l.ville, l.reference, b.adresse as imm_adress, b.ville as imm_ville, b.codepostal as imm_cp" + " , b.periodicite_loyer" + string.Format(" from {0}.quittances q join {0}.biens b on q.bien_id = b.id join {0}.locataire l on l.id = q.locataire_id ", (object) this.getSchema()) + " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite" + " where q.id  = @quittance_id ", new List<NpgsqlParameter>()
            {
                new NpgsqlParameter(nameof (quittance_id), (object) quittance_id)
            });
        }

        public DataTable getDetailAppelDeLoyerEntree(string quittance_id)
        {
            string cmd = "select " + "case when coalesce (comptable_id, '') != '' then  concat(c.nom, ' ', c.prenom) else trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) end as nom_loca, " + " case when coalesce (comptable_id, '') != '' then c.adresse else l.adresse end as adresse, " + " case when coalesce (comptable_id, '') != '' then c.codepostal else l.codepostal end as codepostal, " + " case when coalesce (comptable_id, '') != '' then c.ville else l.ville end as ville, " + " l.reference, b.adresse as imm_adress, b.ville as imm_ville, b.codepostal as imm_cp ," + " q.montant_loyer, q.montant_augmentation, q.valeur_taxe, b.montant_charges, q.frais_bail as frais_bail , q.etat_lieux as etat_lieux, l.total_du as reste_du, b.honoraires_locataire, " + " (q.montant_loyer+ q.montant_augmentation+ q.valeur_taxe+ b.montant_charges+ q.frais_bail +q.etat_lieux+ b.honoraires_locataire + q.montant_divers1 + q.montant_divers2+q.montant_divers3 + q.montant_divers4+ q.montant_divers5 ) as total_du," + " q.montant_divers1, q.montant_divers2, q.montant_divers3, q.montant_divers4, q.montant_divers5," + " q.divers1, q.divers2, q.divers3, q.divers4, q.divers5 " + " , 12 as periodicite_loyer" + string.Format(" from {0}.quittances q join {0}.locataire l on (l.id = q.locataire_id) ", (object) this.getSchema()) + $" join {this.getSchema()}.biens b on (b.id = q.bien_id) " + $" left join {this.getSchema()}.comptable c on c.id = comptable_id " + " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite" + " where q.id  = @quittance_id";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>()
            {
                new NpgsqlParameter(nameof (quittance_id), (object) quittance_id)
            };
            Console.WriteLine(cmd);
            return this.getResultSQL(cmd, parameters);
        }
    }
}
