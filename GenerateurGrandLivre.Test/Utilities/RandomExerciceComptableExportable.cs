using SyndicData.Entites.ExerciceComptable;

namespace GenerateurGrandLivre.Test.Utilities;

internal class RandomExerciceComptableExportable : IExerciceComptableExportable
{
    public RandomExerciceComptableExportable()
    {
        DisplayName = Guid.NewGuid().ToString();
        Id = DisplayName;
    }

    public string DisplayName { get; }
    public string Id { get; }
}