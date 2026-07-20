using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using Npgsql;

namespace CommonProjectsPartners.Common;

public static class AuditDB
{
    public enum Operation
    {
        Insert,
        Update,
        Delete
    }

    public static void Log(Operation operation, IAuditable entite, string schema, DateTime auditDate,
        string auditUser)
    {
        var changes = new List<AuditChange>();
        if (operation == Operation.Update) changes.AddRange(entite.GetChanges());
        if (operation == Operation.Insert)
        {
            var change = new AuditChange();
            changes.Add(change);
        }

        foreach (var change in changes)
        {
            var cmd = "insert into audit ( ";
            cmd += " schema_entite, name_entite, entite_id, operation_entite, propertie_entite, propertie_type, ";
            cmd += " old_value, new_value, audit_date, audit_user";
            cmd += " ) values (";
            cmd += " @schema_entite, @name_entite, @entite_id, @operation_entite, @propertie_entite, @propertie_type, ";
            cmd += " @old_value, @new_value, @audit_date, @audit_user";
            cmd += " )";

            try
            {
                var sqlCmd = new NpgsqlCommand(cmd, Database.GetInstance());
                sqlCmd.Parameters.AddWithValue("@schema_entite", schema);
                sqlCmd.Parameters.AddWithValue("@name_entite", entite.GetType().Name);
                sqlCmd.Parameters.AddWithValue("@entite_id", entite.GetId());
                sqlCmd.Parameters.AddWithValue("@operation_entite", Enum.GetName(typeof(Operation), operation));
                sqlCmd.Parameters.AddWithValue("@propertie_entite", change.propertie_entite);
                sqlCmd.Parameters.AddWithValue("@propertie_type", change.propertie_type);
                sqlCmd.Parameters.AddWithValue("@old_value", change.old_value);
                sqlCmd.Parameters.AddWithValue("@new_value", change.new_value);
                sqlCmd.Parameters.AddWithValue("@audit_date", auditDate);
                sqlCmd.Parameters.AddWithValue("@audit_user", auditUser);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                break;
            }
        }
    }
}

public class AuditChange
{
    public readonly string new_value;
    public readonly string old_value;
    public readonly string propertie_entite;
    public readonly string propertie_type;

    public AuditChange()
    {
    }

    public AuditChange(string name, string type, object newObj, object oldObj)
    {
        propertie_entite = name;
        propertie_type = type;
        if (type.Equals(""))
        {
            if (newObj != null)
                propertie_type = newObj.GetType().Name;
            else if (oldObj != null)
                propertie_type = oldObj.GetType().Name;
        }

        old_value = oldObj == null ? "" : oldObj.ToString();
        new_value = newObj == null ? "" : newObj.ToString();
    }
}

public interface IAuditable
{
    List<AuditChange> GetChanges();
    string GetId();
}