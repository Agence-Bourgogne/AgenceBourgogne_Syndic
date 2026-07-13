using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Controller;
using SyndicData.Entites;
using SyndicData.Common;
namespace SyndicData.Controller
{
    public class ExerciceComptableController : AbstractBaseController<ExerciceComptableEntite>
    {
        static ExerciceComptableController controller = new ExerciceComptableController();
        public override string getTable()
        {
            return "exercice_comptable";
        }
        public static ExerciceComptableController getController()
        {
            return controller;
            //return new ExerciceComptableController();
        }
        public ExerciceComptableController()
        {
            DefaultOrder = "reference";
        }
        public DataTable getListExerciceFromImmeuble(string immeuble_id)
        {
            var cmd =
                $"select e.id, e.reference, e.statut, b.id as budget_id, date_deb, date_fin, b.statut as statut_budget, sum(montant) as montant from {getSchemaTable()} e";
            cmd += $" left join {getSchema()}.budget b on e.id = b.exercice_id";
            cmd += $" left join {getSchema()}.budget_ligne bl on (b.id = bl.budget_id and bl.statut!= @statut_budget)";
            cmd += " where immeuble_id = @immeuble_id and e.statut != @statut ";
            cmd += " group by 1, 2, 3, 4, 5, 6, 7";
            cmd += " order by date_deb desc";
            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@statut", (int) GlobalConstantes.StatutExercice.Supprime),
                new NpgsqlParameter("@statut_budget", (int) GlobalConstantes.StatutBudget.Supprime),
            };

            return getResultSQL(cmd, parameters);
        }
        public DateTime getNewDateDebutExercice(string immeuble_id)
        {
            var dt = DateTime.Now;
            dt = dt.AddDays(1 - dt.DayOfYear);

            var cmd =
                $"select date_fin as date_last from {getSchemaTable()} where immeuble_id = @immeuble_id order by date_fin desc limit 1";

            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
            };
            var table = getResultSQL(cmd, parameters);
            if (table != null && table.Rows.Count > 0 )
            {
                var row = table.Rows[0];
                if (row[0] != null)
                {
                    dt = (DateTime)row[0];
                    dt = dt.AddDays(1);
                }
            }
            return dt;
        }
        public ExerciceComptableEntite getExerciceFromDate(string immeuble_id, DateTime dtDeb)
        {
            var cmd = " select * ";
            ExerciceComptableEntite entite = null;
            cmd += $" from {getSchemaTable()} ";
            cmd += " where immeuble_id = @immeuble_id and date_deb >= @dtDeb and date_fin <= @dtFin ";
//            cmd += " where immeuble_id = @immeuble_id and date_deb >= @dtDeb and date_fin <= @dtDeb ";

            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@dtDeb", dtDeb),
                new NpgsqlParameter("@dtFin", dtDeb.AddYears(1).AddDays(-1)),
            };


            var table = getResultSQL(cmd, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                entite = new ExerciceComptableEntite(table.Rows[0]);
            }
            return entite;
        }


        public ExerciceComptableEntite getExerciceCourant(string immeuble_id)
        {
            var cmd = " select * ";
            ExerciceComptableEntite entite = null;
            cmd += $" from {getSchemaTable()} ";
            cmd += " where id = ";
            cmd += $" (select id from {getSchemaTable()} ";
            cmd += " where immeuble_id = @immeuble_id and statut = @statut";
//            cmd += " order by date_deb desc limit 1)";
            cmd += " order by date_deb limit 1)";

            var statut = (int) GlobalConstantes.StatutExercice.Ouvert;

            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@statut", statut),
            };

//            Console.WriteLine(cmd.Replace("@immeuble_id", String.Format("{0}", immeuble_id)));

            var table = getResultSQL(cmd, parameters);
            if (table != null && table.Rows.Count > 0)
            {
                entite = new ExerciceComptableEntite(table.Rows[0]);
            }
            return entite;
        }

        public DataTable getExercicePrecedent(string exercice_id)
        {
            var schema = getSchema();
            var cmd = " select * ";
            cmd += $" from {getSchemaTable()} ";
            cmd += " where id = ";
            cmd += $" (select id from {getSchemaTable()} ";
            cmd += $" where date_deb < (select  date_deb from {schema}.exercice_comptable where id = @exercice_id)";
            cmd += $" and immeuble_id = (select  immeuble_id from {schema}.exercice_comptable where id = @exercice_id)";
            cmd += " order by date_deb desc limit 1)";
            
            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@exercice_id", exercice_id),
            };

            return getResultSQL(cmd, parameters);
        }
        public DataTable getExerciceSuivant(string exercice_id)
        {
            var schema = getSchema();
            var cmd = " select * ";
            cmd += $" from {getSchemaTable()} ";
            cmd += " where id = ";
            cmd += $" (select id from {getSchemaTable()} ";
            cmd += $" where date_deb > (select  date_deb from {schema}.exercice_comptable where id = @exercice_id)";
            cmd += $" and immeuble_id = (select  immeuble_id from {schema}.exercice_comptable where id = @exercice_id)";
            cmd += " order by date_deb asc limit 1)";
            Console.WriteLine(cmd);
            Console.WriteLine(exercice_id);

            var parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@exercice_id", exercice_id),
            };

            return getResultSQL(cmd, parameters);
        }
        public ExerciceComptableEntite createExerciceSuivant(ExerciceComptableEntite exercice)
        {
            ExerciceComptableEntite exercice_suivant;
            var table = getExerciceSuivant(exercice.id);
            if (table != null && table.Rows.Count > 0)
                exercice_suivant = new ExerciceComptableEntite(table.Rows[0]);
            else
            {
                exercice_suivant = new ExerciceComptableEntite();
                exercice_suivant.date_deb = exercice.date_fin.AddDays(1);
                exercice_suivant.date_fin = exercice_suivant.date_deb.AddYears(1).AddDays(-1);
                var reference =
                    $"{exercice_suivant.date_deb.Month.ToString("D2")}-{exercice_suivant.date_deb.Year} {exercice_suivant.date_fin.Month.ToString("D2")}-{exercice_suivant.date_fin.Year}";
                exercice_suivant.reference = reference;
                exercice_suivant.nom = reference;
                exercice_suivant.immeuble_id = exercice.immeuble_id;
                if (!InsertOrUpdate(exercice_suivant))
                    throw new Exception("Problème durant la création du nouvel exercice");
            }
            return exercice_suivant;
        }
    }
}