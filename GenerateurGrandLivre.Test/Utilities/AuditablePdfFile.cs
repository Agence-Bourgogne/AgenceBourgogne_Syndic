using UglyToad.PdfPig;

namespace GenerateurGrandLivre.Test.Utilities;

internal class AuditablePdfFile
{
    private readonly Lazy<PdfDocument> _pdfDocument;

    public AuditablePdfFile(FileInfo fileInfo)
    {
        _pdfDocument = new Lazy<PdfDocument>(PdfDocument.Open(fileInfo.FullName));
    }

    public bool IsValidPdf
    {
        get
        {
            if (_pdfDocument.IsValueCreated) return true;

            try
            {
                _ = _pdfDocument.Value;
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}