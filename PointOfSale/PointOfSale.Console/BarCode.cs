namespace PointOfSale.Console;

public class BarCode
{
    public string Value { get; set; }

    private BarCode(string value)
    {
        Value = value;
    }

    public static BarCode Create(string value)
    {
        return new BarCode(value);
    }

    public string[] FormatBarCodes()
    {
        return Value.Split('-');
    }

    public bool AreMultipleBarCodes()
    {
        return !string.IsNullOrEmpty(Value) && Value.Contains("-");
    }
}