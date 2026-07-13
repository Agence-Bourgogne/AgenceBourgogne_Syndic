namespace SyndicWordAddIn
{
    partial class RubanSyndic : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RubanSyndic()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.syndic = this.Factory.CreateRibbonTab();
            this.generer = this.Factory.CreateRibbonGroup();
            this.btnEtiquette = this.Factory.CreateRibbonButton();
            this.edRef = this.Factory.CreateRibbonEditBox();
            this.syndic.SuspendLayout();
            this.generer.SuspendLayout();
            // 
            // syndic
            // 
            this.syndic.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.syndic.Groups.Add(this.generer);
            this.syndic.Label = "Syndic";
            this.syndic.Name = "syndic";
            // 
            // generer
            // 
            this.generer.Items.Add(this.edRef);
            this.generer.Items.Add(this.btnEtiquette);
            this.generer.Label = "Génerer";
            this.generer.Name = "generer";
            // 
            // btnEtiquette
            // 
            this.btnEtiquette.Label = "Etiquettes Immeuble";
            this.btnEtiquette.Name = "btnEtiquette";
            this.btnEtiquette.ScreenTip = "Générer Etiquette Immeuble";
            this.btnEtiquette.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.btnEtiquette_Click);
            // 
            // edRef
            // 
            this.edRef.Label = "Réf Immeuble";
            this.edRef.Name = "edRef";
            // 
            // RubanSyndic
            // 
            this.Name = "RubanSyndic";
            this.RibbonType = "Microsoft.Word.Document";
            this.Tabs.Add(this.syndic);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RubanSyndic_Load);
            this.syndic.ResumeLayout(false);
            this.syndic.PerformLayout();
            this.generer.ResumeLayout(false);
            this.generer.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab syndic;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup generer;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton btnEtiquette;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox edRef;
    }

    partial class ThisRibbonCollection
    {
        internal RubanSyndic RubanSyndic
        {
            get { return this.GetRibbon<RubanSyndic>(); }
        }
    }
}
