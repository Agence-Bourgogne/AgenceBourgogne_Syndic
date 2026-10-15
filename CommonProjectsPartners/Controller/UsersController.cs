using System.Data;
using CommonProjectsPartners.Entites;

namespace CommonProjectsPartners.Controller;

public class UsersController : AbstractBaseController<UserEntite>
{
    private static readonly UsersController controller = new();

    public override string getTable()
    {
        return "users";
    }

    public static UsersController getController()
    {
        return controller;
    }

    public override string getSchema()
    {
        return "";
    }

    public override string getSchemaTable()
    {
        return getTable();
    }

    public DataTable getListeUsers()
    {
        var cmd = $" select u.*, r.nom as role from {getSchemaTable()} u ";
        cmd += " join roles r on r.id  = u.roles_id";
        cmd += " order by reference";

        return getResultSQL(cmd);
    }
}