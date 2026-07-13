using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Controller;
using GeranceData.Entites;
using GeranceData.Common;

namespace GeranceData.Controller
{
    public class FacturesController : AbstractBaseController<FactureEntite>
    {
        static FacturesController controller = new FacturesController();
        //static string fournisseur_id = null; 
        public override string getTable()
        {
            return "factures";
        }
        public static FacturesController getController()
        {
            return controller;
        }
        public DataTable getFactures30DerniersJours()
        {
            var cmd = "select f.id, l.reference as ref_locataire,  trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) as locataire, b.reference as ref_immeuble, b.nom as immeuble, f.date_facture, f.libelle, abs(f.debit) as debit,abs(f.credit) as credit";
            cmd += $" from {getSchemaTable()} f ";
            cmd += $" join {getSchema()}.biens b on b.id =  f.bien_id";
            cmd += $" join {getSchema()}.locataire l on l.id =  f.locataire_id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";

            cmd += " where date_facture >= @date_reg ";
            cmd += " and f.statut != @statut_del";
// Mantis 253
//            cmd += " order by f.audit_created desc, f.date_facture desc";
            cmd += " order by f.audit_created desc, f.date_facture desc";

            var date_reg = DateTime.Now;
            date_reg = date_reg.AddDays(-30);

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("date_reg", date_reg),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };

            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeFactures(DateTime dtDeb , DateTime dtFin, string locataire_id = "", string nature_id = "")
        {
            var cmd = "select f.id, l.reference as ref_locataire,  trim(concat(pa.code, ' ', l.nom, ' ', l.prenom)) as locataire, b.reference as ref_immeuble, b.nom as immeuble, f.date_facture, f.libelle, abs(f.debit) as debit,abs(f.credit) as credit";
            cmd += $" from {getSchemaTable()} f ";
            cmd += $" join {getSchema()}.biens b on b.id =  f.bien_id";
            cmd += $" join {getSchema()}.locataire l on l.id =  f.locataire_id";
            cmd += " left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = l.civilite";
            
            cmd += " where date_facture >= @dtDeb and date_Facture <= @dtFin";
            cmd += " and f.statut != @statut_del";
            if (locataire_id != "")
                cmd += " and l.reference = @locataire_id";
            cmd += " order by f.date_facture desc";

            //DateTime date_reg = DateTime.Now;
            //date_reg = date_reg.AddDays(-30);

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("locataire_id", locataire_id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };

            return getResultSQL(cmd, parameters);
        }

        public DataTable getSoldeProprio(string proprietaire_id = "")
        {
            var cmd = "select p.reference as p_reference, to_date('01/01/01', 'dd/mm/yy') as date_facture, 'Solde Antérieur' as nom, '' as libelle, abs(p.debit) as debit , abs(p.credit) as credit";
            cmd += $" from {getSchema()}.proprietaire p ";

            cmd += "where debit <> 0 ";
            if (proprietaire_id != "")
                cmd += " and p.id = @proprietaire_id ";

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }

        public DataTable getDeductionProprio(DateTime dtDeb, DateTime dtFin, string proprietaire_id = "")
        {
            var cmd = "select p.reference as p_reference, f.date_facture, n.nom, f.libelle, abs(f.debit) as debit , abs(f.credit) as credit";
            //cmd += " p.reference as p_reference, concat(p.prenom, ' ', p.nom) as p_nom , p.adresse as p_adresse, p.ville as p_ville, p.codepostal as p_codepostal,";
            //cmd += " b.adresse as b_adresse, b.nom as b_nom, b.ville as b_ville, b.codepostal as b_codepostal";
            cmd += $" from {getSchemaTable()} f ";
            cmd += $" left join {getSchema()}.nature n on n.id = f.nature_id";
            cmd += $" join {getSchema()}.proprietaire p on p.id = f.proprietaire_id";
            //cmd += string.Format(" join {0}.biens b on b.id = r.bien_id", getSchema());

            cmd += " where date_facture >= @dtDeb and date_facture <= @dtFin";
            cmd += " and f.statut != @statut_del";
            if (proprietaire_id != "")
                cmd += " and proprietaire_id = @proprietaire_id";

            cmd += " order by p.reference, date_facture , reglement_id, n.reference, f.libelle";
//            cmd += " order by p.reference, f.locataire_id, f.date_facture , reglement_id, n.reference, f.libelle";

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };
            Console.WriteLine(cmd);
            return getResultSQL(cmd, parameters);
        }
        public FactureEntite getFactureHonoraire(ReglementEntite reglement, string nature_id, string libelle, decimal montant)
        {
            FactureEntite facture = null;
            var cmd = $"select * from {getSchemaTable()} f";
            cmd += " where 1=1";
            cmd += " and f.statut != @statut_del";
            cmd += " and f.reglement_id = @reglement_id";
            cmd += " and trim(libelle)= trim(@libelle)";
            /*
            cmd += " and bien_id= @bien_id";
            cmd += " and proprietaire_id= @proprietaire_id";
            cmd += " and locataire_id= @locataire_id";
            cmd += " and nature_id= @nature_id";
            cmd += " and date_facture= @date_facture";
//            cmd += " and debit = @debit";
             */
//            cmd += " and debit = @montant";
            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("bien_id", reglement.bien_id),
                new NpgsqlParameter("proprietaire_id", reglement.proprietaire_id),
                new NpgsqlParameter("locataire_id", reglement.locataire_id),
                new NpgsqlParameter("nature_id", nature_id),
                new NpgsqlParameter("date_facture", reglement.date_reglement),
                new NpgsqlParameter("libelle", libelle),
                new NpgsqlParameter("montant", montant),
                new NpgsqlParameter("reglement_id", reglement.id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };

            var table = getResultSQL(cmd, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                facture = new FactureEntite(table.Rows[0]);
            }
            else
            {
                facture = new FactureEntite();
            }

            var fournisseur  = FournisseurController.getController().getEntiteFromField("reference", "113");
            facture.code_reglement = 5;
            facture.setValues(reglement, nature_id, libelle, montant, fournisseur.id);
  //              Console.WriteLine(c);

            return facture;
        }
        public DataTable getRecapFraisLigneFiscale(string proprietaire_id, DateTime dtDeb, DateTime dtFin)
        {
            var cmd = "select ";
            cmd += " n.declaration, n.nom, ";
            //cmd += " sum(f.debit) - sum(f.credit) as montant ";
            cmd += " sum (case when f.credit <0 then f.credit else f.debit end - case when f.credit <0 then 0 else f.credit end ) as montant";
            cmd += $" from {getSchemaTable()} f ";
            cmd += $" join {getSchema()}.nature n on n.id = f.nature_id ";
            cmd += " where f.proprietaire_id = @proprietaire_id and date_facture >= @dtDeb and date_facture <= @dtFin";
            cmd += " and f.statut != @statut_del";
            cmd += " and trim(coalesce(n.declaration, '')) != ''";
            cmd += " group by 1, 2";

            var parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
                new NpgsqlParameter("statut_del", (int) GlobalConstantes.StatutOperation.Supprime),
            };

            return getResultSQL(cmd, parameters);
        }

    }
}
