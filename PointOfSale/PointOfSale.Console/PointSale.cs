namespace PointOfSale.Console;

public class PointSale
{
    public string? GetTotal(BarCode barCode)
    {
        return barCode.GetPrice();
    }
}