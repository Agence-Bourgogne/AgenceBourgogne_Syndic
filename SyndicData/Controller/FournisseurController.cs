using CommonProjectsPartners.Controller;
using SyndicData.Entites;

namespace SyndicData.Controller;

public class FournisseurController : AbstractBaseController<FournisseurEntite>
{
    private static readonly FournisseurController Controller = new();

    public FournisseurController()
    {
        DefaultOrder = "reference";
    }

    public override string getTable()
    {
        return "fournisseur";
    }

    public static FournisseurController GetController()
    {
        return Controller;
    }
}