using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using CommonProjectsPartners.Utils;
using CommonProjectsPartners.Entites;
namespace CommonProjectsPartners.Common
{
    public class BaseApplication
    {
        public static string schema = "";
//        public static string ComputerName = "";
        private static Word.Application wrdApp = null;
        private static Microsoft.Office.Interop.Excel.Application excelApp = null;
        static List<string> filesName = new List<string>();
//        public static string modeleEtiquettes;
        public static UserEntite userConnected = null;
        static object oMissing = System.Reflection.Missing.Value;
        static object oFalse = false;
        static object oTrue = true;

        public static string ComputerName
        {
            get
            {
                return System.Windows.Forms.SystemInformation.ComputerName;
            }
        }
        public static string AuditString
        {
            get
            {
                return string.Format("[{0}][{1}]", ComputerName, userConnected.reference);
            }
        }
        public static Word.Application GetWordInstance()
        {
            if ( wrdApp == null )
                wrdApp = new Word.Application();
            try
            {
                int value = wrdApp.Creator;
            }
            catch (Exception )
            {
                wrdApp = new Word.Application();
            }

            return wrdApp;
        }
        public static Microsoft.Office.Interop.Excel.Application GetExcelInstance()
        {
            if (excelApp == null)
                excelApp = new Microsoft.Office.Interop.Excel.Application();

            try
            {
                excelApp.MergeInstances = true;

            }
            catch (Exception)
            {
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.MergeInstances = true;
            } 
            return excelApp;
        }

        public static void DataTableToExcel(System.Data.DataTable table, List<string> colsToHide)
        {
            Cursor.Current = Cursors.WaitCursor;

            Microsoft.Office.Interop.Excel.Application xlApp = BaseApplication.GetExcelInstance();
            Workbook wb = xlApp.ActiveWorkbook;
            Worksheet ws;
            if (wb == null)
            {
                wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                ws = wb.Worksheets[1];
            }
            else
            {
                Worksheet last = wb.Worksheets[wb.Worksheets.Count];
                ws = wb.Sheets.Add(oMissing, last);
            }

            BindingSource bind = new BindingSource();
            bind.DataSource = table;
            xlApp.Visible = false;
            int iCol = 1;

            foreach ( System.Data.DataColumn col in table.Columns)
            {
                if (!colsToHide.Contains(col.ColumnName) )//&& colsToHide.Contains(col.ColumnName))
                    ws.Cells[1, iCol++] = col.ColumnName;
            }
            int iRow = 2;
            Range cells = ws.Cells;
            DateTime dt = DateTime.Now;
            TimeSpan t = DateTime.Now.TimeOfDay;
            foreach (System.Data.DataRow row in table.Rows)
            {
                bool bShowRow = true;
                if (bShowRow)
                {
                    iCol = 1;
                    int idxCol = 0;
                    Range rowXls = cells[iRow];
                    foreach (System.Data.DataColumn col in table.Columns)
                    {
                        if (!colsToHide.Contains(col.ColumnName))
                        {
                            Range range = cells[iRow, iCol++];//ws.Cells[iRow, iCol++];
                            //cells[iRow, iCol++].Value = row[idxCol];
                            //range.Value = row[col.ColumnName].ToString();
//                            range.Value = row[idxCol];
                            var value = row[idxCol];
                            if (value is System.Decimal)
                                range.Value = value;
                            else
                                if (value is System.DateTime)
                                    range.Value = ((DateTime)value).ToShortDateString();
                                else
                                    range.Value = value.ToString();
                        }
                        idxCol++;
                    }
                    iRow++;
                }
            }
            TimeSpan t2 = DateTime.Now.TimeOfDay;
            TimeSpan ta = t2 - t;

            Console.WriteLine(ta.TotalSeconds);

            xlApp.Visible = true;
            ((Microsoft.Office.Interop.Excel._Workbook)wb).Activate();
            ((Microsoft.Office.Interop.Excel._Worksheet)ws).Activate();
            ws.Columns.AutoFit();
            Cursor.Current = Cursors.Default;
        }
        public static void ExcelOpenFile(string fileName)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = BaseApplication.GetExcelInstance();
            Workbook wb = xlApp.ActiveWorkbook;
            if (wb == null)
            {
                wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
//                ws = wb.Worksheets[1];
            }
            wb.MergeWorkbook(fileName);
        }
        public static object DataGridToExcel(DataGridView datagrid, List<string> colsToHide, string checkColumn = "", string [] colToSum = null)
        {
            Cursor.Current = Cursors.WaitCursor;

