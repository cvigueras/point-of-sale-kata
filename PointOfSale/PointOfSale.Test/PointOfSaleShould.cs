using FluentAssertions;
using PointOfSale.Console;

namespace PointOfSale.Test
{
    public class PointOfSaleShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void return_error_empty_bar_code_string_when_bar_code_is_empty()
        {
            var result = PointSale.GetTotal("");

            result.Should().Be("Error: empty barcode");
        }

        [Test]
        public void return_error_empty_bar_code_string_when_bar_code_is_null()
        {
            var result = PointSale.GetTotal(null);

            result.Should().Be("Error: empty barcode");
        }
    }
}