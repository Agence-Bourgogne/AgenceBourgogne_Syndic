using RazorLight;
using SyndicData.Entites.ExerciceComptable;
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

        var data = Factory(exerciceComptable);
        return _engine.CompileRenderAsync(mainRessource, data);
    }

    private static Exercice Factory(IExerciceComptableExportable exerciceComptable)
    {
        //var fullData = exerciceComptable.FetchAllData();

        return new Exercice(
            new Copropriete(exerciceComptable.NomImmeuble, exerciceComptable.AdresseImmeuble), 
            exerciceComptable.DateDebut, exerciceComptable.DateFin, exerciceComptable.Reference);
    }
}