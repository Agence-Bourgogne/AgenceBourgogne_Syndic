using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SyndicData.Entites;
using SyndicData.Controller;
using CommonProjectsPartners.Utils;
using EspaceSyndic.UtilsApp;
using EspaceSyndic.Formulaires.Exercice;
using SyndicData.Common;
using CommonProjectsPartners.Entites;
namespace EspaceSyndic.Formulaires.Immeubles
{
    public partial class FicheImmeubleForm : Form
    {
        public ImmeubleEntite immeuble;
        public ImmeubleController controller = new ImmeubleController();
        private bool modified = false;
        private bool modifiedDataGrid = false;
        public FicheImmeubleForm()
        {
            InitializeComponent();
        }
        private void FicheImmeubleForm_Load(object sender, EventArgs e)
        {
            RepartitionControlsWindows.initGridRepartition(dataGridView, 70);

            dataGridView.ScrollBars = ScrollBars.None;
            setFicheValues(null);
//            setReadOnly(true);

            btnEnter.Width = 0;
        }
        private void setFicheValues(ImmeubleEntite newEntite)
        {
            if (newEntite != null)
                this.immeuble = newEntite;
            tbNumero.Text = immeuble.reference;
            tbAdresse.Text = immeuble.rue;
            tbCodePostal.Text = immeuble.codepostal;
            tbNom.Text = immeuble.nom;
            tbVille.Text = immeuble.ville;
            tbDateCreation.Text = (immeuble.datecreation.Year == 1) ? DateTime.Now.ToShortDateString() : immeuble.datecreation.ToShortDateString();
            tbCompteBanque.Text = immeuble.comptebanque;
            tbLots.Text = immeuble.nombrelots.ToString();
            tbNote.Text = immeuble.note;
            tbNoteRepart.Text = immeuble.note_repart;
            ckDesactiv.Checked = immeuble.statut == (int) AbstractBaseEntite.StatutEntite.Supprime;
            tbAppel.Text = immeuble.texte_date;
            //setText(tbNote, immeuble.note);
            //setText(tbNoteRepart, immeuble.note_repart);
            DataTable repartition_immeuble = immeuble.getRepartitionImmeuble();
            RepartitionControlsWindows.ShowRepartitionImmeuble(dataGridView, repartition_immeuble);
            modifiedDataGrid = modified = false;
            setReadOnly(true);
//            verifLotRepart();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveForm(false);
        }

        private int getCumulLotRepartition(ImmeubleRepartitionEntite repart, DataTable repartLot)
        {
            int cumul = 0;
            foreach (DataRow row in repartLot.Rows)
            {
                LotRepartitionEntite lotRepart = new LotRepartitionEntite(row);
                if (lotRepart.ligne == repart.ligne && lotRepart.colonne == repart.colonne && lotRepart.reference == repart.reference)
                {
                    cumul += lotRepart.valeur;
                }
            }
            return cumul;
        }

        private bool verifLotRepart ()
        {
            bool bHaveError = false;
            DataTable repartImmeuble = ImmeubleRepartitionController.getController().getRepartitionImmeuble(immeuble.id);
            DataTable repartLot = LotRepartitionController.getController().GetLotsRepartition(immeuble);

            foreach (DataRow row in repartImmeuble.Rows)
            {
                ImmeubleRepartitionEntite repart = new ImmeubleRepartitionEntite(row);
                int cumul = getCumulLotRepartition(repart, repartLot);
                if (cumul != repart.valeur)
                {
                    //Console.WriteLine("Bad {0} {1} {2} {3}", repart.ligne, repart.colonne, cumul, repart.valeur);
                    if (repart.type_ventilation != (int)GlobalConstantes.TypeRepartition.Individuelle)
                        dataGridView.Rows[repart.ligne-1].Cells[repart.colonne+1].Style.BackColor = Color.Red;
                    bHaveError = true;
                }
            }
            return bHaveError;
        }
        private bool SaveRepartitionImmeuble()
        {
            bool bSaved = true;
            if (modifiedDataGrid)
            {
                if (ImmeubleRepartitionController.getController().SaveRepartitionImmeuble(immeuble, dataGridView))
                {
                    bSaved = true;
                    setReadOnly(false);
                    if (!verifLotRepart())
                    {
                        bSaved = false;
                    }
                }
                else 
                    bSaved = false;
                modifiedDataGrid = false;
            }
            return bSaved;
        }

