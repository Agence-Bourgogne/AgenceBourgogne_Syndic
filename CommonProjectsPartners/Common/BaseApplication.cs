using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CommonProjectsPartners.Entites;
using CommonProjectsPartners.Utils;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;
using Word = Microsoft.Office.Interop.Word;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace CommonProjectsPartners.Common;

public static class BaseApplication
{
    public static string schema = "";
    private static Word.Application wrdApp;
    private static Application excelApp;

    public static UserEntite userConnected = null;
    private static readonly object oMissing = Missing.Value;
    private static readonly object oFalse = false;

    public static string ComputerName => SystemInformation.ComputerName;

    public static string AuditString => $"[{ComputerName}][{userConnected.reference}]";

    private static Word.Application GetWordInstance()
    {
        wrdApp ??= new Word.Application();

        try
        {
            _ = wrdApp.Creator;
        }
        catch (Exception )
        {
            wrdApp = new Word.Application();
        }

        return wrdApp;
    }

    private static Application GetExcelInstance()
    {
        if (excelApp == null)
            excelApp = new Application();

        try
        {
            excelApp.MergeInstances = true;

        }
        catch (Exception)
        {
            excelApp = new Application
            {
                MergeInstances = true
            };
        } 
        return excelApp;
    }

    public static void DataTableToExcel(DataTable table, List<string> colsToHide)
    {
        Cursor.Current = Cursors.WaitCursor;

        var xlApp = GetExcelInstance();
        var wb = xlApp.ActiveWorkbook;
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

        var bind = new BindingSource();
        bind.DataSource = table;
        xlApp.Visible = false;
        var iCol = 1;

        foreach ( DataColumn col in table.Columns)
        {
            if (!colsToHide.Contains(col.ColumnName) )
                ws.Cells[1, iCol++] = col.ColumnName;
        }
        var iRow = 2;
        var cells = ws.Cells;
        var t = DateTime.Now.TimeOfDay;
        foreach (DataRow row in table.Rows)
        {
            var bShowRow = true;
            if (bShowRow)
            {
                iCol = 1;
                var idxCol = 0;

                foreach (DataColumn col in table.Columns)
                {
                    if (!colsToHide.Contains(col.ColumnName))
                    {
                        Range range = cells[iRow, iCol++];

                        var value = row[idxCol];
                        if (value is decimal)
                            range.Value = value;
                        else
                        if (value is DateTime time)
                            range.Value = time.ToShortDateString();
                        else
                            range.Value = value.ToString();
                    }
                    idxCol++;
                }
                iRow++;
            }
        }
        var t2 = DateTime.Now.TimeOfDay;
        var ta = t2 - t;

        Console.WriteLine(ta.TotalSeconds);

        xlApp.Visible = true;
        wb.Activate();
        ws.Activate();
        ws.Columns.AutoFit();
        Cursor.Current = Cursors.Default;
    }

