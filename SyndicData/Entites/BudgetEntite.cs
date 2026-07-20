using System.Data;
using CommonProjectsPartners.Entites;

namespace SyndicData.Entites;

public class BudgetEntite : AbstractBaseEntite
{
    public string exercice_id;
    public string reference;
    public int statut;
    public int version = 1;

    public BudgetEntite()
    {
        id = "";
        setValues(null);
    }

    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();

        updatables.Clear();

        updatables.Add(new UpdateField("exercice_id", true, members));
        updatables.Add(new UpdateField("reference", true, members));
        updatables.Add(new UpdateField("version", true, members));
        updatables.Add(new UpdateField("statut", true, members));
        base.setValues(row);
    }
}