using System;
using Microsoft.Win32;

namespace CommonProjectsPartners.Utils
{
    public class CommonRegistry
    {
        private static string currentApp = "";

        public static void setCurrentApp(string strApp)
        {
            currentApp = strApp;
        }
        public static string getCurrentApp()
        {
            return currentApp;
        }
        public static object getRegistryValue(string application, string folder, string keyName, object defaultValue = null)
        {
            string strKey = String.Format("HKEY_CURRENT_USER\\SOFTWARE\\ProjectsPartners\\{0}\\{1}", application, folder);
            object obj = Registry.GetValue(strKey, keyName, defaultValue);
            return obj == null ? defaultValue : obj;
        }

        public static object getRegistryValue( string folder, string keyName, object defaultValue = null)
        {
            string strKey = String.Format("HKEY_CURRENT_USER\\SOFTWARE\\ProjectsPartners\\{0}\\{1}", currentApp, folder);
            object obj =  Registry.GetValue(strKey, keyName, defaultValue);
            return obj == null ? defaultValue : obj;
        }
        public static object getAppRegistryValue(string folder, string keyName, object defaultValue = null)
        {
            string strKey = String.Format("HKEY_CURRENT_USER\\SOFTWARE\\ProjectsPartners\\{0}\\{1}", currentApp, folder);
            object obj = Registry.GetValue(strKey, keyName, defaultValue);
            return obj == null ? defaultValue : obj;
        }
        public static void setRegistryValue(string folder, string keyName, object value)
        {
            string strKey = String.Format("HKEY_CURRENT_USER\\SOFTWARE\\ProjectsPartners\\{0}\\{1}", currentApp, folder);
            Registry.SetValue(strKey, keyName, value);
        }
        public static void setRegistryValue(string application, string folder, string keyName, object value)
        {
            string strKey = String.Format("HKEY_CURRENT_USER\\SOFTWARE\\ProjectsPartners\\{0}\\{1}", application, folder);
            Registry.SetValue(strKey, keyName, value);
        }
        public static void deleteRegistryValue(String folder, String value)
        {
            string strKey = String.Format("SOFTWARE\\ProjectsPartners\\{0}\\{1}", currentApp, folder);
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(strKey, true))
            {
                if (key != null)
                    key.DeleteValue(value);
            }
        }
        public static void deleteRegistry(String folder)
        {
            string strKey = String.Format("SOFTWARE\\ProjectsPartners\\{0}", currentApp);
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(strKey, true))
            {
                if (key != null)
                    key.DeleteSubKeyTree(folder);
            }
        }
    }
}
