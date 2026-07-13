using System;
using System.Data;
using CommonProjectsPartners.Entites;

namespace SyndicData.Entites;

public class ExerciceComptableEntite : AbstractBaseEntite
{
    public string immeuble_id;
    public string reference;
    public string nom;
    public DateTime date_deb;
    public DateTime date_fin;
    public int statut;
    public ExerciceComptableEntite()
    {
        id = "";
        setValues(null);
    }
    public ExerciceComptableEntite(DataRow data)
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
        updatables.Add(new UpdateField("date_deb", true, members));
        updatables.Add(new UpdateField("date_fin", true, members));
        updatables.Add(new UpdateField("statut", true, members));
        base.setValues(row);
    }

}