using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NTwain;
using NTwain.Data;
using NTwain.Triplets;
using System.Threading;
using WIA;
using System.IO;
//using CommonProjectsPartners.Utils;

namespace TestScan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnWIA_Click(object sender, EventArgs e)
        {
            //if (ScanUtils.WIAAcquire())
            //{
            //    pictureBox1.Image = ScanUtils.image;
            //}
        }
        private void old_btnWIA_Click(object sender, EventArgs e)
        {
            WIA.CommonDialog cl = new WIA.CommonDialog();
            try
            {
                Device d = cl.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true, true);
                if (d != null)
                {
                    //Item scanItem = d.Items[1];
                    //object result = cl.ShowTransfer(scanItem, WIA.FormatID.wiaFormatPNG, false);
                    
                    object result = cl.ShowAcquireImage(WiaDeviceType.ScannerDeviceType, WiaImageIntent.GrayscaleIntent, WiaImageBias.MinimizeSize, WIA.FormatID.wiaFormatPNG);
                    if (result != null)
                    {
                        ImageFile img = (ImageFile)result;
                        pictureBox1.Image = Image.FromStream(new MemoryStream((byte[])img.FileData.get_BinaryData()));
                    }
                }
            }
            catch (Exception ex)
            {
//                Console.WriteLine("{0}", ex.HResult);
                if (ex.HResult != -2145320860)
                    if ( ex.HResult != -2145320939 )
                        MessageBox.Show(ex.Message);
                    else
                        MessageBox.Show("Pas de scanner connecté");
            }
        }
        private void btnTwain_Click(object sender, EventArgs e)
        {
//            ScanUtils.TwainAcquire(this.Handle);
        }
        private void old_btnTwain_Click(object sender, EventArgs e)
        {
            DataSource src;
            ITwainSession session;

            var id = TWIdentity.CreateFromAssembly(DataGroups.Image, System.Reflection.Assembly.GetExecutingAssembly());
            session = new TwainSession(id);
            session.Open(new WindowsFormsMessageLoopHook(this.Handle));

            session.DataTransferred += (s, ex) =>
                {
                    var img = Image.FromStream(ex.GetNativeImageStream());
                    pictureBox1.Image = img;

                };
            session.SourceDisabled += (s, ex) =>
                {
                    TwainSession sess = (TwainSession)s;
                    sess.CurrentSource.Close();
                    sess.Close();
                    btnTwain.Enabled = btnWIA.Enabled = true;
                };

            src = session.ShowSourceSelector();

            try
            {
                if (src != null)
                {
                    ReturnCode rc = src.Open();
                    btnTwain.Enabled = btnWIA.Enabled = false;
                    
                    src.Capabilities.ICapPixelType.SetValue(PixelType.BlackWhite);
                    src.Capabilities.CapAutoScan.SetValue(BoolType.True);
//                    src.Enable(SourceEnableMode.NoUI, false, (IntPtr)this.Handle);
                    src.Enable(SourceEnableMode.ShowUI, false, (IntPtr)this.Handle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        private void RotateImage(RotateFlipType rotate)
        {
            Image img = pictureBox1.Image;
            img.RotateFlip(rotate);
            pictureBox1.Image = img;
        }

        private void rotation90ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate90FlipNone);
        }

        private void rotation90AntiHoraireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate270FlipNone);
        }

        private void rotation180ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateImage(RotateFlipType.Rotate180FlipNone);
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            if ( fd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image.Save(fd.FileName);
        }

        private void ourvirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();

            if (fd.ShowDialog() == DialogResult.OK)
                pictureBox1.ImageLocation = fd.FileName;
        }
    }
}
