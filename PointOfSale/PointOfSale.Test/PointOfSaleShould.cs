using FluentAssertions;
using PointOfSale.Console;

namespace PointOfSale.Test
{
    public class PointOfSaleShould
    {
        private PointSale _pointSale;
        [SetUp]
        public void Setup()
        {
            _pointSale = new PointSale();
        }

        [Test]
        public void return_error_empty_bar_code_string_when_bar_code_is_empty()
        {
            var result = _pointSale.GetTotal(BarCode.Create(""));

            result.Should().Be("Error: empty barcode");
        }

        [Test]
        public void return_error_empty_bar_code_string_when_bar_code_is_null()
        {
            var result = _pointSale.GetTotal(BarCode.Create(null));

            result.Should().Be("Error: empty barcode");
        }

        [Test]
        public void return_cost_when_bar_code_exist()
        {
            var result = _pointSale.GetTotal(BarCode.Create("12345"));

            result.Should().Be("7,25");
        }

        [Test]
        public void return_cost_when_bar_code_exist_with_other_bar_code()
        {
            var result = _pointSale.GetTotal(BarCode.Create("23456"));

            result.Should().Be("12,5");
        }
    }
}