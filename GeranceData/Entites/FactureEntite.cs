using System;
using System.Data;
using GeranceData.Controller;
using CommonProjectsPartners.Entites;

namespace GeranceData.Entites
{
    public class FactureEntite : AbstractBaseEntite
    {
        public string bien_id;
        public string proprietaire_id;
        public string locataire_id;
        public string nature_id;
        public string fournisseur_id;
        public DateTime date_facture;
        public string libelle;
        public decimal debit;
        public decimal credit;
        public int code_reglement = 5;
        public int statut;
        public string libelle_fournisseur;
        public string reglement_id;

        public FactureEntite()
        {
            id = "";
            setValues(null);
        }
        public FactureEntite(ReglementEntite reglement, string nature_id, string libelle, decimal montant)
        {
            id = "";
            setValues(null);
            bien_id = reglement.bien_id;
            proprietaire_id = reglement.proprietaire_id;
            locataire_id = reglement.locataire_id;
            this.nature_id = nature_id;
            this.libelle = libelle;
            date_facture = reglement.date_reglement;
            reglement_id = reglement.id;
            if (montant > 0)
                debit = montant;
            else
                credit = montant;
        }
        public FactureEntite(DataRow data)
        {
            setValues(data);
        }
        public override void setValues(DataRow row)
        {
            var members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("bien_id", true, members));
            updatables.Add(new UpdateField("proprietaire_id", true, members));
            updatables.Add(new UpdateField("locataire_id", true, members));
            updatables.Add(new UpdateField("nature_id", true, members));
            updatables.Add(new UpdateField("fournisseur_id", true, members));
            updatables.Add(new UpdateField("date_facture", true, members));
            updatables.Add(new UpdateField("libelle", true, members));
            updatables.Add(new UpdateField("debit", true, members));
            updatables.Add(new UpdateField("credit", true, members));
            updatables.Add(new UpdateField("code_reglement", true, members));
            updatables.Add(new UpdateField("libelle_fournisseur", true, members));
            updatables.Add(new UpdateField("reglement_id", true, members));

            updatables.Add(new UpdateField("statut", true, members));

            base.setValues(row);
        }
        public void setValues(ReglementEntite reglement, string nature_id, string libelle, decimal montant, string fournisseur_id)
        {
            bien_id = reglement.bien_id;
            proprietaire_id = reglement.proprietaire_id;
            locataire_id = reglement.locataire_id;
            date_facture = reglement.date_reglement;
            this.nature_id = nature_id;
            this.libelle = libelle;
            this.fournisseur_id = fournisseur_id;
            if (montant > 0)
                debit = montant;
            else
                credit = montant;
            reglement_id = reglement.id;
        }
        private LocataireEntite _Locataire = null;
        public LocataireEntite Locataire
        {
            get
            {
                if (_Locataire != null)
                    return _Locataire;

                if (locataire_id != "")
                    _Locataire = LocataireController.getController().getEntiteById(locataire_id);
                if (_Locataire == null)
                    _Locataire = new LocataireEntite();
                return _Locataire;
            }
            set
            {
                locataire_id = value == null ? null : value.id;
                _Locataire = value;
            }
        }
        private BienEntite _Bien = null;
        public BienEntite Bien
        {
            get
            {
                if (_Bien != null)
                    return _Bien;
                if (bien_id != "")
                    _Bien = BienController.getController().getEntiteById(bien_id);
                if (_Bien == null)
                    _Bien = new BienEntite();
                return _Bien;
            }
            set
            {
                bien_id = value == null ? null : value.id;
                _Bien = value;
            }
        }
        private ProprietaireEntite _Proprietaire = null;
        public ProprietaireEntite Proprietaire
        {
            get
            {
                if (_Proprietaire != null)
                    return _Proprietaire;

                if (proprietaire_id != "")
                    _Proprietaire = ProprietaireController.getController().getEntiteById(proprietaire_id);
                if (_Proprietaire == null)
                    _Proprietaire = new ProprietaireEntite();
                return _Proprietaire;
            }
            set
            {
                proprietaire_id = value == null ? null : value.id;
                _Proprietaire = value;
            }
        }
        public NatureEntite _Nature = null;
        public NatureEntite Nature
        {
            get
            {
                if (_Nature != null)
                    return _Nature;

                if (nature_id != "")
                    _Nature = NatureController.getController().getEntiteById(nature_id);
                if (_Nature == null)
                    _Nature = new NatureEntite();
                return _Nature;
            }
            set
            {
                nature_id = value == null ? null : value.id;
                _Nature = value;
            }
        }
        public FournisseurEntite _Fournisseur = null;
        public FournisseurEntite Fournisseur
        {
            get
            {
                if (_Fournisseur != null)
                    return _Fournisseur;

                if (fournisseur_id != "")
                    _Fournisseur = FournisseurController.getController().getEntiteById(fournisseur_id);
                if (_Fournisseur == null)
                    _Fournisseur = new FournisseurEntite();
                return _Fournisseur;
            }
            set
            {
                fournisseur_id = value == null ? null : value.id;
                _Fournisseur = value;
            }
        }
        

    }
}
