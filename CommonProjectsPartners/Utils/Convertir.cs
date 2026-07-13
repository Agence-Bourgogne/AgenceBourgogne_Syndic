using System;

//using System.Threading.Tasks;

namespace CommonProjectsPartners.Utils
{
    public class Convertir
    {
        public static int ToInt(Object value)
        {
            if (value == null) return 0;
            if (value.ToString() == "") return 0;
            int valeur = (int)System.Convert.ToDouble(value.ToString().Replace(".", ",").Replace("-", ""));
            if (value.ToString().Trim().StartsWith("-"))
                valeur = valeur * -1;
            return valeur;
//            return (int)System.Convert.ToDouble(value.ToString().Replace(".", ","));
        }
        public static float ToFloat(Object value)
        {
            if (value == null) return 0;
            string txtValue = value.ToString().Replace(".", ",").Replace("-", "");
            if (txtValue == "") return 0;
            float valeur = (float)System.Convert.ToDouble(txtValue);
            if (value.ToString().Trim().StartsWith("-"))
                valeur = valeur * -1;
            return valeur;
        }
        public static decimal ToDecimal(Object value)
        {
            if (value == null) return 0;
//            return (decimal)System.Convert.ToDouble(value.ToString().Replace(".", ","));
            if (value.ToString() == "") return 0;
            decimal valeur = (decimal)System.Convert.ToDouble(value.ToString().Replace(".", ",").Replace("-", ""));
            if (value.ToString().Trim().StartsWith("-"))
                valeur = valeur * -1;
            return valeur;
        }
    }
}
