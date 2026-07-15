using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CommonProjectsPartners.Common;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Coproprietaire;
using EspaceSyndic.Formulaires.Exercice;
using EspaceSyndic.Formulaires.Immeubles;
using Microsoft.Reporting.WinForms;
using SyndicData.Common;
using SyndicData.Controller;
using SyndicData.Entites;

namespace EspaceSyndic.Impressions.RelevesIndividuels;

public partial class ReleveIndividuelsPrintForm : Form, ICommonChangedListener
{
    public ImmeubleEntite immeuble;
    private readonly AutoCompleteStringCollection lotsString = new();
    private readonly string TitreForm;
    private readonly BindingSource immeuble_copro = new();
    private readonly BindingSource releve_copro = new();
    private readonly BindingSource releve_soldes = new();
    private readonly BindingSource releve_appel_fond = new();
    private DataTable tableImmeuble_copro, table_soldes, table_appel_fond;
    private readonly BindingSource base_descr = new();
    private DataTable solde_bidon;
    private readonly DataTable tableCondense = new();
    private DataTable releve;
    private string[] base_compteur;

    public ReleveIndividuelsPrintForm()
    {
        InitializeComponent();
        TitreForm = Text;
    }

    private void ReleveIndividuelsPrintForm_Load(object sender, EventArgs e)
    {
        btnRapport.Enabled = false;
        btnEnter.Width = 0;
        reportViewer1.LocalReport.SubreportProcessing += SubreportProcessingEventHandler;
    }
    private void lblImmeuble_Click(object sender, EventArgs e)
    {
        var form = new FindImmeubleForm();
        form.ShowDialog();
        if (!"".Equals(form.reference))
        {
            tbRefImmeuble.Text = form.reference;
            tbRefImmeuble_Validating(null, null);
        }
    }

    private void tbRefImmeuble_Validating(object sender, CancelEventArgs e)
    {
        if (tbRefImmeuble.Enabled)
            immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
        if (immeuble != null)
        {
            tbRefImmeuble.BackColor = Color.White;
            var lots = LotDescriptionController.getController().getListeLot(immeuble.id);

            Text = $"{TitreForm} pour l'immeuble : {immeuble.nom} ({immeuble.DateExercice})";

            var exercice = immeuble.ExerciceCourant;//ExerciceComptableController.getController().getExerciceCourant(immeuble.id);
            if (exercice != null)
            {
                dtDebut.Value = exercice.date_deb;
                dtFin.Value = exercice.date_fin;
            }

            // Milliemes de chaque Copro

            lotsString.Clear();
            foreach (DataRow row in lots.Rows)
            {
                lotsString.Add(row["numero_lot"].ToString());
            }
            ControlsWindows.setAutoControle(tbLot, lotsString);
            btnRapport.Enabled = true;
        }
        else
        {
            Text = TitreForm;
            if (!"".Equals(tbRefImmeuble.Text))
                tbRefImmeuble.BackColor = Color.Red;
            btnRapport.Enabled = false;
        }
    }

