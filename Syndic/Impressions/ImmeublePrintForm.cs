using System;
using System.Windows.Forms;
using SyndicData.Controller;

namespace EspaceSyndic.Impressions;

public partial class ImmeublePrintForm : Form
{
    public ImmeublePrintForm()
    {
        InitializeComponent();
    }

    private void ImmeublePrintForm_Load(object sender, EventArgs e)
    {
    }

    private void btnRapport_Click(object sender, EventArgs e)
    {
        var source = ImmeubleController.getController().GetListeFromMonthCloture(tbMonth.Text.Replace(".", ","));
        immeubleBindingSource.DataSource = source;
        reportViewer1.RefreshReport();
    }
}