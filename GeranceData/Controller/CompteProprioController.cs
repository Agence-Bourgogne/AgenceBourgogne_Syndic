using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Controller;
using GeranceData.Entites;

namespace GeranceData.Controller
{
    public class CompteProprioController : AbstractBaseController<CompteProprioEntite>
    {
        static CompteProprioController controller = new CompteProprioController();
        public override string getTable()
        {
            return "compte_proprietaire";
        }
        public static CompteProprioController getController()
        {
            return controller;
        }
        public DataTable getDetailCompteProprietaire(string ref_proprio)
        {
            string cmd = "select ";
            cmd += "p.reference, trim(concat (pa.code, ' ' , p.nom, ' ', p.prenom)) as nom, date_ecriture, cp.libelle, cp.debit, cp.credit ";

            cmd += String.Format(" from {0} cp ", getSchemaTable());
            cmd += String.Format(" join {0}.proprietaire p on p.id =  cp.proprietaire_id", getSchema());
            cmd += string.Format(" left join (SELECT groupe, code, iparam_1 FROM  parametres WHERE (groupe = 'CIVILITE')) pa on pa.iparam_1 = p.civilite", getSchema());

            cmd += " where p.reference = @ref_proprio";

            cmd += " order by cp.date_ecriture desc";


            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("ref_proprio", ref_proprio),
            };

            return getResultSQL(cmd, parameters);
            
        }
        public CompteProprioEntite getEcriture(string proprietaire_id, DateTime dtEcriture)
        {
            CompteProprioEntite compte = null;
            DateTime dtDeb = new DateTime(dtEcriture.Year, dtEcriture.Month, 1);
            DateTime dtFin = dtDeb.AddMonths(1).AddDays(-1);
            string cmd = String.Format(" select * from {0}", getSchemaTable());
            cmd += " where proprietaire_id = @proprietaire_id ";
            cmd += " and date_ecriture >= @dtDeb and date_ecriture <= @dtFin";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("proprietaire_id", proprietaire_id),
                new NpgsqlParameter("dtDeb", dtDeb),
                new NpgsqlParameter("dtFin", dtFin),
            };
            DataTable table = getResultSQL(cmd, parameters);
            if (table != null && table.Rows.Count > 0)
                compte = new CompteProprioEntite(table.Rows[0]);
            return compte;   
        }
    }
}
