using System;
using System.Net;
using System.Windows.Forms;
namespace CommonProjectsPartners.Utils
{
    public class WebUtils
    {
        public static bool DownLoadFile(string url, string file)
        {
            var obj = new WebClient();
            var rc = false;
            try
            {
                obj.DownloadFile(url, file);
                rc = true;
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.Message);                
            }
            return rc;
        }
    }
}
