using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Entites;
using SyndicData.Controller;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Coproprietaire;
using Npgsql;
using EspaceSyndic.UtilsApp;
using SyndicData.Common;
namespace EspaceSyndic.Formulaires.Immeubles
{
    public partial class FicheRepartLot : Form
    {
        public ImmeubleEntite immeuble;
        private DataRowView currentLot = null;
        DataTable repartitionImmeuble ;//= immeuble.getRepartitionImmeuble();
        DataTable repartitionLots;
        public FicheRepartLot()
        {
            InitializeComponent();
        }

        private void FicheRepartLot_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<LotDescriptionEntite> listToDel = new List<LotDescriptionEntite>();

            foreach (DataGridViewRow r in dataGridViewLots.Rows)
            {
                DataRowView row = (DataRowView)r.DataBoundItem;
                LotDescriptionEntite lot = LotDescriptionController.getController().getEntiteById ( row["id"].ToString());
                if (lot.statut == (int)GlobalConstantes.StatutData.Supprime)
                {
                    listToDel.Add(lot);
                }
            }
            if (listToDel.Count > 0)
            {
                DialogResult res = MessageBox.Show("Des lot ont été marqués comme supprimés définivement voulez les effacer ?", "Attention", MessageBoxButtons.YesNoCancel);
                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else
                    if (res == DialogResult.Yes)
                    {
                        NpgsqlTransaction trx = Database.BeginTransaction();
  
                        try
                        {
                            foreach (LotDescriptionEntite lot in listToDel)
                            {
                                LotDescriptionController.getController().deleteEntite(lot);
                            }
                            trx.Commit();
                            MessageBox.Show("Suppressions effectuées");
                        }
                        catch (Exception ex)
                        {
                            trx.Rollback();                            
                            MessageBox.Show ( ex.Message );
                        }
                    }
            }
        }

        private int countLotActif(DataTable table)
        {
            int count = 0;

            foreach (DataRow row in table.Rows)
            {
                if (Convertir.ToInt(row["statut"].ToString()) == (int)GlobalConstantes.StatutData.Actif)
                    count++;
            }
            return count;
        } 


        private void FicheRepartLot_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Bidon");
            repartitionImmeuble = immeuble.getRepartitionImmeuble();
            DataTable table = LotDescriptionController.getController().getDataGridListeLotDescription(immeuble, false);

            int nbLotActif = countLotActif(table);

            if (nbLotActif < immeuble.nombrelots)
            {
                int nb = immeuble.nombrelots - nbLotActif;
                table = LotDescriptionController.getController().createLotRepartition(immeuble, nb);
            }
            FillDataGridViewLot("");
            //dataGridViewLots.DataSource = table;
            //dataGridViewLots.Columns["id"].Visible = false;
            //dataGridViewLots.Columns["statut"].Visible = false;
            //dataGridViewLots.Columns["coproprietaire_id"].Visible = false;
            //dataGridViewLots.Columns["avance"].Visible = false;
            //dataGridViewLots.ReadOnly = true;
            //ControlsWindows.ToTitleCase(dataGridViewLots.Columns);
            tbImmeuble.ReadOnly = true;
            RepartitionControlsWindows.initGridRepartition(dataGridView);
            dataGridView.Enabled = false;
            dataGridView.ScrollBars = ScrollBars.None;

