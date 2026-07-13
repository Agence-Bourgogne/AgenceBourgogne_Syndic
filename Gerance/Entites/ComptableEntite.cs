using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;
using System.Reflection;
using CommonProjectsPartners.Controller;
using CommonProjectsPartners.Entites;

namespace GeranceData.Entites
{
    public class ComptableEntite : AbstractBaseEntite
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
        public int statut;

        public ComptableEntite()
        {
            id = "";
            setValues(null);
        }
        public ComptableEntite(DataRow data)
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
            updatables.Add(new UpdateField("statut", true, members));
            base.setValues(row);
        }
    }
}
