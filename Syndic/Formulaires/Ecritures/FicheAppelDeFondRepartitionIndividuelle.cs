using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Formulaires.Ecritures;

public partial class FicheAppelDeFondRepartitionIndividuelle : Form
{
    private string[] base_compteur = new string[1];
    private string[] base_compteurFixes = new string[1];
    public ImmeubleEntite immeuble = null;
    private bool initialized;
    public SaisieAppelFondEntite saisie = null;

    public FicheAppelDeFondRepartitionIndividuelle()
    {
        InitializeComponent();
    }

    protected void getBasesCompteurs()
    {
        var bases = ParametresDB.getParam1("BASES", "COMPTEURS");
        var basesFixes = ParametresDB.getParam1("BASES", "COMPTEURS_FIXES");
        if (bases != null)
            base_compteur = bases.Replace(" ", "").Split(',');
        if (basesFixes != null)
            base_compteurFixes = basesFixes.Replace(" ", "").Split(',');
    }

    private void FicheAppelDeFondRepartitionIndividuelle_Load(object sender, EventArgs e)
    {
        getBasesCompteurs();

        dataGridViewLots.DataSource = LotDescriptionController.getController()
            .getDataGridListeLotDescription(immeuble, true, true, true);
        dataGridViewLots.Columns["id"].Visible = false;
        dataGridViewLots.Columns["coproprietaire_id"].Visible = false;
        dataGridViewLots.Columns["avance"].Visible = false;
        foreach (DataGridViewColumn col in dataGridViewLots.Columns) col.ReadOnly = true;

        if (!base_compteur.Contains(saisie.base_repart))
        {
            dataGridViewLots.Columns["ancien"].Visible = false;
            dataGridViewLots.Columns["nouveau"].Visible = false;
        }

        if (saisie.base_repart == "80")
        {
            dataGridViewLots.Columns["index"].Visible = false;
            tbGlobal.Visible = false;
            lblGlobal.Visible = false;
            dataGridViewLots.Columns["montant"].ReadOnly = false;
        }

        if (saisie.base_repart == "81" && saisie.Nature.reference == "140")
        {
            dataGridViewLots.Columns["index"].Visible = false;
            tbGlobal.Visible = false;
            lblGlobal.Visible = false;
            dataGridViewLots.Columns["montant"].ReadOnly = false;
        }

        FillDataGrid();

        ControlsWindows.ToTitleCase(dataGridViewLots.Columns);
        tbBase.Text = saisie.base_repart;
        tbMontantTotal.Enabled = false;
        btnEnter.Width = 0;
        initialized = true;
        dataGridViewLots_CellValueChanged(null, null);
    }

