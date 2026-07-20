using System.Data;
using CommonProjectsPartners.Entites;

namespace SyndicData.Entites;

public class AideImmeubleEntite : AbstractBaseEntite
{
    public string code;
    public string immeuble_id;
    public string libelle;

    public AideImmeubleEntite()
    {
        id = "";
        setValues(null);
    }

    public AideImmeubleEntite(DataRow datas)
    {
        setValues(datas);
    }

    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();

        updatables.Clear();

        updatables.Add(new UpdateField("immeuble_id", true, members));
        updatables.Add(new UpdateField("code", true, members));
        updatables.Add(new UpdateField("libelle", true, members));
        base.setValues(row);
    }
}