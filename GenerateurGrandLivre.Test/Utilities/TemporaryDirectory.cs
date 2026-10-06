namespace GenerateurGrandLivre.Test.Utilities;

internal sealed class TemporaryDirectory : IDisposable
{
    public DirectoryInfo Directory { get; }

    public TemporaryDirectory()
    {
        var path = Path.Combine(
            Path.GetTempPath(),
            Path.GetRandomFileName());

        Directory = System.IO.Directory.CreateDirectory(path);
    }

    public static implicit operator DirectoryInfo(TemporaryDirectory directory) => directory.Directory;

    public void Dispose()
    {
        if (Directory.Exists)
            Directory.Delete(recursive: true);
    }
}