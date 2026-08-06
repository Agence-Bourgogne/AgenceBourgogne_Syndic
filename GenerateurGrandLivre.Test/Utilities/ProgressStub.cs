namespace GenerateurGrandLivre.Test.Utilities;

internal class ProgressStub<T> : IProgress<T>
{
    public void Report(T value)
    {
    }
}