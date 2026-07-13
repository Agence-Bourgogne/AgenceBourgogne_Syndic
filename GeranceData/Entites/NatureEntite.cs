using System.Data;
using System.Reflection;
using CommonProjectsPartners.Entites;

namespace GeranceData.Entites
{
    public class NatureEntite : AbstractBaseEntite
    {
        public string reference;
        public string nom;
        public int charge_locative;
        public string declaration;
        public string reference_comptabilite;
        //public int type_charge;
        //public bool budgetisable;
        public int statut;
        public NatureEntite()
        {
            id = "";
            setValues(null);
        }
        public NatureEntite(DataRow data)
        {
            setValues(data);
        }
        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("nom", true, members));
            updatables.Add(new UpdateField("charge_locative", true, members));
            updatables.Add(new UpdateField("declaration", true, members));
            updatables.Add(new UpdateField("reference_comptabilite", true, members));
            //updatables.Add(new UpdateField("type_charge", true, members));
            //updatables.Add(new UpdateField("budgetisable", true, members));
            updatables.Add(new UpdateField("statut", true, members));

            base.setValues(row);
        }
    }
}
