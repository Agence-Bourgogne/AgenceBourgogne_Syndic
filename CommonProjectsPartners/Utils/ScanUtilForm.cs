using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace CommonProjectsPartners.Utils;

public partial class ScanUtilForm : Form
{
    public ScanUtilForm()
    {
        InitializeComponent();
    }

    private void enregistrerToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var fd = new SaveFileDialog();
        if (fd.ShowDialog() == DialogResult.OK)
            pictureBox1.Image.Save(fd.FileName);
    }

    private void ourvirToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var fd = new OpenFileDialog();

        if (fd.ShowDialog() == DialogResult.OK)
            pictureBox1.ImageLocation = fd.FileName;
    }

    private void DataTransferred(object sender, EventArgs e)
    {
        var sc = (ScanUtils)sender;
        pictureBox1.Image = sc.image;
    }

    private void btnAcquire_Click(object sender, EventArgs e)
    {
        var sc = new ScanUtils();
        sc.DataTransferred += DataTransferred;
        sc.TwainAcquire(Handle);
    }

    private void RotateImage(RotateFlipType rotate)
    {
        var img = pictureBox1.Image;
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
        var pForm = new PrintDialog();
        if (pForm.ShowDialog() == DialogResult.OK)
        {
            var pd = new PrintDocument();
            pd.PrinterSettings.PrinterName = pForm.PrinterSettings.PrinterName;
            pd.PrinterSettings.Copies = pForm.PrinterSettings.Copies;
            pd.PrintPage += pd_PrintPage;
            pd.Print();
        }
    }

    private void pd_PrintPage(object sender, PrintPageEventArgs e)
    {
        var loc = new Point(10, 10);
        e.Graphics.DrawImage(pictureBox1.Image, loc);
    }
}