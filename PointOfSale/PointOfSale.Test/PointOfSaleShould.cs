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

        [TestCase("")]
        [TestCase(null)]
        public void return_error_empty_bar_code_string_when_bar_code_is_null_or_empty(string input)
        {
            var result = _pointSale.GetTotal(BarCodeHandler.Create(input));

            result.Should().Be("Error: empty barcode");
        }

        [Test]
        public void return_cost_when_bar_code_exist()
        {
            var result = _pointSale.GetTotal(BarCodeHandler.Create("12345"));

            result.Should().Be("$7.25");
        }

        [Test]
        public void return_cost_when_bar_code_exist_with_other_bar_code()
        {
            var result = _pointSale.GetTotal(BarCodeHandler.Create("23456"));

            result.Should().Be("$12.5");
        }

        [TestCase("99999")]
        [TestCase("62727")]
        [TestCase("98171")]
        [TestCase("87134")]
        public void return_error_bar_code_not_found(string input)
        {
            var result = _pointSale.GetTotal(BarCodeHandler.Create(input));

            result.Should().Be("Error: barcode not found");
        }

        [Test]
        public void return_sum_prices_for_many_bar_codes()
        {
            var result = _pointSale.GetTotal(BarCodeHandler.Create("12345-23456"));

            result.Should().Be("$19.75");
        }

        [Test]
        public void return_sum_prices_for_many_bar_codes_with_not_existing_one()
        {
            var result = _pointSale.GetTotal(BarCodeHandler.Create("12345-23456-87654"));

            result.Should().Be("$19.75");
        }
    }
}