    private void tbRefImmeuble_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (ModifierKeys == Keys.Control)
            if (e.KeyChar == ' ')
            {
                e.Handled = true;
                if (sender.Equals(tbRefImmeuble))
                    lblImmeuble_Click(null, null);
                if (sender.Equals(tbLot))
                    lblLot_Click(null, null);
            }
    }

    private void tbLot_Validating(object sender, CancelEventArgs e)
    {
        if (tbLot.Text != "")
            if (lotsString.Contains(tbLot.Text))
                tbLot.BackColor = Color.White;
            else
                tbLot.BackColor = Color.Red;
        else
            tbLot.BackColor = Color.White;
    }

    private void btnEnter_Click(object sender, EventArgs e)
    {
        ControlsWindows.FocusNextTabbedControl(this);
    }

      
    // TODO Parametrer ces éléments
    private readonly string[] noCumulable = ["042", "043", "050", "051", "113", "123"];
    private bool isCumulable( string refNature)
    {
        var rc = true;
        if (noCumulable.Contains(refNature))
            return false;
        return rc;
    }
        
    protected void getBasesCompteurs()
    {
        var bases = ParametresDB.getParam1("BASES", "COMPTEURS");
        if (bases != null)
        {
            base_compteur = bases.Replace(" ", "").Split(',');
        }
    }
    private bool IsBaseCompteur(string base_repart)
    {
        if ( base_compteur == null)
            getBasesCompteurs();
        return base_compteur.Contains(base_repart);
    }
    private void loadDataReleve()
    {
        releve = OperationController.getController().GetReleveIndividuels(immeuble.id, dtDebut.Value, dtFin.Value);
        string copro_id = "", nature_id = "", base_repart = "", fournisseur = "";

        tableCondense.Clear();

        if (tableCondense.Columns.Count <= 0)
            foreach (DataColumn col in releve.Columns)
            {
                Console.WriteLine(col.ColumnName);
                tableCondense.Columns.Add(col.ColumnName, col.DataType);
            }

        var bDetail = ckDetail.Checked;
        try
        {
            var row2Update = -1;
            foreach (DataRow row in releve.Rows)
            {
                var debit = (decimal)row["debit"];

                if (debit != 0)
                    row["charge_loc"] = (decimal)row["debit"] * (decimal)row["charge_loc"] / 100;
                else
                    row["charge_loc"] = (decimal)row["credit"] * -1 * (decimal)row["charge_loc"] / 100;

                var rowItem = row.ItemArray;
                rowItem[10] = Math.Abs((decimal)rowItem[10]);

                if (bDetail)
                    copro_id = "";
                var ref_cpt = Convertir.ToInt(row["ref_cpt"].ToString());
                if (copro_id != row["ref_copro"].ToString() )
                {
                    tableCondense.Rows.Add(rowItem);
                    copro_id = row["ref_copro"].ToString();
                    fournisseur = row["fournisseur"].ToString();
                    nature_id = row["ref_nature"].ToString();
                    base_repart = row["base_repart"].ToString();
                    row2Update = -1;
                }
                else
                if (fournisseur != row["fournisseur"].ToString())
                {
                    tableCondense.Rows.Add(rowItem);
                    nature_id = row["ref_nature"].ToString();
                    fournisseur = row["fournisseur"].ToString();
                    base_repart = row["base_repart"].ToString();
                    row2Update = -1;
                }
                else
                if (nature_id != row["ref_nature"].ToString() || !isCumulable(row["ref_nature"].ToString()))
                {
                    tableCondense.Rows.Add(rowItem);
                    nature_id = row["ref_nature"].ToString();
                    base_repart = row["base_repart"].ToString();
                    row2Update = -1;
                }
                else
                if (base_repart != row["base_repart"].ToString())
                {
                    tableCondense.Rows.Add(rowItem);
                    base_repart = row["base_repart"].ToString();
                    row2Update = -1;
                }
                else
                {
                    var current = tableCondense.Rows.Count - 1;
                    var oldItem = tableCondense.Rows[current].ItemArray;
                    //                                    if (!IsBaseCompteur(base_repart))
                    if (!IsBaseCompteur(oldItem[2].ToString())&&!IsBaseCompteur(base_repart))
                    {
                        oldItem[5] = ".";
                        var value = Convertir.ToDecimal(oldItem[8]) + Convertir.ToDecimal(rowItem[8]);

                        oldItem[8] = value;
                        oldItem[9] = Convertir.ToDecimal(oldItem[9]) + Convertir.ToDecimal(rowItem[9]);
                        oldItem[10] = Convertir.ToDecimal(oldItem[10]) + Convertir.ToDecimal(rowItem[10]);
                        oldItem[11] = Convertir.ToDecimal(oldItem[11]) + Convertir.ToDecimal(rowItem[11]);
                        tableCondense.Rows[current].ItemArray = oldItem;
                        row2Update = -1;
                    }
                    else
                    if (row2Update != -1)
                    {
                        var oldRow = tableCondense.Rows[row2Update];
                        if ( oldRow["saisie_id"].ToString() != row["saisie_id"].ToString())
                        {
                            row2Update = -1;
                            tableCondense.Rows.Add(rowItem);
                        }
                        //Console.WriteLine("..");
                    }
                }
                if (IsBaseCompteur (base_repart))
                {
                    var bCumul = true;
                    if (row2Update == -1)
                    {
                        row2Update = tableCondense.Rows.Count - 1;
                        bCumul = false;
                    }
                    if ( row2Update != -1 && bCumul)
                    {
                        var oldItem = tableCondense.Rows[row2Update].ItemArray;
                        oldItem[7] = Convertir.ToDecimal(oldItem[7]) + Convertir.ToDecimal(rowItem[7]);
                        oldItem[9] = Convertir.ToDecimal(oldItem[9]) + Convertir.ToDecimal(rowItem[9]);
                        oldItem[10] = Convertir.ToDecimal(oldItem[10]) + Convertir.ToDecimal(rowItem[10]);
                        oldItem[11] = Convertir.ToDecimal(oldItem[11]) + Convertir.ToDecimal(rowItem[11]);
                        tableCondense.Rows[row2Update].ItemArray = oldItem;
                    }
                    double ancien = Convertir.ToFloat(row["ancien"].ToString());
                    double nouveau = Convertir.ToFloat(row["nouveau"].ToString());
                    if (nouveau != 0)
                    {
                        for (var i = 1; i < rowItem.Length; i++)
                            rowItem[i] = null;
                        rowItem[5] = string.Format("Cpt {2} : Ancien Index {0}   -   Nouvel Index {1} ", ancien, nouveau, ref_cpt);
                        tableCondense.Rows.Add(rowItem);
                    }
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace);
            MessageBox.Show(ex.Message);
        } 
        Console.WriteLine("---");
    }

    private void btnRapport_Click(object sender, EventArgs e)
    {
        try
        {
            loadDataReleve();
            table_soldes = OperationController.getController().getSoldesRelevesIndividuels(immeuble.id, dtDebut.Value, dtFin.Value);
            table_appel_fond = OperationController.getController().getSoldesRelevesIndividuels(immeuble.id, dtDebut.Value, dtFin.Value, true);
            solde_bidon = OperationController.getController().getSoldesBidon();
            //  LoadReport();
            CreateReport(tbLot.Text);

            reportViewer1.RefreshReport();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

    }

    private void CreateReport( string num_lot)
    {
        tableImmeuble_copro = ImmeubleController.getController().GetDescriptionCoproprietairesImmeubleReleveIndividuel(immeuble.id, num_lot);


        var finance = new List<EtatFinancier>();
        foreach (DataRow row in table_appel_fond.Rows)
        {
            finance.Add(new EtatFinancier(row["coproprietaire_id"].ToString(), (decimal)row["credit"] - (decimal)row["debit"]));
        }


        decimal avance = 0, sommes = 0, excedents = 0, solde = 0;

        avance = LotDescriptionController.getController().getAvanceImmeuble(immeuble.id);
        foreach (DataRow row in table_soldes.Rows)
        {
            var ordre = (int)row["ordre"];
            var etat = getIndiceCopro(finance, row["coproprietaire_id"].ToString());
            if (etat == null)
            {
                etat = new EtatFinancier(row["coproprietaire_id"].ToString());
                finance.Add(etat);
            }
            switch (ordre)
            {
                case 1:
                    if ((decimal)row["credit"] - (decimal)row["debit"] == 0)
                    {
                        foreach (DataRow row_copro in tableImmeuble_copro.Rows)
                        {
                            var statut = (int)row_copro["statut"];
                            if (statut != 1)
                                if (row_copro["copro_id"].ToString() == row["coproprietaire_id"].ToString())
                                {
                                    tableImmeuble_copro.Rows.Remove(row_copro);
                                    break;
                                }
                        }
                    }
                    etat.solde += (decimal)row["credit"] - (decimal)row["debit"];
                    break;
                case 2:
                    etat.reglement += (decimal)row["credit"] - (decimal)row["debit"];
                    break;
                case 3:
                    etat.releve += (decimal)row["credit"] - (decimal)row["debit"];
                    break;
            }
        }

        foreach (var etat in finance)
        {
            var cumul = etat.solde + etat.reglement + etat.releve;

            if (cumul < 0)
                sommes += cumul;
            else
                excedents += cumul;
        }

        solde = Math.Abs(sommes) - excedents - avance;

        var table_etat = new DataTable();
        table_etat.Columns.Add("code");
        table_etat.Columns.Add("libelle");
        table_etat.Columns.Add("dettes", typeof(decimal));
        table_etat.Columns.Add("creances", typeof(decimal));


        table_etat.Rows.Add("1033", "Avance fond de roulement", 0.0, avance);
        table_etat.Rows.Add("45", "Sommes exigibles restant à recevoir", sommes, 0.0);
        table_etat.Rows.Add("45", "Excédents Versés", 0.0, excedents);
        if (solde < 0)
            table_etat.Rows.Add("43", "Solde de banque créditeur", solde, 0.0);
        if (solde > 0)
            table_etat.Rows.Add("43", "Solde de banque débiteur", 0.0, solde);

        var hdr_descr = ParametresDB.getParam1("IMPRESSION", "HEADER_DESCRIPTION");
        var hdr_agence = ParametresDB.getParam1("IMPRESSION", "HEADER_AGENCE");

        var parameters = new ReportParameter[]{
            new("DateDebut", dtDebut.Value.ToShortDateString()),
            new("DateFin", dtFin.Value.ToShortDateString()),
            new("DateEdition", dtEdition.Value.ToShortDateString()),
            new("Header_Description", hdr_descr),
            new("Header_Agence", hdr_agence)
        };

        Console.WriteLine(" test " + reportViewer1.LocalReport.ReportEmbeddedResource);
           
        reportViewer1.LocalReport.SetParameters(parameters);
        reportViewer1.LocalReport.DataSources.Clear();
        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("immeuble_copro", tableImmeuble_copro));
        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("etat_financier", table_etat));
        reportViewer1.RefreshReport();
    }

    private DataTable getTableBase()
    {
        var tv = (DataView)releve_copro.List;
        var tb = tv.ToTable();
        var base_def = new List<string>();
        var table = new DataTable();

        table.Columns.Add("base_ref");
        table.Columns.Add("base_nom");
        foreach (DataRow row in tb.Rows)
        {
            var base_ref = row["base_repart"].ToString();
            if (base_ref != "")
            {
                if (!base_def.Contains(base_ref))
                {
                    base_def.Add(base_ref);
                    table.Rows.Add(base_ref, row["base_nom"].ToString());
                }
            }
        }
        return table;
    }
    private EtatFinancier getIndiceCopro(List<EtatFinancier> finance, string copro)
    {
        foreach (var etat in finance )
        {
            if ( etat.copro_id == copro )
                return etat;
        }
        return null;
    }
    private void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
    {
        var coproprietaire_id = e.Parameters[0].Values[0];
        releve_copro.DataSource  = tableCondense;
        releve_copro.Filter = $"ref_copro = '{coproprietaire_id}'";

        base_descr.DataSource = getTableBase();
        base_descr.Sort = "base_ref";
            
        releve_soldes.DataSource = table_soldes;
        releve_appel_fond.DataSource = table_appel_fond;

        immeuble_copro.DataSource = tableImmeuble_copro;
        immeuble_copro.Filter = $"copro_id = '{coproprietaire_id}'";
        releve_soldes.Filter = $"coproprietaire_id = '{coproprietaire_id}'";
        releve_appel_fond.Filter = $"coproprietaire_id = '{coproprietaire_id}'";

        e.DataSources.Clear();
        e.DataSources.Add(new ReportDataSource("base_description", base_descr));
        e.DataSources.Add(new ReportDataSource("releve_indiv", releve_copro));
        e.DataSources.Add(new ReportDataSource("immeuble_copro", immeuble_copro));
        e.DataSources.Add(new ReportDataSource("soldes_releve_indiv", releve_soldes));
        e.DataSources.Add(new ReportDataSource("soldes_appel_fond", releve_appel_fond));
        e.DataSources.Add(new ReportDataSource("soldes_bidon", solde_bidon));
    }
    public void ChangedReference(object send, CommonEventArgs e)
    {
        tbRefImmeuble.Text = e.newRef;
        tbRefImmeuble_Validating(null, null);
        tbLot.Text = e.newRef2;
        tbLot_Validating(null, null);
        btnRapport_Click(null, null);
    }

    private void lblLot_Click(object sender, EventArgs e)
    {
        var form = new FindLotCoproprietaireImmeubleForm();
        form.immeuble = immeuble;
        form.ShowDialog();
        if (form.reference != "")
        {
            tbLot.Text = form.reference;
        }
    }

    private void reportViewer1_Load(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {
        if (immeuble == null)
            return;
        var form = new ReferenceExerciceForm(immeuble);
        form.ShowDialog();
        tbRefImmeuble_Validating(null, null);
    }
}

internal class EtatFinancier
{
    public readonly string copro_id;

    public readonly decimal appel;
    public decimal solde;
    public decimal reglement;
    public decimal releve;

    public EtatFinancier(string copro)
    {
        copro_id = copro;
    }

    public EtatFinancier(string copro, decimal appel)
    {
        copro_id = copro;
        this.appel = appel;
    }
}