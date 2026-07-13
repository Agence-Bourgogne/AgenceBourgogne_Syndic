using System.Data;
using CommonProjectsPartners.Entites;

namespace SyndicData.Entites;

public class ImmeubleRepartitionEntite : AbstractBaseEntite
{
    public string immeuble_id = "";
    public string reference = "";
    public string nom = "";
    public int valeur;
    public int ligne;
    public int colonne;
    public int type_ventilation;

    public ImmeubleRepartitionEntite()
    {
        id = "";
        setValues(null);
    }
    public ImmeubleRepartitionEntite(DataRow data)
    {
        setValues(data);
    }
    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();

        updatables.Clear();

        updatables.Add(new UpdateField("immeuble_id", true, members));
        updatables.Add(new UpdateField("reference", true, members));
        updatables.Add(new UpdateField("nom", true, members));
        updatables.Add(new UpdateField("valeur", true, members));
        updatables.Add(new UpdateField("ligne", true, members));
        updatables.Add(new UpdateField("colonne", true, members));
        updatables.Add(new UpdateField("type_ventilation", true, members));
        base.setValues(row);
    }

}