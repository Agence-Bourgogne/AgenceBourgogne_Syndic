using CommonProjectsPartners.Entites;
using System.Reflection;
using System.Data;

namespace GeranceData.Entites
{
    public class IndiceEntite : AbstractBaseEntite
    {
        public string reference;
        public int annee;
        public int trimestre;
        public decimal indice;
        public decimal variation;

        public IndiceEntite()
        {
            id = "";
            setValues(null);
        }
        public IndiceEntite(DataRow data)
        {
            setValues(data);
        }
        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("reference", true, members));

            updatables.Add(new UpdateField("annee", true, members));
            updatables.Add(new UpdateField("trimestre", true, members));
            updatables.Add(new UpdateField("indice", true, members));
            updatables.Add(new UpdateField("variation", true, members));

            base.setValues(row);
        }
    }
}
