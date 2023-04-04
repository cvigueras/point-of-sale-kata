namespace PointOfSale.Console;

public class BarCode
{
    public string Value { get; }
    private Dictionary<string, double> _barCodesPricesDictionary;

    private BarCode(string value)
    {
        _barCodesPricesDictionary = new Dictionary<string, double>
        {
            {"12345",7.25d},
            {"23456",12.50d},

        };
        Value = value;
    }

    public static BarCode Create(string value)
    {
        return new BarCode(value);
    }

    public double? GetPrice()
    {
        return _barCodesPricesDictionary.FirstOrDefault(x => x.Key.Equals(Value)).Value;
    }
}