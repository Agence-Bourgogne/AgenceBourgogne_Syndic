using System;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires.Config;

public partial class ZoomParamForm : Form
{
    public string txtParam = "";
    public ZoomParamForm()
    {
        InitializeComponent();
    }

    private void ZoomParamForm_Load(object sender, EventArgs e)
    {
        tbComment.Text = txtParam;
        btnEnter.Width = 0;
    }

    private void btnValid_Click(object sender, EventArgs e)
    {
        txtParam = tbComment.Text;
        DialogResult = DialogResult.OK;
        Close();
    }
}