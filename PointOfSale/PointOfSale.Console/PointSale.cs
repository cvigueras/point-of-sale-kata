namespace PointOfSale.Console;

public class PointSale
{
    public static object GetTotal(string barCode)
    {
        if (string.IsNullOrEmpty(barCode))
        {
            return "Error: empty barcode";
        }
        throw new NotImplementedException();
    }
}