using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeranceData.Controller;
using CommonProjectsPartners.Entites;
using System.Data;
using System.Reflection;


namespace GeranceData.Entites
{
    public class RegulChargeEntite : AbstractBaseEntite 
    {
        public string bien_id;
        public string proprietaire_id;
        public string locataire_id;
        public string nature_id;
        public DateTime date_debut;
        public DateTime date_fin;
        public DateTime date_saisie;
        public decimal debit;
        public int statut;
        public RegulChargeEntite()
        {
            id = "";
            setValues(null);
        }
        public RegulChargeEntite( DataRow data) 
        {
            setValues(data);
        }
        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("bien_id", true, members));
            updatables.Add(new UpdateField("proprietaire_id", true, members));
            updatables.Add(new UpdateField("locataire_id", true, members));
            updatables.Add(new UpdateField("nature_id", true, members));
            updatables.Add(new UpdateField("date_debut", true, members));
            updatables.Add(new UpdateField("date_fin", true, members));
            updatables.Add(new UpdateField("date_saisie", true, members));

            updatables.Add(new UpdateField("debit", true, members));

            updatables.Add(new UpdateField("statut", true, members));

            base.setValues(row);
        }

    }
}
