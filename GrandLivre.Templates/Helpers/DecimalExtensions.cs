namespace GrandLivre.Templates.Helpers;

public static class DecimalExtensions
{
    public static string ToInsecableCurrency(this decimal d) 
        => d.ToString("C").Replace(" ", "\u00A0");
}