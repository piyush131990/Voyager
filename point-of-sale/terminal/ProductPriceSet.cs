using point_of_sale.terminal.Pricecalculation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace point_of_sale.terminal
{
    public class ProductPriceSet
    {
        private readonly List<PointOfSaleProductmodel> products = new List<PointOfSaleProductmodel>();

        public ProductPriceSet AddProduct(string productCode, decimal singleProductPrice)
        {
            AttachPricetoProduct(productCode, new SingleProductPriceCalculation(singleProductPrice));
            return this;
        }

        public ProductPriceSet AddProduct(string productCode, decimal singleProductPrice, int quantity, decimal quantityprice)
        {
            AttachPricetoProduct(productCode, new MultipleProductPriceCalculation(singleProductPrice, quantity, quantityprice));
            return this;
        }

        public PointOfSaleProductmodel[] GetAllProducts()
        {
            return products.ToArray();
        }

        private void AttachPricetoProduct(string productCode, IPriceCalculation priceCalculator)
        {
            products.Add(new PointOfSaleProductmodel(productCode, priceCalculator));
        }
    }
}