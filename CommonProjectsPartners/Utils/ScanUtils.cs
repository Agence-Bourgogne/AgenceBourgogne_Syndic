using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using NTwain;
using NTwain.Data;

namespace CommonProjectsPartners.Utils;

public delegate void DataTransferredEventHandler(object sender, EventArgs e);
public class ScanUtils
{
    public Image image;
    public DataTransferredEventHandler DataTransferred;

    public void TwainAcquire(IntPtr handle)
    {
        var id = TWIdentity.CreateFromAssembly(DataGroups.Image, Assembly.GetExecutingAssembly());
        ITwainSession session = new TwainSession(id);
        session.Open(new WindowsFormsMessageLoopHook(handle));

        session.DataTransferred += (_, ex) =>
        {
            image = Image.FromStream(ex.GetNativeImageStream());
            DataTransferred?.Invoke(this, EventArgs.Empty);
        };
        session.SourceDisabled += (s, _) =>
        {
            var sess = (TwainSession)s;
            sess.CurrentSource.Close();
            sess.Close();
        };

        var src = session.ShowSourceSelector();

        try
        {
            if (src != null)
            {
                src.Open();

                src.Capabilities.ICapPixelType.SetValue(PixelType.BlackWhite);
                src.Capabilities.CapAutoScan.SetValue(BoolType.True);
                src.Enable(SourceEnableMode.ShowUI, true, handle);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}