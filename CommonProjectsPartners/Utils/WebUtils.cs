using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
namespace CommonProjectsPartners.Utils
{
    public class WebUtils
    {
        public static bool DownLoadFile(string url, string file)
        {
            WebClient obj = new WebClient();
            bool rc = false;
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
