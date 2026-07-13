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
            cmd += "p.reference, concat (p.nom, ' ', p.prenom) as nom, date_ecriture, cp.libelle, cp.debit, cp.credit ";

            cmd += String.Format(" from {0} cp ", getSchemaTable());
            cmd += String.Format(" join {0}.proprietaire p on p.id =  cp.proprietaire_id", getSchema());

            cmd += " where p.reference = @ref_proprio";

            cmd += " order by cp.date_ecriture ";


            List<NpgsqlParameter> parameters = new List<NpgsqlParameter>{
                new NpgsqlParameter("ref_proprio", ref_proprio),
            };

            return getResultSQL(cmd, parameters);
            
        }
    }
}
