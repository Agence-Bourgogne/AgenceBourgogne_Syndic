using System;
using System.Reflection;
using System.Data;
using CommonProjectsPartners.Entites;
using GeranceData.Controller;

namespace GeranceData.Entites
{
    public class BienEntite : AbstractBaseEntite
    {
        public string reference;
        public int numero_lot;
        public string batiment;
        public string escalier;
        public string etage;
        public int type_construction;
        public string nom;
        public string adresse;
        public string codepostal;
        public string ville;
        public string proprietaire_id;
        public string locataire_id;
        public DateTime date_entree;
        public int taxe;
        public decimal valeur_taxe;
        public decimal montant_loyer;
        public decimal montant_charges;
        public decimal montant_caution;
        public decimal montant_augmentation;
        public decimal etat_lieux;
        public string divers1;
        public decimal montant_divers1;
        public string divers2;
        public decimal montant_divers2;
        public string divers3;
        public decimal montant_divers3;
        public string divers4 = "";
        public decimal montant_divers4;
        public string divers5 = "";
        public decimal montant_divers5;
        public int dernier_indice;
        public int periodicite_loyer;
        public int mois_augmentation;
        public int duree_bail;
        public DateTime date_quittance;
        public int periodicite_augmentation;
        public int type_bien;
        public int type_charge;
        public decimal frais_bail;
        public decimal honoraires_locataire;
        public decimal montant_du;
        public int garantie_universelle;
        public int statut;

        public BienEntite()
        {
            id = "";
            setValues(null);
            date_entree = DateTime.Now;
            mois_augmentation = DateTime.Now.Month;
            periodicite_augmentation = 1;
            duree_bail = 1;
            periodicite_loyer = 12;
        }
        public BienEntite(DataRow data)
        {
            setValues(data);
        }
        public override void setValues(DataRow row)
        {
            var members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("numero_lot", true, members));
            updatables.Add(new UpdateField("batiment", true, members));
            updatables.Add(new UpdateField("escalier", true, members));
            updatables.Add(new UpdateField("etage", true, members));
            updatables.Add(new UpdateField("type_construction", true, members));
            updatables.Add(new UpdateField("nom", true, members));
            updatables.Add(new UpdateField("adresse", true, members));
            updatables.Add(new UpdateField("codepostal", true, members));
            updatables.Add(new UpdateField("ville", true, members));
            updatables.Add(new UpdateField("proprietaire_id", true, members));
            updatables.Add(new UpdateField("locataire_id", true, members));
            updatables.Add(new UpdateField("date_entree", true, members));
            updatables.Add(new UpdateField("taxe", true, members));
            updatables.Add(new UpdateField("valeur_taxe", true, members));
            updatables.Add(new UpdateField("montant_loyer", true, members));
            updatables.Add(new UpdateField("montant_charges", true, members));
            updatables.Add(new UpdateField("montant_caution", true, members));
            updatables.Add(new UpdateField("montant_augmentation", true, members));
            updatables.Add(new UpdateField("etat_lieux", true, members));
            updatables.Add(new UpdateField("divers1", true, members));
            updatables.Add(new UpdateField("montant_divers1", true, members));
            updatables.Add(new UpdateField("divers2", true, members));
            updatables.Add(new UpdateField("montant_divers2", true, members));
            updatables.Add(new UpdateField("divers3", true, members));
            updatables.Add(new UpdateField("montant_divers3", true, members));
            updatables.Add(new UpdateField("divers4", true, members));
            updatables.Add(new UpdateField("montant_divers4", true, members));
            updatables.Add(new UpdateField("divers5", true, members));
            updatables.Add(new UpdateField("montant_divers5", true, members));
            updatables.Add(new UpdateField("dernier_indice", true, members));
            updatables.Add(new UpdateField("periodicite_loyer", true, members));
            updatables.Add(new UpdateField("mois_augmentation", true, members));
            updatables.Add(new UpdateField("duree_bail", true, members));
            updatables.Add(new UpdateField("date_quittance", true, members));
            updatables.Add(new UpdateField("periodicite_augmentation", true, members));
            updatables.Add(new UpdateField("type_bien", true, members));
            updatables.Add(new UpdateField("type_charge", true, members));
            updatables.Add(new UpdateField("frais_bail", true, members));
            updatables.Add(new UpdateField("honoraires_locataire", true, members));
            updatables.Add(new UpdateField("montant_du", true, members));
            updatables.Add(new UpdateField("garantie_universelle", true, members));
            updatables.Add(new UpdateField("statut", true, members));
         
            base.setValues(row);
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
        public decimal MontantDu
        {
            get
            {
                return montant_loyer + frais_bail + etat_lieux + montant_charges + valeur_taxe + montant_augmentation + montant_divers1 + montant_divers2 + montant_divers3 + montant_divers4 + montant_divers5;
            }
        }
    }
}
