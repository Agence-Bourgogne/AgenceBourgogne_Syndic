using System;
using System.Data;
using CommonProjectsPartners.Entites;
using SyndicData.Controller;

namespace SyndicData.Entites;

public class SaisieFactureEntite : AbstractBaseEntite
{
    public string liasse_id;
    public DateTime date_operation;
    public int numero_operation;

    public string immeuble_id;
    public string fournisseur_id;
    public string nature_id;
    public string libelle;
    public string comment_fournisseur;
    public DateTime date_reference;
    public decimal montant;
    public string base_repart;
    public int reglement;
    public int statut = 0; //(int)GlobalConstantes.StatutOperation.Brouillon;
    public string lot_id;

    public SaisieFactureEntite ()
    {
        id = "";
        setValues(null);
    }
    public SaisieFactureEntite(DataRow data)
    {
        setValues(data);
    }
    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();

        updatables.Clear();

        updatables.Add(new UpdateField("date_operation", true, members));
        updatables.Add(new UpdateField("numero_operation", true, members));
        updatables.Add(new UpdateField("liasse_id", true, members));
        updatables.Add(new UpdateField("immeuble_id", true, members));
        updatables.Add(new UpdateField("fournisseur_id", true, members));
        updatables.Add(new UpdateField("nature_id", true, members));
        updatables.Add(new UpdateField("libelle", true, members));
        updatables.Add(new UpdateField("comment_fournisseur", true, members));
        updatables.Add(new UpdateField("date_reference", true, members));
        updatables.Add(new UpdateField("montant", true, members));
        updatables.Add(new UpdateField("reglement", true, members));
        updatables.Add(new UpdateField("base_repart", true, members));
        updatables.Add(new UpdateField("lot_id", true, members));
        updatables.Add(new UpdateField("statut", true, members));

        base.setValues(row);
    }

    private ImmeubleEntite _immeuble;
    public ImmeubleEntite Immeuble
    {
        get
        {
            if (_immeuble == null)
                _immeuble = ImmeubleController.getController().getEntiteById(immeuble_id);
            return _immeuble;
        }
    }

    private NatureEntite _nature;
    public NatureEntite Nature
    {
        get
        {
            if (_nature == null)
                _nature = NatureController.getController().getEntiteById(nature_id);
            return _nature;
        }
    }
}