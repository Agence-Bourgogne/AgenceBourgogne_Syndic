using System.Data;
using CommonProjectsPartners.Entites;
using GeranceData.Controller;

namespace GeranceData.Entites
{
    public class LocataireEntite : AbstractBaseEntite
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
        public string comptable_id;
        public decimal total_du;
        public int civilite;
        public int statut;

        public LocataireEntite()
        {
            id = "";
            setValues(null);
        }
        public LocataireEntite(DataRow data)
        {
            setValues(data);
        }
        public override void setValues(DataRow row)
        {
            var members = GetType().GetFields();

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
            updatables.Add(new UpdateField("comptable_id", true, members));
            updatables.Add(new UpdateField("total_du", true, members));

            updatables.Add(new UpdateField("civilite", true, members));

            updatables.Add(new UpdateField("statut", true, members));
            base.setValues(row);
        }
        private ComptableEntite _Comptable = null;
        public ComptableEntite Comptable  
        {
            get
            {
                if ( _Comptable != null )
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
                if (prenom == null || prenom == "")
                    return $"{nom}";
                else
                    return $"{nom} {prenom}";
            }
        }
        private BienEntite _Bien = null;
        public BienEntite Bien
        {
            get
            {
                if ( _Bien == null )
                    _Bien = BienController.getController().getEntiteFromField("locataire_id", id);
                return _Bien;
            }
            set
            {
                _Bien = value;
            }
        }
    }
}
