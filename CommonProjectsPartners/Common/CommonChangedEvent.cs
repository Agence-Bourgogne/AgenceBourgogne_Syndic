namespace CommonProjectsPartners.Common;

public delegate void CommonChangedEventHandler(object sender, CommonEventArgs e);

public class CommonChangedEvent
{
    public event CommonChangedEventHandler Changed;

    private void OnChanged(object sender, CommonEventArgs e)
    {
        Changed?.Invoke(sender, e);
    }

    public void FireChanged(object sender, CommonEventArgs e)
    {
        OnChanged(sender, e);
    }
}