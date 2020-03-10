using System;
using point_of_sale.terminal;
using System.Collections.Generic;
using NUnit.Framework;

namespace point_of_sale.Tests.terminal
{
    [TestFixture]
    public class PointOfSaleTerminalTest
    {
        double Delta = 1e-2;

        [TestCase("ABCDABA", 13.25)]
        [TestCase("CCCCCCC", 6.0)]
        [TestCase("ABCD", 7.25)]
        public void getproductcode_price(string productCode, decimal totalprice)
        {
            var terminal = new PointOfSaleTerminal(
                new ProductPriceSet()
                    .AddProduct("A", 1.25M, 3, 3.0M)
                    .AddProduct("B", 4.25M)
                    .AddProduct("C", 1.0M, 6, 5.0M)
                    .AddProduct("D", 0.75M)
                    .GetAllProducts());

            ScanStringAsChars(terminal, productCode);

            AssertDecimalEquals(totalprice, terminal.CalculateTotal());
        }

        [Test]
        public void ScanNonExistingProduct_WithEmptyPricesSet_ExceptionThrown()
        {
            var terminal = new PointOfSaleTerminal(new PointOfSaleProductmodel[0]);

            Assert.Throws(typeof(ArgumentException), () => terminal.Scanforproductcode("A"));
        }

        private void ScanStringAsChars(PointOfSaleTerminal terminal, string productCodes)
        {
            foreach (char ch in productCodes)
            {
                terminal.Scanforproductcode(ch.ToString());
            }
        }
        private void AssertDecimalEquals(decimal expected, decimal actual)
        {
            Assert.AreEqual((double)expected, (double)actual, Delta);
        }
    }
}
