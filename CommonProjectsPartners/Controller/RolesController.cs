using System.Data;
using CommonProjectsPartners.Entites;

namespace CommonProjectsPartners.Controller;

public class RolesController : AbstractBaseController<RoleEntite>
{
    private static readonly RolesController controller = new();

    public override string getTable()
    {
        return "roles";
    }

    public static RolesController getController()
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

    public DataTable GetComboRoles()
    {
        var cmd = $" select id, nom from {getSchemaTable()} ";
        return getResultSQL(cmd);
    }
}