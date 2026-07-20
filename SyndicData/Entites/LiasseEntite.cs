using System.Data;
using CommonProjectsPartners.Entites;
using SyndicData.Common;

namespace SyndicData.Entites;

public class LiasseEntite : AbstractBaseEntite
{
//        public enum Type { Ecriture, Cheques, AppelDeFond};
//        public enum Statut { Actif, Inactif , Valide };
    public const string NOUVELLE_ID = "new";
    public const string NOUVELLE_DESI = "Nouvelle";
    public decimal montant;
    public string reference;
    public int statut = (int)GlobalConstantes.StatutOperation.Brouillon;
    public string type_ecriture;

    public LiasseEntite()
    {
        id = "";
        setValues(null);
    }

    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();

        updatables.Clear();

        updatables.Add(new UpdateField("reference", true, members));
        updatables.Add(new UpdateField("montant", false, members));
        updatables.Add(new UpdateField("type_ecriture", true, members));
        updatables.Add(new UpdateField("statut", true, members));

        base.setValues(row);
    }
}