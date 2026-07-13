using System.Data;
using CommonProjectsPartners.Entites;

namespace SyndicData.Entites
{
    public class BudgetLigneEntite : AbstractBaseEntite
    {
        public string budget_id;
//        public string reference;
        //public string libelle;
        public string nature_id;
        public string base_repart;
        public decimal montant;
        public int statut;
        public BudgetLigneEntite()
        {
            id = "";
            setValues(null);
        }
        public BudgetLigneEntite(DataRow row)
        {
            setValues(row);
        }
        public override void setValues(DataRow row)
        {
            var members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("budget_id", true, members));
            //updatables.Add(new UpdateField("reference", true, members));
            //updatables.Add(new UpdateField("libelle", true, members));
            updatables.Add(new UpdateField("nature_id", true, members));
            updatables.Add(new UpdateField("base_repart", true, members));
            updatables.Add(new UpdateField("montant", true, members));
            updatables.Add(new UpdateField("statut", true, members));

            base.setValues(row);

        }
    }
}
