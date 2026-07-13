using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using SyndicData.Entites;
using SyndicData.Controller;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using Npgsql;
using EspaceSyndic.Formulaires.Immeubles;
using EspaceSyndic.UtilsApp;
namespace EspaceSyndic.Formulaires.Ecritures
{
    public partial class FicheFactureRepartitionIndividuelle : Form
    {
        public ImmeubleEntite immeuble = null;
//        DataTable repartitionImmeuble;//= immeuble.getRepartitionImmeuble();
//        DataTable repartitionLots;
        public SaisieFactureEntite saisie = null;
        private bool initialized = false;

        private string[] base_compteur = new string[1];
        private string[] base_compteurFixes = new string[1];

        public FicheFactureRepartitionIndividuelle()
        {
            InitializeComponent();
        }

        protected void getBasesCompteurs()
        {
            string bases = ParametresDB.getParam1("BASES", "COMPTEURS");
            string basesFixes = ParametresDB.getParam1("BASES", "COMPTEURS_FIXES");
            if (bases != null)
                base_compteur = bases.Replace(" ", "").Split(',');
            if (basesFixes != null)
                base_compteurFixes = basesFixes.Replace(" ", "").Split(',');
        }


        protected void FicheFactureRepartitionIndividuelle_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
            getBasesCompteurs();

            //DataTable multiCpt  = null;
            //if (base_compteur.Contains(saisie.base_repart))
            //{
            //multiCpt = LotRepartitionController.getController().GetLotRepartitionCompteur(immeuble.id, saisie.base_repart);
            //}



            //if ( multiCpt != null && multiCpt.Rows.Count > 0 )
            //{
            //    DataTable listeLot = LotDescriptionController.getController().getDataGridListeLotDescriptionCpt(immeuble, true, true, true);
            //    //foreach ( DataRow row in multiCpt.Rows)
            //    //{
            //    //    DataRow newRow = listeLot.NewRow();
            //    //    newRow.ItemArray = row.ItemArray.Clone() as object[];
            //    //    listeLot.ImportRow(newRow);
            //    //}
            //    dataGridViewLots.DataSource = listeLot;
            //}
            //else
                dataGridViewLots.DataSource = LotDescriptionController.getController().getDataGridListeLotDescription(immeuble, true, true, true);
            DataGridViewColumnCollection cols = dataGridViewLots.Columns;
            cols["id"].Visible = false;
            cols["coproprietaire_id"].Visible = false;
            cols["avance"].Visible = false;

            foreach (DataGridViewColumn col in cols)
            {
                 col.ReadOnly = true;
            }

            if (!base_compteur.Contains(saisie.base_repart))
            {
                cols["ancien"].Visible = false;
                cols["nouveau"].Visible = false;
            }

            cols["index"].ReadOnly = false;
            cols["montant"].ReadOnly = false;

            if (saisie.base_repart == "80")
            {
                cols["index"].Visible = false;
                tbGlobal.Visible = false;
                lblGlobal.Visible = false;
                cols["montant"].ReadOnly = false;
            }
            FillDataGrid();

