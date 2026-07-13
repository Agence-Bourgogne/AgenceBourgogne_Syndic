using System;
using System.IO.Compression;
using System.Windows.Forms;

namespace CommonProjectsPartners.Utils
{
    public class ZipUtils
    {
        public static bool ExtractFiles(string zipFile, string folder, string fileToFind = "")
        {
            bool rc = false;
            try
            {
                ZipArchive zip = ZipFile.OpenRead(zipFile);

                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    bool bExtract = fileToFind == "";
                    bExtract |= entry.Name.ToUpper() == fileToFind.ToUpper(); ;
                    if ( bExtract )
                        entry.ExtractToFile(folder + entry.Name, true);
                }
                rc = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return rc;
        }
    }
}
