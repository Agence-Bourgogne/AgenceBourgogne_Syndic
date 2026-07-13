using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using Npgsql;

namespace CommonProjectsPartners.Entites;

public abstract class AbstractBaseEntite : IAuditable
{
    public enum StatutEntite { vide0, Actif, vide2, vide3, vide4, vide5, vide6, vide7, vide8, Supprime }


    public string id = "";
    public DateTime audit_created;
    public string audit_created_by;
    public DateTime audit_updated;
    public string audit_updated_by;
    public AbstractBaseEntite old_entite;
    public List<UpdateField> updatables = [];
    public bool isNew;

    public virtual void setValues(DataRow row)
    {
        if (row != null)
        {
            id = row["id"].ToString();
            if (row.Table.Columns.Contains("audit_created"))
                audit_created = row["audit_created"] is DBNull ? DateTime.Now : (DateTime)row["audit_created"];
            if (row.Table.Columns.Contains("audit_created_by"))
                audit_created_by = row["audit_created_by"].ToString();
            if (row.Table.Columns.Contains("audit_updated"))
                audit_updated = row["audit_updated"] is DBNull ? DateTime.Now : (DateTime)row["audit_updated"];
            if (row.Table.Columns.Contains("audit_updated_by"))
                audit_updated_by = row["audit_updated_by"].ToString();
        }
        isNew = "".Equals(id);
        foreach (var fieldupd in updatables)
        {
            var field = fieldupd.fieldinfo;
            try
            {
                if (row == null || row[field.Name] is DBNull)
                    field.SetValue(this, null);
                else
                    field.SetValue(this, row[field.Name]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        old_entite = (AbstractBaseEntite)MemberwiseClone();
    }
    public virtual string GetInsertOrUdpateCommand(string schemaTable)
    {
        var cmd = "";
//            if (!"".Equals(id))
        if ( !isNew )
        {
            cmd = $"update {schemaTable} set ";
            foreach (var fieldupd in updatables)
            {
                var field = fieldupd.fieldinfo;
                var curr_value = field.GetValue(this);
                var old_value = field.GetValue(old_entite);

                if (curr_value == null)
                {
                    if (curr_value!=old_value)
                        cmd += $"{field.Name}=@{field.Name}, ";

                }
                else
                if (!curr_value.Equals(old_value))
                    cmd += $"{field.Name}=@{field.Name}, ";
            }
            cmd += " audit_updated = @audit_updated, audit_updated_by= @audit_updated_by ";
            cmd += " where id = @id";
        }
        else
        {
            if ( string.IsNullOrEmpty(id))
                id = get_uuid();
            cmd = $"insert into {schemaTable} (";

            cmd += "id, ";
            foreach (var fieldupd in updatables)
            {
                var field = fieldupd.fieldinfo;
                cmd += field.Name + ", ";
            }
            cmd += " audit_created , audit_created_by ";
            cmd += " ) values ( ";
            cmd += "@id, ";
            foreach (var fieldupd in updatables)
            {
                var field = fieldupd.fieldinfo;
                cmd += "@" + field.Name + ", ";
            }
            cmd += " @audit_created , @audit_created_by "; 
            cmd += " )";
        }
        return cmd;
    }
    public string get_uuid()
    {
        var cmd = "select public.get_uuid()";
        var sqlCmd = new NpgsqlCommand(cmd, Database.GetInstance());
        var uuid = (string) sqlCmd.ExecuteScalar();
        return uuid;
    }

    public virtual string ValidationError()
    {
        var message = "";
        return message;
    }
    public virtual void SetInsertOrUpdateParameters(NpgsqlCommand sqlCmd)
    {
        foreach (var fieldupd in updatables)
        {
            var field = fieldupd.fieldinfo;
            sqlCmd.Parameters.AddWithValue("@" + field.Name, field.GetValue(this));
        }

        sqlCmd.Parameters.AddWithValue("@audit_created", audit_created);
        sqlCmd.Parameters.AddWithValue("@audit_created_by", audit_created_by);
        sqlCmd.Parameters.AddWithValue("@audit_updated", audit_updated);
        sqlCmd.Parameters.AddWithValue("@audit_updated_by", audit_updated_by);
        
        sqlCmd.Parameters.AddWithValue("@id", id);
    }
    public virtual List<AuditChange> GetChanges()
    {
        var changes = new List<AuditChange>();
        foreach (var fieldupd in updatables)
        {
            if (fieldupd.Auditable)
            {
                var field = fieldupd.fieldinfo;
                var curr_value = field.GetValue(this);
                var old_value = field.GetValue(old_entite);
                if (curr_value == null)
                {
                    if ( old_value != null )
                        changes.Add(new AuditChange(field.Name, fieldupd.typeinfo, curr_value, old_value));
                }
                else
                if (!curr_value.Equals(old_value))
                    changes.Add(new AuditChange(field.Name, fieldupd.typeinfo, curr_value, old_value));
//                            field.GetValue(this), field.GetValue(old_entite)));
            }
        }
        return changes;
    }
    public virtual string getId()
    {
        return id;
    }
}
public class UpdateField
{
    public string Name { get; set; }
    public bool Auditable { get; set; }
    public bool Updatable { get; set; }
    public FieldInfo fieldinfo;
    public string typeinfo ;
    public UpdateField(string name, bool auditable, FieldInfo[] members, string type)
    {
        setValues(name, auditable,members);
        typeinfo = type;
    }
    public UpdateField(string name, bool auditable, FieldInfo[] members)
    {
        setValues(name, auditable,members);
    }
    public void setValues(string name, bool auditable, FieldInfo[] members, bool updatable = true)
    {
        try
        {
            Name = name;
            Auditable = auditable;
            Updatable = updatable;
            fieldinfo = members.First(x => x.Name == name);
            typeinfo = "";

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message + " => "+ name);
        }
    }
}