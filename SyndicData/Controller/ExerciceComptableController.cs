using System;
using System.Collections.Generic;
using System.Data;
using CommonProjectsPartners.Controller;
using Npgsql;
using SyndicData.Common;
using SyndicData.Entites;

namespace SyndicData.Controller;

public class ExerciceComptableController : AbstractBaseController<ExerciceComptableEntite>
{
    private static readonly ExerciceComptableController Controller = new();

    private ExerciceComptableController()
    {
        DefaultOrder = "reference";
    }

    public override string getTable()
    {
        return "exercice_comptable";
    }

    public static ExerciceComptableController GetController()
    {
        return Controller;
        //return new ExerciceComptableController();
    }

    public DataTable GetListExerciceFromImmeuble(string immeubleId)
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
            new("@immeuble_id", immeubleId),
            new("@statut", (int)GlobalConstantes.StatutExercice.Supprime),
            new("@statut_budget", (int)GlobalConstantes.StatutBudget.Supprime)
        };

        return getResultSQL(cmd, parameters);
    }

    public IEnumerable<ExerciceComptableSelector> GetExercicesIncludedInDates(DateOnly dateMinimale, DateOnly dateMaximale)
    {
        var cmd = $"select " +
                  $"i.reference AS reference_immeuble, " +
                  $"e.reference as reference_exercice, " +
                  $"e.date_deb, " +
                  $"e.date_fin " +
                  $"from {getSchemaTable()} e " +
                  $"join immeuble i on i.id = e.immeuble_id" +
                  "where e.date_deb <= @date_maximale " +
                  "and e.date_fin >= @date_minimale " +
                  "and e.statut != @statut " +
                  "order by e.date_deb";

        var parameters = new List<NpgsqlParameter>
        {
            new("@date_minimale", dateMinimale),
            new("@date_maximale", dateMaximale),
            new("@statut", (int)GlobalConstantes.StatutExercice.Supprime)
        };

        var table = getResultSQL(cmd, parameters);

        return table
            .AsEnumerable()
            .Select(row => new ExerciceComptableSelector(
                (string) row["reference_immeuble"],
                (string) row["reference_exercice"],
                (DateOnly) row["date_deb"],
                (DateOnly) row["date_fin"]));
    }

    public DateTime GetNewDateDebutExercice(string immeubleId)
    {
        var dt = DateTime.Now;
        dt = dt.AddDays(1 - dt.DayOfYear);

        var cmd =
            $"select date_fin as date_last from {getSchemaTable()} where immeuble_id = @immeuble_id order by date_fin desc limit 1";

        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeubleId)
        };
        var table = getResultSQL(cmd, parameters);
        if (table is { Rows.Count: > 0 })
        {
            var row = table.Rows[0];
            dt = (DateTime)row[0];
            dt = dt.AddDays(1);
        }

        return dt;
    }

    public ExerciceComptableEntite GetExerciceFromDate(string immeubleId, DateTime dtDeb)
    {
        var cmd = " select * ";
        ExerciceComptableEntite entite = null;
        cmd += $" from {getSchemaTable()} ";
        cmd += " where immeuble_id = @immeuble_id and date_deb >= @dtDeb and date_fin <= @dtFin ";
//            cmd += " where immeuble_id = @immeuble_id and date_deb >= @dtDeb and date_fin <= @dtDeb ";

        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeubleId),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtDeb.AddYears(1).AddDays(-1))
        };


        var table = getResultSQL(cmd, parameters);
        if (table is { Rows.Count: > 0 }) entite = new ExerciceComptableEntite(table.Rows[0]);
        return entite;
    }


    public ExerciceComptableEntite GetExerciceCourant(string immeubleId)
    {
        var cmd = " select * ";
        ExerciceComptableEntite entite = null;
        cmd += $" from {getSchemaTable()} ";
        cmd += " where id = ";
        cmd += $" (select id from {getSchemaTable()} ";
        cmd += " where immeuble_id = @immeuble_id and statut = @statut";
//            cmd += " order by date_deb desc limit 1)";
        cmd += " order by date_deb limit 1)";

        var statut = (int)GlobalConstantes.StatutExercice.Ouvert;

        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeubleId),
            new("@statut", statut)
        };

//            Console.WriteLine(cmd.Replace("@immeuble_id", String.Format("{0}", immeuble_id)));

        var table = getResultSQL(cmd, parameters);
        if (table is { Rows.Count: > 0 }) entite = new ExerciceComptableEntite(table.Rows[0]);
        return entite;
    }

    public DataTable GetExercicePrecedent(string exerciceId)
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
            new("@exercice_id", exerciceId)
        };

        return getResultSQL(cmd, parameters);
    }

    public DataTable GetExerciceSuivant(string exerciceId)
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
        Console.WriteLine(exerciceId);

        var parameters = new List<NpgsqlParameter>
        {
            new("@exercice_id", exerciceId)
        };

        return getResultSQL(cmd, parameters);
    }

    public ExerciceComptableEntite CreateExerciceSuivant(ExerciceComptableEntite exercice)
    {
        ExerciceComptableEntite exerciceSuivant;
        var table = GetExerciceSuivant(exercice.id);
        if (table is { Rows.Count: > 0 })
        {
            exerciceSuivant = new ExerciceComptableEntite(table.Rows[0]);
        }
        else
        {
            exerciceSuivant = new ExerciceComptableEntite
            {
                date_deb = exercice.date_fin.AddDays(1)
            };
            exerciceSuivant.date_fin = exerciceSuivant.date_deb.AddYears(1).AddDays(-1);
            var reference =
                $"{exerciceSuivant.date_deb.Month:D2}-{exerciceSuivant.date_deb.Year} {exerciceSuivant.date_fin.Month:D2}-{exerciceSuivant.date_fin.Year}";
            exerciceSuivant.reference = reference;
            exerciceSuivant.nom = reference;
            exerciceSuivant.immeuble_id = exercice.immeuble_id;
            if (!InsertOrUpdate(exerciceSuivant))
                throw new Exception("Problème durant la création du nouvel exercice");
        }

        return exerciceSuivant;
    }
}