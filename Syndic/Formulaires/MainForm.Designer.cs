using System.ComponentModel;
using System.Windows.Forms;

namespace EspaceSyndic.Formulaires
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            fichiersToolStripMenuItem = new ToolStripMenuItem();
            immeublesToolStripMenuItem = new ToolStripMenuItem();
            copropriétairesToolStripMenuItem = new ToolStripMenuItem();
            fournisseursToolStripMenuItem = new ToolStripMenuItem();
            naturesToolStripMenuItem = new ToolStripMenuItem();
            commentairesToolStripMenuItem = new ToolStripMenuItem();
            ecrituresToolStripMenuItem = new ToolStripMenuItem();
            saisieToolStripMenuItem = new ToolStripMenuItem();
            validationToolStripMenuItem = new ToolStripMenuItem();
            impressionListeFacturesToolStripMenuItem = new ToolStripMenuItem();
            visualisationOperationDeGestionToolStripMenuItem = new ToolStripMenuItem();
            controleDesDonnéesToolStripMenuItem = new ToolStripMenuItem();
            reflemToolStripMenuItem = new ToolStripMenuItem();
            appelDeFondsToolStripMenuItem = new ToolStripMenuItem();
            appelDeFondDunimmeubleToolStripMenuItem = new ToolStripMenuItem();
            consultationComptesPropriétairesToolStripMenuItem = new ToolStripMenuItem();
            saisieReglementCoproproToolStripMenuItem = new ToolStripMenuItem();
            impressionRéglementsToolStripMenuItem = new ToolStripMenuItem();
            retardDePaiementsToolStripMenuItem = new ToolStripMenuItem();
            transfertAppelDeFondsSurGéranceToolStripMenuItem = new ToolStripMenuItem();
            editionsToolStripMenuItem = new ToolStripMenuItem();
            convocationsToolStripMenuItem = new ToolStripMenuItem();
            additifsToolStripMenuItem = new ToolStripMenuItem();
            accusésDeReceptionToolStripMenuItem = new ToolStripMenuItem();
            feuillesDePrésenceToolStripMenuItem = new ToolStripMenuItem();
            bilanGénéralEtCompteExploitationToolStripMenuItem = new ToolStripMenuItem();
            relevésIndividuelsToolStripMenuItem = new ToolStripMenuItem();
            budgetPrévisionnelToolStripMenuItem = new ToolStripMenuItem();
            bordereauRemiseDeChèquesToolStripMenuItem = new ToolStripMenuItem();
            relevésCommercesToolStripMenuItem = new ToolStripMenuItem();
            clotureExerciceToolStripMenuItem = new ToolStripMenuItem();
            utilitairesToolStripMenuItem = new ToolStripMenuItem();
            immeublesToolStripMenuItem1 = new ToolStripMenuItem();
            editionEtiquettesToolStripMenuItem = new ToolStripMenuItem();
            editionComptesFiscauxParImmeublesToolStripMenuItem = new ToolStripMenuItem();
            tableauRemiseDeClefsToolStripMenuItem = new ToolStripMenuItem();
            balanceReglementsFacturesPourUnImmeubleToolStripMenuItem = new ToolStripMenuItem();
            balanceReglementsAppelsDeFondImmeubleToolStripMenuItem = new ToolStripMenuItem();
            balanceReglementsFacturesPourLeCompteSyndicToolStripMenuItem = new ToolStripMenuItem();
            outilsToolStripMenuItem = new ToolStripMenuItem();
            parametresToolStripMenuItem = new ToolStripMenuItem();
            parametresGenerauxToolStripMenuItem = new ToolStripMenuItem();
            utilisateursToolStripMenuItem = new ToolStripMenuItem();
            modèlesDeDocumentsToolStripMenuItem = new ToolStripMenuItem();
            quitterToolStripMenuItem = new ToolStripMenuItem();
            deconnexionToolStripMenuItem = new ToolStripMenuItem();
            quitterToolStripMenuItem1 = new ToolStripMenuItem();
            controlesDBToolStripMenuItem = new ToolStripMenuItem();
            facturesToolStripMenuItem = new ToolStripMenuItem();
            reglementsToolStripMenuItem = new ToolStripMenuItem();
            appelDeFondToolStripMenuItem = new ToolStripMenuItem();
            operationsReglementsToolStripMenuItem = new ToolStripMenuItem();
            operationsFacturesToolStripMenuItem = new ToolStripMenuItem();
            operationsAppelDeFondToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            repareFacturesToolStripMenuItem = new ToolStripMenuItem();
            répareRéglementsToolStripMenuItem = new ToolStripMenuItem();
            répareOpérationReglementsToolStripMenuItem = new ToolStripMenuItem();
            appelsDeFondsNouvelExerciceToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            grandLivreToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fichiersToolStripMenuItem, ecrituresToolStripMenuItem, reflemToolStripMenuItem, editionsToolStripMenuItem, utilitairesToolStripMenuItem, outilsToolStripMenuItem, quitterToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new System.Drawing.Size(915, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fichiersToolStripMenuItem
            // 
            fichiersToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { immeublesToolStripMenuItem, copropriétairesToolStripMenuItem, fournisseursToolStripMenuItem, naturesToolStripMenuItem, commentairesToolStripMenuItem });
            fichiersToolStripMenuItem.Name = "fichiersToolStripMenuItem";
            fichiersToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            fichiersToolStripMenuItem.Text = "&Fichiers";
            // 
            // immeublesToolStripMenuItem
            // 
            immeublesToolStripMenuItem.Name = "immeublesToolStripMenuItem";
            immeublesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            immeublesToolStripMenuItem.Text = "Immeubles";
            immeublesToolStripMenuItem.Click += immeublesToolStripMenuItem_Click;
            // 
            // copropriétairesToolStripMenuItem
            // 
            copropriétairesToolStripMenuItem.Name = "copropriétairesToolStripMenuItem";
            copropriétairesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            copropriétairesToolStripMenuItem.Text = "Copropriétaires";
            copropriétairesToolStripMenuItem.Click += copropriétairesToolStripMenuItem_Click;
            // 
            // fournisseursToolStripMenuItem
            // 
            fournisseursToolStripMenuItem.Name = "fournisseursToolStripMenuItem";
            fournisseursToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            fournisseursToolStripMenuItem.Text = "Fournisseurs";
            fournisseursToolStripMenuItem.Click += fournisseursToolStripMenuItem_Click;
            // 
            // naturesToolStripMenuItem
            // 
            naturesToolStripMenuItem.Name = "naturesToolStripMenuItem";
            naturesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            naturesToolStripMenuItem.Text = "Natures";
            naturesToolStripMenuItem.Click += naturesToolStripMenuItem_Click;
            // 
            // commentairesToolStripMenuItem
            // 
            commentairesToolStripMenuItem.Name = "commentairesToolStripMenuItem";
            commentairesToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            commentairesToolStripMenuItem.Text = "Aides Immeubles";
            commentairesToolStripMenuItem.Click += commentairesToolStripMenuItem_Click;
            // 
            // ecrituresToolStripMenuItem
            // 
            ecrituresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saisieToolStripMenuItem, validationToolStripMenuItem, impressionListeFacturesToolStripMenuItem, visualisationOperationDeGestionToolStripMenuItem, controleDesDonnéesToolStripMenuItem });
            ecrituresToolStripMenuItem.Name = "ecrituresToolStripMenuItem";
            ecrituresToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            ecrituresToolStripMenuItem.Text = "E&critures";
            // 
            // saisieToolStripMenuItem
            // 
            saisieToolStripMenuItem.Name = "saisieToolStripMenuItem";
            saisieToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            saisieToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            saisieToolStripMenuItem.Text = "Saisie Factures";
            saisieToolStripMenuItem.Click += saisieToolStripMenuItem_Click;
            // 
            // validationToolStripMenuItem
            // 
            validationToolStripMenuItem.Name = "validationToolStripMenuItem";
            validationToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.V;
            validationToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            validationToolStripMenuItem.Text = "Validation Factures / Liasses";
            validationToolStripMenuItem.Click += validationToolStripMenuItem_Click;
            // 
            // impressionListeFacturesToolStripMenuItem
            // 
            impressionListeFacturesToolStripMenuItem.Name = "impressionListeFacturesToolStripMenuItem";
            impressionListeFacturesToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            impressionListeFacturesToolStripMenuItem.Text = "Impression Liste Factures";
            impressionListeFacturesToolStripMenuItem.Click += impressionListeFacturesToolStripMenuItem_Click;
            // 
            // visualisationOperationDeGestionToolStripMenuItem
            // 
            visualisationOperationDeGestionToolStripMenuItem.Name = "visualisationOperationDeGestionToolStripMenuItem";
            visualisationOperationDeGestionToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            visualisationOperationDeGestionToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            visualisationOperationDeGestionToolStripMenuItem.Text = "Visualisation Operations de Gestion";
            visualisationOperationDeGestionToolStripMenuItem.Click += visualisationOperationDeGestionToolStripMenuItem_Click;
            // 
            // controleDesDonnéesToolStripMenuItem
            // 
            controleDesDonnéesToolStripMenuItem.Name = "controleDesDonnéesToolStripMenuItem";
            controleDesDonnéesToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.D;
            controleDesDonnéesToolStripMenuItem.Size = new System.Drawing.Size(303, 22);
            controleDesDonnéesToolStripMenuItem.Text = "Controle des Données";
            controleDesDonnéesToolStripMenuItem.Click += controleDesDonnéesToolStripMenuItem_Click;
            // 
            // reflemToolStripMenuItem
            // 
            reflemToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { appelDeFondsToolStripMenuItem, appelDeFondDunimmeubleToolStripMenuItem, consultationComptesPropriétairesToolStripMenuItem, saisieReglementCoproproToolStripMenuItem, impressionRéglementsToolStripMenuItem, retardDePaiementsToolStripMenuItem, transfertAppelDeFondsSurGéranceToolStripMenuItem });
            reflemToolStripMenuItem.Name = "reflemToolStripMenuItem";
            reflemToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            reflemToolStripMenuItem.Size = new System.Drawing.Size(122, 20);
            reflemToolStripMenuItem.Text = "Opérations &Internes";
            // 
            // appelDeFondsToolStripMenuItem
            // 
            appelDeFondsToolStripMenuItem.Name = "appelDeFondsToolStripMenuItem";
            appelDeFondsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.A;
            appelDeFondsToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            appelDeFondsToolStripMenuItem.Text = "Appel de fonds";
            appelDeFondsToolStripMenuItem.Click += appelDeFondsToolStripMenuItem_Click;
            // 
            // appelDeFondDunimmeubleToolStripMenuItem
            // 
            appelDeFondDunimmeubleToolStripMenuItem.Name = "appelDeFondDunimmeubleToolStripMenuItem";
            appelDeFondDunimmeubleToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            appelDeFondDunimmeubleToolStripMenuItem.Text = "Réédition Appel de fonds";
            appelDeFondDunimmeubleToolStripMenuItem.Click += appelDeFondDunimmeubleToolStripMenuItem_Click;
            // 
            // consultationComptesPropriétairesToolStripMenuItem
            // 
            consultationComptesPropriétairesToolStripMenuItem.Name = "consultationComptesPropriétairesToolStripMenuItem";
            consultationComptesPropriétairesToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            consultationComptesPropriétairesToolStripMenuItem.Text = "Consultation Comptes Propriétaires";
            consultationComptesPropriétairesToolStripMenuItem.Click += consultationComptesPropriétairesToolStripMenuItem_Click;
            // 
            // saisieReglementCoproproToolStripMenuItem
            // 
            saisieReglementCoproproToolStripMenuItem.Name = "saisieReglementCoproproToolStripMenuItem";
            saisieReglementCoproproToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.R;
            saisieReglementCoproproToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            saisieReglementCoproproToolStripMenuItem.Text = "Saisie Règlements Copropriétaires";
            saisieReglementCoproproToolStripMenuItem.Click += saisieReglementCoproproToolStripMenuItem_Click;
            // 
            // impressionRéglementsToolStripMenuItem
            // 
            impressionRéglementsToolStripMenuItem.Name = "impressionRéglementsToolStripMenuItem";
            impressionRéglementsToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            impressionRéglementsToolStripMenuItem.Text = "Impression Réglements";
            impressionRéglementsToolStripMenuItem.Click += impressionRéglementsToolStripMenuItem_Click;
            // 
            // retardDePaiementsToolStripMenuItem
            // 
            retardDePaiementsToolStripMenuItem.Name = "retardDePaiementsToolStripMenuItem";
            retardDePaiementsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.P;
            retardDePaiementsToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            retardDePaiementsToolStripMenuItem.Text = "Retards de paiements";
            retardDePaiementsToolStripMenuItem.Click += retardDePaiementsToolStripMenuItem_Click;
            // 
            // transfertAppelDeFondsSurGéranceToolStripMenuItem
            // 
            transfertAppelDeFondsSurGéranceToolStripMenuItem.Enabled = false;
            transfertAppelDeFondsSurGéranceToolStripMenuItem.Name = "transfertAppelDeFondsSurGéranceToolStripMenuItem";
            transfertAppelDeFondsSurGéranceToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            transfertAppelDeFondsSurGéranceToolStripMenuItem.Text = "Transfert Appel de Fonds sur Gérance";
            transfertAppelDeFondsSurGéranceToolStripMenuItem.Click += transfertAppelDeFondsSurGéranceToolStripMenuItem_Click;
            // 
            // editionsToolStripMenuItem
            // 
            editionsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { convocationsToolStripMenuItem, additifsToolStripMenuItem, accusésDeReceptionToolStripMenuItem, feuillesDePrésenceToolStripMenuItem, bilanGénéralEtCompteExploitationToolStripMenuItem, relevésIndividuelsToolStripMenuItem, budgetPrévisionnelToolStripMenuItem, bordereauRemiseDeChèquesToolStripMenuItem, relevésCommercesToolStripMenuItem, clotureExerciceToolStripMenuItem, grandLivreToolStripMenuItem });
            editionsToolStripMenuItem.Name = "editionsToolStripMenuItem";
            editionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            editionsToolStripMenuItem.Text = "E&ditions";
            // 
            // convocationsToolStripMenuItem
            // 
            convocationsToolStripMenuItem.Name = "convocationsToolStripMenuItem";
            convocationsToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            convocationsToolStripMenuItem.Text = "Convocations";
            convocationsToolStripMenuItem.Click += convocationsToolStripMenuItem_Click;
            // 
            // additifsToolStripMenuItem
            // 
            additifsToolStripMenuItem.Name = "additifsToolStripMenuItem";
            additifsToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            additifsToolStripMenuItem.Text = "Additifs";
            additifsToolStripMenuItem.Click += additifsToolStripMenuItem_Click;
            // 
            // accusésDeReceptionToolStripMenuItem
            // 
            accusésDeReceptionToolStripMenuItem.Enabled = false;
            accusésDeReceptionToolStripMenuItem.Name = "accusésDeReceptionToolStripMenuItem";
            accusésDeReceptionToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            accusésDeReceptionToolStripMenuItem.Text = "Accusés de Reception";
            // 
            // feuillesDePrésenceToolStripMenuItem
            // 
            feuillesDePrésenceToolStripMenuItem.Name = "feuillesDePrésenceToolStripMenuItem";
            feuillesDePrésenceToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            feuillesDePrésenceToolStripMenuItem.Text = "Feuilles de présence";
            feuillesDePrésenceToolStripMenuItem.Click += feuillesDePrésenceToolStripMenuItem_Click;
            // 
            // bilanGénéralEtCompteExploitationToolStripMenuItem
            // 
            bilanGénéralEtCompteExploitationToolStripMenuItem.Name = "bilanGénéralEtCompteExploitationToolStripMenuItem";
            bilanGénéralEtCompteExploitationToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            bilanGénéralEtCompteExploitationToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            bilanGénéralEtCompteExploitationToolStripMenuItem.Text = "Bilan Général et Compte Exploitation";
            bilanGénéralEtCompteExploitationToolStripMenuItem.Click += bilanGénéralEtCompteExploitationToolStripMenuItem_Click;
            // 
            // relevésIndividuelsToolStripMenuItem
            // 
            relevésIndividuelsToolStripMenuItem.Name = "relevésIndividuelsToolStripMenuItem";
            relevésIndividuelsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.I;
            relevésIndividuelsToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            relevésIndividuelsToolStripMenuItem.Text = "Relevés Individuels";
            relevésIndividuelsToolStripMenuItem.Click += relevesIndividuelsToolStripMenuItem_Click;
            // 
            // budgetPrévisionnelToolStripMenuItem
            // 
            budgetPrévisionnelToolStripMenuItem.Name = "budgetPrévisionnelToolStripMenuItem";
            budgetPrévisionnelToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.B;
            budgetPrévisionnelToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            budgetPrévisionnelToolStripMenuItem.Text = "Budgets Prévisionnels";
            budgetPrévisionnelToolStripMenuItem.Click += budgetPrévisionnelToolStripMenuItem_Click;
            // 
            // bordereauRemiseDeChèquesToolStripMenuItem
            // 
            bordereauRemiseDeChèquesToolStripMenuItem.Name = "bordereauRemiseDeChèquesToolStripMenuItem";
            bordereauRemiseDeChèquesToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            bordereauRemiseDeChèquesToolStripMenuItem.Text = "Bordereau Remise de Chèques";
            bordereauRemiseDeChèquesToolStripMenuItem.Click += bordereauRemiseDeChèquesToolStripMenuItem_Click;
            // 
            // relevésCommercesToolStripMenuItem
            // 
            relevésCommercesToolStripMenuItem.Enabled = false;
            relevésCommercesToolStripMenuItem.Name = "relevésCommercesToolStripMenuItem";
            relevésCommercesToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            relevésCommercesToolStripMenuItem.Text = "Relevés Commerces";
            // 
            // clotureExerciceToolStripMenuItem
            // 
            clotureExerciceToolStripMenuItem.Name = "clotureExerciceToolStripMenuItem";
            clotureExerciceToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.E;
            clotureExerciceToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            clotureExerciceToolStripMenuItem.Text = "Cloture Exercice";
            clotureExerciceToolStripMenuItem.Click += clotureExerciceToolStripMenuItem_Click;
            // 
            // utilitairesToolStripMenuItem
            // 
            utilitairesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { immeublesToolStripMenuItem1, editionEtiquettesToolStripMenuItem, editionComptesFiscauxParImmeublesToolStripMenuItem, tableauRemiseDeClefsToolStripMenuItem, balanceReglementsFacturesPourUnImmeubleToolStripMenuItem, balanceReglementsAppelsDeFondImmeubleToolStripMenuItem, balanceReglementsFacturesPourLeCompteSyndicToolStripMenuItem });
            utilitairesToolStripMenuItem.Name = "utilitairesToolStripMenuItem";
            utilitairesToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            utilitairesToolStripMenuItem.Text = "Utilitaires";
            // 
            // immeublesToolStripMenuItem1
            // 
            immeublesToolStripMenuItem1.Name = "immeublesToolStripMenuItem1";
            immeublesToolStripMenuItem1.Size = new System.Drawing.Size(351, 22);
            immeublesToolStripMenuItem1.Text = "Feuille de commentaires Immeubles";
            immeublesToolStripMenuItem1.Click += immeublesToolStripMenuItem1_Click;
            // 
            // editionEtiquettesToolStripMenuItem
            // 
            editionEtiquettesToolStripMenuItem.Name = "editionEtiquettesToolStripMenuItem";
            editionEtiquettesToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            editionEtiquettesToolStripMenuItem.Text = "Edition Etiquettes";
            editionEtiquettesToolStripMenuItem.Click += editionEtiquettesToolStripMenuItem_Click;
            // 
            // editionComptesFiscauxParImmeublesToolStripMenuItem
            // 
            editionComptesFiscauxParImmeublesToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            editionComptesFiscauxParImmeublesToolStripMenuItem.Name = "editionComptesFiscauxParImmeublesToolStripMenuItem";
            editionComptesFiscauxParImmeublesToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            editionComptesFiscauxParImmeublesToolStripMenuItem.Text = "Edition Comptes Fiscaux par Immeuble";
            editionComptesFiscauxParImmeublesToolStripMenuItem.Click += editionComptesFiscauxParImmeublesToolStripMenuItem_Click;
            // 
            // tableauRemiseDeClefsToolStripMenuItem
            // 
            tableauRemiseDeClefsToolStripMenuItem.Name = "tableauRemiseDeClefsToolStripMenuItem";
            tableauRemiseDeClefsToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            tableauRemiseDeClefsToolStripMenuItem.Text = "Tableau Remise de Clefs";
            tableauRemiseDeClefsToolStripMenuItem.Click += tableauRemiseDeClefsToolStripMenuItem_Click;
            // 
            // balanceReglementsFacturesPourUnImmeubleToolStripMenuItem
            // 
            balanceReglementsFacturesPourUnImmeubleToolStripMenuItem.Name = "balanceReglementsFacturesPourUnImmeubleToolStripMenuItem";
            balanceReglementsFacturesPourUnImmeubleToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            balanceReglementsFacturesPourUnImmeubleToolStripMenuItem.Text = "Balance Règlements-Factures Pour un Immeuble";
            balanceReglementsFacturesPourUnImmeubleToolStripMenuItem.Click += balanceReglementsFacturesPourUnImmeubleToolStripMenuItem_Click;
            // 
            // balanceReglementsAppelsDeFondImmeubleToolStripMenuItem
            // 
            balanceReglementsAppelsDeFondImmeubleToolStripMenuItem.Name = "balanceReglementsAppelsDeFondImmeubleToolStripMenuItem";
            balanceReglementsAppelsDeFondImmeubleToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            balanceReglementsAppelsDeFondImmeubleToolStripMenuItem.Text = "Balance Règlements-Appel de Fonds Immeuble";
            balanceReglementsAppelsDeFondImmeubleToolStripMenuItem.Click += balanceReglementsAppelsDeFondImmeubleToolStripMenuItem_Click;
            // 
            // balanceReglementsFacturesPourLeCompteSyndicToolStripMenuItem
            // 
            balanceReglementsFacturesPourLeCompteSyndicToolStripMenuItem.Enabled = false;
            balanceReglementsFacturesPourLeCompteSyndicToolStripMenuItem.Name = "balanceReglementsFacturesPourLeCompteSyndicToolStripMenuItem";
            balanceReglementsFacturesPourLeCompteSyndicToolStripMenuItem.Size = new System.Drawing.Size(351, 22);
            balanceReglementsFacturesPourLeCompteSyndicToolStripMenuItem.Text = "Balance Règlements-Factures Pour le compte Syndic";
            // 
            // outilsToolStripMenuItem
            // 
            outilsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { parametresToolStripMenuItem, parametresGenerauxToolStripMenuItem, utilisateursToolStripMenuItem, modèlesDeDocumentsToolStripMenuItem });
            outilsToolStripMenuItem.Name = "outilsToolStripMenuItem";
            outilsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.T;
            outilsToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            outilsToolStripMenuItem.Text = "Paramètres";
            // 
            // parametresToolStripMenuItem
            // 
            parametresToolStripMenuItem.Name = "parametresToolStripMenuItem";
            parametresToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            parametresToolStripMenuItem.Text = "Parametrès de Connexion";
            parametresToolStripMenuItem.Click += parametresToolStripMenuItem_Click;
            // 
            // parametresGenerauxToolStripMenuItem
            // 
            parametresGenerauxToolStripMenuItem.Name = "parametresGenerauxToolStripMenuItem";
            parametresGenerauxToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.G;
            parametresGenerauxToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            parametresGenerauxToolStripMenuItem.Text = "Paramètres Généraux";
            parametresGenerauxToolStripMenuItem.Click += parametresGenerauxToolStripMenuItem_Click;
            // 
            // utilisateursToolStripMenuItem
            // 
            utilisateursToolStripMenuItem.Name = "utilisateursToolStripMenuItem";
            utilisateursToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            utilisateursToolStripMenuItem.Text = "Utilisateurs";
            utilisateursToolStripMenuItem.Click += utilisateursToolStripMenuItem_Click;
            // 
            // modèlesDeDocumentsToolStripMenuItem
            // 
            modèlesDeDocumentsToolStripMenuItem.Name = "modèlesDeDocumentsToolStripMenuItem";
            modèlesDeDocumentsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            modèlesDeDocumentsToolStripMenuItem.Text = "Modèles de documents";
            modèlesDeDocumentsToolStripMenuItem.Click += modèlesDeDocumentsToolStripMenuItem_Click;
            // 
            // quitterToolStripMenuItem
            // 
            quitterToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { deconnexionToolStripMenuItem, quitterToolStripMenuItem1, controlesDBToolStripMenuItem });
            quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            quitterToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            quitterToolStripMenuItem.Text = "&Actions";
            // 
            // deconnexionToolStripMenuItem
            // 
            deconnexionToolStripMenuItem.Name = "deconnexionToolStripMenuItem";
            deconnexionToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            deconnexionToolStripMenuItem.Text = "Déconnexion";
            deconnexionToolStripMenuItem.Click += deconnexionToolStripMenuItem_Click;
            // 
            // quitterToolStripMenuItem1
            // 
            quitterToolStripMenuItem1.Name = "quitterToolStripMenuItem1";
            quitterToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            quitterToolStripMenuItem1.Text = "&Quitter";
            quitterToolStripMenuItem1.Click += quitterToolStripMenuItem1_Click;
            // 
            // controlesDBToolStripMenuItem
            // 
            controlesDBToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { facturesToolStripMenuItem, reglementsToolStripMenuItem, appelDeFondToolStripMenuItem, operationsReglementsToolStripMenuItem, operationsFacturesToolStripMenuItem, operationsAppelDeFondToolStripMenuItem, toolStripSeparator1, repareFacturesToolStripMenuItem, répareRéglementsToolStripMenuItem, répareOpérationReglementsToolStripMenuItem });
            controlesDBToolStripMenuItem.Name = "controlesDBToolStripMenuItem";
            controlesDBToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            controlesDBToolStripMenuItem.Text = "Controles DB";
            controlesDBToolStripMenuItem.Visible = false;
            // 
            // facturesToolStripMenuItem
            // 
            facturesToolStripMenuItem.Name = "facturesToolStripMenuItem";
            facturesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            facturesToolStripMenuItem.Text = "Factures";
            facturesToolStripMenuItem.Click += facturesToolStripMenuItem_Click;
            // 
            // reglementsToolStripMenuItem
            // 
            reglementsToolStripMenuItem.Name = "reglementsToolStripMenuItem";
            reglementsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            reglementsToolStripMenuItem.Text = "Reglements";
            reglementsToolStripMenuItem.Click += reglementsToolStripMenuItem_Click;
            // 
            // appelDeFondToolStripMenuItem
            // 
            appelDeFondToolStripMenuItem.Name = "appelDeFondToolStripMenuItem";
            appelDeFondToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            appelDeFondToolStripMenuItem.Text = "Appel de Fond";
            appelDeFondToolStripMenuItem.Click += appelDeFondToolStripMenuItem_Click;
            // 
            // operationsReglementsToolStripMenuItem
            // 
            operationsReglementsToolStripMenuItem.Name = "operationsReglementsToolStripMenuItem";
            operationsReglementsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            operationsReglementsToolStripMenuItem.Text = "Operations Reglements";
            operationsReglementsToolStripMenuItem.Click += operationsReglementsToolStripMenuItem_Click;
            // 
            // operationsFacturesToolStripMenuItem
            // 
            operationsFacturesToolStripMenuItem.Name = "operationsFacturesToolStripMenuItem";
            operationsFacturesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            operationsFacturesToolStripMenuItem.Text = "Operations Factures";
            operationsFacturesToolStripMenuItem.Click += operationsFacturesToolStripMenuItem_Click;
            // 
            // operationsAppelDeFondToolStripMenuItem
            // 
            operationsAppelDeFondToolStripMenuItem.Name = "operationsAppelDeFondToolStripMenuItem";
            operationsAppelDeFondToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            operationsAppelDeFondToolStripMenuItem.Text = "Operations Appel de Fond";
            operationsAppelDeFondToolStripMenuItem.Click += operationsAppelDeFondToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(228, 6);
            // 
            // repareFacturesToolStripMenuItem
            // 
            repareFacturesToolStripMenuItem.Name = "repareFacturesToolStripMenuItem";
            repareFacturesToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            repareFacturesToolStripMenuItem.Text = "Répare Factures";
            repareFacturesToolStripMenuItem.Click += repareFacturesToolStripMenuItem_Click;
            // 
            // répareRéglementsToolStripMenuItem
            // 
            répareRéglementsToolStripMenuItem.Name = "répareRéglementsToolStripMenuItem";
            répareRéglementsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            répareRéglementsToolStripMenuItem.Text = "Répare Règlements";
            répareRéglementsToolStripMenuItem.Click += répareRéglementsToolStripMenuItem_Click;
            // 
            // répareOpérationReglementsToolStripMenuItem
            // 
            répareOpérationReglementsToolStripMenuItem.Name = "répareOpérationReglementsToolStripMenuItem";
            répareOpérationReglementsToolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            répareOpérationReglementsToolStripMenuItem.Text = "Répare Opération Reglements";
            répareOpérationReglementsToolStripMenuItem.Click += répareOpérationReglementsToolStripMenuItem_Click;
            // 
            // appelsDeFondsNouvelExerciceToolStripMenuItem
            // 
            appelsDeFondsNouvelExerciceToolStripMenuItem.Enabled = false;
            appelsDeFondsNouvelExerciceToolStripMenuItem.Name = "appelsDeFondsNouvelExerciceToolStripMenuItem";
            appelsDeFondsNouvelExerciceToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            appelsDeFondsNouvelExerciceToolStripMenuItem.Text = "Appels de fonds ( Nouvel exercice)";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(230, 117);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(385, 41);
            label1.TabIndex = 1;
            label1.Text = "Gestion des copropriétés ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Times New Roman", 65.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            label2.ForeColor = System.Drawing.Color.White;
            label2.Location = new System.Drawing.Point(218, 209);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(380, 98);
            label2.TabIndex = 2;
            label2.Text = "AGENCE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Times New Roman", 65.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            label3.ForeColor = System.Drawing.Color.White;
            label3.Location = new System.Drawing.Point(83, 322);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(574, 98);
            label3.TabIndex = 3;
            label3.Text = "BOURGOGNE";
            // 
            // grandLivreToolStripMenuItem
            // 
            grandLivreToolStripMenuItem.Name = "grandLivreToolStripMenuItem";
            grandLivreToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            grandLivreToolStripMenuItem.Text = "Grand Livre";
            grandLivreToolStripMenuItem.Click += GrandLivreToolStripMenuItemOnClick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Silver;
            ClientSize = new System.Drawing.Size(915, 648);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Application Syndic";
            Activated += MainForm_Activated;
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fichiersToolStripMenuItem;
        private ToolStripMenuItem immeublesToolStripMenuItem;
        private ToolStripMenuItem copropriétairesToolStripMenuItem;
        private ToolStripMenuItem fournisseursToolStripMenuItem;
        private ToolStripMenuItem naturesToolStripMenuItem;
        private ToolStripMenuItem commentairesToolStripMenuItem;
        private ToolStripMenuItem ecrituresToolStripMenuItem;
        private ToolStripMenuItem saisieToolStripMenuItem;
        private ToolStripMenuItem validationToolStripMenuItem;
        private ToolStripMenuItem reflemToolStripMenuItem;
        private ToolStripMenuItem appelDeFondsToolStripMenuItem;
        private ToolStripMenuItem appelsDeFondsNouvelExerciceToolStripMenuItem;
        private ToolStripMenuItem editionsToolStripMenuItem;
        private ToolStripMenuItem convocationsToolStripMenuItem;
        private ToolStripMenuItem additifsToolStripMenuItem;
        private ToolStripMenuItem accusésDeReceptionToolStripMenuItem;
        private ToolStripMenuItem feuillesDePrésenceToolStripMenuItem;
        private Label label1;
        private Label label2;
        private Label label3;
        private ToolStripMenuItem utilitairesToolStripMenuItem;
        private ToolStripMenuItem outilsToolStripMenuItem;
        private ToolStripMenuItem quitterToolStripMenuItem;
        private ToolStripMenuItem saisieReglementCoproproToolStripMenuItem;
        private ToolStripMenuItem parametresToolStripMenuItem;
        private ToolStripMenuItem bordereauRemiseDeChèquesToolStripMenuItem;
        private ToolStripMenuItem tableauRemiseDeClefsToolStripMenuItem;
        private ToolStripMenuItem appelDeFondDunimmeubleToolStripMenuItem;
        private ToolStripMenuItem consultationComptesPropriétairesToolStripMenuItem;
        private ToolStripMenuItem retardDePaiementsToolStripMenuItem;
        private ToolStripMenuItem transfertAppelDeFondsSurGéranceToolStripMenuItem;
        private ToolStripMenuItem bilanGénéralEtCompteExploitationToolStripMenuItem;
        private ToolStripMenuItem relevésIndividuelsToolStripMenuItem;
        private ToolStripMenuItem budgetPrévisionnelToolStripMenuItem;
        private ToolStripMenuItem relevésCommercesToolStripMenuItem;
        private ToolStripMenuItem immeublesToolStripMenuItem1;
        private ToolStripMenuItem editionEtiquettesToolStripMenuItem;
        private ToolStripMenuItem editionComptesFiscauxParImmeublesToolStripMenuItem;
        private ToolStripMenuItem balanceReglementsFacturesPourUnImmeubleToolStripMenuItem;
        private ToolStripMenuItem balanceReglementsAppelsDeFondImmeubleToolStripMenuItem;
        private ToolStripMenuItem balanceReglementsFacturesPourLeCompteSyndicToolStripMenuItem;
        private ToolStripMenuItem parametresGenerauxToolStripMenuItem;
        private ToolStripMenuItem visualisationOperationDeGestionToolStripMenuItem;
        private ToolStripMenuItem clotureExerciceToolStripMenuItem;
        private ToolStripMenuItem deconnexionToolStripMenuItem;
        private ToolStripMenuItem quitterToolStripMenuItem1;
        private ToolStripMenuItem controlesDBToolStripMenuItem;
        private ToolStripMenuItem facturesToolStripMenuItem;
        private ToolStripMenuItem reglementsToolStripMenuItem;
        private ToolStripMenuItem appelDeFondToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem repareFacturesToolStripMenuItem;
        private ToolStripMenuItem répareRéglementsToolStripMenuItem;
        private ToolStripMenuItem operationsReglementsToolStripMenuItem;
        private ToolStripMenuItem répareOpérationReglementsToolStripMenuItem;
        private ToolStripMenuItem operationsFacturesToolStripMenuItem;
        private ToolStripMenuItem operationsAppelDeFondToolStripMenuItem;
        private ToolStripMenuItem controleDesDonnéesToolStripMenuItem;
        private ToolStripMenuItem aideMenuItem;
        private ToolStripMenuItem impressionRéglementsToolStripMenuItem;
        private ToolStripMenuItem modèlesDeDocumentsToolStripMenuItem;
        private ToolStripMenuItem impressionListeFacturesToolStripMenuItem;
        private ToolStripMenuItem utilisateursToolStripMenuItem;
        private ToolStripMenuItem grandLivreToolStripMenuItem;
    }
}