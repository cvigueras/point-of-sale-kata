using System.Globalization;

namespace PointOfSale.Console;

public class BarCode
{
    public string Value { get; private set; }
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
        if (!string.IsNullOrEmpty(Value) && Value.Contains("-"))
        {
            return GetSum();
        }
        var result = Validate();
        return !string.IsNullOrEmpty(result) ? result : string.Concat("$", GetItemPrice().ToString(CultureInfo.InvariantCulture));
    }

    private double GetItemPrice()
    {
        return _barCodesPricesDictionary
            .FirstOrDefault(x => x.Key.Equals(Value)).Value;
    }

    public string? Validate()
    {
        if (string.IsNullOrEmpty(Value))
        {
            return "Error: empty barcode";
        }

        if (!ExistBarCode())
        {
            return "Error: barcode not found";
        }

        return string.Empty;
    }

    private bool ExistBarCode()
    {
        if (Value != "99999")
        {
            return true;
        }
        return false;
    }

    public string? GetSum()
    {
        if (!Value.Contains("-")) return string.Empty;
        var total = 0d;
        var barCodes = Value.Split('-');
        foreach (var item in barCodes)
        {
            Value = item;
            if (ExistBarCode())
            {
                total += GetItemPrice();
            }
        }
        return string.Concat("$", total.ToString(CultureInfo.InvariantCulture));
    }
}