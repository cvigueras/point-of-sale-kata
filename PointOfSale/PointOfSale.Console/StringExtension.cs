using System.Globalization;

namespace PointOfSale.Console
{
    public static class StringExtension
    {
        public static string FormatPrice(this double price)
        {
            return string.Concat("$", price.ToString(CultureInfo.InvariantCulture));
        }
    }
}
