using System;
using System.Collections.Generic;
using System.Data;
using CommonProjectsPartners.Controller;
using Npgsql;
using SyndicData.Common;
using SyndicData.Entites;

namespace SyndicData.Controller;

public class RepartIndividuelleController : AbstractBaseController<RepartIndividuelleEntite>
{
    private static readonly RepartIndividuelleController controller = new();
    public override string getTable()
    {
        return "repart_individuelle";
    }

    public static RepartIndividuelleController getController()
    {
        return controller;
        //return new RepartIndividuelleController();
    }
    public DataTable getRepartFromSaisie(string saisie_id)
    {
        var cmd = $"select * from {getSchemaTable()} where saisie_id = @saisie_id and statut!= @statut";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@saisie_id", saisie_id),
            new("@statut", (int) GlobalConstantes.StatutOperation.Supprime)
        };
        return getResultSQL(cmd, parameters);
    }

    public DataTable getFactureRepartFromAppel(string immeuble_id, string reference, DateTime date_reference) 
    {
        var cmd =
            $"select * from {getSchemaTable()} where immeuble_id = @immeuble_id and type_saisie = {(int)GlobalConstantes.TypeSaisie.AppelDeFond} and reference = @reference and date_reference = @date_reference and statut!= @statut";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@reference", reference),
            new("@date_reference", date_reference),
            new("@statut", (int) GlobalConstantes.StatutOperation.Supprime)
        };
        return getResultSQL(cmd, parameters);
    }

    public DataTable getLastRepartFromSaisie(string immeuble_id, string base_repart, GlobalConstantes.TypeSaisie saisie)
    {
        var where =
            $"select saisie_id from {getSchemaTable()} where immeuble_id = @immeuble_id and reference = @base_repart and type_saisie = @saisie order by audit_created desc limit 1";
        var cmd = $"select * from {getSchemaTable()} where statut != @statut and saisie_id = ({where})";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@base_repart", base_repart),
            new("@saisie", (int) saisie),
            new("@statut", (int) GlobalConstantes.StatutOperation.Supprime)
        };
        return getResultSQL(cmd, parameters);
    }

    public bool InsertRepartIndividuelleFromSaisie(OperationEntite operation, RepartIndividuelleEntite oldRepart, decimal index, decimal ancien, decimal nouveau, decimal global, GlobalConstantes.TypeSaisie type, int ref_cpt = 1)
    {
        var rc = false;

        var repart = RepartIndividuelleEntite.setData(operation, oldRepart, type);
        var montant = operation.debit;
        repart.global = operation.global;
        repart.global = global;
        repart.ref_cpt = ref_cpt;
        if (montant == 0)
        {
            if (repart.id == "")
                return true;
            repart.statut = (int)GlobalConstantes.StatutOperation.Supprime;
        }
        else
            repart.statut = (int)GlobalConstantes.StatutOperation.Brouillon;
            
        if (operation.base_repart == "80")
        {
            repart.index = montant != 0 ? repart.global : 0;
            repart.nouveau = repart.ancien = 0;
        }
        else
        {
            repart.index = index;
            repart.ancien = ancien;
            repart.nouveau = nouveau;
        }
        repart.montant = montant;
        rc = doInsertOrUpdate(repart);

        return rc;
    }
    public void DeleteElements(DataTable table)
    {
        foreach (DataRow row in table.Rows)
        {
            var ope = new RepartIndividuelleEntite(row)
            {
                statut = (int)GlobalConstantes.StatutOperation.Supprime
            };
            if (!doInsertOrUpdate(ope))
                throw new Exception("Annulation Repartition");
        }
    }
}