using GenerateurGrandLivre.Test.Utilities;

namespace GenerateurGrandLivre.Test;

public class GenerateurGrandLivreTest
{
    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void GeneratesOnePdfPerId(ushort n)
    {
        // ETANT DONNE un dossier
        using var dossier = new TemporaryDirectory();

        // ET une liste de <n> demandes d'export
        var exportables = Enumerable
            .Range(0, n)
            .Select(_ => new RandomExerciceComptableExportable());

        // QUAND la génération de Grand Livre est appelée
        GenerateurPdfGrandLivre.GénérerDans(dossier, exportables);

        // ALORS <n> fichiers PDF valides sont générés
        var pdfFiles = dossier
            .Directory
            .GetFiles("*.pdf")
            .Select(file => new AuditablePdfFile(file))
            .ToArray();

        Assert.Equal(n, pdfFiles.Length);

        Assert.All(pdfFiles, 
            pdfFile => Assert.True(pdfFile.IsValidPdf));
    }
}