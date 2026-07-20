using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using EspaceSyndic.Formulaires.Immeubles;

namespace EspaceSyndic.Formulaires.Controles;

public delegate void ValidatingEventHandler(object sender, CancelEventArgs e);

public partial class ImmeubleUserControl : UserControl
{
    public ImmeubleUserControl()
    {
        InitializeComponent();
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Reference
    {
        get => tbRefImmeuble.Text;
        set => tbRefImmeuble.Text = value;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Invalid
    {
        set
        {
            if (value)
                tbRefImmeuble.BackColor = Color.Red;
            else
                tbRefImmeuble.BackColor = Color.White;
        }
    }

    public event ValidatingEventHandler ValidatingControl;

    private void lblImmeuble_Click(object sender, EventArgs e)
    {
        var form = new FindImmeubleForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbRefImmeuble.Text = form.reference;
            tbRefImmeuble_Validating(null, null);
        }
    }

    private void tbRefImmeuble_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (ModifierKeys == Keys.Control)
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                lblImmeuble_Click(null, null);
            }
    }

    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        ValidatingControl?.Invoke(sender, e);
    }
}