using System.Data;
using CommonProjectsPartners.Entites;

namespace SyndicData.Entites;

public class ConvocationDescriptionEntite : AbstractBaseEntite
{
    public int abstensions;
    public int approuves;
    public string convocation_id;
    public string description;
    public int numero_ordre;
    public int refuses;
    public int statut;
    public int votants;

    public ConvocationDescriptionEntite(DataRow row)
    {
        setValues(row);
    }

    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();

        updatables.Clear();
        updatables.Add(new UpdateField("convocation_id", true, members));
        updatables.Add(new UpdateField("numero_ordre", true, members));
        updatables.Add(new UpdateField("description", true, members));
        updatables.Add(new UpdateField("votants", true, members));
        updatables.Add(new UpdateField("approuves", true, members));
        updatables.Add(new UpdateField("abstensions", true, members));
        updatables.Add(new UpdateField("refuses", true, members));
        updatables.Add(new UpdateField("statut", true, members));
        base.setValues(row);
    }
}