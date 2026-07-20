using CommonProjectsPartners.Controller;
using SyndicData.Entites;

namespace SyndicData.Controller;

public class NatureController : AbstractBaseController<NatureEntite>
{
    private static readonly NatureController controller = new();

    public NatureController()
    {
        DefaultOrder = "reference";
    }

    public override string getTable()
    {
        return "nature";
    }

    public static NatureController getController()
    {
//            return new NatureController();
        return controller;
    }
}