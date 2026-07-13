using System;
using System.Reflection;
using System.Data;
using CommonProjectsPartners.Entites;
using GeranceData.Controller;

namespace GeranceData.Entites
{
    public class WorkflowEntite : AbstractBaseEntite
    {
        public int reference;
        public string nom;
        public DateTime date_reference;
        public int revision;
        public int statut;

        public WorkflowEntite()
        {
            id = "";
            setValues(null);
        }
        public WorkflowEntite(DataRow row)
        {
            setValues(row);
        }
        public WorkflowEntite(int reference, DateTime date_reference)
        {
            setValues(null);
            this.reference = reference;
            nom = WorkflowController.TACHE_DEFINITION[reference];
            this.date_reference = new DateTime(date_reference.Year, date_reference.Month, 1);
            revision = 0;
        }
        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("nom", true, members));
            updatables.Add(new UpdateField("date_reference", true, members));
            updatables.Add(new UpdateField("revision", true, members));
            updatables.Add(new UpdateField("statut", true, members));

            base.setValues(row);
        }
    }
}
