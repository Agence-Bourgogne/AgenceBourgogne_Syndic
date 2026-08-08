using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CommonProjectsPartners.Controller;
using Npgsql;
using SyndicData.Common;
using SyndicData.Entites.ExerciceComptable;

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
        var cmd = $"""
                   select
                       e.id as id_exercice,
                       i.nom AS nom_immeuble,
                       CONCAT_WS(' ', i.rue, i.codepostal, i.ville) AS adresse_immeuble,
                       e.reference AS reference_exercice,
                       e.date_deb,
                       e.date_fin
                   from {getSchemaTable()} e
                   join agence.immeuble i on i.id = e.immeuble_id
                   where e.date_deb <= @date_maximale
                     and e.date_fin >= @date_minimale
                     and e.statut != @statut
                   order by e.date_deb
                   """;

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
                (string) row["id_exercice"],
                (string) row["nom_immeuble"],
                (string) row["adresse_immeuble"],
                (string) row["reference_exercice"],
                (DateOnly) row["date_deb"],
                (DateOnly) row["date_fin"],
                this));
    }

    public IEnumerable<CompteComptable> FetchComptesComptablesFor(string idExercice)
    {
        const string natureSoldeBilan = "140";
        const string natureVirement = "143";
        const string natureAppelDeFonds = "145";
        const string natureCheques = "146";

        const string operationsQuery =
            $"""
             SELECT 
             o.date_operation, 
             o.libelle, 
             o.debit, 
             o.credit, 
             o.liasse_id, 
             n.nom AS nature_nom, 
             n.reference_comptabilite AS nature_ref,
             COALESCE(f.nom, sr.emetteur) AS tiers,
             rf.date_reglement, 
             rf.libelle AS libelle_reg
             FROM agence.operation o
             INNER JOIN agence.exercice_comptable e ON e.id = @exercice_id
             LEFT JOIN agence.nature n ON o.nature_id = n.id 
             LEFT JOIN agence.saisie_facture sf ON o.saisie_id = sf.id
             LEFT JOIN agence.fournisseur f ON sf.fournisseur_id = f.id
             LEFT JOIN agence.saisie_reglement sr ON o.saisie_id = sr.id
             LEFT JOIN agence.reglement_facture rf ON o.saisie_id = rf.facture_id
             WHERE o.immeuble_id = e.immeuble_id
             AND o.date_operation >= e.date_deb
             AND o.date_operation <= e.date_fin
             AND (
                 n.reference NOT IN (
                     '{natureSoldeBilan}',
                     '{natureCheques}',
                     '{natureAppelDeFonds}',
                     '{natureVirement}'
                 )
                 OR n.reference IS NULL
             )
             ORDER BY n.nom, o.date_operation, o.liasse_id
             """;

        var parameters = new List<NpgsqlParameter>
        {
            new("@exercice_id", idExercice)
        };

        var operationsTable = getResultSQL(operationsQuery, parameters);

        const uint compteAbsent = 999999;

        var operationsCopropriété = operationsTable.AsEnumerable()
            .Select(row => (
                date_operation: row.Field<DateOnly>("date_operation"),
                libelle: row.Field<string>("libelle"),
                debit: row.Field<decimal?>("debit"),
                credit: row.Field<decimal?>("credit"),
                liasse_id: row.Field<string>("liasse_id"),
                nature_nom: row.Field<string>("nature_nom"),
                nature_ref: uint.TryParse(row.Field<string>("nature_ref"), out var compteValide) ? compteValide : compteAbsent,
                tiers: row.Field<string>("tiers"),
                date_reglement: row.Field<DateOnly?>("date_reglement"),
                libelle_reg: row.Field<string>("libelle_reg")
            ))
            .GroupBy(opération => (opération.nature_ref, opération.nature_nom))
            .Select(compte =>
            {
                var orderedByDate = compte
                    .OrderBy(operation => operation.date_operation)
                    .ToArray();

                var solde = orderedByDate.Aggregate(0m, (cur, elem) => cur + elem.credit ?? 0 - elem.debit ?? 0);
                var dateSolde = orderedByDate.Last().date_operation;

                var operations = orderedByDate.Select(operation => new OperationSurCompte(
                    operation.date_operation, operation.libelle, operation.tiers, operation.credit ?? -(operation.debit ?? 0)));

                return new CompteCopropriete(compte.Key.nature_ref, compte.Key.nature_nom, operations, new Solde(dateSolde, solde));
            })
            .ToArray();

        return operationsCopropriété;
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
        cmd += " order by date_deb limit 1)";

        var statut = (int)GlobalConstantes.StatutExercice.Ouvert;

        var parameters = new List<NpgsqlParameter>
        {
            new("@immeuble_id", immeubleId),
            new("@statut", statut)
        };

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