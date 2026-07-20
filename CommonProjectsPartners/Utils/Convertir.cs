using System;

namespace CommonProjectsPartners.Utils;

public static class Convertir
{
    public static int ToInt(object value)
    {
        if (value == null) return 0;
        if (value.ToString() == "") return 0;
        var valeur = (int)Convert.ToDouble(value.ToString().Replace(".", ",").Replace("-", ""));
        if (value.ToString().Trim().StartsWith("-"))
            valeur *= -1;
        return valeur;
    }

    public static float ToFloat(object value)
    {
        if (value == null) return 0;
        var txtValue = value.ToString().Replace(".", ",").Replace("-", "");
        if (txtValue == "") return 0;
        var valeur = (float)Convert.ToDouble(txtValue);
        if (value.ToString().Trim().StartsWith("-"))
            valeur *= -1;
        return valeur;
    }

    public static decimal ToDecimal(object value)
    {
        if (value == null) return 0;
        if (value.ToString() == "") return 0;
        var valeur = (decimal)Convert.ToDouble(value.ToString().Replace(".", ",").Replace("-", ""));
        if (value.ToString().Trim().StartsWith("-"))
            valeur *= -1;
        return valeur;
    }
}