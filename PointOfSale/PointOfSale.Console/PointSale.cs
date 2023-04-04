namespace PointOfSale.Console;

public class PointSale
{
    public static object GetTotal(string barCode)
    {
        if (string.IsNullOrEmpty(barCode))
        {
            return "Error: empty barcode";
        }

        if (barCode == "12345")
        {
            return "$7.25";
        }
        throw new NotImplementedException();
    }
}