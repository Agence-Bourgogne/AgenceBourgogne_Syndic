using System;
using System.Data;
using System.Reflection;
using CommonProjectsPartners.Entites;
using SyndicData.Controller;
namespace SyndicData.Entites
{
    public class SaisieReglementEntite : AbstractBaseEntite
    {
//        public enum Statut { Inactif, Actif, Valide };

        public string liasse_id;
        public DateTime date_operation;
        public int numero_operation;
        public string coproprietaire_id;
        public string immeuble_id;	
//        public string lot_id;	
        public string nature_id;
        public string libelle;			
        public DateTime date_reference;
        public decimal montant;
        public string emetteur;
        public string banque;
        public string comptebanque;
//        public decimal base_global;
        public int statut;

        public SaisieReglementEntite()
        {
            id = "";
            setValues(null);
        }
        public SaisieReglementEntite(DataRow data)
        {
            setValues(data);
        }

        public SaisieReglementEntite(OperationEntite operation)
        {
            setValues(null);
            date_reference = date_operation = operation.date_reference;
            liasse_id = operation.liasse_id;
            coproprietaire_id = operation.coproprietaire_id;
            numero_operation = operation.numero_operation;
            immeuble_id = operation.immeuble_id;
            nature_id = operation.nature_id;
            libelle = operation.libelle;
            if (operation.credit >= 0)
                montant = operation.credit;
            else
                montant = operation.debit *-1;
            statut = 1;
        }
        public override void setValues(DataRow row)
        {
            var members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("date_operation", true, members));
            updatables.Add(new UpdateField("numero_operation", true, members));
            updatables.Add(new UpdateField("liasse_id", true, members));
            updatables.Add(new UpdateField("coproprietaire_id", true, members));
            updatables.Add(new UpdateField("immeuble_id", true, members));
            updatables.Add(new UpdateField("comptebanque", true, members));
//            updatables.Add(new UpdateField("lot_id", true, members));
            updatables.Add(new UpdateField("nature_id", true, members));
            updatables.Add(new UpdateField("libelle", true, members));
            updatables.Add(new UpdateField("date_reference", true, members));
            updatables.Add(new UpdateField("montant", true, members));
            updatables.Add(new UpdateField("emetteur", true, members));
            updatables.Add(new UpdateField("banque", true, members));
//            updatables.Add(new UpdateField("base_global", true, members));
            updatables.Add(new UpdateField("statut", true, members));

            base.setValues(row);
        }
        NatureEntite _nature;
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
}