            Microsoft.Office.Interop.Excel.Application xlApp = BaseApplication.GetExcelInstance();
            Workbook wb = xlApp.ActiveWorkbook;
            Worksheet ws;
            if (wb == null)
            {
                wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                ws = wb.Worksheets[1];
            }
            else
            {
                Worksheet last = wb.Worksheets[wb.Worksheets.Count];
                ws = wb.Sheets.Add(oMissing, last);
            }

            xlApp.Visible = false;
            int iCol = 1;
            foreach (DataGridViewColumn col in datagrid.Columns)
            {
                if (!colsToHide.Contains(col.Name) && col.Visible)
                {
                    ws.Cells[1, iCol++] = col.HeaderText;
                }
            }
            int iRow = 2;

            foreach (DataGridViewRow row in datagrid.Rows)
            {
                bool bShowRow = true;
                if (checkColumn != "")
                {
                    if (row.Cells[checkColumn].Value == null)
                        bShowRow = false;
                    else
                        if (!(bool)row.Cells[checkColumn].Value)
                            bShowRow = false;
                }
                if ( bShowRow )
                {
                    iCol = 1;
                    int idxCol = 0;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        DataGridViewColumn col = datagrid.Columns[idxCol];

                        if (!colsToHide.Contains(col.Name) && col.Visible)
                        {
                            Range range = ws.Cells[iRow, iCol++];
                            if (cell.Value  is  System.Decimal)
                                range.Value = cell.Value;
                            else
                                if (cell.Value is System.DateTime)
                                    range.Value = "'"+((DateTime) cell.Value).ToShortDateString();
                                else
                                    range.Value = "'"+ cell.Value;
                        }
                        idxCol++;
                    }
                    iRow++;
                }
            }

            if (colToSum != null)
            {
                foreach ( string colName in colToSum )
                {
                    DataGridViewColumn col = datagrid.Columns[colName];
                    if (col != null)
                    {
                        char colChar = (char)((int)'A' + col.Index - 1);
                        Range r = ws.Cells[iRow, col.Index];
                        r.Formula = String.Format("=SUM({0}2:{0}{1})", colChar, iRow - 1);
                    }
                }
            }
            
            xlApp.Visible = true;

