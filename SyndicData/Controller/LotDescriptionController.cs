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

public class LotDescriptionController : AbstractBaseController<LotDescriptionEntite>
{
    private static readonly LotDescriptionController controller = new();
    public override string getTable()
    {
        return "lot_description";
    }
    public static LotDescriptionController getController()
    {
        return controller;
        //            return new LotDescriptionController();
    }
    public DataTable getDataGridListeLotDescription(ImmeubleEntite immeuble, bool bAddMontant = true, bool bAddValeur = true, bool bAddindex = false)
    {
        var cmd =
            $"select @fields from {getSchemaTable()} l  @join1 where l.immeuble_id = @immeuble_id order by numero_lot";
        var fields = "";

        if (bAddindex)
        {
            fields += "null as ancien, ";
            fields += "null as nouveau, ";
        }

        if (bAddValeur)
            fields += "null as index, ";

        if (bAddMontant)
            fields += "null as montant, ";

        fields += "l.id, numero_lot, l.coproprietaire_id, c.reference as coproprietaire, c.nom, c.prenom, ";
        fields += " numero_batiment, numero_escalier, numero_etage, avance, l.statut";
        var join1 = $" left join {getSchema()}.coproprietaire  C on (c.id = l.coproprietaire_id)";

        cmd = cmd.Replace("@fields", fields);
        cmd = cmd.Replace("@join1", join1);
        Console.WriteLine(cmd);

        adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
        var table = new DataTable();
        adapter.SelectCommand.Parameters.AddWithValue("@immeuble_id", immeuble.id);
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

    public DataTable createLotRepartition(ImmeubleEntite immeuble, int nblot)
    {
        TimestampServer = Database.GetTimestampServer();

        var cmd =
            $"select coalesce(max(numero_lot),0) as valeur from {getSchemaTable()} where immeuble_id = @immeuble_id";
        var numero_lot = 0;

        var table = getResultSQL(cmd, [new NpgsqlParameter("@immeuble_id", immeuble.id)]);
        if (table.Rows.Count > 0)
            if (table.Rows[0] != null)
                numero_lot = (int)table.Rows[0]["valeur"];

        var cnx = Database.GetInstance();
        var trx = cnx.BeginTransaction();
        var ctl = LotRepartitionController.getController();
        ctl.setTimestampServer(TimestampServer);
        try
        {
            for (var i = 0; i < nblot; i++)
            {
                var lot_entite = new LotDescriptionEntite
                {
                    numero_lot = ++numero_lot,
                    immeuble_id = immeuble.id,
                    coproprietaire_id = "",
                    date_changement = TimestampServer,
                    numero_batiment = "",
                    numero_escalier = "",
                    numero_etage = "",
                    avance = 0,
                    statut = (int)GlobalConstantes.StatutData.Actif
                };

                if (!doInsertOrUpdate(lot_entite))
                    throw new Exception("Lot Description");

                // TODO A Revoir ces Repart Indiv
                // createLotRepartition Individuelle

                // TODO creer la colonne statut en DB
                for (var b = 0; b < 8; b++)
                {
                    var rep_entite = new LotRepartitionEntite
                    {
                        colonne = b,
                        ligne = 8,
                        reference = $"{8}{b}",
                        immeuble_id = immeuble.id,
                        lot_id = lot_entite.id,
                        type_ventilation = 1
                    };
                    //rep_entite.statut = (int)GlobalConstantes.StatutData.Actif;
                    if (!ctl.doInsertOrUpdate(rep_entite))
                        throw new Exception("Lot Repartition");
                }
            }

            trx.Commit();
        }
        catch (Exception ex)
        {
            trx.Rollback();
            MessageBox.Show(ex.Message);
        }
        return getDataGridListeLotDescription(immeuble, false, false);
    }

    public DataTable getListeLotCoproprietaires(ImmeubleEntite immeuble, CoproprietaireEntite copro = null)
    {
        if (immeuble == null) // || copro == null)
            return null;
        var cmd = "select l.id, l.numero_lot as reference, concat(c.nom, ' ', c.prenom ) as nom ";
        cmd += $" from {getSchema()}.lot_description l";
        cmd += $" join  {getSchema()}.coproprietaire c on c.id = l.coproprietaire_id ";
        //            cmd += String.Format(" ";
        cmd += " where l.immeuble_id = @immeuble_id ";
        cmd += " and l.statut = 1";
        cmd += " order by 2";
        if (copro != null)
            cmd += $" and and c.id = '{copro.id}'";
        return getResultSQL(cmd, [new NpgsqlParameter("@immeuble_id", immeuble.id)]);
    }

    public DataTable getComboListeLotCoproprietaires(ImmeubleEntite immeuble, CoproprietaireEntite copro = null)
    {
        if (immeuble == null) // || copro == null)
            return null;
        var cmd = "select l.id, l.numero_lot as reference, concat(l.numero_lot, ' - ', c.nom, ' ', c.prenom ) as nom ";
        cmd += $" from {getSchema()}.lot_description l";
        cmd += $" join  {getSchema()}.coproprietaire c on c.id = l.coproprietaire_id ";
        //            cmd += String.Format(" ";
        cmd += " where l.immeuble_id = @immeuble_id and c.statut = @statut_actif";
        if (copro != null)
            cmd += $" and and c.id = '{copro.id}'";

        cmd += " order by 2";
        var parameters = new List<NpgsqlParameter> 
        { 
            new("@immeuble_id", immeuble.id) ,
            new("@statut_actif", (int) GlobalConstantes.StatutData.Actif)
        };

        return getResultSQL(cmd, parameters);//new List<NpgsqlParameter> { new NpgsqlParameter("@immeuble_id", immeuble.id) });
    }

    public DataTable getListeLot(string immeuble_id)
    {
        var cmd = $"select * from {getSchemaTable()} where immeuble_id = @immeuble_id";
        return getResultSQL(cmd, [new NpgsqlParameter("@immeuble_id", immeuble_id)]);
    }
    public DataTable getListeLotFiscaux(string immeuble_id)
    {
        var cmd =
            $"select * from {getSchemaTable()} l join {getSchema()}.coproprietaire c on c.id = l.coproprietaire_id where l.immeuble_id = @immeuble_id and c.declaration=true";
        return getResultSQL(cmd, [new NpgsqlParameter("@immeuble_id", immeuble_id)]);
    }
    public List<LotDescriptionEntite> getListeLotDescription(string immeuble_id)
    {
        var cmd = $"select * from {getSchemaTable()} where immeuble_id = @immeuble_id";
        var table = getResultSQL(cmd, [new NpgsqlParameter("@immeuble_id", immeuble_id)]);
        var liste = new List<LotDescriptionEntite>();
        if (table != null)
            foreach (DataRow row in table.Rows)
                liste.Add(new LotDescriptionEntite(row));

        return liste;
    }
    public List<LotDescriptionEntite> getListeLotDescriptionFiscaux(string immeuble_id)
    {
        var cmd =
            $"select * from {getSchemaTable()} l join {getSchema()}.coproprietaire c on c.id = l.coproprietaire_id where immeuble_id = @immeuble_id and c.declaration=true";
        var table = getResultSQL(cmd, [new NpgsqlParameter("@immeuble_id", immeuble_id)]);
        var liste = new List<LotDescriptionEntite>();
        if (table != null)
            foreach (DataRow row in table.Rows)
                liste.Add(new LotDescriptionEntite(row));

        return liste;
    }

    public LotDescriptionEntite getLotFromReference(string immeuble_id, string numLot)
    {
        LotDescriptionEntite lot = null;
        var numlot = Convertir.ToInt(numLot);

        var cmd =
            $"select * from {getSchemaTable()} where immeuble_id = @immeuble_id and numero_lot = @numero_lot ";

        var table = getResultSQL(cmd, [new NpgsqlParameter("@immeuble_id", immeuble_id), new NpgsqlParameter("@numero_lot", numlot)]);

        if (table != null)
            if (table.Rows.Count > 0)
                lot = new LotDescriptionEntite(table.Rows[0]);
        return lot;
    }
    // TODO Quid des copro avec plusieurs lots
    public LotDescriptionEntite getLotFromCopro(string coproprietaire_id)
    {
        LotDescriptionEntite lot = null;

        var cmd = $"select * from {getSchemaTable()} where coproprietaire_id = @coproprietaire_id ";

        var table = getResultSQL(cmd, [new NpgsqlParameter("@coproprietaire_id", coproprietaire_id)]);

        if (table != null)
            if (table.Rows.Count > 0)
                lot = new LotDescriptionEntite(table.Rows[0]);
        return lot;
    }
    public LotDescriptionEntite getLotFromCopro(string immeuble_id, string coproprietaire_id)
    {
        LotDescriptionEntite lot = null;

        var cmd =
            $"select * from {getSchemaTable()} where immeuble_id = @immeuble_id and coproprietaire_id = @coproprietaire_id ";

        var table = getResultSQL(cmd, [
            new NpgsqlParameter("@immeuble_id", immeuble_id),
            new NpgsqlParameter("@coproprietaire_id", coproprietaire_id)
        ]);

        if (table != null)
            if (table.Rows.Count > 0)
                lot = new LotDescriptionEntite(table.Rows[0]);
        return lot;
    }
    public decimal getAvanceImmeuble(string immeuble_id)
    {
        decimal avance = 0;
        var cmd = $" select sum(avance) as avance from {getSchemaTable()} where immeuble_id = @immeuble_id";
        var table = getResultSQL(cmd, [
            new NpgsqlParameter("@immeuble_id", immeuble_id)
        ]);
        if (table != null)
            if (table.Rows.Count > 0)
                avance = Convertir.ToDecimal(table.Rows[0]["avance"]);
        return avance;
    }

    public LotDescriptionEntite getLotFromRefImmeubleNumLot(string ref_imm, int numero_lot)
    {
        LotDescriptionEntite lot = null;

        var cmd = $"select * from {getSchemaTable()} ";
        cmd += $" join {getSchema()}.immeuble i on i.id = immeuble_id ";
        cmd += " where i.reference = @ref_imm and numero_lot = @numero_lot";
        var parameters = new List<NpgsqlParameter> 
        { 
            new("@ref_imm", ref_imm),
            new("@numero_lot", numero_lot)
        };
        var table = getResultSQL(cmd, parameters);

        if (table != null)
            if (table.Rows.Count > 0)
                lot = new LotDescriptionEntite(table.Rows[0]);
        return lot;
    }

}