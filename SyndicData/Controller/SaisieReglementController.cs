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

public class SaisieReglementController : AbstractBaseController<SaisieReglementEntite>
{
    private static readonly SaisieReglementController controller = new();
    public override string getTable()
    {
        return "saisie_reglement";
    }
    public static SaisieReglementController getController()
    {
        //return new SaisieReglementController();
        return controller;
    }

    public DataTable GetAllElements(string immeuble_id , DateTime dtDeb, DateTime dtFin)
    {
        var cmd = $"select r.*, c.reference as ref_copro, i.reference as ref_imm from {getSchemaTable()} r ";
        cmd += " join agence.coproprietaire c on c.id = r.coproprietaire_id ";
        cmd += " join agence.immeuble i on i.id = r.immeuble_id ";
        cmd += " where r.statut!=@statut";

        if (immeuble_id != "")
            cmd += " and immeuble_id = @immeuble_id";

        if (dtDeb != Database.NullDate)
            cmd += " and date_reference >= @dtDeb";
        if (dtFin != Database.NullDate)
            cmd += " and date_reference <= @dtFin";
            
        cmd += " order by i.reference";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@statut", (int) GlobalConstantes.StatutOperation.Supprime),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin)
        };

        return getResultSQL(cmd, parameters);
    }
    public DataTable getGridRowSaisieReglement(string liasse_id)
    {
        var schema = getSchema();
        var cmd = " Select ";
        cmd += " concat(c.reference, ':',  c.nom, ' ', c.prenom) as \"Coproprietaire\", ";
        cmd += " concat(i.reference, ':',  i.nom) as \"Immeuble\", ";
        cmd += " concat ( n.reference, ':', n.nom) as \"Nature\", ";
        cmd += " e.montant, e.libelle as \"Libellé Ecriture\", ";
        cmd += " e.date_reference as \"Date Ecriture\", ";
        cmd += " c.reference as coproprietaire_ref, ";
        cmd += " i.reference as immeuble_ref, ";
        cmd += " n.reference as nature_ref, ";

        //            cmd += " l.numero_lot as \"Lot\", e.lot_id, " 
        cmd += " e.emetteur, e.banque, ";
        cmd += " e.liasse_id, e.immeuble_id, e.nature_id, e.coproprietaire_id, ";
        cmd += "  e.id";
        cmd += $" from {getSchemaTable()} e ";
        cmd += $" left join {schema}.immeuble i on i.id = e.immeuble_id";
        cmd += $" left join {schema}.coproprietaire c on c.id = e.coproprietaire_id";
        //cmd += String.Format(" left join {0}.lot_description l on l.id = e.lot_id", schema);
        cmd += $" left join {schema}.nature n on n.id = e.nature_id";

        cmd += " where liasse_id = @liasse_id and e.statut = @statut ";

        adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
        adapter.SelectCommand.Parameters.AddWithValue("@liasse_id", liasse_id);
        adapter.SelectCommand.Parameters.AddWithValue("@statut", (int)GlobalConstantes.StatutOperation.Brouillon);
        var table = new DataTable();
        try
        {
            adapter.Fill(table);
        }
        catch (NpgsqlException e)
        {
            MessageBox.Show(e.Message);
            return null;
        }
        return table;
    }
    public DataTable GetListeReglementValideFromNature(string liasse_id, string ref_nature)
    {
        var cmd = $" select * from {getSchemaTable()} r";
        if (ref_nature != "" && ref_nature != "0")
        {
            cmd += $" join {getSchema()}.nature n on n.id = nature_id ";
        }
        cmd += " where liasse_id = @liasse_id and r.statut = @statut ";
        if (ref_nature != "" && ref_nature != "0")
            cmd += " and n.reference = @nature_ref ";
        cmd += " order by nature_id, comptebanque";


        adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
        adapter.SelectCommand.Parameters.AddWithValue("@liasse_id", liasse_id);
        adapter.SelectCommand.Parameters.AddWithValue("@nature_ref", ref_nature);
        adapter.SelectCommand.Parameters.AddWithValue("@statut", (int)GlobalConstantes.StatutOperation.Valide);
        var table = new DataTable();
        try
        {
            adapter.Fill(table);
        }
        catch (NpgsqlException e)
        {
            MessageBox.Show(e.Message);
            return null;
        }
        return table;
    }
    public DataTable GetListeReglementValideFromCompteBanque(string liasse_id, string nature_id, string comptebanque)
    {
        var cmd = "SELECT date_reference, montant, emetteur, banque, reference ";
        cmd += $" FROM {getSchemaTable()} f";
        cmd += $" join {getSchema()}.coproprietaire c ON f.coproprietaire_id = c.id";
        cmd += " where liasse_id = @liasse_id and nature_id = @nature_id and comptebanque = @comptebanque and f.statut = @statut";

        adapter.SelectCommand = new NpgsqlCommand(cmd, Database.GetInstance());
        adapter.SelectCommand.Parameters.AddWithValue("@liasse_id", liasse_id);
        adapter.SelectCommand.Parameters.AddWithValue("@nature_id", nature_id);
        adapter.SelectCommand.Parameters.AddWithValue("@comptebanque", comptebanque);
        adapter.SelectCommand.Parameters.AddWithValue("@statut", (int)GlobalConstantes.StatutOperation.Valide);
        var table = new DataTable();
        try
        {
            adapter.Fill(table);
        }
        catch (NpgsqlException e)
        {
            MessageBox.Show(e.Message);
            return null;
        }
        return table;
    }
    public DataTable getListeOperations(string immeuble, string lot_reference, DateTime dtDeb, DateTime dtFin, string ref_nature = "", string libelle = "", string montant="", bool bValidOnly = true)
    {
        var schema = getSchema();
        var cmd = "Select ";
        var numlot = 0;

        cmd += " sf.id, i.reference as ref_immeuble, date_reference, n.reference as ref_nature, libelle, montant, c.reference as ref_copro, concat(c.prenom, ' ',c .nom) as coproprietaire, banque, sf.statut ";
        cmd += $" from {getSchemaTable()} sf";
        cmd += $" join {schema}.immeuble i on i.id = immeuble_id ";
        cmd += $" left join {schema}.nature n on n.id = nature_id ";
        cmd += $" left join {schema}.coproprietaire c on c.id = coproprietaire_id ";
        cmd += $" left join {schema}.lot_description l on l.coproprietaire_id = sf.coproprietaire_id";


        cmd += " where 1=1";
        if ( immeuble != "")
            cmd += " and i.reference = @immeuble";
        if (ref_nature != "")
            cmd += " and n.reference = @ref_nature";
        if (lot_reference != "")
        {
            numlot = Convert.ToInt32(lot_reference);
            cmd += " and l.numero_lot = @numlot";
        }
        if (dtDeb != DateTime.Parse("01/01/1970"))
            if (dtFin != DateTime.Parse("01/01/1970"))
                cmd += " and date_reference >= @dtDeb";
            else
                cmd += " and date_reference = @dtDeb";
        if (dtFin != DateTime.Parse("01/01/1970"))
            cmd += " and date_reference <= @dtFin";

        if (libelle != "")
            cmd += " and libelle like (@libelle)";
        if (montant != "")
            cmd += " and montant = @montant";
        if (bValidOnly)
            cmd += " and sf.statut = @statut";

        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble", immeuble),
            new("@numlot", numlot),
            new("@ref_nature", ref_nature),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin),
            new("@libelle", "%"+libelle+"%"),
            new("@montant", Convertir.ToDecimal(montant)),
            new("@statut", (int) GlobalConstantes.StatutOperation.Valide)
        };

        return getResultSQL(cmd, parameters);

    }
    public decimal getSumReglements(string immeuble_id, DateTime dtDeb, DateTime dtFin)
    {
        decimal sum = 0;
        var cmd = $"Select sum(montant) as montant from {getSchemaTable()}";
        cmd += " where immeuble_id = @immeuble_id and date_reference >= @dtDeb and date_reference <= @dtFin ";
        cmd += " and statut != @statut";

        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin),
            new("@statut", (int) GlobalConstantes.StatutOperation.Supprime)
        };

        var table = getResultSQL(cmd, parameters);

        if (table != null)
            if (table.Rows.Count > 0)
            {
                var row = table.Rows[0];
                sum = Convertir.ToDecimal(row["montant"]);
            }

        return sum;
    }

    public decimal getTotalOperationWithoutSolde(string immeuble_id, DateTime dtDeb, DateTime dtFin, string copro_id = "")
    {
        decimal sum = 0;
        var nature = "140";

        var cmd = $"select coalesce(sum(credit)-sum(debit),0) as montant from {getSchema()}.operation f";
        cmd += string.Format(" left join agence.nature n on n.id = f.nature_id ", getSchema());
        cmd += " where immeuble_id = @immeuble_id and date_reference >= @dtDeb and date_reference <= @dtFin";
        cmd += " and type_mouvement=@type_mouvement and type_operation = @type_operation";
        cmd += " and n.reference <> @nature ";
        cmd += " and f.statut != @statut";
        if ( copro_id != "")
            cmd += " and coproprietaire_id=@copro_id";

        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@nature", nature),
            new("@dtDeb", dtDeb),
            new("@dtFin", dtFin),
            new("@copro_id", copro_id),
            new("@statut", (int) GlobalConstantes.StatutOperation.Supprime),
            new("@type_mouvement",  nameof(GlobalConstantes.TypeMouvement.Recette)),
            new("@type_operation",  nameof(GlobalConstantes.TypeOperation.Tresorerie))
        };

        var table = getResultSQL(cmd, parameters);

        if (table != null)
            if (table.Rows.Count > 0)
            {
                var row = table.Rows[0];
                sum = Convertir.ToDecimal(row["montant"]);
            }

        return sum;
    }
    public bool AnnuleElement(SaisieReglementEntite entite, DataTable table)
    {
        var rc = false;
        var cnx = Database.GetInstance();
        var trx = cnx.BeginTransaction();
        try
        {
            TimestampServer = Database.GetTimestampServer();

            var ctl = OperationController.getController();
            ctl.setTimestampServer(TimestampServer);
            if (table != null)
            {
                foreach (DataRow row in table.Rows)
                {
                    var operation = new OperationEntite(row)
                    {
                        statut = (int)GlobalConstantes.StatutOperation.Supprime
                    };
                    if (!ctl.doInsertOrUpdate(operation))
                        throw new Exception("Annulation Operation");
                }
            }
            entite.statut = (int)GlobalConstantes.StatutOperation.Supprime;
            if (!doInsertOrUpdate(entite))
                throw new Exception("Annulation reglement");
            rc = true;
            trx.Commit();
        }
        catch (Exception ex)
        {
            trx.Rollback();
            MessageBox.Show(ex.Message);
        }
        return rc;
    }

    public void AnnuleElement(string element_id)
    {
        var entite = getController().getEntiteById(element_id);
        if ( entite != null )
        {
            AnnuleElement(entite);
            return;
        }
    }

    public bool AnnuleElement(SaisieReglementEntite entite)
    {
        var cmd = $"Select * from {getSchema()}.operation where saisie_id = @saisie_id";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@saisie_id", entite.id)
        };

        var table = getResultSQL(cmd, parameters);
        return AnnuleElement(entite, table);
    }
    public DataTable getSaisieReglement(OperationEntite operation)
    {
        var cmd = $"select o.*, c.reference as ref_copro from {getSchemaTable()} o";
        cmd += " join agence.coproprietaire c on c.id = o.coproprietaire_id ";
        cmd += " where immeuble_id = @immeuble_id and coproprietaire_id =@coproprietaire_id and date_reference = @date_reference and nature_id = @nature_id and trim(libelle) = trim(@libelle)";
        cmd += " and montant = @montant";
        var montant = operation.credit;

        if (operation.debit != 0)
            montant = operation.debit;

        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", operation.immeuble_id),
            new("@coproprietaire_id", operation.coproprietaire_id),
            new("@nature_id", operation.nature_id),
            new("@date_reference", operation.date_reference),
            new("@libelle", operation.libelle),
            new("@montant", montant)

        };
        return getResultSQL(cmd, parameters);
    }
}