using Microsoft.Win32;

namespace CommonProjectsPartners.Utils;

public static class CommonRegistry
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
        var strKey = $"HKEY_CURRENT_USER\\SOFTWARE\\ProjectsPartners\\{application}\\{folder}";
        var obj = Registry.GetValue(strKey, keyName, defaultValue);
        return obj == null ? defaultValue : obj;
    }

    public static object getRegistryValue( string folder, string keyName, object defaultValue = null)
    {
        var strKey = $"HKEY_CURRENT_USER\\SOFTWARE\\ProjectsPartners\\{currentApp}\\{folder}";
        var obj =  Registry.GetValue(strKey, keyName, defaultValue);
        return obj == null ? defaultValue : obj;
    }
    public static object getAppRegistryValue(string folder, string keyName, object defaultValue = null)
    {
        var strKey = $"HKEY_CURRENT_USER\\SOFTWARE\\ProjectsPartners\\{currentApp}\\{folder}";
        var obj = Registry.GetValue(strKey, keyName, defaultValue);
        return obj == null ? defaultValue : obj;
    }
    public static void setRegistryValue(string folder, string keyName, object value)
    {
        var strKey = $"HKEY_CURRENT_USER\\SOFTWARE\\ProjectsPartners\\{currentApp}\\{folder}";
        Registry.SetValue(strKey, keyName, value);
    }
    public static void setRegistryValue(string application, string folder, string keyName, object value)
    {
        var strKey = $"HKEY_CURRENT_USER\\SOFTWARE\\ProjectsPartners\\{application}\\{folder}";
        Registry.SetValue(strKey, keyName, value);
    }

    public static void deleteRegistry(string folder)
    {
        var strKey = $"SOFTWARE\\ProjectsPartners\\{currentApp}";
        using var key = Registry.CurrentUser.OpenSubKey(strKey, true);
        key?.DeleteSubKeyTree(folder);
    }
}