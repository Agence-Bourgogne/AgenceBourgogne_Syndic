using System.Reflection;
using System.Data;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Controller;

namespace CommonProjectsPartners.Entites
{
    public class UserEntite : AbstractBaseEntite
    {
        public string reference;
        public string password;
        public string nom;
        public string prenom;
        public string roles_id;
        public string resources_id;
        public int statut;

        public UserEntite()
        {
            id = "";
            setValues(null);
        }
        public UserEntite(DataRow row)
        {
            setValues(row);
        }
        public override void setValues(DataRow row)
        {
            var members = GetType().GetFields();

            updatables.Clear();

            updatables.Add(new UpdateField("reference", true, members));
            updatables.Add(new UpdateField("password", true, members));
            updatables.Add(new UpdateField("nom", true, members));
            updatables.Add(new UpdateField("prenom", true, members));
            updatables.Add(new UpdateField("roles_id", true, members));
            updatables.Add(new UpdateField("resources_id", true, members));
            updatables.Add(new UpdateField("statut", true, members));

            base.setValues(row);
        }
        public string Password
        {
            get
            {
                if (password != null)
                    return CryptoUtils.Decrypt(password);
                else
                    return null;
            }
            set
            {
                password = CryptoUtils.Encrypt(value);
            }
        }
        public RoleEntite Role
        {
            get
            {
                return RolesController.getController().getEntiteById(roles_id);
            }
        }
        public bool IsAdmin
        {
            get
            {
                if (Role != null)
                    return Role.reference == "ADMIN";
                return false;
            }
        }
    }
}
