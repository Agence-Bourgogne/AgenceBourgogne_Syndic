using System;
using System.Data;
using System.Reflection;
using CommonProjectsPartners.Entites;
using SyndicData.Controller;
namespace SyndicData.Entites
{
    public class CoproprietaireEntite : AbstractBaseEntite
    {
        public string reference;
        public string nom;
        public bool huissier;
        public string prenom;
        public string email;
        public int codenvoi;
        public string adresse;
        public string codepostal;
        public string ville;
        public string telephone;
        public string pays;
        public string nomcomp;
        public int codenvcomp;
        public string adressecomp;
        public string villecomp;
        public string codecomp;
        public string telcomp;
        public bool declaration;
        public string note;
        public DateTime dateappel;
        public DateTime daterel1;
        public DateTime daterel2;
        public DateTime daterel3;
        public bool commerce;
        public int statut;
        public CoproprietaireEntite()
        {
            id = "";
            setValues(null);
        }
        public CoproprietaireEntite(DataRow data)
        {
            setValues(data);
        }
        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("nom", true, members));
            updatables.Add(new UpdateField("huissier", true, members));
            updatables.Add(new UpdateField("prenom", true, members));
            updatables.Add(new UpdateField("email", true, members));
            updatables.Add(new UpdateField("codenvoi", true, members));
            updatables.Add(new UpdateField("adresse", true, members));
            updatables.Add(new UpdateField("codepostal", true, members));
            updatables.Add(new UpdateField("ville", true, members));
            updatables.Add(new UpdateField("telephone", true, members));
            updatables.Add(new UpdateField("pays", true, members));
            updatables.Add(new UpdateField("nomcomp", true, members));
            updatables.Add(new UpdateField("codenvcomp", true, members));
            updatables.Add(new UpdateField("adressecomp", true, members));
            updatables.Add(new UpdateField("villecomp", true, members));
            updatables.Add(new UpdateField("codecomp", true, members));
            updatables.Add(new UpdateField("telcomp", true, members));
            updatables.Add(new UpdateField("declaration", true, members));
            updatables.Add(new UpdateField("note", true, members));
            updatables.Add(new UpdateField("dateappel", true, members));
            updatables.Add(new UpdateField("daterel1", true, members));
            updatables.Add(new UpdateField("daterel2", true, members));
            updatables.Add(new UpdateField("daterel3", true, members));
            updatables.Add(new UpdateField("commerce", true, members));
            updatables.Add(new UpdateField("statut", true, members));
         
            base.setValues(row);
        }
        ImmeubleEntite _immeuble;
        public ImmeubleEntite Immeuble 
        {
            get
            {
                if ( _immeuble == null)
                    _immeuble =  ImmeubleController.getController().getImmeubleFromCopro(id);
                return _immeuble;
            }
        }
        LotDescriptionEntite _lot_description;
        public LotDescriptionEntite LotDescription
        {
            get
            {
                if (_lot_description == null)
                    _lot_description = LotDescriptionController.getController().getLotFromCopro(id);
                return _lot_description;
            }
        }
        public string NomPrenom
        {
            get
            {
                if (prenom == null || prenom == "")
                    return string.Format("{0}", nom);
                else
                    return string.Format("{0} {1}", prenom, nom);
            }
        }
    }
}