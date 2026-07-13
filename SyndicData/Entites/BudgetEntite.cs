using System.Data;
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
            var members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("exercice_id", true, members));
            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("version", true, members));
            updatables.Add(new UpdateField("statut", true, members));
            base.setValues(row);
        }

    }
}
