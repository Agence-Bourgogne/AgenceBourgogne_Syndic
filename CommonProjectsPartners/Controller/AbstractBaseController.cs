using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using MessageBox = System.Windows.Forms.MessageBox;

namespace CommonProjectsPartners.Controller
{
    public abstract class AbstractBaseController<TENTITE> where TENTITE : AbstractBaseEntite, new()
    {

        protected NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
        abstract public string getTable();
        protected DateTime TimestampServer;
        protected string DefaultOrder = "reference";
        public static NpgsqlConnection cnx = null;        
        public virtual string getSchema()
        {
            return BaseApplication.schema;
        }

        public virtual string getSchemaTable()
        {
            return String.Format(String.Format("{0}.{1}", getSchema(), getTable()));
        }
        protected virtual void setListSelectCommand()
        {
            String order = DefaultOrder;
            if ( cnx == null)
                cnx = Database.GetInstance();
            adapter.SelectCommand = new NpgsqlCommand(String.Format("select * from {0} where statut = 1 order by {1}", getSchemaTable(), order), cnx);
        }
        public void setTimestampServer(DateTime time)
        {
            if (time == null)
                setTimestampServer();
            else
                this.TimestampServer = time;
        }
        public DateTime getTimestampServer()
        {
            return this.TimestampServer;
        }
        public DateTime setTimestampServer()
        {
            this.TimestampServer = Database.GetTimestampServer();
            return this.TimestampServer;
        }
        public DataTable GetTableList()
            {
            String order = DefaultOrder;
            if (cnx == null)
                cnx = Database.GetInstance();
            adapter.SelectCommand = new NpgsqlCommand(String.Format("select * from {0} where statut = 1 order by {1}", getSchemaTable(), order), cnx);
            DataTable table = new DataTable();
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

//            setListSelectCommand();
            String order = DefaultOrder;
            if (cnx == null)
                cnx = Database.GetInstance();
            adapter.SelectCommand = new NpgsqlCommand(String.Format("select * from {0} order by {1}", getSchemaTable(), order), cnx);

            DataTable table = new DataTable();
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
            DataTable table = new DataTable();
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
            DataTable table = GetList();
            List<TENTITE> list = new List<TENTITE>();

            foreach (DataRow row in table.Rows)
            {
                TENTITE entite = new TENTITE();
                entite.setValues(row);
                list.Add(entite);
            }
            return list;
        }
        public virtual DataTable GetFindList(string filter)
        {
            String order = DefaultOrder;
            string cmd = String.Format("Select id, reference, nom from {0} ", getSchemaTable());
            cmd += " where statut != @statut_del";

            if (filter != "")
                cmd += " and "+filter;
            cmd += String.Format(" order by {0}", order);

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@statut_del", (int) AbstractBaseEntite.StatutEntite.Supprime),
            };
            
