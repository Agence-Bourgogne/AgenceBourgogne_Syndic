using CommonProjectsPartners.Entites;
using System.Data;
using System.Reflection;
using GeranceData.Controller;
namespace GeranceData.Entites
{
    public class ProprietaireEntite : AbstractBaseEntite
    {
        public string reference ;
        public string nom ;
        public string prenom;
        public string adresse;
        public string codepostal;
        public string ville;
        public string telephone;
        public string email;
        public string pays;
        public string note;
        public int taux_honoraire;
        public string comptable_id;

        public decimal dernier_cheque;
        public decimal debit;
        public decimal credit;
        public string libelle;

        public int paiement_type;
        public string rib;
        public string banque;
        public int civilite;

        public int statut;

        public ProprietaireEntite()
        {
            id = "";
            setValues(null);
        }
        public ProprietaireEntite(DataRow data)
        {
            setValues(data);
        }
        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("nom", true, members));
            updatables.Add(new UpdateField("prenom", true, members));
            updatables.Add(new UpdateField("adresse", true, members));
            updatables.Add(new UpdateField("codepostal", true, members));
            updatables.Add(new UpdateField("ville", true, members));
            updatables.Add(new UpdateField("telephone", true, members));
            updatables.Add(new UpdateField("email", true, members));
            updatables.Add(new UpdateField("pays", true, members));
            updatables.Add(new UpdateField("note", true, members));
            updatables.Add(new UpdateField("taux_honoraire", true, members));
            updatables.Add(new UpdateField("comptable_id", true, members));

            updatables.Add(new UpdateField("dernier_cheque", true, members));
            updatables.Add(new UpdateField("debit", true, members));
            updatables.Add(new UpdateField("credit", true, members));
            updatables.Add(new UpdateField("libelle", true, members));

            updatables.Add(new UpdateField("paiement_type", true, members));
            updatables.Add(new UpdateField("rib", true, members));
            updatables.Add(new UpdateField("banque", true, members));

            updatables.Add(new UpdateField("civilite", true, members));
            
            updatables.Add(new UpdateField("statut", true, members));
         
            base.setValues(row);
        }
        private ComptableEntite _Comptable = null;
        public ComptableEntite Comptable
        {
            get
            {
                if (_Comptable != null)
                    return _Comptable;

                if (comptable_id != "")
                    _Comptable = ComptableController.getController().getEntiteById(comptable_id);
                if (_Comptable == null)
                    _Comptable = new ComptableEntite();
                return _Comptable;
            }
            set
            {
                comptable_id = value == null ? null : value.id;
                _Comptable = value;
            }
        }
        public string NomPrenom
        {
            get 
            {
                if ( prenom == null || prenom == "")
                    return string.Format("{0}", nom);
                else
                    return string.Format("{0} {1}", prenom, nom); 
            }
        }

    }
}
