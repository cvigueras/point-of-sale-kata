namespace PointOfSale.Console;

public class PointSale
{
    public string? GetTotal(BarCode barCode)
    {
        if (string.IsNullOrEmpty(barCode.Value))
        {
            return "Error: empty barcode";
        }
        return barCode.GetPrice().ToString();

    }
}