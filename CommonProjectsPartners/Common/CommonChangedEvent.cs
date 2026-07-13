namespace CommonProjectsPartners.Common
{
    public delegate void CommonChangedEventHandler(object sender, CommonEventArgs e);
    public class CommonChangedEvent
    {
        public event CommonChangedEventHandler Changed;
        protected virtual void OnChanged ( object sender, CommonEventArgs e)
        {
            if ( Changed != null )
                Changed(sender, e);
        }
        public void FireChanged(object sender, CommonEventArgs e)
        {
            OnChanged(sender, e);
        }
    }
}
