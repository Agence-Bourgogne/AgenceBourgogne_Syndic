using CommonProjectsPartners.Entites;
using System.Data;
namespace SyndicData.Entites
{
    public class ParametreEntite : AbstractBaseEntite
    {
        public string groupe;
        public string code;
        public string nom;
        public string param_1;
        public string param_2;
        public string param_3;
        public int iparam_1;
        public int iparam_2;
        public int iparam_3;


        public ParametreEntite()
        {
            setValues(null);
        }
        public ParametreEntite(DataRow datas)
        {
            setValues(datas);
        }
        public override void setValues(DataRow row)
        {
            var members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("groupe", true, members));
            updatables.Add(new UpdateField("code", true, members));
            updatables.Add(new UpdateField("nom", true, members));
            updatables.Add(new UpdateField("param_1", true, members));
            updatables.Add(new UpdateField("param_2", true, members));
            updatables.Add(new UpdateField("param_3", true, members));
            updatables.Add(new UpdateField("iparam_1", true, members));
            updatables.Add(new UpdateField("iparam_2", true, members));
            updatables.Add(new UpdateField("iparam_3", true, members));
            base.setValues(row);
        }
    }
}
