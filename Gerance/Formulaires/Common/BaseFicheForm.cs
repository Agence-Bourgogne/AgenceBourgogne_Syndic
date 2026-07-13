using System;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Utils;

namespace Gerance.Formulaires.Common
{
    public partial class BaseFicheForm : Form
    {
        private bool modified = false;
        protected string entite_id = "";
        protected string currentReference;

        public BaseFicheForm()
        {
            InitializeComponent();
            btnFirst.Visible = btnNext.Visible = btnPrev.Visible = btnLast.Visible = false;
        }
        public BaseFicheForm(string entite_id)
        {
            InitializeComponent();
            this.entite_id = entite_id;
        }
        private void setChangedEvent(Control parent)
        {
            if (parent.HasChildren)
            {
                foreach (Control child in parent.Controls)
                {
                    if (child is TextBox)
                    {
                        child.TextChanged += new EventHandler(tbTextChanged);
                    }
                }
            }
            else
                if (parent is TextBox)
                {
                    parent.TextChanged += new EventHandler(tbTextChanged);
                }
        }

        protected virtual void InitializeCombos()
        {

        }
        protected void BaseFicheForm_Load(object sender, EventArgs e)
        {
            InitializeCombos();
            setFicheValues(getCurrentEntite(entite_id));

            foreach (Control ctl in Controls)
            {
                setChangedEvent(ctl);
            }
            btnEnter.Width = 0;
        }
        protected virtual void setFicheValues(AbstractBaseEntite newEntite)
        {
            setModified(false);
        }
        protected virtual void setModified(bool bModified)
        {
            modified = bModified;
            if (!modified)
            {
                if (Text.EndsWith("*"))
                    Text = Text.Replace(" *", "");
            }
            else
            {
                if (!Text.EndsWith("*"))
                    Text += " *";
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult rc = saveForm(false);
            if (rc != DialogResult.Cancel)
                DialogResult = rc;
        }

        protected virtual bool saveValue()
        {
            return true;
        }

        protected virtual DialogResult saveForm(bool bShowMessage = false, bool bShowResult = true)
        {
            if (!modified)
                return DialogResult.OK;
            if (bShowMessage)
            {
                DialogResult result = MessageBox.Show("Des modifications on été apportéees\nVoulez-vous les enregistrer",
                    "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                    return result;
                if (result == DialogResult.No)
                {
                    return result;
                }
            }
            bool rc = saveValue();
            if (rc && !bShowResult)
            {
                modified = false;
                return DialogResult.OK;
            }
            if (rc && bShowResult)
            {
                MessageBox.Show("Modification enregistrées");
                modified = false;
                return DialogResult.OK;
            }
            else
                return DialogResult.Cancel;
        }
        protected virtual AbstractBaseEntite getCurrentEntite(string entite_id)
        {
            return null;
        }

        protected virtual AbstractBaseEntite getEntite(string where)
        {
            return null;
        }
        protected virtual void getNewEntite(String where, String message)
        {
            if (saveForm(true, false) == DialogResult.Cancel)
                return;

            try
            {
                AbstractBaseEntite entite = getEntite(where);
                if (entite != null)
                    setFicheValues(entite);

            }
            catch (Exception)
            {
                MessageBox.Show(message);
            }
        }

        protected virtual void btnFirst_Click(object sender, EventArgs e)
        {
            getNewEntite("order by reference", "Début de liste atteint");
        }
        protected virtual void btnPrev_Click(object sender, EventArgs e)
        {
            getNewEntite(String.Format("where reference < '{0}' order by reference desc", currentReference), "Début de liste atteint");
        }
        protected virtual void btnNext_Click(object sender, EventArgs e)
        {
            getNewEntite(String.Format("where reference > '{0}' order by reference ", currentReference), "Fin de liste atteinte");
        }
        protected virtual void btnLast_Click(object sender, EventArgs e)
        {
            getNewEntite("order by reference desc", "Fin de liste atteinte");
        }

        protected virtual void tbTextChanged(object sender, EventArgs e)
        {
            modified = true;
            if (!Text.EndsWith("*"))
                Text += " *";
        }
        protected bool bFromEnter;
        private void btnEnter_Click(object sender, EventArgs e)
        {
            bFromEnter = true;
            ControlsWindows.FocusNextTabbedControl(this);
            bFromEnter = false;
        }
        protected virtual DialogResult ShowFindForm(CommonFindForm form, Control tbResult)
        {
            DialogResult res = form.ShowDialog();
            if (res == DialogResult.OK)
                tbResult.Text = form.reference;
            return res;
        }
        protected virtual DialogResult btnTypedAdd_Click(BaseFicheForm form, Control tbResult)
        {
            form.ShowDialog();
            if (form.currentReference!="" )
            {
                tbResult.Text = form.currentReference;
                return DialogResult.OK;
            }
            return DialogResult.Cancel;
        }

        private void BaseFicheForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (saveForm(true, false) == DialogResult.Cancel)
                e.Cancel = true; ;
        }
    }
}
