using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using EspaceSyndic.Formulaires.Immeubles;
using SyndicData.Controller;
using SyndicData.Entites;


namespace EspaceSyndic.Formulaires.Extranet
{
    public partial class PublishDocument : Form
    {
        ImmeubleEntite _immeuble = null;
        CoproprietaireEntite _copro = null;
        List<FilesList> listFiles;
        //string filename ="";
        string _copro_id = "";
        string _immeuble_id = "";
        bool dialogResult = false;
        public PublishDocument()
        {
            InitializeComponent();
            btnEnter.Width = 0;
            btnPublish.Enabled = false;
        }
        //-----  Ouverture à partir de WebUserForm avec copro préselectionné
        public PublishDocument(ImmeubleEntite immeuble, CoproprietaireEntite copro = null)
        {
            InitializeComponent();
            tbRefImmeuble.Enabled = false;
            listCopro.Enabled = false;
            btnEnter.Width = 0;
            btnPublish.Enabled = false;
            _immeuble = immeuble;
            _copro = copro;
            _copro_id = (copro != null) ? copro.id : "";
            tbRefImmeuble.Text = immeuble.reference;
            selectImmeuble(_copro_id);
        }
        //-----
        private void btnPublish_Click(object sender, EventArgs e)
        {
            if (_immeuble != null)
            {
                _immeuble_id = _immeuble.id;
                var dlg = new Impressions.RelevesIndividuels.ExportCopro();
                try
                {
                    dlg.Show(this);
                    dlg.Activate();
                    dlg.textBox1.Height = 56;

                    var index = 1;
                    foreach (DataGridViewRow item in ListFilesView.Rows)
                    {
                        var fileName = item.Cells[0].Value.ToString();
                        var title = item.Cells[1].Value.ToString();
                        dlg.textBox1.Text =
                            $"Export document {index} sur {ListFilesView.Rows.Count} \r\n{title} pour immeuble : {_immeuble.nom}";
                        dlg.textBox1.Refresh();
                        try
                        {
                            UtilsApp.ServiceReferenceUtils.SendReportPDF(fileName, title, Guid.NewGuid().ToString(), _immeuble_id, _copro_id);
                            dialogResult = true;
                        }
                        catch
                        { }
                        index++;
                    }
                    dlg.Close();
                }
                catch (Exception ex)
                {
                    dlg.Close();
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void tbRefImmeuble_DoubleClick(object sender, EventArgs e)
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
            selectImmeuble();
        }

        private void selectImmeuble(string value = "")
        {
            _immeuble = ImmeubleController.getController().getEntiteFromField("reference", tbRefImmeuble.Text);
            if (_immeuble != null)
            {
                tbRefImmeuble.BackColor = Color.White;
                btnPublish.Enabled = true;
                FillCopropriétaireList(value);
            }
            else
            {
                if (!"".Equals(tbRefImmeuble.Text))
                    tbRefImmeuble.BackColor = Color.Red;
            }
        }
        private void FillCopropriétaireList(string value = "")
        {
            listCopro.DataSource = null;
            var table = CoproprietaireController.getController().CoproprietaireImmeubleDescription(_immeuble.id);
            listCopro.DataSource = table;
            listCopro.DisplayMember = "nom";
            listCopro.ValueMember = "copro_id";
            if (!string.IsNullOrEmpty(value))
            {
                listCopro.SelectedValue = value;
            }
            else
                listCopro.SelectedIndex = -1;
        }
        private void listCopro_SelectedIndexChanged(object sender, EventArgs e)
        {
            _copro_id = (listCopro.SelectedItem != null) ? listCopro.SelectedValue.ToString() : "";
        }

        private void btnFiles_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Multiselect = true;
            dlg.Filter = "Fichiers PDF(*.pdf)|*.pdf";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FillDataGridView(dlg.FileNames);
            }
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            var result = fbd.ShowDialog();
            if (result == DialogResult.OK)
            {
                var FilterFiles = from file in System.IO.Directory.EnumerateFiles(fbd.SelectedPath)
                                 let extension = System.IO.Path.GetExtension(file)
                                 where extension.Equals(".pdf")
                                 select file;
                if(FilterFiles.Count() > 0)
                {
                    var files = FilterFiles.ToArray();
                    FillDataGridView(files);
                }
                else
                {
                    MessageBox.Show(this, "Aucun fichier PDF dans ce répertoire");
                }
            }
        }
        private void FillDataGridView(string[] files)
        {
            if(listFiles != null && listFiles.Count > 0)
            {
                var dr = MessageBox.Show("Voulez vous ajouter les fichiers?\nSi non la liste sera remplacée", "Attention", MessageBoxButtons.YesNo);
                if (dr != DialogResult.Yes)
                {
                    listFiles = new List<FilesList>();
                }
            }
            else
            {
                listFiles = new List<FilesList>();
            }
            foreach (var filename in files)
            {
                if(!listFiles.Exists(x=>x.Fichier == filename))
                {
                    var file = new FilesList();
                    file.Fichier = filename;
                    file.Titre = GetUniqueTitle(System.IO.Path.GetFileNameWithoutExtension(filename) + "_" + DateTime.Now.ToString("dd-M-yyyy"));
                    listFiles.Add(file);
                }
            }
            if (listFiles.Count > 0)
            {
                ListFilesView.DataSource = null;
                ListFilesView.DataSource = listFiles;
                ListFilesView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                ListFilesView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                ListFilesView.Columns[0].ReadOnly = true;
            }
        }
        public string GetUniqueTitle(string titre)
        {
            var titreSrc = titre;
            var newIndex = 1;
            while (listFiles.FindIndex(x => x.Titre.Equals(titre, StringComparison.OrdinalIgnoreCase)) != -1 && newIndex < 10000)
            {
                titre = titreSrc + " (" + newIndex.ToString() + ")";
                newIndex++;
            }
            return titre;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {

            var fileToDelete = new List<int>();
            foreach (DataGridViewCell oneCell in ListFilesView.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    if (!fileToDelete.Exists(x => x == oneCell.RowIndex))
                    {
                        var dRow = ListFilesView.Rows[oneCell.RowIndex];
                        var fileName = dRow.Cells[0].Value.ToString();
                        if (listFiles.Exists(x => x.Fichier == fileName))
                        {
                            fileToDelete.Add(oneCell.RowIndex);
                        }
                    }
                }
            }
            if (fileToDelete.Count > 0)
            {
                ListFilesView.DataSource = null;
                foreach (var index in fileToDelete.OrderByDescending(i => i))
                {
                    listFiles.RemoveAt(index);
                }
                if (listFiles.Count > 0)
                    ListFilesView.DataSource = listFiles;
            }
        }
        private void btnQuit_Click(object sender, EventArgs e)
        {
            DialogResult = dialogResult?DialogResult.OK:DialogResult.Cancel;
            Close();
        }

        private void PublishDocument_FormClosed(object sender, FormClosedEventArgs e)
        {
            DialogResult = dialogResult ? DialogResult.OK : DialogResult.Cancel;
            Dispose();
        }
    }
    public class FilesList
    {
        public string Fichier { get; set; }
        public string Titre { get; set; }
    }
}
