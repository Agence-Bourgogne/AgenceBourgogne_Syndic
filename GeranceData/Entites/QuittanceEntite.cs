using System;
using System.Data;
using System.Reflection;
using CommonProjectsPartners.Entites;
using GeranceData.Controller;
namespace GeranceData.Entites
{
    public class QuittanceEntite : AbstractBaseEntite
    {
        public string bien_id;
        public string proprietaire_id;
        public string locataire_id;
        public DateTime date_quittance;

        public decimal montant_quittance;
        public decimal montant_loyer;
        public decimal montant_charge;
        public decimal montant_augmentation;
        public decimal honoraire_locataire;
        public decimal frais_bail;
        public decimal valeur_taxe;

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
        public int statut;

        public QuittanceEntite()
        {
            id = "";
            setValues(null);
        }
        public QuittanceEntite(DataRow row)
        {
            setValues(row);
        }
        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("bien_id", true, members));
            updatables.Add(new UpdateField("proprietaire_id", true, members));
            updatables.Add(new UpdateField("locataire_id", true, members));
            updatables.Add(new UpdateField("date_quittance", true, members));

            updatables.Add(new UpdateField("montant_quittance", true, members));
            updatables.Add(new UpdateField("montant_loyer", true, members));
            updatables.Add(new UpdateField("montant_charge", true, members));
            updatables.Add(new UpdateField("montant_augmentation", true, members));
            updatables.Add(new UpdateField("honoraire_locataire", true, members));
            updatables.Add(new UpdateField("frais_bail", true, members));
            updatables.Add(new UpdateField("valeur_taxe", true, members));

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

            updatables.Add(new UpdateField("statut", true, members));

            base.setValues(row);
        }
        private BienEntite _Bien = null;
        public BienEntite Bien
        {
            get
            {
                if (_Bien == null)
                    _Bien = BienController.getController().getEntiteById(bien_id);
                return _Bien;
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
        public void setValuesFromBien(BienEntite bien, DateTime date_quittance)
        {
            bien_id = bien.id;
            locataire_id = bien.locataire_id;
            proprietaire_id = bien.proprietaire_id;

            montant_quittance = bien.montant_du;

            montant_loyer = bien.montant_loyer;
            montant_augmentation = bien.montant_augmentation;
            montant_charge = bien.montant_charges;
            montant_augmentation = bien.montant_augmentation;
            honoraire_locataire = bien.honoraires_locataire;
            frais_bail = bien.frais_bail;
            etat_lieux = bien.etat_lieux;
            valeur_taxe = bien.valeur_taxe;
            divers1 = bien.divers1;
            montant_divers1 = bien.montant_divers1;
            divers2 = bien.divers2;
            montant_divers2 = bien.montant_divers2;
            divers3 = bien.divers3;
            montant_divers3 = bien.montant_divers3;
            divers4 = bien.divers4;
            montant_divers4 = bien.montant_divers4;
            divers5 = bien.divers5;
            montant_divers5 = bien.montant_divers5;
            this.date_quittance = date_quittance;
        }

        public void SetValueFromQuittance()
        {
            BienEntite bien = this.Bien;
            if (bien != null)
            {
                bien.montant_du = montant_quittance;

                bien.montant_loyer = montant_loyer;
                bien.montant_augmentation = montant_augmentation;
                bien.montant_charges = montant_charge;
                bien.montant_augmentation = montant_augmentation;
                bien.honoraires_locataire = honoraire_locataire;
                bien.frais_bail = frais_bail;
                bien.etat_lieux = etat_lieux;
                bien.valeur_taxe = valeur_taxe;
                bien.divers1 = divers1;
                bien.montant_divers1 = montant_divers1;
                bien.divers2 = divers2;
                bien.montant_divers2 = montant_divers2;
                bien.divers3 = divers3;
                bien.montant_divers3 = montant_divers3;
                bien.divers4 = divers4;
                bien.montant_divers4 = montant_divers4;
                bien.divers5 = divers5;
                bien.montant_divers5 = montant_divers5;
            }
        }

        public decimal SumMontant()
        {
            decimal montant = montant_loyer;
            montant += montant_augmentation;
            montant += montant_charge;
            montant += frais_bail;
            montant += honoraire_locataire;
            montant += valeur_taxe;
            
            montant += etat_lieux ;

            montant += montant_divers1;
            montant += montant_divers2;
            montant += montant_divers3;
            montant += montant_divers4;
            montant += montant_divers5;
            return montant;
        }
    }
}