            ShowLotInfo();

        }

        private void dataGridViewLots_Click(object sender, EventArgs e)
        {
            ShowLotInfo();
        }
        private void LoadRepartitionLots()
        {
            LotRepartitionController controller = new LotRepartitionController();
            repartitionLots = controller.GetLotsRepartition(immeuble);
        }
        private void ShowFromRepartitionImmeuble()
        {
            foreach (DataGridViewRow r in dataGridView.Rows)
            {
                foreach (DataGridViewCell c in r.Cells)
                {
                    if (c.ColumnIndex != 0)
                        c.Style.BackColor = Color.LightGray;
                    c.ReadOnly = true;
                }
            }
            foreach ( DataRow row in repartitionImmeuble.Rows)
            {
                int ligne = Convert.ToInt32( row["ligne"].ToString());
                int colonne = Convert.ToInt32(row["colonne"].ToString());
                int valeur = Convert.ToInt32(row["valeur"].ToString());
                ControlRepartition(ligne, colonne);
                dataGridView.Rows[ligne - 1].Cells[colonne+1].ReadOnly = false;
                dataGridView.Rows[ligne - 1].Cells[colonne + 1].ToolTipText = row["nom"].ToString();
            }
        }

        private DataRow getRepartitionImmeuble(int ligne, int colonne)
        {
            foreach (DataRow row in repartitionImmeuble.Rows)
            {
                if ( Convert.ToInt32(row["ligne"]) == ligne)
                    if (Convert.ToInt32(row["colonne"]) == colonne)
                    {
                        return row;
                    }
            }
            return null;
        }
        private void ControlRepartition(int ligne, int colonne)
        {
            DataRow totalRow = getRepartitionImmeuble(ligne, colonne);
            int totalRepart = Convert.ToInt32(totalRow["valeur"].ToString());
            if (totalRepart == 0)
                return;
            int totalLots = 0;
            if (repartitionLots != null)
                foreach (DataRow row in repartitionLots.Rows)
                {
                    if (Convert.ToInt32(row["ligne"]) == ligne)
                        if (Convert.ToInt32(row["colonne"]) == colonne)
                        {
                            totalLots += Convert.ToInt32(row["valeur"].ToString());
                        }
                }
            if ( totalLots == totalRepart) {
                dataGridView.Rows[ligne - 1].Cells[colonne+1].Style.BackColor = Color.Green;
                dataGridView.Rows[ligne - 1].Cells[colonne+1].Style.ForeColor = Color.Black;
            }
            else
                if (totalLots < totalRepart)
                {
                    dataGridView.Rows[ligne - 1].Cells[colonne+1].Style.BackColor = Color.Red;
                    dataGridView.Rows[ligne - 1].Cells[colonne+1].Style.ForeColor = Color.Black;
                }
                else
                {
                    dataGridView.Rows[ligne - 1].Cells[colonne+1].Style.BackColor = Color.Maroon;
                    dataGridView.Rows[ligne - 1].Cells[colonne+1].Style.ForeColor = Color.White;
                }
        }
        private void ShowLotInfo() 
        {
            if (dataGridViewLots.SelectedRows.Count <= 0)
                return;
            DataRowView row = (DataRowView)dataGridViewLots.SelectedRows[0].DataBoundItem;
            if (row != null )
            {
                tbImmeuble.Text = immeuble.reference;
                tbNumLot.Text = row["numero_lot"].ToString();
                tbCoproprietaire.Text = row["coproprietaire"].ToString();
                tbBatiment.Text = row["numero_batiment"].ToString();
                tbEscalier.Text = row["numero_escalier"].ToString();
                tbEtage.Text = row["numero_etage"].ToString();
                tbAvance.Text = row["avance"].ToString();
                dataGridView.Enabled = true;
                currentLot = row;
                SetRepartitionLot();
            }
        }
        private void SetRepartitionLot()
        {
            LoadRepartitionLots();

            foreach ( DataGridViewRow rows in dataGridView.Rows)
                foreach (DataGridViewCell cell in rows.Cells)
                {
                    if ( cell.ColumnIndex > 0 )
                    {
                        cell.Value = "";
                        cell.Tag = null;
                    }
                }
            string lot_id = currentLot["id"].ToString();

            if (dataGridView.Rows.Count > 0)
            {
                foreach (DataRow row in repartitionLots.Rows)
                {
                    if (lot_id.Equals(row["lot_id"].ToString()))
                    {
                        LotRepartitionEntite entite = new LotRepartitionEntite(row);
                        dataGridView.Rows[entite.ligne - 1].Cells[entite.colonne + 1].Tag = entite;
                        if (entite.valeur != 0 )
                            //if ( entite.type_ventilation != (int) GlobalConstantes.TypeRepartition.Individuelle )
                                dataGridView.Rows[entite.ligne - 1].Cells[entite.colonne +1 ].Value = entite.valeur.ToString();
                    }
                }
                ShowFromRepartitionImmeuble();
            }
        }
        private void tbNumLot_Validating(object sender, CancelEventArgs e)
        {
        }

        private void lblReference_Click(object sender, EventArgs e)
        {
            FindCoproprietaireForm form = new FindCoproprietaireForm();
            form.ShowDialog();
            if (!"".Equals(form.reference))
                tbCoproprietaire.Text = form.reference;

        }
        private CoproprietaireEntite getCoproprietaireEntite()
        {
            CoproprietaireController controller = new CoproprietaireController();
            NpgsqlParameter parameter = new NpgsqlParameter("@reference", tbCoproprietaire.Text);
            List<NpgsqlParameter> parameters = new List<NpgsqlParameter> { parameter };
            return controller.getEntite(" where reference = @reference", parameters);

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveLot();
        }
        private void SaveRepartitionLot()
        {
            LotRepartitionController controller = new LotRepartitionController();

            foreach ( DataGridViewRow row in dataGridView.Rows)
            {
                foreach ( DataGridViewCell cell in row.Cells)
                {
                    if ( cell.ColumnIndex != 0 )
                        if (!cell.ReadOnly)
                        {
                            LotRepartitionEntite entite = (LotRepartitionEntite) cell.Tag;
                            if ( entite == null)
                                entite = new LotRepartitionEntite();

                            foreach (DataRow rowImm in repartitionImmeuble.Rows)
                            {
                                ImmeubleRepartitionEntite imm = new ImmeubleRepartitionEntite(rowImm);
                                if (imm.ligne == (row.Index+1))
                                    if (imm.colonne == cell.ColumnIndex)
                                    {
                                        entite.type_ventilation = imm.type_ventilation;
                                        break;
                                    }
                            }

                            entite.immeuble_id = immeuble.id;
                            entite.lot_id = currentLot["id"].ToString();
                            entite.ligne = row.Index + 1; ;
                            entite.colonne = cell.ColumnIndex -1;
                            entite.reference = String.Format("{0}{1}", entite.ligne, entite.colonne );
                            if (cell.Value == null || cell.Value.Equals(""))
                                entite.valeur = 0;
                            try
                            {
                                entite.valeur = Convertir.ToInt(cell.Value);
                            }
                            catch (Exception)
                            {
                            }
                            controller.InsertOrUpdate(entite);
                        }
                }
            }
        }
        private bool saveLot()
        {

            //LotDescriptionEntite entite = new LotDescriptionEntite();
            LotDescriptionEntite entite = LotDescriptionController.getController().getEntiteById(currentLot["id"].ToString());
            //entite.id = currentLot["id"].ToString();
            entite.isNew = false;
            entite.immeuble_id = immeuble.id;
            entite.numero_lot = Convert.ToInt32(tbNumLot.Text);
            string copro_id = "";

//            if (tbCoproprietaire.Text != "")
            {
                CoproprietaireEntite copro = getCoproprietaireEntite();
                if (copro == null)
                {
                    MessageBox.Show("Référence Copropriétaire Invalide");
                    tbCoproprietaire.Focus();
                    return false;
                }
                copro_id = copro.id;
            }

            currentLot = (DataRowView)dataGridViewLots.SelectedRows[0].DataBoundItem;

            entite.coproprietaire_id = copro_id;
            entite.numero_batiment = tbBatiment.Text;
            entite.numero_escalier = tbEscalier.Text;
            entite.numero_etage = tbEtage.Text;
            entite.avance = Convert.ToDecimal(tbAvance.Text.Replace(".", ","));

            LotDescriptionController controller = new LotDescriptionController();
            if (controller.InsertOrUpdate(entite))
            {

                SaveRepartitionLot();
                FillDataGridViewLot(currentLot["id"].ToString());

                return true;
            }
            return false;
        }
        private void FillDataGridViewLot(string oldSelect)
        {
            dataGridViewLots.DataSource = LotDescriptionController.getController().getDataGridListeLotDescription(immeuble, false);
            DataGridViewColumnCollection cols = dataGridViewLots.Columns;

            cols["index"].Width = 40;
            cols["coproprietaire"].Width = 40;
            cols["numero_lot"].Width = 30;
            cols["numero_etage"].Width = 30;
            cols["numero_batiment"].Width = 30;
            cols["numero_escalier"].Width = 30;
            cols["id"].Visible = false;
            cols["statut"].Visible = false;
            cols["coproprietaire_id"].Visible = false;
            cols["avance"].Visible = false;
            dataGridViewLots.ReadOnly = true;
            ControlsWindows.ToTitleCase(cols);

            foreach (DataGridViewRow row in dataGridViewLots.Rows)
            {
                if (oldSelect.Equals(row.Cells["id"].Value.ToString()))
                {
                    row.Selected = true;
                    dataGridViewLots.FirstDisplayedScrollingRowIndex = row.Index;
                    ShowLotInfo();
                    break;
                }
            }
            dataGridView.ClearSelection();
        }
        private void btnCoproAdd_Click(object sender, EventArgs e)
        {
            FicheCoproprietaireForm form = new FicheCoproprietaireForm();
            form.ShowDialog();
            if ( form.entite != null )
                tbCoproprietaire.Text = form.entite.reference;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            desactiverLeLotToolStripMenuItem.Enabled = dataGridViewLots.SelectedRows.Count > 0;
        }

        private void desactiverLeLotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewLots.SelectedRows.Count <= 0)
                return;
            DataRowView row = (DataRowView)dataGridViewLots.SelectedRows[0].DataBoundItem;
            if (row != null)
            {
                LotDescriptionEntite lot = LotDescriptionController.getController().getEntiteById(row["id"].ToString());
                lot.statut = (int)GlobalConstantes.StatutData.Inactif;
                LotDescriptionController.getController().InsertOrUpdate(lot);
                FillDataGridViewLot(row["id"].ToString());
            }
        }

        private void dataGridViewLots_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            DataGridViewRow row = dataGridViewLots.Rows[e.RowIndex];
            if (Convertir.ToInt(row.Cells["statut"].Value) == (int)GlobalConstantes.StatutData.Inactif)
            {
                row.DefaultCellStyle.BackColor = Color.OrangeRed;
            }
            if (Convertir.ToInt(row.Cells["statut"].Value) == (int)GlobalConstantes.StatutData.Supprime)
            {
                row.DefaultCellStyle.BackColor = Color.DarkRed;
            }
        }

        private void reactiverLeLotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewLots.SelectedRows.Count <= 0)
                return;
            DataRowView row = (DataRowView)dataGridViewLots.SelectedRows[0].DataBoundItem;
            if (row != null)
            {
                LotDescriptionEntite lot = LotDescriptionController.getController().getEntiteById ( row["id"].ToString());
                lot.statut = (int) GlobalConstantes.StatutData.Actif;
                LotDescriptionController.getController().InsertOrUpdate(lot);
                FillDataGridViewLot(row["id"].ToString());
            }
        }

        private void supprimerLeLotDéfinitivemantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewLots.SelectedRows.Count <= 0)
                return;
            DataRowView row = (DataRowView)dataGridViewLots.SelectedRows[0].DataBoundItem;
            if (row != null)
            {
                LotDescriptionEntite lot = LotDescriptionController.getController().getEntiteById(row["id"].ToString());
                lot.statut = (int)GlobalConstantes.StatutData.Supprime;
                LotDescriptionController.getController().InsertOrUpdate(lot);
                FillDataGridViewLot(row["id"].ToString());
            }
        }

        private void dataGridViewLots_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewLots.Rows[e.RowIndex];
                if (Convertir.ToInt(row.Cells["statut"].Value) == (int)GlobalConstantes.StatutData.Supprime)
                {
                    e.Paint(e.CellBounds, e.PaintParts);
                    Point pDeb = new Point(e.CellBounds.Left, e.CellBounds.Top + e.CellBounds.Height / 2);
                    Point pEnd = new Point(e.CellBounds.Right, e.CellBounds.Top + e.CellBounds.Height / 2);
                    e.Graphics.DrawLine(new Pen(Color.Black, 1), pDeb, pEnd);
                    e.Handled = true;
                }
            }
        }
    }
}
