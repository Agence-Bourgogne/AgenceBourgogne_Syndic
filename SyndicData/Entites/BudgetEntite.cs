using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;
using CommonProjectsPartners.Entites;

namespace SyndicData.Entites
{
    public class BudgetEntite : AbstractBaseEntite
    {
        public string exercice_id;
        public string reference;
        public int version = 1;
        public int statut;
        public BudgetEntite()
        {
            id = "";
            setValues(null);

        }
        public BudgetEntite(DataRow row)
        {
            setValues(row);
        }

        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("exercice_id", true, members));
            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("version", true, members));
            updatables.Add(new UpdateField("statut", true, members));
            base.setValues(row);
        }

    }
}
