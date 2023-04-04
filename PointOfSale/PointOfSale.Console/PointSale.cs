namespace PointOfSale.Console;

public class PointSale
{
    public string GetTotal(BarCodeHandler barCode)
    {
        return barCode.GetTotalPrice();
    }
}