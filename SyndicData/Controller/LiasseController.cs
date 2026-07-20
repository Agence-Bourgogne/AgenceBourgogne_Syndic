using System;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Utils;
using Npgsql;
using SyndicData.Common;
using SyndicData.Entites;

namespace SyndicData.Controller;

public class LiasseController : AbstractBaseController<LiasseEntite>
{
    private static readonly LiasseController controller = new();

    public override string getTable()
    {
        return "liasse";
    }

    public static LiasseController getController()
    {
        //return new LiasseController();
        return controller;
    }

    public DataTable getLiasseActives(GlobalConstantes.TypeOperation type_ecriture, bool bAddNew = true)
    {
        var cmd = $"select * from {getSchemaTable()} ";
        cmd += " where type_ecriture = @type_ecriture and statut = @statut";
        //getSchemaTable());
        //, (int)type, (int)GlobalConstantes.StatutOperation.Actif);
        adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());

        adapter.SelectCommand.Parameters.AddWithValue("@type_ecriture", type_ecriture.ToString());
        adapter.SelectCommand.Parameters.AddWithValue("@statut", (int)GlobalConstantes.StatutOperation.Brouillon);

        var table = new DataTable();
        try
        {
            adapter.Fill(table);
            if (bAddNew)
            {
                var row = table.NewRow();
                row["id"] = LiasseEntite.NOUVELLE_ID;
                row["reference"] = LiasseEntite.NOUVELLE_DESI;
                row["montant"] = type_ecriture switch
                {
                    GlobalConstantes.TypeOperation.Facture => ParametresDB.getParam1("MONTANT_DEFAULT", "ECRITURE"),
                    GlobalConstantes.TypeOperation.AppelDeFond => ParametresDB.getParam1("MONTANT_DEFAULT",
                        "APPEL_FOND"),
                    GlobalConstantes.TypeOperation.Tresorerie =>
                        ParametresDB.getParam1("MONTANT_DEFAULT", "TRESORERIE"),
                    _ => row["montant"]
                };
                row["type_ecriture"] = type_ecriture;
                table.Rows.InsertAt(row, 0);
            }

            return table;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        return null;
    }

    public DataTable GetLiassesValidees(GlobalConstantes.TypeOperation type_ecriture, string limit = "")
    {
        var cmd = $"select * from {getSchemaTable()} ";
        cmd += " where type_ecriture = @type_ecriture and statut = @statut";
        cmd += " order by audit_created desc ";
        if (limit != "")
            cmd += limit;
        //getSchemaTable());
        //, (int)type, (int)GlobalConstantes.StatutOperation.Actif);
        adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());

        adapter.SelectCommand.Parameters.AddWithValue("@type_ecriture", type_ecriture.ToString());
        adapter.SelectCommand.Parameters.AddWithValue("@statut", (int)GlobalConstantes.StatutOperation.Valide);

        var table = new DataTable();
        adapter.Fill(table);
        return table;
    }
}