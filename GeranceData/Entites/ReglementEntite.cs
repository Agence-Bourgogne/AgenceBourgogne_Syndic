using System;
using System.Data;
using CommonProjectsPartners.Entites;
using GeranceData.Controller;

namespace GeranceData.Entites
{
    public class ReglementEntite : AbstractBaseEntite
    {
        public string bien_id;
        public string proprietaire_id;
        public string locataire_id;
        public DateTime date_reglement;
        public string libelle;
        public decimal debit;
        public decimal credit;
        public int code_reglement;
        public string tire;
        public string banque_tire;
        public decimal base_honoraire;
        public decimal charges;
        public decimal honoraire_locataire;
        public decimal augmentation;
        public decimal frais_bail;
        public decimal etat_lieux;
        public decimal valeur_taxe;
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

        public ReglementEntite()
        {
            id = "";
            setValues(null);

        }
        public ReglementEntite(DataRow data)
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
            updatables.Add(new UpdateField("date_reglement", true, members));
            updatables.Add(new UpdateField("libelle", true, members));
            updatables.Add(new UpdateField("debit", true, members));
            updatables.Add(new UpdateField("credit", true, members));
            updatables.Add(new UpdateField("code_reglement", true, members));
            updatables.Add(new UpdateField("tire", true, members));
            updatables.Add(new UpdateField("banque_tire", true, members));
            updatables.Add(new UpdateField("base_honoraire", true, members));
            updatables.Add(new UpdateField("charges", true, members));
            updatables.Add(new UpdateField("honoraire_locataire", true, members));
            updatables.Add(new UpdateField("augmentation", true, members));
            updatables.Add(new UpdateField("frais_bail", true, members));
            updatables.Add(new UpdateField("etat_lieux", true, members));
            updatables.Add(new UpdateField("valeur_taxe", true, members));

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

    }
}
