namespace PointOfSale.Console;

public class BarCodeRepository
{
    public Dictionary<string, double> Values { get; }

    private BarCodeRepository()
    {
        Values = new Dictionary<string, double>
        {
            { "12345", 7.25d },
            { "23456", 12.50d },
        };
    }

    public static BarCodeRepository Create()
    {
        return new BarCodeRepository();
    }

    public double GetItemPrice(BarCode barCode)
    {
        return Values
            .FirstOrDefault(x => x.Key.Equals(barCode.Value)).Value;
    }

    public bool ExistBarCode(BarCode barCode)
    {
        return GetItemPrice(barCode) != 0;
    }
}