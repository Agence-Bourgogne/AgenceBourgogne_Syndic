using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using SyndicData.Controller;
using SyndicData.Entites;
using CommonProjectsPartners.Utils;
using SyndicData.Common;

namespace EspaceSyndic.Formulaires.Ecritures
{
    public partial class FicheFactureRepartitionIndividuelleMultiCpt : Form
    {
        public ImmeubleEntite immeuble;
        public SaisieFactureEntite saisie;
        

        public FicheFactureRepartitionIndividuelleMultiCpt()
        {
            InitializeComponent();
        }

        bool initialized = false;

        private void FicheFactureRepartitionIndividuelleMultiCpt_Load(object sender, EventArgs e)
        {
            btnEnter.Width = 0;
            DataTable repart = LotRepartitionController.getController().GetListLotsDescription(immeuble.id, saisie.base_repart);
            
            dataGridViewLots.DataSource = repart;
            DataGridViewColumnCollection cols = dataGridViewLots.Columns;

            cols["id"].Visible = false;
            cols["coproprietaire_id"].Visible = false;
            cols["ref_cpt"].Visible = false;
            cols["ancien"].ValueType = typeof (int);

            foreach (DataGridViewColumn col in cols)
            {
                col.ReadOnly = true;
            }

            cols["index"].ReadOnly = false;
            cols["montant"].ReadOnly = false;

            FillDataGrid();

            ControlsWindows.ToTitleCase(cols);
            tbBase.Text = saisie.base_repart;
            tbMontantTotal.Enabled = false;
            initialized = true;
            dataGridViewLots_CellValueChanged(null, null);

        }
        void FillDataGrid()
        {
            try
            {
                DataTable table = OperationController.getController().getOperationFromSaisie(saisie.id);
                DataTable repart = RepartIndividuelleController.getController().getRepartFromSaisie(saisie.id);
                bool bFromSaisie = true;
                if (repart == null || repart.Rows.Count < 1)
                {
                    repart = RepartIndividuelleController.getController().getLastRepartFromSaisie(saisie.immeuble_id, saisie.base_repart, GlobalConstantes.TypeSaisie.Facture) ;
                    bFromSaisie = false;
                }
                if (repart != null && repart.Rows.Count > 0)
                    tbGlobal.Text = repart.Rows[0]["global"].ToString();

                tbMontantTotal.Text = saisie.montant.ToString();
                String currentLotId = "";
                Color currentColor = Color.LightBlue;
                foreach (DataGridViewRow rowItem in dataGridViewLots.Rows)
                {
                    DataRowView rowGrid = (DataRowView)rowItem.DataBoundItem;
                    foreach (DataRow row in table.Rows)
                    {
                        if (rowGrid["id"].ToString() == row["lot_id"].ToString() && (int)rowGrid["ref_cpt"] == (int)row["ref_cpt"])
                        {
                            rowGrid["montant"] = ((decimal)row["debit"]) == 0 ? null : row["debit"];
                            rowItem.Tag = row;
                            break;
                        }
                    }
                    foreach (DataRow row in repart.Rows)
                    {
                        if (rowGrid["id"].ToString() == row["lot_id"].ToString() && (int) rowGrid["ref_cpt"] == (int) row["ref_cpt"])
                        {
                            if (bFromSaisie)
                            {
                                rowGrid["ancien"] = Convert.ToInt64(row["ancien"]);
                                rowGrid["nouveau"] = row["nouveau"];
                                rowGrid["index"] = row["index"];
                                ((DataGridViewCell)rowItem.Cells["index"]).Tag = row;
                            }
                            else
                            {
                                rowGrid["ancien"] = Convert.ToInt64(row["nouveau"] == null ? row["ancien"] : row["nouveau"]);
                            }
                            dataGridViewLots_CellEndEdit(dataGridViewLots, new DataGridViewCellEventArgs(((DataGridViewCell)rowItem.Cells["index"]).ColumnIndex, rowItem.Index));
                            break;
                        }
                    }
                    if (currentLotId != rowGrid["id"].ToString())
                    {
                        currentColor = currentColor == Color.LightBlue ? Color.White : Color.LightBlue;
                        currentLotId = rowGrid["id"].ToString();
                    }
                    rowItem.DefaultCellStyle.BackColor = currentColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewLots_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).Columns[e.ColumnIndex].Name == "index")
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
                        if (value != 0)
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
                    if (row.Cells["ancien"].Value.ToString() != "" && row.Cells["nouveau"].Value.ToString() != "")
                    {
                        decimal ancien = Convertir.ToDecimal(row.Cells["ancien"].Value);
                        decimal nouveau = Convertir.ToDecimal(row.Cells["nouveau"].Value);
                        row.Cells["index"].Value = nouveau - ancien;

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

        private void btnEnter_Click(object sender, EventArgs e)
        {
            ControlsWindows.FocusNextTabbedControl(this);
        }

        private void tbGlobal_Validating(object sender, CancelEventArgs e)
        {
            if (tbGlobal.Text != "")
            {
                DataGridViewColumnCollection cols = dataGridViewLots.Columns;
                cols["ancien"].ReadOnly = false;
                cols["nouveau"].ReadOnly = false;
            }
            dataGridViewLots_CellValueChanged(null, null);

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
                    tbDiff.Text = String.Format("{0:0.00}", (total - current));
                    if (Math.Abs(total - current) > 1)
                        tbDiff.BackColor = Color.Red;
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

        private void dataGridViewLots_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
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
                    tbDiff.Text = String.Format("{0:0.00}", (total - current));
                    if (Math.Abs(total - current) > 1)
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
                if (DialogResult.Yes != MessageBox.Show("Le montant total de la répartition n'est pas valide\r\nVoulez-vous enregistrer cette répartition", "Attention", MessageBoxButtons.YesNo))
                    return;
            }
            object trx = Database.BeginTransaction();

            try
            {
                DateTime dt = DateTime.Now;
                OperationController operationCtl = OperationController.getController();
                RepartIndividuelleController repartCtl = RepartIndividuelleController.getController();

                repartCtl.setTimestampServer(dt);
                operationCtl.setTimestampServer(dt);
                if (!SaisieFactureController.getController().doInsertOrUpdate(saisie))
                    throw new Exception("Saisie Facture");
                Decimal global = Convertir.ToDecimal(tbGlobal.Text);

                foreach (DataGridViewRow rowGrid in dataGridViewLots.Rows)
                {
                    DataRowView row = (DataRowView)rowGrid.DataBoundItem;
                    Decimal montant = Convertir.ToDecimal(row["montant"]);

                    if (montant != 0 || rowGrid.Tag != null)
                    {
                        OperationEntite operation = new OperationEntite(saisie);
                        if (rowGrid.Tag != null)
                            operation = new OperationEntite((DataRow)rowGrid.Tag);
                        operation.ref_cpt = Convertir.ToInt(rowGrid.Cells["ref_cpt"].Value);

                        if (!operationCtl.InsertOperationFromSaisie(saisie, operation, montant, row["coproprietaire_id"].ToString(), row["id"].ToString(), numligne++))
                            throw new Exception("Operation");

                        DataGridViewCell cell = rowGrid.Cells["index"];
                        RepartIndividuelleEntite repart = new RepartIndividuelleEntite((DataRow)cell.Tag);
                        decimal index = Convertir.ToDecimal(rowGrid.Cells["index"].Value);
                        decimal ancien = Convertir.ToDecimal(rowGrid.Cells["ancien"].Value);
                        decimal nouveau = Convertir.ToDecimal(rowGrid.Cells["nouveau"].Value);

                        if (!repartCtl.InsertRepartIndividuelleFromSaisie(operation, repart, index, ancien, nouveau, global, GlobalConstantes.TypeSaisie.Facture, operation.ref_cpt))
                            throw new Exception("Repartition");
                    }
                }
                Database.CommitTransaction(trx);
                MessageBox.Show("Modifications enregistrées");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Database.RollBackTransaction(trx);
            }

        }
    }
}
