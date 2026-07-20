using System;
using System.Data;
using CommonProjectsPartners.Entites;
using SyndicData.Controller;

namespace SyndicData.Entites;

public class LotDescriptionEntite : AbstractBaseEntite
{
    private CoproprietaireEntite _coproprietaire;
    public decimal avance;
    public string coproprietaire_id;
    public DateTime date_changement;
    public string immeuble_id;
    public string numero_batiment;
    public string numero_escalier;
    public string numero_etage;
    public int numero_lot;
    public int statut;

    public LotDescriptionEntite()
    {
        id = "";
        setValues(null);
    }

    public LotDescriptionEntite(DataRow data)
    {
        setValues(data);
    }

    public CoproprietaireEntite Coproprietaire
    {
        get
        {
            if (_coproprietaire == null)
                _coproprietaire = CoproprietaireController.getController().getEntiteById(coproprietaire_id);
            return _coproprietaire;
        }
    }

    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();

        updatables.Clear();

        updatables.Add(new UpdateField("numero_lot", true, members));
        updatables.Add(new UpdateField("immeuble_id", true, members));
        updatables.Add(new UpdateField("coproprietaire_id", true, members));
        updatables.Add(new UpdateField("date_changement", true, members));
        updatables.Add(new UpdateField("numero_batiment", true, members));
        updatables.Add(new UpdateField("numero_escalier", true, members));
        updatables.Add(new UpdateField("numero_etage", true, members));
        updatables.Add(new UpdateField("avance", true, members));
        updatables.Add(new UpdateField("statut", true, members));

        base.setValues(row);
    }
}