using System;
using System.Data;
using CommonProjectsPartners.Entites;
using SyndicData.Common;
using SyndicData.Controller;

namespace SyndicData.Entites;

public class OperationEntite : AbstractBaseEntite
{
//        public enum Statut { Inactif, Actif, Valide };

    public string type_mouvement;
    public string type_operation;
    public DateTime date_operation;
    public int numero_operation;
    public int numero_ligne;

    public string liasse_id;
    public string saisie_id;
    public string immeuble_id;
    public string lot_id;
    public string base_repart;
    public string nature_id;
    public string coproprietaire_id;
    public string libelle;
    public DateTime date_reference;
    public decimal debit;
    public decimal credit;
    public decimal global;
    public int ref_cpt = 1;
       
    public int statut;

    public OperationEntite()
    {
        id = "";
        setValues(null);
    }
    public OperationEntite(DataRow data)
    {
        setValues(data);
    }
    public override void setValues(DataRow row)
    {
        var members = GetType().GetFields();

        updatables.Clear();
        updatables.Add(new UpdateField("type_mouvement", true, members));
        updatables.Add(new UpdateField("type_operation", true, members));
        updatables.Add(new UpdateField("date_operation", true, members));
        updatables.Add(new UpdateField("numero_operation", true, members));
        updatables.Add(new UpdateField("numero_ligne", true, members));

        updatables.Add(new UpdateField("liasse_id", true, members));
        updatables.Add(new UpdateField("saisie_id", true, members));
        updatables.Add(new UpdateField("immeuble_id", true, members));
        updatables.Add(new UpdateField("lot_id", true, members));
        updatables.Add(new UpdateField("base_repart", true, members));
        updatables.Add(new UpdateField("nature_id", true, members));
        updatables.Add(new UpdateField("coproprietaire_id", true, members));
        updatables.Add(new UpdateField("libelle", true, members));
        updatables.Add(new UpdateField("date_reference", true, members));
        updatables.Add(new UpdateField("debit", true, members));
        updatables.Add(new UpdateField("credit", true, members));
        updatables.Add(new UpdateField("global", true, members));
        updatables.Add(new UpdateField("statut", true, members));
        updatables.Add(new UpdateField("ref_cpt", true, members));
        base.setValues(row);
    }
    public OperationEntite(SaisieAppelFondEntite saisie)
    {
        setValues(null);
        setValue(saisie);
    }
    public void setValue ( SaisieAppelFondEntite saisie)
    {
        type_mouvement = nameof(GlobalConstantes.TypeMouvement.Recette);
        type_operation = nameof(GlobalConstantes.TypeOperation.AppelDeFond);
        date_operation = date_reference = saisie.date_reference;
        numero_operation = saisie.numero_operation;
        liasse_id = saisie.liasse_id;
        immeuble_id = saisie.immeuble_id;
        base_repart = saisie.base_repart;
        nature_id = saisie.nature_id;
        saisie_id = saisie.id;
//            coproprietaire_id = lot.coproprietaire_id;
        libelle = saisie.libelle;
//            date_reference = saisie.date_reference;
        debit = 0;
        credit = 0;
        global = saisie.montant;
        statut = saisie.statut;
    }
    public OperationEntite(SaisieFactureEntite saisie)
    {
        setValues(null);
        setValue(saisie);
    }
    public void setValue(SaisieFactureEntite saisie)
    {
        type_mouvement = nameof(GlobalConstantes.TypeMouvement.Depense);
        type_operation = nameof(GlobalConstantes.TypeOperation.Facture);
        date_operation = date_reference = saisie.date_reference;
        numero_operation = saisie.numero_operation;
        base_repart = saisie.base_repart;
        //numero_ligne = numero_ligne++;
        //lot_id = row_lotdesc["id"].ToString();
        liasse_id = saisie.liasse_id;
        immeuble_id = saisie.immeuble_id;
        nature_id = saisie.nature_id;
        saisie_id = saisie.id;
        //            coproprietaire_id = lot.coproprietaire_id;
        libelle = saisie.libelle;
//            date_reference = saisie.date_reference;
        debit = 0;
        credit = 0;
        global = saisie.montant;
        statut = saisie.statut;
    }
    public OperationEntite(SaisieReglementEntite saisie)
    {
        setValues(null);
        setValue(saisie);
    }
    public void setValue(SaisieReglementEntite saisie)
    {
        type_mouvement = nameof(GlobalConstantes.TypeMouvement.Recette);
        type_operation = nameof(GlobalConstantes.TypeOperation.Tresorerie);
        date_operation = date_reference = saisie.date_reference;
        numero_operation = saisie.numero_operation;
        liasse_id = saisie.liasse_id;
        immeuble_id = saisie.immeuble_id;
        base_repart = "10";
        lot_id = "0";
        nature_id = saisie.nature_id;
        saisie_id = saisie.id;
        credit = saisie.montant;
        debit = 0;
        libelle = saisie.libelle;
//            date_reference = saisie.date_reference;
        global = saisie.montant;
        statut = saisie.statut;
    }

    private CoproprietaireEntite _copro;

    public CoproprietaireEntite Coproprietaire
    {
        get
        {
            if (_copro == null)
                _copro = CoproprietaireController.getController().getEntiteById(coproprietaire_id);
            return _copro;
        }
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

    private LotDescriptionEntite _lot;
    public LotDescriptionEntite Lot
    {
        get
        {
            if (_lot == null)
                _lot = LotDescriptionController.getController().getEntiteById(lot_id);
            return _lot;
        }
    }
}