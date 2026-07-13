using System;
using System.Drawing;
using System.Windows.Forms;
using CommonProjectsPartners.Utils;
using EspaceSyndic.Formulaires.Common;
using SyndicData.Common;
using SyndicData.Controller;



namespace EspaceSyndic.Formulaires.Coproprietaire;

public class FindCoproprietaireForm : FindStdForm
{
    private TextBox tbGerant;
    private Label label3;
    public readonly CoproprietaireController controller = new();

    public FindCoproprietaireForm()
    {
        InitializeComponent();
        AdapteControls();
        dataGridView.CellPainting += dataGridView_CellPainting;
    }

    public FindCoproprietaireForm(TextBox tbResult)
        : base(tbResult)
    {
        InitializeComponent();
        AdapteControls();
        dataGridView.CellPainting += dataGridView_CellPainting;
    }

    private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            var row = dataGridView.Rows[e.RowIndex];
            if (Convertir.ToInt(row.Cells["statut"].Value) != (int)GlobalConstantes.StatutData.Actif)
            {
                row.DefaultCellStyle.BackColor = Color.OrangeRed;
            }
        }
    }

    public override void FillListFromFilter(string filter)
    {
        if (tbGerant.Text != "")
            filter += $" and LOWER(nomcomp) like LOWER('{tbGerant.Text}%') ";
        source = controller.GetFindListStatut(filter);
        base.FillListFromFilter(filter);
        var cols = dataGridView.Columns;
        cols["statut"].Visible = false;
    }

    private void AdapteControls()
    {
        var decal = 168;
        var size = dataGridView.Size;
        dataGridView.Size = size with { Width = size.Width + decal };
        dataGridView.TabIndex = 6;
        valid.TabIndex = 7;
        cancel.TabIndex = 8;
    }
    private void InitializeComponent()
    {
        tbGerant = new TextBox();
        label3 = new Label();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // panel1
        // 
        panel1.Location = new Point(12, 410);
        panel1.Size = new Size(553, 35);
        // 
        // cancel
        // 
        cancel.Location = new Point(296, 5);
        // 
        // valid
        // 
        valid.Location = new Point(213, 5);
        // 
        // tbNom
        // 
        tbNom.ScrollBars = ScrollBars.Vertical;
        // 
        // btnEnter
        // 
        btnEnter.Size = new Size(0, 23);
        // 
        // tbGerant
        // 
        tbGerant.Location = new Point(428, 6);
        tbGerant.Name = "tbGerant";
        tbGerant.Size = new Size(137, 20);
        tbGerant.TabIndex = 5;
        tbGerant.TextChanged += tbGerant_TextChanged;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(383, 9);
        label3.Name = "label3";
        label3.Size = new Size(39, 13);
        label3.TabIndex = 4;
        label3.Text = "Gérant";
        // 
        // FindCoproprietaireForm
        // 
        AutoScaleDimensions = new SizeF(6F, 13F);
        AutoSize = true;
        ClientSize = new Size(577, 455);
        Controls.Add(tbGerant);
        Controls.Add(label3);
        Name = "FindCoproprietaireForm";
        Controls.SetChildIndex(panel1, 0);
        Controls.SetChildIndex(label1, 0);
        Controls.SetChildIndex(tbRef, 0);
        Controls.SetChildIndex(label2, 0);
        Controls.SetChildIndex(tbNom, 0);
        Controls.SetChildIndex(label3, 0);
        Controls.SetChildIndex(tbGerant, 0);
        panel1.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();

    }

    private void tbGerant_TextChanged(object sender, EventArgs e)
    {
        FillListFromTbFilter();
    }

}