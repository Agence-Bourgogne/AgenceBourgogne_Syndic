using System;
using System.Data;
using System.Reflection;
using CommonProjectsPartners.Entites;
using SyndicData.Controller;

namespace SyndicData.Entites
{
    public class SaisieAppelFondEntite : AbstractBaseEntite
    {

        public string liasse_id;
        public DateTime date_operation;
        public int numero_operation;
        public string immeuble_id;
        public string base_repart;
        public string nature_id;
        public string libelle;
        public DateTime date_reference;
        public decimal montant;
        public string lot_id;
//        public decimal base_global;
        public int statut = 0;//(int)GlobalConstantes.StatutOperation.Brouillon;

        public SaisieAppelFondEntite()
        {
            id = "";
            setValues(null);
        }
        public SaisieAppelFondEntite(DataRow data)
        {
            setValues(data);
        }

        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("date_operation", true, members));
            updatables.Add(new UpdateField("numero_operation", true, members));
            updatables.Add(new UpdateField("liasse_id", true, members));
            updatables.Add(new UpdateField("immeuble_id", true, members));
            updatables.Add(new UpdateField("base_repart", true, members));
            updatables.Add(new UpdateField("nature_id", true, members));
            updatables.Add(new UpdateField("libelle", true, members));
            updatables.Add(new UpdateField("date_reference", true, members));
            updatables.Add(new UpdateField("montant", true, members));
            updatables.Add(new UpdateField("lot_id", true, members));
            updatables.Add(new UpdateField("statut", true, members));

            base.setValues(row);
        }
        ImmeubleEntite _immeuble = null;
        public ImmeubleEntite Immeuble
        {
            get
            {
                if (_immeuble == null)
                    _immeuble = ImmeubleController.getController().getEntiteById(immeuble_id);
                return _immeuble;
            }
        }
        NatureEntite _nature = null;
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
