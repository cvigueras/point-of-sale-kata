namespace PointOfSale.Console;

public class PointSale
{
    public string? GetTotal(BarCode barCode)
    {
        return string.IsNullOrEmpty(barCode.Value) ? "Error: empty barcode" : barCode.GetPrice().ToString();
    }
}