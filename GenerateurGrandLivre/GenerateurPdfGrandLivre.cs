using PuppeteerSharp;
using PuppeteerSharp.Media;
using SyndicData.Entites.ExerciceComptable;

namespace GenerateurGrandLivre;

public static class GenerateurPdfGrandLivre
{
    public static async Task GénérerDansAsync(
        DirectoryInfo directory, 
        IEnumerable<IExerciceComptableExportable> exercicesComptables,
        IProgress<int> progress)
    {
        await new BrowserFetcher().DownloadAsync();

        await using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        });

        var générateurHtml = new GenerateurHtmlGrandLivre();
        var i = 1;

        foreach (var exportable in exercicesComptables)
        {
            var html = générateurHtml.GénérerHtml(exportable);
            var filename = (exportable.DisplayName + ".pdf").ToSafeFileName();

            await using var page = await browser.NewPageAsync();

            await page.SetContentAsync(html);

            await page.PdfAsync(Path.Combine(directory.FullName, filename), new PdfOptions
            {
                Format = PaperFormat.A4,
                PrintBackground = true,
                MarginOptions = new MarginOptions
                {
                    Top = "15mm",
                    Bottom = "15mm",
                    Left = "15mm",
                    Right = "15mm"
                }
            });

            progress.Report(i ++);
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