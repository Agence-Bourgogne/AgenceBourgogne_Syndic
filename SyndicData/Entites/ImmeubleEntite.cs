using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using SyndicData.Controller;
using CommonProjectsPartners.Entites;

namespace SyndicData.Entites
{
    public class ImmeubleEntite : AbstractBaseEntite
    {
        public string reference;
        public string nom;
        public string rue;
        public string codepostal;
        public string ville;
        public string comptebanque;
        public int nombrelots;
        public string note;
        public string note_repart;
        public DateTime datecreation;
        public DateTime datecloture;
        public DateTime dateass;
        public string lieuconv;
        public int statut = (int)AbstractBaseEntite.StatutEntite.Actif;
        public string texte_date;
        private DataTable immeuble_repart = null;
        private DataTable listeLots = null;
        public ImmeubleEntite()
        {
            id = "";
            datecreation = DateTime.Now;
            setValues(null);
        }
        public ImmeubleEntite(DataRow datas) 
        {
            setValues(datas);
        }
        public override void setValues( DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();
            updatables.Clear();

            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("nom", true, members));
            updatables.Add(new UpdateField("rue", true, members));
            updatables.Add(new UpdateField("codepostal", true, members));
            updatables.Add(new UpdateField("ville", true, members));
            updatables.Add(new UpdateField("comptebanque", true, members));
            updatables.Add(new UpdateField("nombrelots", true, members));
            updatables.Add(new UpdateField("note", true, members));
            updatables.Add(new UpdateField("note_repart", true, members));
            updatables.Add(new UpdateField("datecreation", true, members));
            updatables.Add(new UpdateField("datecloture", true, members));
            updatables.Add(new UpdateField("dateass", true, members));
            updatables.Add(new UpdateField("lieuconv", true, members));
            updatables.Add(new UpdateField("statut", true, members));
            updatables.Add(new UpdateField("texte_date", true, members));

            base.setValues(row);
        }
        public DataTable getRepartitionImmeuble()
        {
            //if (immeuble_repart == null)
            {
                ImmeubleRepartitionController controller = new ImmeubleRepartitionController();
                if ( ! isNew )
                    immeuble_repart = controller.getRepartitionImmeuble(id/*, reference*/);
            }
            return immeuble_repart;
        }
        public DataTable getListeLots()
        {
            //if (listeLots == null)
            {
                LotDescriptionController controller = new LotDescriptionController();
                listeLots = controller.getDataGridListeLotDescription(this);
            }
            return listeLots;
        }
        List<LotDescriptionEntite> lot_description;
        public List<LotDescriptionEntite> LotDescription
        {
            get
            {
                if (lot_description == null)
                {
                    lot_description = LotDescriptionController.getController().getListeLotDescription(id);
                }
                return lot_description;
            }
        }
        public string Adresse
        {
            get
            {
                return rue + " " + codepostal + " " + ville;
            }
        }
        ExerciceComptableEntite _exercice;
        public ExerciceComptableEntite ExerciceCourant
        {
            get
            {
                if ( _exercice == null )
                    _exercice = ExerciceComptableController.getController().getExerciceCourant(id);
                return _exercice;
            }
        }
        public String DateExercice 
        {
            get
            {
                string strDate = "  /  /    ";
                if ( ExerciceCourant != null )
                    strDate = ExerciceCourant.date_deb.ToShortDateString();
                return strDate;
            }
        }
    }
}
