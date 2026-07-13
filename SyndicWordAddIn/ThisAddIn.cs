using System;
using System.Collections.Generic;
using SyndicData.Controller;
using SyndicData.Entites;
using SyndicData.Common;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Common;
using System.IO;
namespace SyndicWordAddIn
{
    public partial class ThisAddIn
    {
        List<string> filesName = new List<string>();
        
        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
            CommonRegistry.setCurrentApp("syndic");
        }

        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
            foreach (string file in filesName)
            {
                File.Delete(file);
            }
        }
        internal void GenerationEtiquetteImmeuble(string refImmeuble)
        {
            String modele = ParametresDB.getParam1("MODELES", "ETIQUETTES");
            BaseApplication.schema = ParametresDB.getParam1("AGENCE", "schema");
            ImmeubleEntite immeuble = ImmeubleController.getController().getEntiteFromField("reference", refImmeuble);
            if ( immeuble != null )
                BaseApplication.PublipostageEtiquetteWord(CoproprietaireController.getController().CoproprietaireImmeubleDescription(immeuble.id), modele);
        }


        #region Code généré par VSTO

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InternalStartup()
        {
            Startup += new EventHandler(ThisAddIn_Startup);
            Shutdown += new EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
