using System.Data;
using CommonProjectsPartners.Entites;

namespace SyndicData.Entites;

public class FournisseurEntite : AbstractBaseEntite
{
    public string adresse;
    public string codeape;
    public string codepostal;
    public string commentaire;
    public string interlocuteur;
    public string nom;
    public string numsecu;

    public string numurs;

    //public int id;
    public string reference;
    public int reglement;
    public string siret;
    public int statut;
    public string telephone;
    public string ville;

    public FournisseurEntite()
    {
        id = "";
        setValues(null);
    }

    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();
        updatables.Clear();
        updatables.Add(new UpdateField("reference", true, members));
        updatables.Add(new UpdateField("nom", true, members));
        updatables.Add(new UpdateField("interlocuteur", true, members));
        updatables.Add(new UpdateField("telephone", true, members));
        updatables.Add(new UpdateField("adresse", true, members));
        updatables.Add(new UpdateField("codepostal", true, members));
        updatables.Add(new UpdateField("ville", true, members));
        updatables.Add(new UpdateField("reglement", true, members));
        updatables.Add(new UpdateField("commentaire", true, members));
        updatables.Add(new UpdateField("siret", true, members));
        updatables.Add(new UpdateField("numsecu", true, members));
        updatables.Add(new UpdateField("codeape", true, members));
        updatables.Add(new UpdateField("numurs", true, members));
        updatables.Add(new UpdateField("statut", true, members));
        base.setValues(row);
    }
}