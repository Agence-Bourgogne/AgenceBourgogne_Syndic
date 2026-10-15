using System.Data;
using CommonProjectsPartners.Entites;

namespace CommonProjectsPartners.Controller;

public class RolesController : AbstractBaseController<RoleEntite>
{
    private static readonly RolesController Controller = new();

    protected override string GetTable()
    {
        return "roles";
    }

    public static RolesController GetController()
    {
        return Controller;
    }

    protected override string GetSchema()
    {
        return "";
    }

    public override string GetSchemaTable()
    {
        return GetTable();
    }

    public DataTable GetComboRoles()
    {
        var cmd = $" select id, nom from {GetSchemaTable()} ";
        return getResultSQL(cmd);
    }
}