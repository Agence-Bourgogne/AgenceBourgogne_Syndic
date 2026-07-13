using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;

namespace EspaceSyndic.Formulaires.Common
{
    public partial class HelpForm : Form
    {
        protected string helpKey = "aide";

        Form formParent;
        public HelpForm(string key)
        {
            InitializeComponent();
            this.helpKey = key;
        }

        protected void HelpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                CommonRegistry.setRegistryValue(helpKey, "Visible", 0);
                this.Hide();
                if (formParent != null)
                    formParent.Activate();
            }

            CommonRegistry.setRegistryValue(helpKey, "Location X", Location.X);
            CommonRegistry.setRegistryValue(helpKey, "Location Y", Location.Y);

        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
        }
        public void setLocation(int defPosX, int defPosY)
        {
            int newPosX = (int) CommonRegistry.getRegistryValue(helpKey, "Location X", defPosX);
            int newPosY = (int) CommonRegistry.getRegistryValue(helpKey, "Location Y", defPosY);
            
            this.Location = new Point (newPosX, newPosY);
        }

        public void writeVisibility(Form parent)
        {
            CommonRegistry.setRegistryValue(helpKey, "Visible", this.Visible ? 1 : 0);
        }
        public void setVisibility(Form parent)
        {
            bool visibility = ((int)CommonRegistry.getRegistryValue(helpKey, "Visible", 1) == 1) ? true : false;
            if (this.tbHelp.Text.Replace("\n", "").Trim() == "")
                visibility = false;
            this.Visible = false;
            if (visibility)
                this.Show(parent);
            formParent = parent;
        }

        public virtual void DoFormText(Form parent, String text)
        {
            String note = text.Replace("\n", "").Trim();

            this.tbHelp.Text = text;
            if (!"".Equals(note))
            {
                setVisibility(parent);
                string[] lines = text.Split('\n');
                int nbLines = lines.Count() +1;
                if (nbLines < 4)
                    nbLines = 4;
                int height = nbLines * 15;

                this.tbHelp.Height = height+10;
                this.Height = height;

                int posX = parent.Location.X + (parent.Width - this.Width) / 2;
                int posY = parent.Location.Y + parent.Height - height;

                setLocation(posX, posY);                        
                
                parent.Activate();
            }
            else
                this.Visible = false;

        }
        public void ShowForm(Form parent)
        {
            CommonRegistry.setRegistryValue(helpKey, "Visible", 1);
            setVisibility(parent);
            setLocation(0, 0);
        }
    }
}
