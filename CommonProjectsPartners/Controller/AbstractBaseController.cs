using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Utils;
using Npgsql;
using MessageBox = System.Windows.Forms.MessageBox;

namespace CommonProjectsPartners.Controller;

public abstract class AbstractBaseController<TENTITE> where TENTITE : AbstractBaseEntite, new()
{

    protected readonly NpgsqlDataAdapter adapter = new();
    public abstract string getTable();
    protected DateTime TimestampServer;
    protected string DefaultOrder = "reference";
    public static NpgsqlConnection cnx;        
    public virtual string getSchema()
    {
        return BaseApplication.schema;
    }

    public virtual string getSchemaTable()
    {
        return string.Format($"{getSchema()}.{getTable()}");
    }
    protected virtual void setListSelectCommand()
    {
        var order = DefaultOrder;
        if ( cnx == null)
            cnx = Database.GetInstance();
        adapter.SelectCommand = new NpgsqlCommand(
            $"select * from {getSchemaTable()} where statut = 1 order by {order}", cnx);
    }
    public void setTimestampServer(DateTime time)
    {
        TimestampServer = time;
    }

    public DateTime setTimestampServer()
    {
        TimestampServer = Database.GetTimestampServer();
        return TimestampServer;
    }
    public DataTable GetTableList()
    {
        var order = DefaultOrder;
        if (cnx == null)
            cnx = Database.GetInstance();
        adapter.SelectCommand = new NpgsqlCommand(
            $"select * from {getSchemaTable()} where statut = 1 order by {order}", cnx);
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

    public DataTable GetAllEntite()
    {
        var order = DefaultOrder;
        if (cnx == null)
            cnx = Database.GetInstance();
        adapter.SelectCommand = new NpgsqlCommand($"select * from {getSchemaTable()} order by {order}", cnx);

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
    public DataTable GetList()
    {
        setListSelectCommand();
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
    public List<TENTITE> GetListEntite()
    {
        var table = GetList();
        var list = new List<TENTITE>();

        foreach (DataRow row in table.Rows)
        {
            var entite = new TENTITE();
            entite.setValues(row);
            list.Add(entite);
        }
        return list;
    }
    public virtual DataTable GetFindList(string filter)
    {
        var order = DefaultOrder;
        var cmd = $"Select id, reference, nom from {getSchemaTable()} ";
        cmd += " where statut != @statut_del";

        if (filter != "")
            cmd += " and "+filter;
        cmd += $" order by {order}";

        var parameters = new List<NpgsqlParameter> 
        {
            new("@statut_del", (int) AbstractBaseEntite.StatutEntite.Supprime)
        };
            
        return getResultSQL(cmd, parameters);
    }
    public bool SaveList(DataTable datas, bool bShowMessage = true)
    {
        if (datas == null)
            return true;

        var changes = datas.GetChanges();
        if (changes != null)
        {
            if (bShowMessage)
            {
                var result = MessageBox.Show("Des modifications on été apportéees\nVoulez-vous les enregistrer",
                    "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                    return false;
                if (result == DialogResult.No)
                {
                    datas.RejectChanges();
                    return true;
                }
            }
            try
            {
                TimestampServer = Database.GetTimestampServer();
                foreach (DataRow row in changes.Rows)
                {
                    var entite = new TENTITE();
                    if ( row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified )
                    {
                        entite.setValues(row);
                        if ( !"".Equals(entite.id) )
                            entite.old_entite = getEntiteById(entite.id);
                        doInsertOrUpdate(entite);
                    }
                }
            }
            catch (NpgsqlException e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        datas.AcceptChanges();
        return true;
    }
    public TENTITE getEntiteById(string id)
    {
        return getEntiteFromField("id", id);
    }
    public TENTITE getEntiteFromField(string field, string value)
    {
        return getEntite($" where {field} = @value",
            [new NpgsqlParameter("@value", value)]);
    }

    public TENTITE getEntite(string where, List<NpgsqlParameter> parameters = null)
    {
        var entite = default(TENTITE);
        var cmd = $"select * from {getSchemaTable()} {where} limit 1";
        var adapter = new NpgsqlDataAdapter();
        if (cnx == null)
            cnx = Database.GetInstance();

        adapter.SelectCommand = new NpgsqlCommand(cmd, cnx);
        if (parameters != null)
        {
            foreach (var parameter in parameters)
            {
                adapter.SelectCommand.Parameters.AddWithValue(parameter.ParameterName, parameter.NpgsqlValue);
            }
        }
        var table = new DataTable();
        try
        {
            adapter.Fill(table);
            if ( table.Rows.Count > 0 )
            {
                var row = table.Rows[0];
                entite = new TENTITE();
                entite.setValues(row);
                return entite;
            }
            return null;
        }
        catch (NpgsqlException e)
        {
            MessageBox.Show(e.Message);
        }
        return entite;
    }
    public DataTable getDataTable(string where, List<NpgsqlParameter> parameters = null)
    {
        var cmd = $"select * from {getSchemaTable()} {where} limit 1";
        var adapter = new NpgsqlDataAdapter();
        if (cnx == null)
            cnx = Database.GetInstance();

        adapter.SelectCommand = new NpgsqlCommand(cmd, cnx);
        if (parameters != null)
        {
            foreach (var parameter in parameters)
            {
                adapter.SelectCommand.Parameters.AddWithValue(parameter.ParameterName, parameter.NpgsqlValue);
            }
        }
        var table = new DataTable();
        try
        {
            adapter.Fill(table);
            return table;
        }
        catch (NpgsqlException e)
        {
            MessageBox.Show(e.Message);
        }
        return null;
    }

    public bool InsertOrUpdate(TENTITE entite)
    {
        TimestampServer = Database.GetTimestampServer();
        return doInsertOrUpdate(entite);
    }

    protected virtual bool doBeforeInsert() 
    {
        return true;
    }

    public bool doInsertOrUpdate(TENTITE entite )
    {
        var rc = false;

        if (cnx == null)
            cnx = Database.GetInstance();
        var msgError = entite.ValidationError();
        if ( msgError!="")
        {
            MessageBox.Show(msgError);
            return rc;
        }
        var operation = AuditDB.Operation.Update;
        if (entite.isNew)
        {
            if (!doBeforeInsert())
                return false;
            operation = AuditDB.Operation.Insert;
        }
        entite.audit_created = entite.audit_updated = TimestampServer;
        entite.audit_updated_by = entite.audit_created_by = BaseApplication.AuditString;
            
        var changes = entite.GetChanges();
        if (!entite.isNew && changes.Count < 1)
            return true;

        var cmd = entite.GetInsertOrUdpateCommand(getSchemaTable());
        var sqlCmd = new NpgsqlCommand(cmd, cnx);
        entite.SetInsertOrUpdateParameters(sqlCmd);

        try
        {
            sqlCmd.ExecuteNonQuery();
            AuditDB.Log(operation, entite , getSchema(), TimestampServer, BaseApplication.AuditString);
            entite.isNew = false;
            rc = true;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        return rc;
    }
    public AutoCompleteStringCollection getAutoComplete(string field)
    {
        var source = new AutoCompleteStringCollection();

        var cmd = $"Select {field} from {getSchemaTable()} order by reference";
        if (cnx == null)
            cnx = Database.GetInstance();

        adapter.SelectCommand = new NpgsqlCommand(cmd, cnx);
        var table = new DataTable();
        try
        {
            adapter.Fill(table);
            foreach (DataRow row in table.Rows)
            {
                source.Add(row["reference"].ToString());
            }
        }
        catch (NpgsqlException e)
        {
            MessageBox.Show(e.Message);
            return null;
        }
        return source;
    }
    public bool deleteEntite(AbstractBaseEntite entite)
    {
        var rc = false;
        var cmd = $"delete from {getSchemaTable()} where id = @id";
        if (cnx == null)
            cnx = Database.GetInstance();
        var sqlCmd = new NpgsqlCommand(cmd, cnx);
        try
        {
            sqlCmd.Parameters.AddWithValue("@id", entite.id);
            var nb = sqlCmd.ExecuteNonQuery();
            AuditDB.Log(AuditDB.Operation.Delete, entite, getSchema(), TimestampServer, BaseApplication.AuditString);
            rc = nb > 0;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        return rc;
    }

    public bool ExecuteNonQuery(string cmd, List<NpgsqlParameter> parameters = null)
    {
        var rc = false;
        if (cnx == null)
            cnx = Database.GetInstance();
        var sqlCmd = new NpgsqlCommand(cmd, cnx);
        try
        {
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    sqlCmd.Parameters.AddWithValue(parameter.ParameterName, parameter.NpgsqlValue);
                }
            }
            var nb = sqlCmd.ExecuteNonQuery();
            rc = nb > 0;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        return rc;
    }
    public DataTable getResultSQL(string cmd, List<NpgsqlParameter> parameters = null )
    {
        var adapter = new NpgsqlDataAdapter();
        if ( cnx == null )
            cnx = Database.GetInstance();
        adapter.SelectCommand = new NpgsqlCommand(cmd, cnx);
        if (parameters != null)
        {
            foreach (var parameter in parameters)
            {
                adapter.SelectCommand.Parameters.AddWithValue(parameter.ParameterName, parameter.NpgsqlValue);
            }
        }
        var table = new DataTable();
        int c;
        try
        {
            c = adapter.Fill(table);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
            return null;
        }
        return table;
    }
    public int getNextNumeroOperation(DateTime dateRef)
    {
        var valeur = 0;
        var cmd =
            $"select coalesce(max(numero_operation), 0 ) as valeur from {getSchemaTable()} where date_reference = @date_reference";
        var table = getResultSQL(cmd, [new NpgsqlParameter("@date_reference", dateRef)]);
        if (table != null)
        {
            valeur = (int)table.Rows[0]["valeur"] + 1;
        }

        return valeur;
    }

    public DataTable getListeSaisiesNonValidees(string liasse_id, int statutOperation)
    {
        var cmd = $"select * from {getSchemaTable()} ";
        cmd += " where liasse_id = @liasse_id and statut = @statut ";

        if (cnx == null)
            cnx = Database.GetInstance();

        adapter.SelectCommand = new NpgsqlCommand(cmd, cnx);
        adapter.SelectCommand.Parameters.AddWithValue("@liasse_id", liasse_id);
        adapter.SelectCommand.Parameters.AddWithValue("@statut", statutOperation);

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

    public bool ChangeEtat(string immeuble_id, DateTime date_deb, DateTime date_fin, int statut, int statut_del)
    {
        var cmd = $" update {getSchemaTable()} set statut = @statut ";
        cmd += "  where immeuble_id= @immeuble_id and date_reference >= @dtDeb and date_reference <= @dtFin ";
        cmd += " and statut != @statut_del";
        var parameters = new List<NpgsqlParameter> 
        {
            new("@immeuble_id", immeuble_id),
            new("@statut", statut),
            new("@statut_del", statut_del),
            new("@dtDeb", date_deb),
            new("@dtFin", date_fin)
        };

        getResultSQL(cmd, parameters);
        return true;
    }
}