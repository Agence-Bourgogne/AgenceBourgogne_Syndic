using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Utils;
using Npgsql;
using SyndicData.Common;
using SyndicData.Entites;

namespace SyndicData.Controller;

public class ImmeubleRepartitionController : AbstractBaseController<ImmeubleRepartitionEntite>
{
    private static readonly ImmeubleRepartitionController controller = new();
    public string specific_schema = "";
    public override string getTable()
    {
        return "immeuble_repartition";
    }

    public static ImmeubleRepartitionController getController()
    {
        //return new ImmeubleRepartitionController();
        return controller;
    }

    public static string keyRepart(int ligne, int colonne)
    {
        return $"{ligne}{colonne}";
    }
    public DataTable getRepartitionImmeuble(string immeuble_id)
    {
        adapter.SelectCommand = new NpgsqlCommand(
            $"select * from {getSchemaTable()} where immeuble_id=@immeuble_id and statut=@statut order by ligne, colonne", Database.GetInstance());
        var table = new DataTable();
        adapter.SelectCommand.Parameters.AddWithValue("@immeuble_id", immeuble_id);
        adapter.SelectCommand.Parameters.AddWithValue("@statut", (int) GlobalConstantes.StatutData.Actif);

        try
        {
            adapter.Fill(table);
            return table;
        }
        catch (NpgsqlException e)
        {
            MessageBox.Show(e.Message);
            return null;
        }
    }

    public ImmeubleRepartitionEntite getRepartitionImmeubleEntite(string immeuble_id)
    {
        var repart = getRepartitionImmeuble(immeuble_id);
        return new ImmeubleRepartitionEntite(repart.Rows[0]);
    }

    // TODO A Revoir
    private int getTypeVentilation(int ligne)
    {
        return ligne < 8 ? 0 : 1;
    }

    private bool HaveRepartitionIndividuelle(string immeuble_id)
    {
        var valeur = 0;
        var cmd = $"select coalesce(count(*),0)::integer as valeur  from {getSchemaTable()} ";
        cmd += " where immeuble_id = @immeuble_id and ligne = 8 ";

        var table = getResultSQL(cmd, [new NpgsqlParameter("@immeuble_id", immeuble_id)]);
        if (table != null)
        {
            valeur = (int)table.Rows[0]["valeur"] ;
        }
        return valeur > 0;
    } 
    public bool SaveRepartitionImmeuble(ImmeubleEntite immeuble_entite, DataGridView grid)
    {
        bool rc;
        specific_schema = immeuble_entite.reference;
        TimestampServer = Database.GetTimestampServer();
        var cnx = Database.GetInstance();
        var trx = cnx.BeginTransaction();

        try
        {
            var bIndiv = HaveRepartitionIndividuelle(immeuble_entite.id);
            foreach (DataGridViewRow rowGrid in grid.Rows)
            {
                foreach (DataGridViewTextBoxCell cell in rowGrid.Cells)
                {
                    if (cell.ColumnIndex == 0)
                        continue;
                    var entite_repart = (ImmeubleRepartitionEntite)cell.Tag;
                    var value = 0;
                    if (cell.Value.ToString() != "" && cell.Value.ToString() != "*")
                        value = Convert.ToInt32(cell.Value);
                    if (entite_repart == null)
                    {
                        if (value != 0)
                        {
                            entite_repart = new ImmeubleRepartitionEntite
                            {
                                immeuble_id = immeuble_entite.id,
                                nom = "",
                                reference = keyRepart(cell.RowIndex + 1, cell.ColumnIndex - 1),
                                ligne = cell.RowIndex + 1,
                                colonne = cell.ColumnIndex - 1,
                                type_ventilation = getTypeVentilation(cell.RowIndex + 1)
                            };
                        }
                    }
                    if (entite_repart != null)
                    {
                        if (entite_repart.valeur != value)
                        {
                            entite_repart.valeur = value;
                            if (!doInsertOrUpdate(entite_repart))
                                throw new Exception("Repartition Millieme");
                        }
                    }
                }
            }
            if ( !bIndiv )
                for (var i = 0; i < 8; i++)
                {
                    var entite_repart = new ImmeubleRepartitionEntite
                    {
                        immeuble_id = immeuble_entite.id,
                        nom = "",
                        reference = keyRepart(8, i),
                        ligne = 8,
                        colonne = i,
                        type_ventilation = getTypeVentilation(8)
                    };
                    if (!doInsertOrUpdate(entite_repart))
                        throw new Exception("Repartition Individuelle");
                }
            rc = true;
            trx.Commit();
        }
        catch (Exception ex)
        {
            trx.Rollback();
            rc = false;
            MessageBox.Show(ex.Message);                    
        }
        return rc;
    }
    public bool ExistRepartitionReference(string immeuble_id, string reference )
    {
        var bExist = false;
        var cmd =
            $"select immeuble_id, reference from {getSchemaTable()} where immeuble_id=@immeuble_id and reference = @reference";

        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@reference", reference)
        };

        var table = getResultSQL(cmd, parameters);
        if (table.Rows.Count > 0)
            bExist = true;
        return bExist;
    }
    public ImmeubleRepartitionEntite getRepartFromImmeubleBase(string immeuble_id, string base_ref)
    {
        adapter.SelectCommand = new NpgsqlCommand(
            $"select * from {getSchemaTable()} where immeuble_id=@immeuble_id and reference = @reference", Database.GetInstance());
        var table = new DataTable();
        adapter.SelectCommand.Parameters.AddWithValue("@immeuble_id", immeuble_id);
        adapter.SelectCommand.Parameters.AddWithValue("@reference", base_ref);

        try
        {
            adapter.Fill(table);

            if ( table.Rows.Count > 0 )
                return new ImmeubleRepartitionEntite(table.Rows[0]);

            return null;
        }
        catch (NpgsqlException e)
        {
            MessageBox.Show(e.Message);
            return null;
        }
    }
}