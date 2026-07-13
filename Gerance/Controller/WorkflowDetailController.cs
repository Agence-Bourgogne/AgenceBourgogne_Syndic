using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Utils;
using GeranceData.Entites;
using System.Windows.Forms;

namespace GeranceData.Controller
{
    public class WorkflowDetailController : AbstractBaseController<WorkflowDetailEntite>
    {
        static WorkflowDetailController controller = new WorkflowDetailController();
        private WorkflowDetailController()
        {
            setTimestampServer();
        }
        public override string getTable()
        {
            return "workflow_detail";
        }
        public static WorkflowDetailController getController()
        {
            return controller;
        }
        public WorkflowDetailEntite getDetail(string workflow_id, string item_id)
        {
            String cmd = " where workflow_id = @workflow_id and item_id = @item_id";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@workflow_id", workflow_id), 
                new NpgsqlParameter("@item_id", item_id), 
            };
            return getEntite(cmd, parameters);
        }
        public bool WriteRecord(WorkflowEntite workflow, string item_id, string error_msg)
        {
            WorkflowDetailEntite detail = getDetail(workflow.id, item_id);

            if (detail == null)
                detail = new WorkflowDetailEntite(workflow, item_id);

            if (!doInsertOrUpdate(detail))
                throw new Exception("Mise à jour détail Tache : " + error_msg);
            
            return true;
        }
        public DataTable getListeDetail(string workflow_id)
        {
            string cmd = String.Format("select * from {0} where workflow_id = @workflow_id", getSchemaTable());

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@workflow_id", workflow_id), 
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeDetailReglements(string workflow_id)
        {
            string cmd = "select ";
            cmd += " l.reference, concat ( l.prenom, ' ', l.nom) as locataire, r.credit, ";
            cmd += " coalesce(d.audit_updated, d.audit_created) as date_reference, coalesce( d.audit_updated_by,d.audit_created_by) as utilisateur,";
            cmd += " d.id";
            cmd += String.Format(" from {0} d ", getSchemaTable());
            cmd += String.Format(" join {0}.reglements r on r.id = item_id", getSchema() );
            cmd += String.Format(" join {0}.locataire l on l.id = r.locataire_id", getSchema());

            cmd +=  " where workflow_id = @workflow_id";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@workflow_id", workflow_id), 
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeDetailSoldesLocataires(string workflow_id)
        {
            string cmd = "select ";
            cmd += " l.reference, concat ( l.prenom, ' ', l.nom) as locataire, l.total_du, ";
            cmd += " coalesce(d.audit_updated, d.audit_created) as date_reference, coalesce( d.audit_updated_by,d.audit_created_by) as utilisateur,";
            cmd += " d.id";
            cmd += String.Format(" from {0} d ", getSchemaTable());
            cmd += String.Format(" join {0}.locataire l on l.id = d.item_id", getSchema());

            cmd += " where workflow_id = @workflow_id";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@workflow_id", workflow_id), 
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeDetailImpressionQuittance(string workflow_id)
        {
            string cmd = "select ";
            cmd += " l.reference, l.nom, l.adresse,";
            cmd += " coalesce(d.audit_updated, d.audit_created) as date_reference, coalesce( d.audit_updated_by,d.audit_created_by) as utilisateur,";
            cmd += " d.id";
            cmd += String.Format(" from {0} d ", getSchemaTable());
            cmd += String.Format(" join {0}.biens l on l.id = d.item_id", getSchema());

            cmd += " where workflow_id = @workflow_id";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@workflow_id", workflow_id), 
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeDetailSoldesProprietaires(string workflow_id)
        {
            string cmd = "select ";
            cmd += " l.reference, concat ( l.prenom, ' ', l.nom) as proprietaire, ";
            cmd += " coalesce(d.audit_updated, d.audit_created) as date_reference, coalesce( d.audit_updated_by,d.audit_created_by) as utilisateur,";
            cmd += " d.id";
            cmd += String.Format(" from {0} d ", getSchemaTable());
            cmd += String.Format(" join {0}.proprietaire l on l.id = d.item_id", getSchema());

            cmd += " where workflow_id = @workflow_id";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@workflow_id", workflow_id), 
            };
            return getResultSQL(cmd, parameters);
        }
        public DataTable getListeDetailFacturesProprietaires(string workflow_id)
        {
            string cmd = "select ";
            cmd += " p.reference, concat ( p.nom, ' ', p.prenom) as proprietaire, f.debit, f.credit, f.statut, ";
            cmd += " coalesce(d.audit_updated, d.audit_created) as date_reference, coalesce( d.audit_updated_by,d.audit_created_by) as utilisateur,";
            cmd += " d.id";
            cmd += String.Format(" from {0} d ", getSchemaTable());
            cmd += String.Format(" join {0}.factures f on f.id = d.item_id", getSchema());
            cmd += String.Format(" join {0}.proprietaire p on p.id= f.proprietaire_id", getSchema());
            cmd += " where workflow_id = @workflow_id";

            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@workflow_id", workflow_id), 
            };
            return getResultSQL(cmd, parameters);
        }
    }
}
