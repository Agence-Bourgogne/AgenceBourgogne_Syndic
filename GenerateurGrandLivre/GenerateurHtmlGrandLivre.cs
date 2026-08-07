using Microsoft.Office.Interop.Excel;
using RazorLight;
using SyndicData.Entites.ExerciceComptable;
using System.Windows.Documents;
using GrandLivre.Templates.Models;

namespace GenerateurGrandLivre;

internal class GenerateurHtmlGrandLivre
{
    private readonly RazorLightEngine _engine;

    public GenerateurHtmlGrandLivre()
    {
        _engine = new RazorLightEngineBuilder()
            .UseEmbeddedResourcesProject(
                typeof(Exercice).Assembly)
            .UseMemoryCachingProvider()
            .Build();
    }

    public Task<string> GénérerHtmlAsync(IExerciceComptableExportable exerciceComptable)
    {
        var resources = typeof(Exercice)
            .Assembly
            .GetManifestResourceNames();

        var mainRessource = resources.Single(resName => resName.EndsWith("Main.cshtml"));

        var data = new Exercice(new Copropriete("Copro", "Test"), DateOnly.MinValue, DateOnly.MaxValue, exerciceComptable.DisplayName);
        return _engine.CompileRenderAsync(mainRessource, data);
    }
}