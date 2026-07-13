using System;
using System.Data;
using System.Windows.Forms;
using SyndicData.Common;
using SyndicData.Controller;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Common;
using System.IO;

namespace EspaceSyndic.Formulaires.Config
{
    public partial class ModelesDocumentsForm : Form
    {
        public ModelesDocumentsForm()
        {
            InitializeComponent();
        }

        private void ModelesDocumentsForm_Load(object sender, EventArgs e)
        {
            var groupe = ParametreController.controller.getGroupeEntite("MODELES"); 
            if ( groupe != null )
            { 
                dataGridView.DataSource = ParametreController.controller.getListFromEntiteGroupe(groupe);
                var cols = dataGridView.Columns;
                cols["id"].Visible = false;
                cols["groupe"].Visible = false;
                cols["code"].Visible = false;
                cols["nom"].Visible = false;
                cols["param_1"].Visible = false;
                cols["param_2"].Visible = false;
                cols["param_3"].Visible = false;
                cols["iparam_1"].Visible = false;
                cols["iparam_2"].Visible = false;
                cols["iparam_3"].Visible = false;
                cols["audit_created"].Visible = false;
                cols["audit_created_by"].Visible = false;
                cols["audit_updated"].Visible = false;
                cols["audit_updated_by"].Visible = false;
                var columnsDef = groupe.param_1.Split(',');
                foreach (var coldef in columnsDef)
                {
                    var paramCol = coldef.Replace(" as ", ":").Split(':');
                    var colName = paramCol[0].ToLower().Trim();
                    cols[colName].Visible = true;
                    if (paramCol.Length > 1)
                        cols[colName].HeaderText = paramCol[1];
                    else
                        cols[colName].HeaderText = colName;
                }
                ControlsWindows.ToTitleCase(cols);
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if ( dataGridView.SelectedRows.Count > 0  )
            {
                var row = (DataRowView)dataGridView.SelectedRows[0].DataBoundItem;
                if ( row != null )
                {
                    Console.WriteLine(row["param_1"].ToString());
                    BaseApplication.OpenWordFile(row["param_1"].ToString());
                }
            }

        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var serveur_modeles = ParametresDB.getParam1("PARAMETRES_DIVERS", "SERVEUR_MODELES");
                if (!serveur_modeles.EndsWith("\\"))
                    serveur_modeles += "\\";

                try
                {
                    foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
                    {
                        var row = (DataRowView)rowGrid.DataBoundItem;
                        if (row != null)
                        {
                            var fileSrc = row["param_1"].ToString();
                            var fInfoSrc = new FileInfo(fileSrc);
                            var fInfoDst = new FileInfo(serveur_modeles + fInfoSrc.Name);
                            var bWriteFile = true;
                            if (fInfoDst.LastWriteTime > fInfoSrc.LastWriteTime)
                            {
                                if (DialogResult.Yes != MessageBox.Show("Le fichier sur le serveur est plus récent que le fichier local\r\nVoulez-vous Continuer", "Attention", MessageBoxButtons.YesNo))
                                    bWriteFile = false;
                            }
                            if (bWriteFile)
                            {
                                Console.WriteLine(fInfoSrc.Name);
                                var g = Guid.NewGuid();
                                
                                File.Move(fInfoDst.FullName, fInfoDst.FullName+"."+g.ToString());
                                File.Copy(fInfoSrc.FullName, fInfoDst.FullName);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                var serveur_modeles = ParametresDB.getParam1("PARAMETRES_DIVERS", "SERVEUR_MODELES");
                if (!serveur_modeles.EndsWith("\\"))
                    serveur_modeles += "\\";

                try
                {
                    foreach (DataGridViewRow rowGrid in dataGridView.SelectedRows)
                    {
                        var row = (DataRowView)rowGrid.DataBoundItem;
                        if (row != null)
                        {
                            var fileDst = row["param_1"].ToString();
                            var fInfoDst = new FileInfo(fileDst);
                            var fInfoSrc = new FileInfo(serveur_modeles + fInfoDst.Name);
                            var bWriteFile = true;
                            if (fInfoDst.LastWriteTime > fInfoSrc.LastWriteTime)
                            {
                                if (DialogResult.Yes != MessageBox.Show("Le fichier local est plus récent que le fichier sur le serveur\r\nVoulez-vous Continuer", "Attention", MessageBoxButtons.YesNo))
                                    bWriteFile = false;
                            }
                            if (bWriteFile)
                            {
                                Console.WriteLine(fInfoSrc.Name);
                                var g = Guid.NewGuid();

                                File.Move(fInfoDst.FullName, fInfoDst.FullName + "." + g.ToString());
                                File.Copy(fInfoSrc.FullName, fInfoDst.FullName);
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
