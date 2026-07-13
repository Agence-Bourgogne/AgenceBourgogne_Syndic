using System;
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
            Update();
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
            var rowDb = ParametresDB.get("INDICES", refIndice);
            if (rowDb != null)
            {
                var path = "c:\\indices\\";
                var fileToExtract = rowDb["param_2"].ToString();
                var bank = rowDb["param_1"].ToString();
                var fileName = $"{path}{bank}.zip";
                var baseUrl = "http://www.bdm.insee.fr/bdm2/exporterSeries.action?liste_formats=txt&idbank={0}&periode=toutes&qualite=false&request_locale=fr";
                var url = string.Format(baseUrl, bank);
                Log($"Telechargement Indice {refIndice} ({bank}) sur {fileName} ");

                if (WebUtils.DownLoadFile(url, fileName))
                {
                    Log("Téléchargement Réussi");
                    Log($"Décompression sur {path} de {fileToExtract}");
                    if (ZipUtils.ExtractFiles(fileName, path, fileToExtract))
                    {
                        Log("Extraction Réussie");
                        Log("Lectures des données");
                        var table = Database.CSV2DataTable(path+fileToExtract, 2, false);
                        Log("Mise à jour base de données");
                        if (IndiceController.getController().updateIndices(refIndice, table))
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