        private bool saveForm(bool bShowMessage = false, bool bShowResult = true)
        {
            if (bShowMessage)
            {
                DialogResult result = MessageBox.Show("Des modifications on été apportéees\nVoulez-vous les enregistrer",
                    "", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Cancel)
                    return false;
                if (result == DialogResult.No)
                {
                    return true;
                }
            }

            immeuble.reference = tbNumero.Text;
            immeuble.rue = tbAdresse.Text;
            immeuble.codepostal = tbCodePostal.Text;
            immeuble.nom = tbNom.Text;
            immeuble.ville = tbVille.Text;
            immeuble.datecreation = Convert.ToDateTime(tbDateCreation.Text);
            immeuble.comptebanque = tbCompteBanque.Text;
            immeuble.nombrelots = Convert.ToInt32(tbLots.Text);
            immeuble.note = tbNote.Text;
            immeuble.note_repart = tbNoteRepart.Text;
            immeuble.statut = ckDesactiv.Checked ? (int)AbstractBaseEntite.StatutEntite.Supprime : (int)AbstractBaseEntite.StatutEntite.Actif;
            immeuble.texte_date = tbAppel.Text;
            if (controller.InsertOrUpdate(immeuble))
            {
                if ( SaveRepartitionImmeuble())
                    if (bShowResult)
                        MessageBox.Show("Modifications entregistrées");
                modified = false;
                setReadOnly(true);
                return true;
            }
            return false;
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        protected void getNewEntite(String where, String message)
        {
            if (modified || modifiedDataGrid)
                if (!saveForm(true, false))
                    return;

            try
            {
                ImmeubleEntite entite = controller.getEntite(where);
                if (entite != null)
                    setFicheValues(entite);

            }
            catch (Exception)
            {
                MessageBox.Show(message);
            }

        }
        private void btnFirst_Click(object sender, EventArgs e)
        {
            getNewEntite("order by reference", "Début de liste atteint");
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            getNewEntite(String.Format("where reference < '{0}' order by reference desc", immeuble.reference), "Début de liste atteint");
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            getNewEntite(String.Format("where reference > '{0}' order by reference ", immeuble.reference), "Fin de liste atteinte");
        }
        private void btnLast_Click(object sender, EventArgs e)
        {
            getNewEntite("order by reference desc", "Fin de liste atteinte");
        }

        private void FicheImmeubleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (modified)
                saveForm(true);
        }
        private void tbTextChanged(object sender, EventArgs e)
        {
            modified = true;
        }

        private void btnModif_Click(object sender, EventArgs e)
        {
            if (dataGridView.ReadOnly)
            {
                setReadOnly(true);
            }
            else
            {
                setReadOnly(false);
            }
        }
        public void setReadOnly(bool bReadOnly)
        {
            dataGridView.Columns[0].ReadOnly = true;
            
            foreach (DataGridViewRow row in dataGridView.Rows)
                foreach ( DataGridViewCell cell in row.Cells)
                    if ( cell.ColumnIndex != 0 )
                {
                    cell.ReadOnly = bReadOnly;
                    cell.Style.BackColor = bReadOnly ? Color.LightGray : Color.White;
                }
            verifLotRepart();
        }

        private void btnModifLot_Click(object sender, EventArgs e)
        {
            if (modified || modifiedDataGrid)
                if (!saveForm(true, false))
                    return;
            FicheRepartLot form = new FicheRepartLot();
            form.immeuble = immeuble;
            form.ShowDialog();
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            modifiedDataGrid = true;
        }

        private void lblTitre_Click(object sender, EventArgs e)
        {
            if (immeuble != null)
            {
                TitreRepartImmeubleForm form = new TitreRepartImmeubleForm();
                form.immeuble_id = immeuble.id;
                form.ShowDialog();
                DataTable repartition_immeuble = immeuble.getRepartitionImmeuble();
                RepartitionControlsWindows.ShowRepartitionImmeuble(dataGridView, repartition_immeuble);
                modifiedDataGrid = modified = false;
                setReadOnly(true);
            }
            else
                MessageBox.Show("vous devez d'abord créer l'immeuble");
        }

        private void lblTextesImmeuble_Click(object sender, EventArgs e)
        {
            if (immeuble != null)
            {
                FicheAideImmeubleForm form = new FicheAideImmeubleForm(immeuble);
                form.ShowDialog();

            }
            else
                MessageBox.Show("vous devez d'abord créer l'immeuble");
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void lblRef_Click(object sender, EventArgs e)
        {
            FindImmeubleForm form = new FindImmeubleForm(tbNumero);
            if (DialogResult.Cancel != form.ShowDialog())
            {
                immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbNumero.Text);
                setFicheValues(immeuble);
            }
        }

        private void lblExercice_Click(object sender, EventArgs e)
        {
            if ( immeuble != null )
            {
                ReferenceExerciceForm form = new ReferenceExerciceForm(immeuble);
                form.ShowDialog();
            }
        }
    }
}
