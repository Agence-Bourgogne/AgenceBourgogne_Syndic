namespace CommonProjectsPartners.Common;

public class CommonEventArgs
{
    public readonly string newRef;
    public readonly string newRef2;

    public CommonEventArgs(string newRef, string newRef2 = "")
    {
        this.newRef = newRef;
        this.newRef2 = newRef2;
    }
}