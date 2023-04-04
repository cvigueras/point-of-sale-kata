namespace PointOfSale.Console;

public class PointSale
{
    public static object GetTotal(string barCode)
    {
        if (barCode == "")
        {
            return "Error: empty barcode";
        }
        if (barCode == null)
        {
            return "Error: empty barcode";
        }
        throw new NotImplementedException();
    }
}