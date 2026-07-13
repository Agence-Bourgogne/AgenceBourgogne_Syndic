using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Entites;
using GeranceData.Controller;
using System.Windows.Forms;

namespace GeranceData.Entites
{
    public class WorkflowDetailEntite : AbstractBaseEntite
    {
        public string workflow_id;
        public string item_id;
        public DateTime date_reference;
        public int statut;

        public WorkflowDetailEntite()
        {
            id = "";
            setValues(null);
        }
        public WorkflowDetailEntite(DataRow row)
        {
            setValues(row);
        }
        public WorkflowDetailEntite(WorkflowEntite workflow, string item_id)
        {
            setValues(null);
            workflow_id = workflow.id;
            this.item_id = item_id;
            date_reference = workflow.date_reference;
        }
        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("workflow_id", true, members));
            updatables.Add(new UpdateField("item_id", true, members));
            updatables.Add(new UpdateField("date_reference", true, members));
            updatables.Add(new UpdateField("statut", true, members));

            base.setValues(row);
        }

    }
}
