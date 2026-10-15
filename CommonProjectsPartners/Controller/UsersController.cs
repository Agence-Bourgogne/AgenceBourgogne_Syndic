using System.Data;
using CommonProjectsPartners.Entites;

namespace CommonProjectsPartners.Controller;

public class UsersController : AbstractBaseController<UserEntite>
{
    private static readonly UsersController controller = new();

    protected override string GetTable()
    {
        return "users";
    }

    public static UsersController GetController()
    {
        return controller;
    }

    protected override string GetSchema()
    {
        return "";
    }

    public override string GetSchemaTable()
    {
        return GetTable();
    }

    public DataTable getListeUsers()
    {
        var cmd = $" select u.*, r.nom as role from {GetSchemaTable()} u ";
        cmd += " join roles r on r.id  = u.roles_id";
        cmd += " order by reference";

        return getResultSQL(cmd);
    }
}