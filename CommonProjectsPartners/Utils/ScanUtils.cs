using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WIA;
using System.IO;
using System.Windows.Forms;
using NTwain;
using NTwain.Data;

namespace CommonProjectsPartners.Utils
{
    public delegate void DataTransferredEventHandler(object sender, EventArgs e);
    public class ScanUtils
    {
        public Image image;
        public DataTransferredEventHandler DataTransferred;
        public bool WIAAcquire(bool bShowUI = true)
        {
            bool rc = false;
            WIA.CommonDialog cl = new WIA.CommonDialog();
            try
            {
                Device d = cl.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, true);
                if (d != null)
                {
                    object result = cl.ShowAcquireImage(WiaDeviceType.ScannerDeviceType, WiaImageIntent.GrayscaleIntent, WiaImageBias.MinimizeSize, FormatID.wiaFormatPNG);
                    if (result != null)
                    {
                        ImageFile img = (ImageFile)result;
                        image = Image.FromStream(new MemoryStream((byte[])img.FileData.get_BinaryData()));
                        if (DataTransferred != null)
                            DataTransferred(this, new EventArgs());
                        rc = true;
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
                        MessageBox.Show("Pas de scanner connecté");
            }

            return rc;
        }

        public bool TwainAcquire(IntPtr handle, bool bShowUI = true)
        {
            bool rc = false;
            DataSource src;
            ITwainSession session;

            var id = TWIdentity.CreateFromAssembly(DataGroups.Image, System.Reflection.Assembly.GetExecutingAssembly());
            session = new TwainSession(id);
            session.Open(new WindowsFormsMessageLoopHook(handle));

            session.DataTransferred += (s, ex) =>
            {
                image = Image.FromStream(ex.GetNativeImageStream());
                if (DataTransferred != null)
                    DataTransferred(this, new EventArgs());
            };
            session.SourceDisabled += (s, ex) =>
            {
                TwainSession sess = (TwainSession)s;
                sess.CurrentSource.Close();
                sess.Close();
            };

            src = session.ShowSourceSelector();

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
}
