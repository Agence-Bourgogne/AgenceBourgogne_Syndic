using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Data;

namespace CommonProjectsPartners.Entites
{
    public class RoleEntite : AbstractBaseEntite
    {
        public string reference;
        public string nom;

        public RoleEntite()
        {
            id = "";
            setValues(null);
        }
        public RoleEntite(DataRow row)
        {
            setValues(row);
        }
        public override void setValues(DataRow row)
        {
            FieldInfo[] members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("nom", true, members));

            base.setValues(row);
        }
    }
}
