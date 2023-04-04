namespace PointOfSale.Console
{
    public class BarCodeHandler
    {
        private readonly BarCode _barCode;
        private readonly BarCodeRepository _barCodeRepository;

        private BarCodeHandler(string value)
        {
            _barCode = BarCode.Create(value);
            _barCodeRepository = BarCodeRepository.Create();
        }

        public static BarCodeHandler Create(string value)
        {
            return new BarCodeHandler(value);
        }

        public string GetTotalPrice()
        {
            return _barCode.AreMultipleBarCodes() ? GetSum() :
                !string.IsNullOrEmpty(Validate()) ? Validate() :
                _barCodeRepository.GetItemPrice(_barCode).FormatPrice();
        }

        private string GetSum()
        {
            if (!_barCode.Value.Contains("-")) return string.Empty;
            var total = 0d;
            var barCodes = _barCode.FormatBarCodes();
            foreach (var item in barCodes)
            {
                _barCode.Value = item;
                total += GetTotalItemPrices(_barCode);
            }
            return total.FormatPrice();
        }

        private double GetTotalItemPrices(BarCode barCode)
        {
            var total = 0d;
            if (_barCodeRepository.ExistBarCode(barCode))
            {
                total += _barCodeRepository.GetItemPrice(barCode);
            }
            return total;
        }

        private string Validate() =>
            string.IsNullOrEmpty(_barCode.Value) ? "Error: empty barcode" :
            !_barCodeRepository.ExistBarCode(_barCode) ? "Error: barcode not found" : string.Empty;
    }
}