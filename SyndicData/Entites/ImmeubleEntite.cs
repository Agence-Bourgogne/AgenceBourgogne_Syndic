using System;
using System.Collections.Generic;
using System.Data;
using CommonProjectsPartners.Entites;
using SyndicData.Controller;

namespace SyndicData.Entites;

public class ImmeubleEntite : AbstractBaseEntite
{
    private ExerciceComptableEntite _exercice;
    public string codepostal;
    public string comptebanque;
    public DateTime dateass;
    public DateTime datecloture;
    public DateTime datecreation;
    private DataTable immeuble_repart;
    public string lieuconv;
    private DataTable listeLots;
    public string nom;
    public int nombrelots;
    public string note;
    public string note_repart;
    public string reference;
    public string rue;
    public int statut = (int)StatutEntite.Actif;
    public string texte_date;
    public string ville;

    public ImmeubleEntite()
    {
        id = "";
        datecreation = DateTime.Now;
        setValues(null);
    }

    public ImmeubleEntite(DataRow datas)
    {
        setValues(datas);
    }

    public List<LotDescriptionEntite> LotDescription
    {
        get
        {
            if (field == null) field = LotDescriptionController.getController().getListeLotDescription(id);
            return field;
        }
    }

    public string Adresse => rue + " " + codepostal + " " + ville;

    public ExerciceComptableEntite ExerciceCourant
    {
        get
        {
            if (_exercice == null)
                _exercice = ExerciceComptableController.getController().getExerciceCourant(id);
            return _exercice;
        }
    }

    public string DateExercice
    {
        get
        {
            var strDate = "  /  /    ";
            if (ExerciceCourant != null)
                strDate = ExerciceCourant.date_deb.ToShortDateString();
            return strDate;
        }
    }

    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();
        updatables.Clear();

        updatables.Add(new UpdateField("reference", true, members));
        updatables.Add(new UpdateField("nom", true, members));
        updatables.Add(new UpdateField("rue", true, members));
        updatables.Add(new UpdateField("codepostal", true, members));
        updatables.Add(new UpdateField("ville", true, members));
        updatables.Add(new UpdateField("comptebanque", true, members));
        updatables.Add(new UpdateField("nombrelots", true, members));
        updatables.Add(new UpdateField("note", true, members));
        updatables.Add(new UpdateField("note_repart", true, members));
        updatables.Add(new UpdateField("datecreation", true, members));
        updatables.Add(new UpdateField("datecloture", true, members));
        updatables.Add(new UpdateField("dateass", true, members));
        updatables.Add(new UpdateField("lieuconv", true, members));
        updatables.Add(new UpdateField("statut", true, members));
        updatables.Add(new UpdateField("texte_date", true, members));

        base.setValues(row);
    }

    public DataTable getRepartitionImmeuble()
    {
        //if (immeuble_repart == null)
        {
            var controller = new ImmeubleRepartitionController();
            if (!isNew)
                immeuble_repart = controller.getRepartitionImmeuble(id /*, reference*/);
        }
        return immeuble_repart;
    }

    public DataTable getListeLots()
    {
        //if (listeLots == null)
        {
            var controller = new LotDescriptionController();
            listeLots = controller.getDataGridListeLotDescription(this);
        }
        return listeLots;
    }
}