            ControlsWindows.ToTitleCase(cols);
            tbBase.Text = saisie.base_repart;
            tbMontantTotal.Enabled = false;
            initialized = true;
            dataGridViewLots_CellValueChanged(null, null);

        }
        protected void FillDataGrid()
        {
            try
            {
                DataTable table = OperationController.getController().getOperationFromSaisie(saisie.id);
                DataTable repart = RepartIndividuelleController.getController().getRepartFromSaisie(saisie.id);
                bool bFromSaisie = true;
                if (repart == null || repart.Rows.Count < 1)
                {
                    repart = RepartIndividuelleController.getController().getLastRepartFromSaisie(saisie.immeuble_id, saisie.base_repart, GlobalConstantes.TypeSaisie.Facture) ;
                    if (base_compteurFixes.Contains(saisie.base_repart))
                    {
                        DataTable totalRepart = RepartIndividuelleController.getController().getFactureRepartFromAppel(immeuble.id, saisie.base_repart, saisie.date_reference);
                        repart = totalRepart;
                    }
                    bFromSaisie = false;
                }
                if (repart != null && repart.Rows.Count > 0)
                    tbGlobal.Text = repart.Rows[0]["global"].ToString();
                tbMontantTotal.Text = saisie.montant.ToString();

                foreach (DataGridViewRow rowItem in dataGridViewLots.Rows)
                {
                    DataRowView rowGrid = (DataRowView)rowItem.DataBoundItem;
                    foreach (DataRow row in table.Rows)
                    {
                        if (rowGrid["id"].ToString() == row["lot_id"].ToString())
                        {
                            rowGrid["montant"] = ((decimal)row["debit"]) == 0 ? null : row["debit"];
                            rowItem.Tag = row;
                            break;
                        }
                    }
                    foreach (DataRow row in repart.Rows)
                    {
                        if (rowGrid["id"].ToString() == row["lot_id"].ToString())
                        {
                            if (bFromSaisie)
                            {
                                rowGrid["ancien"] = row["ancien"];
                                rowGrid["nouveau"] = row["nouveau"];
                                rowGrid["index"] = row["index"];
                                ((DataGridViewCell)rowItem.Cells["index"]).Tag = row;
                            }
                            else
                            {
                                if (base_compteurFixes.Contains(saisie.base_repart))
                                    rowGrid["index"] = row["index"];
                                else
                                    rowGrid["ancien"] = row["nouveau"] == null ? row["ancien"] : row["nouveau"];
                            }
                            dataGridViewLots_CellEndEdit(dataGridViewLots, new DataGridViewCellEventArgs(((DataGridViewCell)rowItem.Cells["index"]).ColumnIndex, rowItem.Index));
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewLots_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (initialized) 
            {
                float current = 0;
                foreach (DataGridViewRow row in dataGridViewLots.Rows)
                {
                    current += Convertir.ToFloat(row.Cells["montant"].Value);
//                    current += Convertir.ToFloat(row.Cells["index"].Value);
                }
                tbMontantActuel.Text = current.ToString();
                tbDiff.BackColor = Color.White;
                if (!"".Equals(tbMontantTotal.Text))
                {
                    double total = Convertir.ToFloat(tbMontantTotal.Text);
//                    double total = Convertir.ToFloat(tbGlobal.Text);
                    tbDiff.Text = String.Format("{0:0.00}",(total - current));
                    if ( Math.Abs(total - current) > 1 )
                        tbDiff.BackColor = Color.Red;
                }
            }
        }

        private void btnValid_Click(object sender, EventArgs e)
        {
            int numligne = 1;

            dataGridViewLots_CellValueChanged(null, null);

            if (Math.Abs(Convertir.ToDecimal(tbDiff.Text)) > (decimal)1.0)
            {
                if ( DialogResult.Yes !=  MessageBox.Show("Le montant total de la répartition n'est pas valide\r\nVoulez-vous enregistrer cette répartition", "Attention", MessageBoxButtons.YesNo ))
                    return;
            }
            NpgsqlConnection cnx = Database.GetInstance();
            NpgsqlTransaction trx = cnx.BeginTransaction();

            try
            {
                DateTime dt = DateTime.Now;
                OperationController operationCtl = OperationController.getController();
                RepartIndividuelleController repartCtl = RepartIndividuelleController.getController();
                
                repartCtl.setTimestampServer(dt);
                operationCtl.setTimestampServer(dt);
                if ( !SaisieFactureController.getController().doInsertOrUpdate(saisie))
                    throw new Exception("Saisie Facture");
                Decimal global = Convertir.ToDecimal(tbGlobal.Text);

                foreach (DataGridViewRow rowGrid in dataGridViewLots.Rows)
                {
                    DataRowView row = (DataRowView) rowGrid.DataBoundItem;
                    Decimal montant = Convertir.ToDecimal(row["montant"]);

                    if (montant != 0 || rowGrid.Tag != null )
                    {
                        OperationEntite operation = new OperationEntite(saisie);
                        if (rowGrid.Tag != null)
                            operation = new OperationEntite((DataRow)rowGrid.Tag);

                        if (!operationCtl.InsertOperationFromSaisie(saisie, operation, montant, row["coproprietaire_id"].ToString(), row["id"].ToString(), numligne++))
                            throw new Exception("Operation");

                        DataGridViewCell cell = rowGrid.Cells["index"];
                        RepartIndividuelleEntite repart = new RepartIndividuelleEntite((DataRow)cell.Tag);
                        decimal index = Convertir.ToDecimal(rowGrid.Cells["index"].Value);
                        decimal ancien = Convertir.ToDecimal(rowGrid.Cells["ancien"].Value);
                        decimal nouveau = Convertir.ToDecimal(rowGrid.Cells["nouveau"].Value);
                        if (!repartCtl.InsertRepartIndividuelleFromSaisie(operation, repart, index, ancien, nouveau, global, GlobalConstantes.TypeSaisie.Facture))
                            throw new Exception("Repartition");
                    }
                }
                trx.Commit();
                MessageBox.Show("Modifications enregistrées");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trx.Rollback();
            }
        }

        private void tbGlobal_Validating(object sender, CancelEventArgs e)
        {
            if ( tbGlobal.Text != "" )
            {
                DataGridViewColumnCollection cols = dataGridViewLots.Columns;
                if (base_compteur.Contains(saisie.base_repart))
                {
                    cols["ancien"].ReadOnly = false;
                    cols["nouveau"].ReadOnly = false;
                }
                else
                {
                    cols["index"].ReadOnly = false;
                }
            }
            dataGridViewLots_CellValueChanged(null, null);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void dataGridViewLots_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if ( ((DataGridView) sender).Columns[e.ColumnIndex].Name == "index" )
            {
                DataGridViewCell cell = dataGridViewLots.Rows[e.RowIndex].Cells[e.ColumnIndex];
                //if ( !cell.ReadOnly )
                {
                    decimal montant = Convertir.ToDecimal(tbMontantTotal.Text);
                    decimal global = Convertir.ToDecimal(tbGlobal.Text);
                    decimal curr = Convertir.ToDecimal(cell.Value);
                    if (global != 0)
                    {
                        decimal value = montant * curr / global;
                        if ( value != 0)
                            dataGridViewLots.Rows[e.RowIndex].Cells["montant"].Value = string.Format("{0:0.00}", value);
                        //else
                        //    dataGridViewLots.Rows[e.RowIndex].Cells["montant"].Value = null;
                    }
                }
            }
            if (((DataGridView)sender).Columns[e.ColumnIndex].Name == "nouveau" || ((DataGridView)sender).Columns[e.ColumnIndex].Name == "ancien")
            {
                DataGridViewRow row = dataGridViewLots.Rows[e.RowIndex];
                if (row != null)
                    if ( row.Cells["ancien"].Value.ToString() != "" && row.Cells["nouveau"].Value.ToString() != "" )
                    {
                        decimal ancien = Convertir.ToDecimal(row.Cells["ancien"].Value);
                        decimal nouveau = Convertir.ToDecimal(row.Cells["nouveau"].Value);
                        row.Cells["index"].Value =  nouveau-ancien;

                        decimal montant = Convertir.ToDecimal(tbMontantTotal.Text);
                        decimal global = Convertir.ToDecimal(tbGlobal.Text);
                        decimal curr = Convertir.ToDecimal(row.Cells["index"].Value);
                        if (global != 0)
                        {
                            decimal value = montant * curr / global;
                            if (value != 0)
                                dataGridViewLots.Rows[e.RowIndex].Cells["montant"].Value = string.Format("{0:0.00}", value);
                            else
                                dataGridViewLots.Rows[e.RowIndex].Cells["montant"].Value = null;
                        }
                    }
            }
        }

        private void dataGridViewLots_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            String name = dataGridViewLots.Columns[e.ColumnIndex].Name;
            if (name == "nouveau" || name == "ancien" || name == "index" || name == "montant")
            {
                DataGridViewCell cell = dataGridViewLots.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (Convertir.ToDecimal(e.Value) == 0)
                    e.Value = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (immeuble != null)
            {
                TitreRepartImmeubleForm form = new TitreRepartImmeubleForm();
                form.immeuble_id = immeuble.id;
                form.ShowDialog();
                //DataTable repartition_immeuble = immeuble.getRepartitionImmeuble();
                //RepartitionControlsWindows.ShowRepartitionImmeuble(dataGridView, repartition_immeuble);
            }
            else
                MessageBox.Show("vous devez d'abord définir l'immeuble");

        }

        private void dataGridViewLots_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewLots.Rows[e.RowIndex];
                if (Convertir.ToInt(row.Cells["statut"].Value) == (int)GlobalConstantes.StatutData.Inactif)
                {
                    row.DefaultCellStyle.BackColor = Color.OrangeRed;
                }
            }
        }
    }
}
