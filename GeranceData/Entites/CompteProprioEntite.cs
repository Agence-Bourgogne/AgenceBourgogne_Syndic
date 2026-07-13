using System;
using CommonProjectsPartners.Entites;
using GeranceData.Controller;
using System.Data;

namespace GeranceData.Entites
{
    public class CompteProprioEntite : AbstractBaseEntite
    {
        public string proprietaire_id;
        public string libelle;
        public DateTime date_ecriture;
        public decimal debit;
        public decimal credit;
        public int statut;

        public CompteProprioEntite()
        {
            setValues(null);
            id = "";
        }
        public CompteProprioEntite(DataRow row)
        {
            setValues(row);
        }
        public override void setValues(DataRow row)
        {
            var members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("proprietaire_id", true, members));
            updatables.Add(new UpdateField("date_ecriture", true, members));
            updatables.Add(new UpdateField("libelle", true, members));
            updatables.Add(new UpdateField("debit", true, members));
            updatables.Add(new UpdateField("credit", true, members));

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

    }
}
