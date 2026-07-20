using System;
using System.Data;
using CommonProjectsPartners.Entites;
using SyndicData.Controller;

namespace SyndicData.Entites;

public class CoproprietaireEntite : AbstractBaseEntite
{
    private ImmeubleEntite _immeuble;

    private LotDescriptionEntite _lot_description;
    public string adresse;
    public string adressecomp;
    public string codecomp;
    public int codenvcomp;
    public int codenvoi;
    public string codepostal;
    public bool commerce;
    public DateTime dateappel;
    public DateTime daterel1;
    public DateTime daterel2;
    public DateTime daterel3;
    public bool declaration;
    public string email;
    public bool huissier;
    public string nom;
    public string nomcomp;
    public string note;
    public string pays;
    public string prenom;
    public string reference;
    public int statut;
    public string telcomp;
    public string telephone;
    public string ville;
    public string villecomp;

    public CoproprietaireEntite()
    {
        id = "";
        setValues(null);
    }

    public CoproprietaireEntite(DataRow data)
    {
        setValues(data);
    }

    public ImmeubleEntite Immeuble
    {
        get
        {
            if (_immeuble == null)
                _immeuble = ImmeubleController.getController().getImmeubleFromCopro(id);
            return _immeuble;
        }
    }

    public LotDescriptionEntite LotDescription
    {
        get
        {
            if (_lot_description == null)
                _lot_description = LotDescriptionController.getController().getLotFromCopro(id);
            return _lot_description;
        }
    }

    public string NomPrenom
    {
        get
        {
            if (string.IsNullOrEmpty(prenom))
                return $"{nom}";
            return $"{prenom} {nom}";
        }
    }

    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();

        updatables.Clear();

        updatables.Add(new UpdateField("reference", true, members));
        updatables.Add(new UpdateField("nom", true, members));
        updatables.Add(new UpdateField("huissier", true, members));
        updatables.Add(new UpdateField("prenom", true, members));
        updatables.Add(new UpdateField("email", true, members));
        updatables.Add(new UpdateField("codenvoi", true, members));
        updatables.Add(new UpdateField("adresse", true, members));
        updatables.Add(new UpdateField("codepostal", true, members));
        updatables.Add(new UpdateField("ville", true, members));
        updatables.Add(new UpdateField("telephone", true, members));
        updatables.Add(new UpdateField("pays", true, members));
        updatables.Add(new UpdateField("nomcomp", true, members));
        updatables.Add(new UpdateField("codenvcomp", true, members));
        updatables.Add(new UpdateField("adressecomp", true, members));
        updatables.Add(new UpdateField("villecomp", true, members));
        updatables.Add(new UpdateField("codecomp", true, members));
        updatables.Add(new UpdateField("telcomp", true, members));
        updatables.Add(new UpdateField("declaration", true, members));
        updatables.Add(new UpdateField("note", true, members));
        updatables.Add(new UpdateField("dateappel", true, members));
        updatables.Add(new UpdateField("daterel1", true, members));
        updatables.Add(new UpdateField("daterel2", true, members));
        updatables.Add(new UpdateField("daterel3", true, members));
        updatables.Add(new UpdateField("commerce", true, members));
        updatables.Add(new UpdateField("statut", true, members));

        base.setValues(row);
    }
}