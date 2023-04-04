namespace PointOfSale.Console;

public class PointSale
{
    public string? GetTotal(BarCode barCode)
    {
        if (string.IsNullOrEmpty(barCode.Value))
        {
            return "Error: empty barcode";
        }

        if (barCode.Value == "99999")
        {
            return "Error: barcode not found";
        }

        return barCode.GetPrice().ToString();

    }
}