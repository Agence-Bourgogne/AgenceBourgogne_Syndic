using System.Data;
using System.Reflection;
using CommonProjectsPartners.Entites;


namespace SyndicData.Entites
{
    public class LotRepartitionEntite : AbstractBaseEntite
    {
        public string immeuble_id;
        public string lot_id;
        public string reference;
        public int valeur;
        public int ligne;
        public int colonne;
        public int type_ventilation;
        //public int statut;
        public LotRepartitionEntite()
        {
            id = "";
            setValues(null);
        }
        public LotRepartitionEntite(DataRow data)
        {
            setValues(data);
        }
        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();
            updatables.Add(new UpdateField("immeuble_id", true, members));
            updatables.Add(new UpdateField("lot_id", true, members));

            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("valeur", true, members));
            updatables.Add(new UpdateField("ligne", true, members));
            updatables.Add(new UpdateField("colonne", true, members));
            updatables.Add(new UpdateField("type_ventilation", true, members));
            //updatables.Add(new UpdateField("statut", true, members));
            
            base.setValues(row);
        }
    }
}
