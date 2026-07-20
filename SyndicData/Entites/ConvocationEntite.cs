using System;
using System.Collections.Generic;
using System.Data;
using CommonProjectsPartners.Entites;
using SyndicData.Controller;

namespace SyndicData.Entites;

public class ConvocationEntite : AbstractBaseEntite
{
    private List<ConvocationDescriptionEntite> _description;
    public DateTime date_assemblee;
    public string heure_assemblee;
    public string immeuble_id;
    public string lieu_assemblee;
    public int statut;
    public int type_convocation;

    public ConvocationEntite()
    {
        id = "";
        setValues(null);
    }

    public List<ConvocationDescriptionEntite> Description
    {
        get
        {
            if (_description == null)
                _description = ConvocationController.getController().getListeDescription(id);
            return _description;
        }
    }

    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();

        updatables.Clear();
        updatables.Add(new UpdateField("immeuble_id", true, members));
        updatables.Add(new UpdateField("date_assemblee", true, members));
        updatables.Add(new UpdateField("heure_assemblee", true, members));
        updatables.Add(new UpdateField("lieu_assemblee", true, members));
        updatables.Add(new UpdateField("type_convocation", true, members));
        updatables.Add(new UpdateField("statut", true, members));
        base.setValues(row);
    }
}