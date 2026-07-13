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
    public delegate void WorkflowEventHandler ( object sender, EventArgs e);
    public class WorkflowController:AbstractBaseController<WorkflowEntite>
    {
        public event WorkflowEventHandler WorkFlowChanged;
        public static List<string> TACHE_DEFINITION = new List<string>
        {
           "Mise a jour soldes locataires", 
           "Creation factures proprietaires",
           "Mise a jour soldes proprietaires",
           "Reglements Locataires",
           "Impression Appel à Loyer",
           "Impression Quittance",
           "Enregistrement Réglement/Loyers Proprietaire",
        };

        static WorkflowController controller = new WorkflowController();
        private WorkflowController()
        {
            setTimestampServer();
        }

        public override string getTable()
        {
            return "workflow";
        }
        public static WorkflowController getController()
        {
            return controller;
        }

        public static void FireWorkflowChanged()
        {
            if (controller.WorkFlowChanged != null)
                controller.WorkFlowChanged(controller, new EventArgs());
        }

        public WorkflowEntite getWorkflow(int reference, DateTime date)
        {
            DateTime date_reference = new DateTime(date.Year, date.Month, 1);
            String cmd = " where reference = @reference and date_reference = @date_reference";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@reference", reference), 
                new NpgsqlParameter("@date_reference", date_reference), 

            };
            return getEntite(cmd, parameters);
        }
        public DataTable getMonthListWorkflow(DateTime date)
        {
            DateTime date_reference = new DateTime(date.Year, date.Month, 1);
            string cmd = " select w.*, coalesce(audit_updated, audit_created) as date_ecriture, coalesce(audit_updated_by, audit_created_by) as utilisateur, ";
            cmd += String.Format("( select count(*) from {0}.workflow_detail where workflow_id = w.id ) as nombre_elements", getSchema());
            cmd += String.Format(" from {0} w", getSchemaTable() );
            cmd += " where date_reference >= @date_reference and date_reference <= @date_fin ";
            cmd += " order by date_ecriture";
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> 
            { 
                new NpgsqlParameter("@date_reference", date_reference), 
                new NpgsqlParameter("@date_fin", date_reference.AddMonths(1).AddDays(-1)), 

            };
            return getResultSQL(cmd, parameters);
        }
        public WorkflowEntite WriteRecord(int reference, DateTime date)
        {
//            setTimestampServer();
            DateTime date_reference = new DateTime(date.Year, date.Month, 1);
            WorkflowEntite workflow = getWorkflow(reference, date_reference);

            if (workflow == null)
                workflow = new WorkflowEntite(reference, date_reference);
            
            workflow.revision++;
            
            if (!doInsertOrUpdate(workflow))
                throw new Exception("Mise à Jour Tache");

            return workflow;
        }
    }
}
