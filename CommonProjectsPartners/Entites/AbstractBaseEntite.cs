using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Common;
using System.Reflection;
using CommonProjectsPartners.Utils;

namespace CommonProjectsPartners.Entites
{
    public abstract class AbstractBaseEntite : IAuditable
    {
        public enum StatutEntite { vide0, Actif, vide2, vide3, vide4, vide5, vide6, vide7, vide8, Supprime };


        public string id = "";
        public DateTime audit_created;
        public string audit_created_by;
        public DateTime audit_updated;
        public string audit_updated_by;
        public AbstractBaseEntite old_entite;
        public List<UpdateField> updatables = new List<UpdateField>();
        public bool isNew = false;

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
            foreach (UpdateField fieldupd in updatables)
            {
                FieldInfo field = fieldupd.fieldinfo;
                try
                {
                    if (row == null)
                        field.SetValue(this, null);
                    else
                    {
                        if (row[field.Name] is DBNull)
                        {
                            field.SetValue(this, null);
                        }
                        else
                            field.SetValue(this, row[field.Name]);
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            old_entite = (AbstractBaseEntite)this.MemberwiseClone();
        }
        public virtual string GetInsertOrUdpateCommand(string schemaTable)
        {
            string cmd = "";
//            if (!"".Equals(id))
            if ( !isNew )
            {
                cmd = String.Format("update {0} set ", schemaTable);
                foreach (UpdateField fieldupd in updatables)
                {
                    FieldInfo field = fieldupd.fieldinfo;
                    object curr_value = field.GetValue(this);
                    object old_value = field.GetValue(old_entite);

                    if (curr_value == null)
                    {
                        if (curr_value!=old_value)
                            cmd += String.Format("{0}=@{1}, ", field.Name, field.Name);

                    }
                    else
                        if (!curr_value.Equals(old_value))
                            cmd += String.Format("{0}=@{1}, ",  field.Name, field.Name );
                }
                cmd += " audit_updated = @audit_updated, audit_updated_by= @audit_updated_by ";
                cmd += " where id = @id";
            }
            else
            {
                if ( id == null || id =="")
                    id = get_uuid();
                cmd = String.Format("insert into {0} (", schemaTable);

                cmd += "id, ";
                foreach (UpdateField fieldupd in updatables)
                {
                    FieldInfo field = fieldupd.fieldinfo;
                    cmd += field.Name + ", ";
                }
                cmd += " audit_created , audit_created_by ";
                cmd += " ) values ( ";
                cmd += "@id, ";
                foreach (UpdateField fieldupd in updatables)
                {
                    FieldInfo field = fieldupd.fieldinfo;
                    cmd += "@" + field.Name + ", ";
                }
                cmd += " @audit_created , @audit_created_by "; 
                cmd += " )";
            }
            return cmd;
        }
        public string get_uuid()
        {
            string cmd = "select public.get_uuid()";
            NpgsqlCommand sqlCmd = new NpgsqlCommand(cmd, Database.GetInstance());
            string uuid = (string) sqlCmd.ExecuteScalar();
            return uuid;
        }

        public virtual string ValidationError()
        {
            String message = "";
            return message;
        }
        public virtual void SetInsertOrUpdateParameters(NpgsqlCommand sqlCmd)
        {
            foreach (UpdateField fieldupd in updatables)
            {
                FieldInfo field = fieldupd.fieldinfo;
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
            List<AuditChange> changes = new List<AuditChange>();
            foreach (UpdateField fieldupd in updatables)
            {
                if (fieldupd.Auditable)
                {
                    FieldInfo field = fieldupd.fieldinfo;
                    object curr_value = field.GetValue(this);
                    object old_value = field.GetValue(old_entite);
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
        public UpdateField(String name, bool auditable, FieldInfo[] members, string type)
        {
            setValues(name, auditable,members);
            typeinfo = type;
        }
        public UpdateField(String name, bool auditable, FieldInfo[] members)
        {
            setValues(name, auditable,members);
        }
        public void setValues(String name, bool auditable, FieldInfo[] members, bool updatable = true)
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
}
