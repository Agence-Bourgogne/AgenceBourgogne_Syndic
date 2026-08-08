using SyndicData.Entites.ExerciceComptable;

namespace GenerateurGrandLivre.Test.Utilities;

internal class RandomExerciceComptableExportable : IExerciceComptableExportable
{
    public RandomExerciceComptableExportable()
    {
        Reference = Guid.NewGuid().ToString();
        NomImmeuble = Guid.NewGuid().ToString();
        AdresseImmeuble = Guid.NewGuid().ToString();

        var jourDebut = Random.Shared.Next(DateOnly.MaxValue.DayNumber - 366);
        DateDebut = DateOnly.FromDayNumber(jourDebut);
        DateFin = DateDebut.AddYears(1);
    }

    public string FactoryDisplayNameOfExercice() => Reference;

    public string Reference { get; }
    public DateOnly DateDebut { get; }
    public DateOnly DateFin { get; }
    public string NomImmeuble { get; }
    public string AdresseImmeuble { get; }
    public GrandLivreData FetchAllData() => new RandomGrandLivreData();
}