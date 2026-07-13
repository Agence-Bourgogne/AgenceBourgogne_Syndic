using System.Data;
using System.Reflection;
using SyndicData.Common;
using CommonProjectsPartners.Entites;

namespace SyndicData.Entites
{
    public class LiasseEntite :AbstractBaseEntite
    {
//        public enum Type { Ecriture, Cheques, AppelDeFond};
//        public enum Statut { Actif, Inactif , Valide };
        public const string NOUVELLE_ID = "new";
        public const string NOUVELLE_DESI = "Nouvelle";
        public string reference;
        public decimal montant;
        public string type_ecriture;
        public int statut = (int)GlobalConstantes.StatutOperation.Brouillon;
        public LiasseEntite ()
        {
            id = "";
            setValues(null);
        }
        public LiasseEntite(DataRow data)
        {
            setValues(data);
        }
        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("montant", false, members));
            updatables.Add(new UpdateField("type_ecriture", true, members));
            updatables.Add(new UpdateField("statut", true, members));

            base.setValues(row);
        }

    }
}
