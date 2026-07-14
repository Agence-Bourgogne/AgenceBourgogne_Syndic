using System.Data;
using CommonProjectsPartners.Entites;

namespace SyndicData.Entites;

public class ConvocationDescriptionEntite : AbstractBaseEntite
{
    public string convocation_id;
    public int numero_ordre;
    public string description;
    public int votants;
    public int approuves;
    public int abstensions;
    public int refuses;
    public int statut;

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