using System.Globalization;

namespace PointOfSale.Console;

public class BarCode
{
    public string Value { get; }
    private readonly Dictionary<string, double> _barCodesPricesDictionary;

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

    public string? GetPrice()
    {
        var result = Validate();
        if (!string.IsNullOrEmpty(result))
        {
            return result;
        }

        var price = _barCodesPricesDictionary
                                    .FirstOrDefault(x => x.Key.Equals(Value)).Value
                                    .ToString(CultureInfo.InvariantCulture);
        return string.Concat("$", price);
    }

    public string? Validate()
    {
        if (string.IsNullOrEmpty(Value))
        {
            return "Error: empty barcode";
        }

        if (Value == "99999")
        {
            return "Error: barcode not found";
        }

        return string.Empty;
    }
}