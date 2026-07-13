using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeranceData.Common;
using CommonProjectsPartners.Utils;
using GeranceData.Controller;
namespace Gerance.Formulaires.Indices
{
    public partial class UpdateIndiceForm : Form
    {
        string refIndice;
        public UpdateIndiceForm( string refIndice )
        {
            InitializeComponent();
            this.refIndice = refIndice;
        }

        private void Log(string txt)
        {
            if (tbLog.Text == "")
                tbLog.Text = txt;
            else
                tbLog.Text += "\r\n" + txt;
            this.Update();
        }

        private void UpdateIndiceForm_Load(object sender, EventArgs e)
        {
            //string fileName = "c:\\indices\\001515333.zip";

            //WebUtils.DownLoadFile("http://www.bdm.insee.fr/bdm2/exporterSeries.action?liste_formats=txt&idbank=001515333&periode=toutes&qualite=false&request_locale=fr", fileName);
            //ZipUtils.ExtractFiles(fileName, "c:\\indices\\" , "valeurs.csv");

            //DataTable table = Database.CSV2DataTable("c:\\indices\\valeurs.csv", 2, false);

            //foreach (DataRow row in table.Rows)
            //{
            //    Console.WriteLine("{0} {1} {2}", row[0], row[1], row[2]);
            //}

        }

        private void btnMaj_Click(object sender, EventArgs e)
        {
            DataRow rowDb = ParametresDB.get("INDICES", refIndice);
            if (rowDb != null)
            {
                string path = "c:\\indices\\";
                string fileToExtract = rowDb["param_2"].ToString();
                string bank = rowDb["param_1"].ToString();
                string fileName = String.Format("{0}{1}.zip", path, bank);
                string baseUrl = "http://www.bdm.insee.fr/bdm2/exporterSeries.action?liste_formats=txt&idbank={0}&periode=toutes&qualite=false&request_locale=fr";
                string url = string.Format(baseUrl, bank);
                Log(String.Format("Telechargement Indice {0} ({1}) sur {2} ", this.refIndice, bank, fileName));

                if (WebUtils.DownLoadFile(url, fileName))
                {
                    Log("Téléchargement Réussi");
                    Log(String.Format("Décompression sur {0} de {1}", path, fileToExtract));
                    if (ZipUtils.ExtractFiles(fileName, path, fileToExtract))
                    {
                        Log("Extraction Réussie");
                        Log("Lectures des données");
                        DataTable table = Database.CSV2DataTable(path+fileToExtract, 2, false);
                        Log("Mise à jour base de données");
                        if (IndiceController.getController().updateIndices(this.refIndice, table))
                        {
                            Log("Mise à jour base de données OK");
                        }
                        else
                            Log("Mise à jour base de données Avortée");

                    }
                    else
                        Log("Extraction Avortée");
                }
                else
                    Log("Téléchargement Avorté");
            }

        }
    }
}
