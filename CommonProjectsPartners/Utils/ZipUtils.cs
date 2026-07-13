using System;
using System.IO.Compression;
using System.Windows.Forms;

namespace CommonProjectsPartners.Utils
{
    public class ZipUtils
    {
        public static bool ExtractFiles(string zipFile, string folder, string fileToFind = "")
        {
            var rc = false;
            try
            {
                var zip = ZipFile.OpenRead(zipFile);

                foreach (var entry in zip.Entries)
                {
                    var bExtract = fileToFind == "";
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