            return getResultSQL(cmd, parameters);
        }
        public bool SaveList(DataTable datas, bool bShowMessage = true)
        {
            if (datas == null)
                return true;

            DataTable changes = datas.GetChanges();
            if (changes != null)
            {
                if (bShowMessage)
                {
                    DialogResult result = MessageBox.Show("Des modifications on été apportéees\nVoulez-vous les enregistrer",
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
                        TENTITE entite = new TENTITE();
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
            return getEntite(String.Format(" where {0} = @value", field),
                        new List<NpgsqlParameter> { new NpgsqlParameter("@value", value) });
        }

        public TENTITE getEntite(string where, List<NpgsqlParameter> parameters = null)
        {
            TENTITE entite = default(TENTITE);
            String cmd = String.Format("select * from {0} {1} limit 1", getSchemaTable(), where);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            if (cnx == null)
                cnx = Database.GetInstance();

            adapter.SelectCommand = new NpgsqlCommand(cmd, cnx);
            if (parameters != null)
            {
                foreach (NpgsqlParameter parameter in parameters)
                {
                    adapter.SelectCommand.Parameters.AddWithValue(parameter.ParameterName, parameter.NpgsqlValue);
                }
            }
            DataTable table = new DataTable();
            try
            {
                adapter.Fill(table);
                if ( table.Rows.Count > 0 )
                {
                    DataRow row = table.Rows[0];
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
            String cmd = String.Format("select * from {0} {1} limit 1", getSchemaTable(), where);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            if (cnx == null)
                cnx = Database.GetInstance();

            adapter.SelectCommand = new NpgsqlCommand(cmd, cnx);
            if (parameters != null)
            {
                foreach (NpgsqlParameter parameter in parameters)
                {
                    adapter.SelectCommand.Parameters.AddWithValue(parameter.ParameterName, parameter.NpgsqlValue);
                }
            }
            DataTable table = new DataTable();
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

        public virtual bool InsertOrUpdate(TENTITE entite, NpgsqlConnection cnx = null)
        {
            TimestampServer = Database.GetTimestampServer();
            return doInsertOrUpdate(entite);
        }

        protected virtual bool doBeforeInsert(TENTITE entite) 
        {
            return true;
        }
        protected virtual bool doAfterInsert()
        {
            return true;
        }
        public bool doInsertOrUpdate(TENTITE entite )
        {
            string cmd;
            bool rc = false;

            if (cnx == null)
                cnx = Database.GetInstance();
            String msgError = entite.ValidationError();
            if ( msgError!="")
            {
                MessageBox.Show(msgError);
                return rc;
            }
            AuditDB.Operation operation = AuditDB.Operation.Update;
            if (entite.isNew)
            {
                if (!doBeforeInsert( entite))
                    return false;
                operation = AuditDB.Operation.Insert;
            }
            entite.audit_created = entite.audit_updated = TimestampServer;
            entite.audit_updated_by = entite.audit_created_by = BaseApplication.AuditString;
            
// Verifier Changes
            List<AuditChange> changes = entite.GetChanges();
            if (!entite.isNew && changes.Count < 1)
                return true;

            cmd = entite.GetInsertOrUdpateCommand(getSchemaTable());
            NpgsqlCommand sqlCmd = new NpgsqlCommand(cmd, cnx);
            entite.SetInsertOrUpdateParameters(sqlCmd);

            try
            {
                int nbRow = sqlCmd.ExecuteNonQuery();
                doAfterInsert();
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

            string cmd = String.Format("Select {0} from {1} order by reference", field, getSchemaTable());
            if (cnx == null)
                cnx = Database.GetInstance();

            adapter.SelectCommand = new NpgsqlCommand(cmd, cnx);
            DataTable table = new DataTable();
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
            bool rc = false;
            string cmd = String.Format("delete from {0} where id = @id", getSchemaTable());
            if (cnx == null)
                cnx = Database.GetInstance();
            NpgsqlCommand sqlCmd = new NpgsqlCommand(cmd, cnx);
            try
            {
                sqlCmd.Parameters.AddWithValue("@id", entite.id);
                int nb = sqlCmd.ExecuteNonQuery();
                AuditDB.Log(AuditDB.Operation.Delete, entite, getSchema(), TimestampServer, BaseApplication.AuditString);
                rc = (nb > 0);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return rc;
        }

        public bool ExecuteNonQuery(string cmd, List<NpgsqlParameter> parameters = null)
        {
            bool rc = false;
            if (cnx == null)
                cnx = Database.GetInstance();
            NpgsqlCommand sqlCmd = new NpgsqlCommand(cmd, cnx);
            try
            {
                if (parameters != null)
                {
                    foreach (NpgsqlParameter parameter in parameters)
                    {
                        sqlCmd.Parameters.AddWithValue(parameter.ParameterName, parameter.NpgsqlValue);
                    }
                }
                int nb = sqlCmd.ExecuteNonQuery();
                rc = (nb > 0);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return rc;
        }
        public DataTable getResultSQL(string cmd, List<NpgsqlParameter> parameters = null )
        {
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter();
            if ( cnx == null )
                cnx = Database.GetInstance();
            adapter.SelectCommand = new NpgsqlCommand(cmd, cnx);
            if (parameters != null)
            {
                foreach (NpgsqlParameter parameter in parameters)
                {
                    adapter.SelectCommand.Parameters.AddWithValue(parameter.ParameterName, parameter.NpgsqlValue);
                }
            }
            DataTable table = new DataTable();
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
        public virtual int getNextNumeroOperation(DateTime dateRef)
        {
            int valeur = 0;
            string cmd = String.Format("select coalesce(max(numero_operation), 0 ) as valeur from {0} where date_reference = @date_reference", getSchemaTable());
            DataTable table = getResultSQL(cmd, new List<NpgsqlParameter> { new NpgsqlParameter("@date_reference", dateRef) });
            if (table != null)
            {
                valeur = (int)table.Rows[0]["valeur"] + 1;
            }

            return valeur;
        }

        public DataTable getListeSaisiesNonValidees(string liasse_id, int statutOperation)
        {
            string cmd = String.Format("select * from {0} ", getSchemaTable());
            cmd += " where liasse_id = @liasse_id and statut = @statut ";

            if (cnx == null)
                cnx = Database.GetInstance();

            adapter.SelectCommand = new NpgsqlCommand(cmd, cnx);
            adapter.SelectCommand.Parameters.AddWithValue("@liasse_id", liasse_id);
            adapter.SelectCommand.Parameters.AddWithValue("@statut", statutOperation);//(int)GlobalConstantes.StatutOperation.Brouillon);

            DataTable table = new DataTable();
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
        //public bool ChangeEtat(ExerciceComptableEntite exercice, GlobalConstantes.StatutOperation statut)
        public bool ChangeEtat(string immeuble_id, DateTime date_deb, DateTime date_fin, int statut, int statut_del)
        {
            string cmd = String.Format(" update {0} set statut = @statut ", getSchemaTable());
            cmd += "  where immeuble_id= @immeuble_id and date_reference >= @dtDeb and date_reference <= @dtFin ";
            cmd += " and statut != @statut_del";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            {
                new NpgsqlParameter("@immeuble_id", immeuble_id),
                new NpgsqlParameter("@statut", (int) statut),
                new NpgsqlParameter("@statut_del", (int) statut_del),
                new NpgsqlParameter("@dtDeb", date_deb),
                new NpgsqlParameter("@dtFin", date_fin)
            };
            //Console.WriteLine(cmd);
            getResultSQL(cmd, parameters);
            return true;
        }
    
    }
}