    protected void FillDataGrid()
    {
        try
        {
            var table = OperationController.getController().getOperationFromSaisie(saisie.id);
            var repart = RepartIndividuelleController.getController().getRepartFromSaisie(saisie.id);
            var bFromSaisie = true;
            if (repart == null || repart.Rows.Count < 1)
            {
                repart = RepartIndividuelleController.getController().getLastRepartFromSaisie(saisie.immeuble_id,
                    saisie.base_repart, GlobalConstantes.TypeSaisie.AppelDeFond);

                if (base_compteurFixes.Contains(saisie.base_repart))
                {
                    //DataTable totalRepart = RepartIndividuelleController.getController().getRepartFromSaisie(repart.Rows[0]["saisie_id"].ToString());
                    //repart = totalRepart;
                }

                bFromSaisie = false;
            }

            if (repart != null && repart.Rows.Count > 0)
                tbGlobal.Text = repart.Rows[0]["global"].ToString();
            tbMontantTotal.Text = saisie.montant.ToString();

            foreach (DataGridViewRow rowItem in dataGridViewLots.Rows)
            {
                var rowGrid = (DataRowView)rowItem.DataBoundItem;
                foreach (DataRow row in table.Rows)
                    if (rowGrid["id"].ToString() == row["lot_id"].ToString())
                    {
                        rowGrid["montant"] = (decimal)row["debit"] == 0 ? null : row["debit"];
                        rowItem.Tag = row;
                        break;
                    }

                foreach (DataRow row in repart.Rows)
                    if (rowGrid["id"].ToString() == row["lot_id"].ToString())
                    {
                        if (bFromSaisie)
                        {
                            rowGrid["ancien"] = row["ancien"];
                            rowGrid["nouveau"] = row["nouveau"];
                            rowGrid["index"] = row["index"];
                            rowItem.Cells["index"].Tag = row;
                        }
                        else
                        {
                            if (base_compteurFixes.Contains(saisie.base_repart))
                                rowGrid["index"] = row["index"];
                            else
                                rowGrid["ancien"] = row["nouveau"] == null ? row["ancien"] : row["nouveau"];
                        }

                        dataGridViewLots_CellEndEdit(dataGridViewLots,
                            new DataGridViewCellEventArgs(rowItem.Cells["index"].ColumnIndex, rowItem.Index));
                        break;
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
            //                Console.WriteLine("changed");
            float current = 0;
            foreach (DataGridViewRow row in dataGridViewLots.Rows)
                current += Convertir.ToFloat(row.Cells["montant"].Value);
            tbMontantActuel.Text = current.ToString();
            tbDiff.BackColor = Color.White;
            if (!"".Equals(tbMontantTotal.Text))
            {
                double total = Convertir.ToFloat(tbMontantTotal.Text);
                tbDiff.Text = $"{total - current:0.00}";
                if (Math.Abs(total - current) > 1)
                    tbDiff.BackColor = Color.Red;
            }
        }
    }

    private void btnValid_Click(object sender, EventArgs e)
    {
        var numligne = 1;

        dataGridViewLots_CellValueChanged(null, null);

        if (Math.Abs(Convertir.ToDecimal(tbDiff.Text)) > (decimal)1.0)
            if (DialogResult.Yes !=
                MessageBox.Show(
                    "Le montant total de la répartition n'est pas valide\r\nVoulez-vous enregistrer cette répartition",
                    "Attention", MessageBoxButtons.YesNo))
                return;

        var cnx = Database.GetInstance();
        var trx = cnx.BeginTransaction();


        try
        {
            var dt = DateTime.Now;
            var operationCtl = OperationController.getController();
            var repartCtl = RepartIndividuelleController.getController();

            repartCtl.setTimestampServer(dt);
            operationCtl.setTimestampServer(dt);

            if (!SaisieAppelFondController.getController().doInsertOrUpdate(saisie))
                throw new Exception("Saisie Appel");
            var global = Convertir.ToDecimal(tbGlobal.Text);

            foreach (DataGridViewRow rowGrid in dataGridViewLots.Rows)
            {
                var row = (DataRowView)rowGrid.DataBoundItem;
                var montant = Convertir.ToDecimal(row["montant"]);
                if (montant != 0 || rowGrid.Tag != null)
                {
                    var operation = new OperationEntite(saisie);
                    if (rowGrid.Tag != null)
                        operation = new OperationEntite((DataRow)rowGrid.Tag);

                    if (!operationCtl.InsertOperationFromSaisie(saisie, operation, montant,
                            row["coproprietaire_id"].ToString(), row["id"].ToString(), numligne++))
                        throw new Exception("Operation");

                    var cell = rowGrid.Cells["index"];
                    var repart = new RepartIndividuelleEntite((DataRow)cell.Tag);
                    var index = Convertir.ToDecimal(rowGrid.Cells["index"].Value);
                    var ancien = Convertir.ToDecimal(rowGrid.Cells["ancien"].Value);
                    var nouveau = Convertir.ToDecimal(rowGrid.Cells["nouveau"].Value);
                    if (!repartCtl.InsertRepartIndividuelleFromSaisie(operation, repart, index, ancien, nouveau, global,
                            GlobalConstantes.TypeSaisie.AppelDeFond))
                        throw new Exception("Repartition");
                }
            }

            trx.Commit();
            MessageBox.Show(@"Modifications enregistrées");
            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            trx.Rollback();
        }
    }

    private void tbGlobal_Validating(object sender, CancelEventArgs e)
    {
        if (tbGlobal.Text != "")
        {
            var cols = dataGridViewLots.Columns;
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
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
    }

    private void dataGridViewLots_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (((DataGridView)sender).Columns[e.ColumnIndex].Name == "index")
        {
            var cell = dataGridViewLots.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //if ( !cell.ReadOnly )
            {
                var montant = Convertir.ToDecimal(tbMontantTotal.Text);
                var global = Convertir.ToDecimal(tbGlobal.Text);
                var curr = Convertir.ToDecimal(cell.Value);
                if (global != 0)
                {
                    var value = montant * curr / global;
                    if (value != 0)
                        dataGridViewLots.Rows[e.RowIndex].Cells["montant"].Value = $"{value:0.00}";
                    else
                        dataGridViewLots.Rows[e.RowIndex].Cells["montant"].Value = null;
                }
            }
        }

        if (((DataGridView)sender).Columns[e.ColumnIndex].Name == "nouveau" ||
            ((DataGridView)sender).Columns[e.ColumnIndex].Name == "ancien")
        {
            var row = dataGridViewLots.Rows[e.RowIndex];
            if (row != null)
                if (row.Cells["ancien"].Value.ToString() != "" && row.Cells["nouveau"].Value.ToString() != "")
                {
                    var ancien = Convertir.ToDecimal(row.Cells["ancien"].Value);
                    var nouveau = Convertir.ToDecimal(row.Cells["nouveau"].Value);
                    row.Cells["index"].Value = nouveau - ancien;

                    var montant = Convertir.ToDecimal(tbMontantTotal.Text);
                    var global = Convertir.ToDecimal(tbGlobal.Text);
                    var curr = Convertir.ToDecimal(row.Cells["index"].Value);
                    if (global != 0)
                    {
                        var value = montant * curr / global;
                        if (value != 0)
                            dataGridViewLots.Rows[e.RowIndex].Cells["montant"].Value = $"{value:0.00}";
                        else
                            dataGridViewLots.Rows[e.RowIndex].Cells["montant"].Value = null;
                    }
                }
        }
    }

    private void dataGridViewLots_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            var row = dataGridViewLots.Rows[e.RowIndex];
            if (Convertir.ToInt(row.Cells["statut"].Value) == (int)GlobalConstantes.StatutData.Inactif)
                row.DefaultCellStyle.BackColor = Color.OrangeRed;
        }
    }
}