            ((Microsoft.Office.Interop.Excel._Workbook)wb).Activate();
            ((Microsoft.Office.Interop.Excel._Worksheet)ws).Activate();
            ws.Columns.AutoFit();
            Cursor.Current = Cursors.Default;
            return ws;
        }
        public static void ColumnFormula(object wsObject, int colDesti , string colFormula, string colName, int colStop)
        {
            Microsoft.Office.Interop.Excel._Worksheet ws = ((Microsoft.Office.Interop.Excel._Worksheet)wsObject);
            try
            {
                Range range = ws.Rows;
                int nbRows = range.Rows.Count;

                ws.Cells[1, colDesti].Value = colName;
                for (int iRow = 2; iRow < nbRows; iRow++)
                {
                    Range cell = ws.Cells[iRow, colStop];
                    if (cell.Value == null)
                        break;
                    char colChar = (char)((int)'A' + colDesti);
                    cell = ws.Cells[iRow, colDesti];
                    string formula = String.Format(colFormula, iRow, colChar );
                    cell.Formula = formula;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void OpenWordFile(string fileName)
        {
            Word.Application wrdApp = BaseApplication.GetWordInstance();
            try
            {
                wrdApp.Visible = true;
                Word.Document doc = wrdApp.Documents.Add(System.Reflection.Missing.Value);
                wrdApp.Documents.Open(fileName);
                wrdApp.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        static Word.Bookmark GetField(Word.Document doc, String FieldName)
        {
            foreach (Word.Bookmark field in doc.Bookmarks)
            {
                if ( field.Name == FieldName)
                    return field;
            }
            return null;
        }

        public static void ActivateWord()
        {
            Word.Application wrdApp = BaseApplication.GetWordInstance();
            wrdApp.Visible = true;
            wrdApp.Activate();
        }
        public static String GetTempFileName(string ext)
        {
            if (!ext.StartsWith("."))
                ext = "." + ext;
            return System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ext;
        }
        public static void InsertFileEnd(String docName, String DocToInsert)
        {
            Word.Application wrdApp = BaseApplication.GetWordInstance();
            try
            {
                string FileTemp = GetTempFileName(Path.GetExtension(docName));
                Word.Document doc = wrdApp.Documents.Add(docName);
                doc.Words.Last.InsertFile(DocToInsert);
                ((Microsoft.Office.Interop.Word._Document)doc).SaveAs2(FileTemp);
                ((Microsoft.Office.Interop.Word._Document)doc).Close();

                File.Copy(FileTemp, docName, true);
                File.Delete(FileTemp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void MergeFiles(string outputFile, List<String> files, bool bDelete = true)
        {
            Word.Application wrdApp = BaseApplication.GetWordInstance();
            try
            {
                Word.Document doc = wrdApp.Documents.Add();
                Word.Selection sel = wrdApp.Selection;
                bool bFirst = true;

                foreach (String file in files)
                {
                    if (File.Exists(file))
                    {
                        Word.Document newDoc = wrdApp.Documents.Add(file);
                        Word.Range wrdRange = doc.Content;

                        Word.Section sec;
                        if (bFirst)
                        {
                            wrdRange.PageSetup.TopMargin = newDoc.PageSetup.TopMargin;
                            wrdRange.PageSetup.BottomMargin = newDoc.PageSetup.BottomMargin;
                            wrdRange.PageSetup.LeftMargin = newDoc.PageSetup.LeftMargin;
                            wrdRange.PageSetup.RightMargin = newDoc.PageSetup.RightMargin;
                            bFirst = false;
                        }
                        else
                        {
                            sec = wrdRange.Sections.Add();
                            sec.PageSetup.TopMargin = newDoc.PageSetup.TopMargin;
                            sec.PageSetup.BottomMargin = newDoc.PageSetup.BottomMargin;
                            sec.PageSetup.LeftMargin = newDoc.PageSetup.LeftMargin;
                            sec.PageSetup.RightMargin = newDoc.PageSetup.RightMargin;
                        }
                        doc.Words.Last.InsertFile(file);
                        ((Microsoft.Office.Interop.Word._Document)newDoc).Close();
                        if (bDelete)
                            File.Delete(file);
                    }
                }
                string dir = Path.GetDirectoryName(outputFile);
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                doc.SaveAs(outputFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void PublipostageLettreWordAndInsertFile(System.Data.DataTable source, string modele, String DocToInsert, String FieldName, String FileResult = "")
        {
            Word.Application wrdApp = BaseApplication.GetWordInstance();

            try
            {
                Word.Document doc = wrdApp.Documents.Add(modele);
                Word.MailMerge merge = doc.MailMerge;

                Word.Bookmark field = GetField(doc, FieldName);
                if (field != null)
                {
                    field.Range.InsertFile(DocToInsert);
                }

                string fileNameCsv = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";
                GenerateDataSource(source, fileNameCsv);
                merge.MainDocumentType = Word.WdMailMergeMainDocType.wdFormLetters;
                merge.OpenDataSource(fileNameCsv, false);
                merge.Execute();
                merge.ViewMailMergeFieldCodes = 0;
                ((Microsoft.Office.Interop.Word._Document)doc).Close(oFalse);
                
                if ( !String.IsNullOrEmpty(FileResult))
                    wrdApp.ActiveDocument.SaveAs2(FileResult);
                
                ((Microsoft.Office.Interop.Word._Document)wrdApp.ActiveDocument).Close(oFalse);

                File.Delete(fileNameCsv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void PublipostageLettreWordAndFillTable(System.Data.DataTable source, string modele, List<String[]> datas, int indexTable, String FileResult = "")
        {
            Word.Application wrdApp = BaseApplication.GetWordInstance();

            try
            {
                Word.Document doc = wrdApp.Documents.Add(modele);
                Word.MailMerge merge = doc.MailMerge;

                string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";
                GenerateDataSource(source, fileName);
                merge.MainDocumentType = Word.WdMailMergeMainDocType.wdFormLetters;
                merge.OpenDataSource(fileName, false);
                merge.Execute();
                merge.ViewMailMergeFieldCodes = 0;
                ((Microsoft.Office.Interop.Word._Document)doc).Close(oFalse);
                File.Delete(fileName);
                Word.Table table = wrdApp.ActiveDocument.Tables[indexTable];
                int col = 1;
                foreach (String[] dataColumns in datas)
                {
                    Word.Row row = table.Rows.Add();
                    col = 1;
                    foreach (String data in dataColumns)
                    {
                        row.Cells[col].Range.Text = data;
                        col++;
                    }
                }
                table.Rows[2].Delete();
                {
                    Word.Row row = table.Rows.Add();
                    System.Data.DataRow dataRow = source.Rows[0];
                    for (int i = 1; i < col - 1; i++)
                    {
                        row.Cells[i].Borders[Word.WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleNone;
                        row.Cells[i].Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleNone;
                        row.Cells[i].Borders[Word.WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleNone;
                    }
                    row.Cells[col - 1].Range.Text = dataRow["valeur"].ToString();
                    row.Cells[col - 1].Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                }
                if (!String.IsNullOrEmpty(FileResult))
                    wrdApp.ActiveDocument.SaveAs2(FileResult);

                ((Microsoft.Office.Interop.Word._Document)wrdApp.ActiveDocument).Close(oFalse);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void PublipostageLettreWord(System.Data.DataTable source, string modele)
        {
            Word.Application wrdApp = BaseApplication.GetWordInstance();

            try
            {
                wrdApp.Visible = true;
                Word.Document docMailing = wrdApp.Documents.Add(modele);
                Word.MailMerge merge = docMailing.MailMerge;

                string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";
                GenerateDataSource(source, fileName);

                merge.MainDocumentType = Word.WdMailMergeMainDocType.wdFormLetters;
                merge.OpenDataSource(fileName, false);
                merge.Execute();
                merge.ViewMailMergeFieldCodes = 0;
                ((Microsoft.Office.Interop.Word._Document)docMailing).Close(oFalse);
                File.Delete(fileName);
                wrdApp.Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
        public static void PublipostageEtiquetteWord( System.Data.DataTable source, string modele)
        {
            Word.Application wrdApp = BaseApplication.GetWordInstance();
            try
            {
                string fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".csv";
                wrdApp.Visible = true;

                Word.Document docMailing = wrdApp.Documents.Add(modele);
                Word.MailMerge merge = docMailing.MailMerge;

            
                //                string fileName = @"c:\syndic_modeles\csv\etiquettes.csv";

                GenerateDataSource(source, fileName);
                
                merge.MainDocumentType = Word.WdMailMergeMainDocType.wdMailingLabels;
                merge.OpenDataSource(fileName, false);

                //-----------------------------------
                //// Obtenir la source de données
              
                // Obtenir la source de données
                var dataSource = docMailing.MailMerge.DataSource.MappedDataFields;

            //    // Définir les mappages souhaités
            //    var fieldMappings = new Dictionary<string, string>
            //{
            //    {"Nom", "NOM"},
            //    {"Prénom", "PRENOM"},
            //    {"Adresse1", "ADRESSE"},
            //    {"CodePostal", "CP"},
            //    {"Ville", "VILLE"},
            //    {"Pays", "PAYS"}
            //};
                dataSource[Word.WdMappedDataFields.wdCourtesyTitle].DataFieldIndex = 1;
                dataSource[Word.WdMappedDataFields.wdLastName].DataFieldIndex = 2;
                dataSource[Word.WdMappedDataFields.wdFirstName].DataFieldIndex = 4;
                dataSource[Word.WdMappedDataFields.wdAddress1].DataFieldIndex = 5;
                dataSource[Word.WdMappedDataFields.wdPostalCode].DataFieldIndex =6;
                dataSource[Word.WdMappedDataFields.wdCity].DataFieldIndex = 7;

                // Mettre à jour tous les champs du document
                docMailing.Fields.Update();

                // Sauvegarder les modifications
               // docMailing.Save();


                //------------------------------------


                merge.Execute();
                merge.ViewMailMergeFieldCodes = 0;
                ((Microsoft.Office.Interop.Word._Document)docMailing).Close(oFalse);
                File.Delete(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            } 

        }
        public static bool GenerateDataSource(System.Data.DataTable source, string fileName, Encoding encoding = null)
        {
            bool retValue = false;
            try
            {
                if (source != null)
                {
                    TextWriter file;
                    if (encoding != null)
                        file = new StreamWriter(fileName, false, encoding);
                    else
                        file = new StreamWriter(fileName);
                    Database.SerializeCSV(source, file);
                    file.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return retValue;
        }

        public static void CloseOfficeInstance()
        {
            try
            {
                if (wrdApp != null)
                {
                    ((Microsoft.Office.Interop.Word._Application)wrdApp.Application).Quit(false);
                    wrdApp = null;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (excelApp != null)
                {
                    Workbook wb = excelApp.Application.ActiveWorkbook;
                    if (wb != null)
                        wb.Close(false);
                    excelApp.Application.Quit();
                    excelApp = null;
                }
            }
            catch (Exception)
            {
            }

            foreach (string file in filesName)
            {
                if ( File.Exists(file))
                    File.Delete(file);
            }

        }
    }
}
