using System;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;

namespace EspaceSyndic.Formulaires.Common;

public partial class HelpForm : Form
{
    private readonly string helpKey;

    private Form formParent;

    public HelpForm(string key)
    {
        InitializeComponent();
        helpKey = key;
    }

    protected void HelpForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            CommonRegistry.setRegistryValue(helpKey, "Visible", 0);
            Hide();
            formParent?.Activate();
        }

        CommonRegistry.setRegistryValue(helpKey, "Location X", Location.X);
        CommonRegistry.setRegistryValue(helpKey, "Location Y", Location.Y);
    }

    private void HelpForm_Load(object sender, EventArgs e)
    {
    }

    public void setLocation(int defPosX, int defPosY)
    {
        var newPosX = (int)CommonRegistry.getRegistryValue(helpKey, "Location X", defPosX);
        var newPosY = (int)CommonRegistry.getRegistryValue(helpKey, "Location Y", defPosY);

        Location = new Point(newPosX, newPosY);
    }

    public void setVisibility(Form parent)
    {
        var visibility = (int)CommonRegistry.getRegistryValue(helpKey, "Visible", 1) == 1 ? true : false;
        if (tbHelp.Text.Replace("\n", "").Trim() == "")
            visibility = false;
        Visible = false;
        if (visibility)
            Show(parent);
        formParent = parent;
    }

    public virtual void DoFormText(Form parent, string text)
    {
        var note = text.Replace("\n", "").Trim();

        tbHelp.Text = text;
        if (!"".Equals(note))
        {
            setVisibility(parent);
            var lines = text.Split('\n');
            var nbLines = lines.Length + 1;
            if (nbLines < 4)
                nbLines = 4;
            var height = nbLines * 15;

            tbHelp.Height = height + 10;
            Height = height;

            var posX = parent.Location.X + (parent.Width - Width) / 2;
            var posY = parent.Location.Y + parent.Height - height;

            setLocation(posX, posY);

            parent.Activate();
        }
        else
        {
            Visible = false;
        }
    }

    public void ShowForm(Form parent)
    {
        CommonRegistry.setRegistryValue(helpKey, "Visible", 1);
        setVisibility(parent);
        setLocation(0, 0);
    }
}