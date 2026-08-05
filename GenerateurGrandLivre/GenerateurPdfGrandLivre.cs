using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using SyndicData.Entites.ExerciceComptable;

namespace GenerateurGrandLivre;

public static class GenerateurPdfGrandLivre
{
    static GenerateurPdfGrandLivre()
    {
        QuestPDF.Settings.License = LicenseType.Community;
    }

    public static void GénérerDans(DirectoryInfo directory, IEnumerable<IExerciceComptableExportable> exercicesComptables)
    {
        foreach (var exportable in exercicesComptables)
        {
            var filename = (exportable.DisplayName + ".pdf").ToSafeFileName();

            Document.Create(container =>
                {
                    container.Page(page => { });
                })
                .GeneratePdf(Path.Combine(directory.FullName, filename));
        }
    }

    private static string ToSafeFileName(this string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return "unnamed";

        var invalidChars = Path.GetInvalidFileNameChars();

        var result = new string(value
            .Select(c => invalidChars.Contains(c) ? '_' : c)
            .ToArray());

        return result
            .Trim()
            .TrimEnd('.');
    }
}