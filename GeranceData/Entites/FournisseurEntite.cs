using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Reflection;
using CommonProjectsPartners.Entites;
namespace GeranceData.Entites
{
    public class FournisseurEntite : AbstractBaseEntite
    {
	    //public int id;
	    public string reference;
	    public string nom;
	    public string interlocuteur;
	    public string telephone;
	    public string adresse;
	    public string codepostal;
	    public string ville;
	    public int reglement;
	    public string commentaire;
	    public string siret;
	    public string numsecu;
	    public string codeape;
        public string numurs;
        public int statut;

        public FournisseurEntite()
        {
            id = "";
            setValues(null);
        }
        public FournisseurEntite(DataRow data)
        {
            setValues(data);
        }
        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();
            updatables.Clear();
            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("nom", true, members));
            updatables.Add(new UpdateField("interlocuteur", true, members));
            updatables.Add(new UpdateField("telephone", true, members));
            updatables.Add(new UpdateField("adresse", true, members));
            updatables.Add(new UpdateField("codepostal", true, members));
            updatables.Add(new UpdateField("ville", true, members));
            updatables.Add(new UpdateField("reglement", true, members));
            updatables.Add(new UpdateField("commentaire", true, members));
            updatables.Add(new UpdateField("siret", true, members));
            updatables.Add(new UpdateField("numsecu", true, members));
            updatables.Add(new UpdateField("codeape", true, members));
            updatables.Add(new UpdateField("numurs", true, members));
            updatables.Add(new UpdateField("statut", true, members));

            base.setValues(row);
            
        }
    }
}
