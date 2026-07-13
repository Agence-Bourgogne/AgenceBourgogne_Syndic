namespace CommonProjectsPartners.Common;

public interface ICommonChangedListener
{
    void ChangedReference(object sender, CommonEventArgs e);
}