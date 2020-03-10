using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace point_of_sale.terminal.Pricecalculation
{
    internal class MultipleProductPriceCalculation : IPriceCalculation
    {
        private readonly SingleProductPriceCalculation singlepropriceCalculator;
        private readonly decimal quantityprice;
        private readonly int quantity;

        public MultipleProductPriceCalculation(decimal singleProductPrice, int quantity, decimal quantityprice)
        {
            if(quantity > 0 && quantityprice > 0.0M)
            {
                singlepropriceCalculator = new SingleProductPriceCalculation(singleProductPrice);
                this.quantity = quantity;
                this.quantityprice = quantityprice;
            }
            else
            {
                throw new ArgumentException("Product does not exist or already scanned!");
            }

        }

        public decimal CalculatePrice(int itemsCount)
        {
            return (itemsCount / quantity) * quantityprice + singlepropriceCalculator.CalculatePrice(itemsCount % quantity);
        }
    }
}