    public static void DataGridToExcel(DataGridView datagrid, List<string> colsToHide, string checkColumn = "", string[] colToSum = null)
    {
        Cursor.Current = Cursors.WaitCursor;

        var xlApp = GetExcelInstance();
        var wb = xlApp.ActiveWorkbook;
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
        var iCol = 1;
        foreach (DataGridViewColumn col in datagrid.Columns)
        {
            if (!colsToHide.Contains(col.Name) && col.Visible)
            {
                ws.Cells[1, iCol++] = col.HeaderText;
            }
        }
        var iRow = 2;

        foreach (DataGridViewRow row in datagrid.Rows)
        {
            var bShowRow = true;
            if (checkColumn != "")
            {
                if (row.Cells[checkColumn].Value == null || !(bool)row.Cells[checkColumn].Value)
                    bShowRow = false;
            }
            if ( bShowRow )
            {
                iCol = 1;
                var idxCol = 0;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    var col = datagrid.Columns[idxCol];

                    if (!colsToHide.Contains(col.Name) && col.Visible)
                    {
                        Range range = ws.Cells[iRow, iCol++];
                        if (cell.Value  is  decimal)
                            range.Value = cell.Value;
                        else
                        if (cell.Value is DateTime time)
                            range.Value = "'"+time.ToShortDateString();
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
            foreach ( var colName in colToSum )
            {
                var col = datagrid.Columns[colName];
                if (col != null)
                {
                    var colChar = (char)('A' + col.Index - 1);
                    Range r = ws.Cells[iRow, col.Index];
                    r.Formula = string.Format("=SUM({0}2:{0}{1})", colChar, iRow - 1);
                }
            }
        }
            
        xlApp.Visible = true;

        wb.Activate();
        ws.Activate();
        ws.Columns.AutoFit();
        Cursor.Current = Cursors.Default;
    }

    public static void OpenWordFile(string fileName)
    {
        var wrdApp = GetWordInstance();
        try
        {
            wrdApp.Visible = true;
            wrdApp.Documents.Add(Missing.Value);
            wrdApp.Documents.Open(fileName);
            wrdApp.Activate();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private static Word.Bookmark GetField(Word.Document doc, string FieldName)
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
        var wrdApp = GetWordInstance();
        wrdApp.Visible = true;
        wrdApp.Activate();
    }
    public static string GetTempFileName(string ext)
    {
        if (!ext.StartsWith("."))
            ext = "." + ext;
        return Path.GetTempPath() + Guid.NewGuid() + ext;
    }

    public static void MergeFiles(string outputFile, List<string> files, bool bDelete = true)
    {
        var wrdApp = GetWordInstance();
        try
        {
            var doc = wrdApp.Documents.Add();
            var bFirst = true;

            foreach (var file in files)
            {
                if (File.Exists(file))
                {
                    var newDoc = wrdApp.Documents.Add(file);
                    var wrdRange = doc.Content;

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
                        var sec = wrdRange.Sections.Add();
                        sec.PageSetup.TopMargin = newDoc.PageSetup.TopMargin;
                        sec.PageSetup.BottomMargin = newDoc.PageSetup.BottomMargin;
                        sec.PageSetup.LeftMargin = newDoc.PageSetup.LeftMargin;
                        sec.PageSetup.RightMargin = newDoc.PageSetup.RightMargin;
                    }
                    doc.Words.Last.InsertFile(file);
                    newDoc.Close();
                    if (bDelete)
                        File.Delete(file);
                }
            }
            var dir = Path.GetDirectoryName(outputFile);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
            doc.SaveAs(outputFile);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public static void PublipostageLettreWordAndInsertFile(DataTable source, string modele, string DocToInsert, string FieldName, string FileResult = "")
    {
        var wrdApp = GetWordInstance();

        try
        {
            var doc = wrdApp.Documents.Add(modele);
            var merge = doc.MailMerge;

            var field = GetField(doc, FieldName);
            field?.Range.InsertFile(DocToInsert);

            var fileNameCsv = Path.GetTempPath() + Guid.NewGuid() + ".csv";
            GenerateDataSource(source, fileNameCsv);
            merge.MainDocumentType = Word.WdMailMergeMainDocType.wdFormLetters;
            merge.OpenDataSource(fileNameCsv, false);
            merge.Execute();
            merge.ViewMailMergeFieldCodes = 0;
            doc.Close(oFalse);
                
            if ( !string.IsNullOrEmpty(FileResult))
                wrdApp.ActiveDocument.SaveAs2(FileResult);
                
            wrdApp.ActiveDocument.Close(oFalse);

            File.Delete(fileNameCsv);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public static void PublipostageLettreWordAndFillTable(DataTable source, string modele, List<string[]> datas, int indexTable, string FileResult = "")
    {
        var wrdApp = GetWordInstance();

        try
        {
            var doc = wrdApp.Documents.Add(modele);
            var merge = doc.MailMerge;

            var fileName = Path.GetTempPath() + Guid.NewGuid() + ".csv";
            GenerateDataSource(source, fileName);
            merge.MainDocumentType = Word.WdMailMergeMainDocType.wdFormLetters;
            merge.OpenDataSource(fileName, false);
            merge.Execute();
            merge.ViewMailMergeFieldCodes = 0;
            doc.Close(oFalse);
            File.Delete(fileName);
            var table = wrdApp.ActiveDocument.Tables[indexTable];
            var col = 1;
            foreach (var dataColumns in datas)
            {
                var row = table.Rows.Add();
                col = 1;
                foreach (var data in dataColumns)
                {
                    row.Cells[col].Range.Text = data;
                    col++;
                }
            }
            table.Rows[2].Delete();
            {
                var row = table.Rows.Add();
                var dataRow = source.Rows[0];
                for (var i = 1; i < col - 1; i++)
                {
                    row.Cells[i].Borders[Word.WdBorderType.wdBorderBottom].LineStyle = Word.WdLineStyle.wdLineStyleNone;
                    row.Cells[i].Borders[Word.WdBorderType.wdBorderLeft].LineStyle = Word.WdLineStyle.wdLineStyleNone;
                    row.Cells[i].Borders[Word.WdBorderType.wdBorderRight].LineStyle = Word.WdLineStyle.wdLineStyleNone;
                }
                row.Cells[col - 1].Range.Text = dataRow["valeur"].ToString();
                row.Cells[col - 1].Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            }
            if (!string.IsNullOrEmpty(FileResult))
                wrdApp.ActiveDocument.SaveAs2(FileResult);

            wrdApp.ActiveDocument.Close(oFalse);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public static void PublipostageLettreWord(DataTable source, string modele)
    {
        var wrdApp = GetWordInstance();

        try
        {
            wrdApp.Visible = true;
            var docMailing = wrdApp.Documents.Add(modele);
            var merge = docMailing.MailMerge;

            var fileName = Path.GetTempPath() + Guid.NewGuid() + ".csv";
            GenerateDataSource(source, fileName);

            merge.MainDocumentType = Word.WdMailMergeMainDocType.wdFormLetters;
            merge.OpenDataSource(fileName, false);
            merge.Execute();
            merge.ViewMailMergeFieldCodes = 0;
            docMailing.Close(oFalse);
            File.Delete(fileName);
            wrdApp.Activate();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        } 
    }
    public static void PublipostageEtiquetteWord( DataTable source, string modele)
    {
        var wrdApp = GetWordInstance();
        try
        {
            var fileName = Path.GetTempPath() + Guid.NewGuid() + ".csv";
            wrdApp.Visible = true;

            var docMailing = wrdApp.Documents.Add(modele);
            var merge = docMailing.MailMerge;

            GenerateDataSource(source, fileName);
                
            merge.MainDocumentType = Word.WdMailMergeMainDocType.wdMailingLabels;
            merge.OpenDataSource(fileName, false);

            var dataSource = docMailing.MailMerge.DataSource.MappedDataFields;

            dataSource[Word.WdMappedDataFields.wdCourtesyTitle].DataFieldIndex = 1;
            dataSource[Word.WdMappedDataFields.wdLastName].DataFieldIndex = 2;
            dataSource[Word.WdMappedDataFields.wdFirstName].DataFieldIndex = 4;
            dataSource[Word.WdMappedDataFields.wdAddress1].DataFieldIndex = 5;
            dataSource[Word.WdMappedDataFields.wdPostalCode].DataFieldIndex =6;
            dataSource[Word.WdMappedDataFields.wdCity].DataFieldIndex = 7;

            docMailing.Fields.Update();

            merge.Execute();
            merge.ViewMailMergeFieldCodes = 0;
            docMailing.Close(oFalse);
            File.Delete(fileName);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);                
        } 
    }
    public static void GenerateDataSource(DataTable source, string fileName, Encoding encoding = null)
    {
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
    }

    public static void CloseOfficeInstance()
    {
        try
        {
            if (wrdApp != null)
            {
                wrdApp.Application.Quit(false);
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
                var wb = excelApp.Application.ActiveWorkbook;
                wb?.Close(false);
                excelApp.Application.Quit();
                excelApp = null;
            }
        }
        catch (Exception)
        {
        }
    }
}