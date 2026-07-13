using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using GeranceData.Entites;
using GeranceData.Controller;
using CommonProjectsPartners.Utils;
using Npgsql;
using Microsoft.Reporting.WinForms;

namespace Gerance.Formulaires.Locataires
{
    public partial class ChargesLocataireForm : Common.BaseFicheForm
    {
        LocataireEntite locataire;
        public ChargesLocataireForm()
        {
            InitializeComponent();
        }
        protected override void setFicheValues(AbstractBaseEntite entite)
        {
            if (entite != null)
                locataire = (LocataireEntite)entite;
            else
                locataire = new LocataireEntite();

            currentReference = locataire.reference;

            tbRefLocataire.Text = locataire.reference;
            tbNom.Text = locataire.NomPrenom;
            tbAdresse.Text = locataire.adresse;

            BienEntite bien = locataire.Bien;
            if (bien != null)
                tbDateEntree.Text = bien.date_entree.ToShortDateString();
            else
                tbDateEntree.Text = "no bene";
            if (locataire.id != "")
            {
                decimal charges_reglees = QuittancesController.getController().getChargesReglees(locataire.id, dateDeb.Value, dateFin.Value);
                tbCharges.Text = charges_reglees.ToString();
//                decimal charge_
            }
            else
                tbCharges.Text = "";
            FillDataGrid();
            reportViewer1.Visible = false;
            base.setFicheValues(locataire);
        }
        
//        bool bLoading = false;

        private void FillDataGrid()
        {
//            bLoading = true;
            dataGridView.DataSource = NatureController.getController().getFromChargeLocative();
            if (dataGridView.DataSource != null)
            {
                DataGridViewColumnCollection cols = dataGridView.Columns;
                cols["id"].Visible = false;
                cols["reference"].Width = 40;
                cols["credit"].Visible = false;
                ControlsWindows.ToTitleCase(cols);

                cols["reference"].DefaultCellStyle.BackColor = Color.LightGray;
                cols["nom"].DefaultCellStyle.BackColor = Color.LightGray;
                cols["reference_comptabilite"].DefaultCellStyle.BackColor = Color.LightGray;
                cols["montant_charge"].Width = 60;
                cols["nom"].MinimumWidth = 180;

                DataGridViewCellStyle style = cols["montant_charge"].DefaultCellStyle;
                style.Alignment = DataGridViewContentAlignment.MiddleRight;
                cols["montant_charge"].DefaultCellStyle = style;
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.ReadOnly = true;
                    row.Cells[3].ReadOnly = false;
                }
            }

            DataTable table = RegulChargeController.getController().getDataFromRegul(locataire.id, dateDeb.Value, dateFin.Value);

            foreach (DataRow row in table.Rows)
            {
                string nature = row["nature_id"].ToString();
                foreach (DataGridViewRow rowGrid in dataGridView.Rows)
                {
                    string natureGrid = rowGrid.Cells["id"].Value.ToString();
                    if ( nature == natureGrid )
                    {
                        Console.WriteLine("Bingo => {0}", rowGrid.Cells["reference"].ToString());
                        rowGrid.Cells["montant_charge"].Value = row["debit"];
                        //rowGrid.Cells["montant_charge"].Tag = row;
                        rowGrid.Tag = new RegulChargeEntite(row);
                    }
                }
            }

            showChargesRelles();
            dataGridView.ClearSelection();
//            bLoading = false;
        }

        protected override AbstractBaseEntite getEntite(string where)
        {
            return LocataireController.getController().getLocataireBien(where);
        }


        protected override AbstractBaseEntite getCurrentEntite(string entite_id)
        {
            return LocataireController.getController().getEntiteById(entite_id);
        }

        private void lblRefLocataire_Click(object sender, EventArgs e)
        {
            if (ShowFindForm(new LocataireFindForm(), tbRefLocataire) == DialogResult.OK)
            {
                tbRefLocataire_Validating(null, null);
            }
        }

        private void tbRefLocataire_Validating(object sender, CancelEventArgs e)
        {
            LocataireEntite entite = LocataireController.getController().getEntiteFromField("reference", tbRefLocataire.Text);
            setFicheValues(entite);
        }


