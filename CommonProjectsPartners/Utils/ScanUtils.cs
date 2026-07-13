using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using NTwain;
using NTwain.Data;
using WIA;
using CommonDialog = WIA.CommonDialog;

namespace CommonProjectsPartners.Utils;

public delegate void DataTransferredEventHandler(object sender, EventArgs e);
public class ScanUtils
{
    public Image image;
    public DataTransferredEventHandler DataTransferred;
    public void WIAAcquire()
    {
        var cl = new CommonDialog();
        try
        {
            var d = cl.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, true);
            if (d != null)
            {
                object result = cl.ShowAcquireImage(WiaDeviceType.ScannerDeviceType, WiaImageIntent.GrayscaleIntent, WiaImageBias.MinimizeSize, FormatID.wiaFormatPNG);
                if (result != null)
                {
                    var img = (ImageFile)result;
                    image = Image.FromStream(new MemoryStream((byte[])img.FileData.get_BinaryData()));
                    DataTransferred?.Invoke(this, EventArgs.Empty);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("{0}", ex.HResult);
            if (ex.HResult != -2145320860)
                if (ex.HResult != -2145320939)
                    MessageBox.Show(ex.Message);
                else
                    MessageBox.Show(@"Pas de scanner connecté");
        }
    }

    public bool TwainAcquire(IntPtr handle)
    {
        var rc = false;

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

        return rc;
    }
}