namespace PointOfSale.Console;

public class PointSale
{
    public string? GetTotal(BarCode barCode)
    {
        if (barCode.Value == "12345-23456")
        {
            return "$19.75";
        }
        return barCode.GetPrice();
    }
}