        private void dateDeb_Validated(object sender, EventArgs e)
        {
            if (!bFromEnter)
            {
                Console.WriteLine(dateDeb.Value.ToShortDateString());
                setFicheValues(locataire);
            }
        }
        protected override bool saveValue()
        {
            Console.WriteLine("saveValue");
            RegulChargeController controller = RegulChargeController.getController();
            controller.setTimestampServer(Database.GetTimestampServer());
            NpgsqlConnection cnx = Database.GetInstance();
            NpgsqlTransaction trx = cnx.BeginTransaction();

            // TODO Créer une Facture
//            FactureEntite facture = FacturesController.getController().getFacture

            try
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    DataRowView rowView = (DataRowView)row.DataBoundItem;
                    if (rowView.Row.RowState == DataRowState.Modified)
                    {
                        Console.WriteLine(rowView.Row.RowState);
                        RegulChargeEntite entite = (RegulChargeEntite)row.Tag;
                        if (entite == null)
                            entite = new RegulChargeEntite();

                        entite.date_debut = dateDeb.Value;
                        entite.date_fin = dateFin.Value;
                        entite.date_saisie = dateEcriture.Value;
                        entite.locataire_id = locataire.id;
                        entite.nature_id = row.Cells["id"].Value.ToString();
                        entite.bien_id = locataire.Bien.id;
                        entite.proprietaire_id = locataire.Bien.proprietaire_id;
                        entite.debit = Convertir.ToDecimal(row.Cells["montant_charge"].Value);

                        if (!controller.doInsertOrUpdate(entite))
                            throw new Exception(String.Format("Enregistrement non effectué pour {0}", row.Cells["nom"].Value));
                    }

                }

                trx.Commit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                trx.Rollback();
                return false;    
            } 
            return true;
        }

        private void tbRefLocataire_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
                if (e.KeyCode == Keys.Space)
                {
                    lblRefLocataire_Click(null, null);
                    e.SuppressKeyPress = true;
                }
        }

        private void dataGridView_Enter(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell.ColumnIndex != 3)
            {
                DataGridViewCell c = dataGridView.CurrentCell;
                dataGridView.CurrentCell = dataGridView.Rows[c.RowIndex].Cells[3];
            }
        }
        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            showChargesRelles();
        }
        void showChargesRelles()
        {
            decimal total_regul = 0; ;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                total_regul += (decimal)Convertir.ToDecimal(row.Cells["montant_charge"].Value);
            }
            tbRelles.Text = total_regul.ToString();
            setModified(true);
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Tab)
                e.Handled = true;
        }

        private void ChargesLocataireForm_Load(object sender, EventArgs e)
        {
            reportViewer1.Visible = false;
            reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportProcessingEventHandler);
        }
        // TODO Peux etre plusieurs locataires en une seule impression
        private DataTable getListLocataires()
        {
            return LocataireController.getController().getListLocatairesCharge(locataire.id);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            reportViewer1.Location = new Point(0,0);
            reportViewer1.Width = gbHdr.Width;
            reportViewer1.Height = gbList.Bottom - gbList.Top;
            reportViewer1.Visible = true;
            reportViewer1.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            string hdr_descr = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
            string hdr_agence = GeranceData.Common.ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");

            ReportParameter[] parameters = new ReportParameter[]{
                    new ReportParameter("dateDeb", dateDeb.Value.ToShortDateString()),
                    new ReportParameter("dateFin", dateFin.Value.ToShortDateString()),
                    new ReportParameter("dateEdition", dateEcriture.Value.ToShortDateString()),
                    new ReportParameter("charges_reelles", tbCharges.Text),
                    new ReportParameter("Header_Description", hdr_descr),
                    new ReportParameter("Header_Agence", hdr_agence),
                };

            reportViewer1.LocalReport.SetParameters(parameters);
            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("list_locataires", getListLocataires()));
            reportViewer1.RefreshReport();
        }
        void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            if (e.Parameters.Count > 0)
            {
                string locataire_id = e.Parameters["locataire_id"].Values[0];

                e.DataSources.Clear();
                e.DataSources.Add(new ReportDataSource("hdrLocataireCharge", LocataireController.getController().getHdrLocataireCharge(locataire_id)));

                BindingSource src = new BindingSource();
                src.DataSource = dataGridView.DataSource;
                e.DataSources.Add(new ReportDataSource("listCharges", src));
            }
        }

    }
}
