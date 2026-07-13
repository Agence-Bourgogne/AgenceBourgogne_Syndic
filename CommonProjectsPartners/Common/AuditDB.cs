using System;
using System.Collections.Generic;
using Npgsql;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;

namespace CommonProjectsPartners.Common
{
    public static class AuditDB
    {
        public enum Operation
        {
            Insert ,
            Update,
            Delete 
        }
        public static void Log(Operation operation, IAuditable entite, string schema, DateTime audit_date, string audit_user)
        {
            var changes = new List<AuditChange>();
            if (operation == Operation.Update) 
            {
                changes.AddRange(entite.GetChanges());
            }
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
                    sqlCmd.Parameters.AddWithValue("@entite_id", entite.getId());
                    sqlCmd.Parameters.AddWithValue("@operation_entite", Enum.GetName(typeof(Operation), operation));
                    sqlCmd.Parameters.AddWithValue("@propertie_entite", change.propertie_entite);
                    sqlCmd.Parameters.AddWithValue("@propertie_type", change.propertie_type);
                    sqlCmd.Parameters.AddWithValue("@old_value", change.old_value);
                    sqlCmd.Parameters.AddWithValue("@new_value", change.new_value);
                    sqlCmd.Parameters.AddWithValue("@audit_date", audit_date);
                    sqlCmd.Parameters.AddWithValue("@audit_user", audit_user);
                    var result = sqlCmd.ExecuteNonQuery();
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
        public string propertie_entite;
        public string propertie_type;
        public string old_value;
        public string new_value;
        public AuditChange() { }
        public AuditChange(string name, string type, object new_obj, object old_obj)
        {
            propertie_entite = name;
            propertie_type = type;
            if (type.Equals(""))
            {
                if (new_obj!= null)
                    propertie_type = new_obj.GetType().Name;
                else
                    if (old_obj != null)
                        propertie_type = old_obj.GetType().Name;
            }
            old_value = old_obj == null ? "":old_obj.ToString();
            new_value = new_obj == null ? "":new_obj.ToString();
        }
    }

    public interface IAuditable
    {
        List<AuditChange> GetChanges();
        string  getId();
    }


}
