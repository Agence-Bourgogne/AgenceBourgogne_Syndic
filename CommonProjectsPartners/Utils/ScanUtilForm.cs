using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace CommonProjectsPartners.Utils
{
    public delegate void SaveEventHandler(object sender, EventArgs e);
    public delegate void LoadEventHandler(object sender, EventArgs e);
    public enum ScanMethod { WIA=0, TWAIN=1};
    public partial class ScanUtilForm : Form
    {
        public event SaveEventHandler SavePicture;
        public event LoadEventHandler LoadPicture;
        ScanMethod scanMethod;
        public ScanUtilForm()
        {
            InitializeComponent();
        }
        public ScanUtilForm(ScanMethod scanMethod)
        {
            InitializeComponent();
            this.scanMethod = scanMethod;
        }

        private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SavePicture != null)
                SavePicture(this, e);
            else
            {
                SaveFileDialog fd = new SaveFileDialog();
                if (fd.ShowDialog() == DialogResult.OK)
                    pictureBox1.Image.Save(fd.FileName);
            }
        }

        private void ourvirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LoadPicture != null)
                LoadPicture(this, e);
            else
            {
                OpenFileDialog fd = new OpenFileDialog();

                if (fd.ShowDialog() == DialogResult.OK)
                    pictureBox1.ImageLocation = fd.FileName;
            }
        }
        private void DataTransferred(object sender, EventArgs e)
        {
            ScanUtils sc = (ScanUtils)sender;
            pictureBox1.Image = sc.image;
        }

        private void btnAcquire_Click(object sender, EventArgs e)
        {
            ScanUtils sc = new ScanUtils();
            sc.DataTransferred += DataTransferred;
            if (scanMethod == ScanMethod.WIA)
                sc.WIAAcquire();
            if (scanMethod == ScanMethod.TWAIN)
                sc.TwainAcquire(Handle);
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

        private void modeWIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scanMethod = ScanMethod.WIA;
            btnAcquire_Click(null, null);
        }

        private void modeTwainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            scanMethod = ScanMethod.TWAIN;
            btnAcquire_Click(null, null);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void ScanUtilForm_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
        }

        private void imprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog pForm = new PrintDialog();
            if ( pForm.ShowDialog() == DialogResult.OK)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = pForm.PrinterSettings.PrinterName;
                pd.PrinterSettings.Copies = pForm.PrinterSettings.Copies;
                pd.PrintPage += pd_PrintPage;
                pd.Print();
            }
        }
        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            Point loc = new Point(10, 10);
            e.Graphics.DrawImage(pictureBox1.Image, loc);
        }
    }
}
