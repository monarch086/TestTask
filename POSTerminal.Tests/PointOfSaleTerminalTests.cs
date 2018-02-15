using NUnit.Framework;
using POSTerminal.Core;

namespace POSTerminal.Tests
{
    [TestFixture]
    public class PointOfSaleTerminalTests
    {
        private PointOfSaleTerminal _terminal;
        
        [SetUp]
        public void TerminalSetUp()
        {
            _terminal = new PointOfSaleTerminal();
        }

        [TestCase("ABCDABA", 13.25)]
        [TestCase("CCCCCCC", 6.00)]
        [TestCase("ABCD", 7.25)]
        public void CalculateTotal_PassDifferentOrders_ShouldReturnActualSum(string orders, double expectedTotalPrice)
        {
            //Arrange
            foreach (var order in orders)
            {
                _terminal.Scan(order.ToString());
            }

            //Act
            var actualTotalPrice = _terminal.CalculateTotal();

            //Assert
            Assert.AreEqual(expectedTotalPrice, actualTotalPrice);
        }
    }
}