using System;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using SyndicData.Controller;
using SyndicData.Entites;
using SyndicData.Common;

namespace EspaceSyndic.Formulaires.Immeubles
{
    public partial class FicheAideImmeubleForm : Form
    {
        private ImmeubleEntite immeuble = null;
        private string typeAide = "";
        public FicheAideImmeubleForm()
        {
            InitializeComponent();
        }
        public FicheAideImmeubleForm(ImmeubleEntite immeuble, string  typeAide = "" )
        {
            InitializeComponent();
            this.immeuble = immeuble;
            this.typeAide = typeAide;
        }

        private void FicheCommentaireForm_Load(object sender, EventArgs e)
        {
            tbComment.SelectionTabs = new int[] { 5, 30, 50, 520 };
            cbTypeComment.DataSource = ParametresDB.getComboData("AIDE_IMMEUBLE", typeAide);
            cbTypeComment.DisplayMember = "nom";
            cbTypeComment.ValueMember = "code";
//            cbTypeComment.Enabled = false;
            if (immeuble != null)
            {
                cbTypeComment.Enabled = true;
                tbRefImmeuble.Text = immeuble.reference;
                tbRefImmeuble_Leave(null, null);
            }
//            cbTypeComment_SelectedIndexChanged(null, null);
            btnEnter.Width = 0;
//            this.WindowState = FormWindowState.Maximized;
        }

        private void valid_Click(object sender, EventArgs e)
        {
            if (immeuble == null)
                return;
            string code = cbTypeComment.SelectedValue.ToString();

            AideImmeubleEntite comment = AideImmeubleController.getController().getAideImmeuble(immeuble.id, code);
            if (comment == null)
            {
                comment = new AideImmeubleEntite();
                comment.code = code;
                comment.immeuble_id = immeuble.id;
            }
            comment.libelle = tbComment.Text;
            if (AideImmeubleController.getController().InsertOrUpdate(comment))
                this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTypeComment_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbComment.Text = "";
            if (immeuble == null)
                return;
            string code = cbTypeComment.SelectedValue.ToString();
            AideImmeubleEntite comment = AideImmeubleController.getController().getAideImmeuble(immeuble.id, code);
            if (comment != null)
                tbComment.Text = comment.libelle;
        }

        private void lblImmeuble_Click(object sender, EventArgs e)
        {
            FindImmeubleForm form = new FindImmeubleForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
            {
                tbRefImmeuble.Text = form.reference;
                tbRefImmeuble_Leave(null, null);
            }
        }

        private void tbRefImmeuble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
                if (e.KeyChar == ' ')
                {
                    e.Handled = true;
                    if (sender.Equals(tbRefImmeuble))
                        lblImmeuble_Click(null, null);
                }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            //Console.WriteLine(sender);
            if ( !tbComment.Focused)
                ControlsWindows.FocusNextTabbedControl(this);
        }

        private void tbComment_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = null;
        }
        private void tbRefImmeuble_Leave(object sender, EventArgs e)
        {
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (immeuble != null)
            {
                tbRefImmeuble.BackColor = Color.White;
                tbComment.Enabled = true;
                cbTypeComment.Enabled = true;
                //                infoForm.DoFormText(this, immeuble.note);
            }
            else
            {
                if (!"".Equals(tbRefImmeuble.Text))
                    tbRefImmeuble.BackColor = Color.Red;
                tbComment.Enabled = false;
                cbTypeComment.Enabled = false;
            }
            cbTypeComment_SelectedIndexChanged(null, null);
        }

    }
}
