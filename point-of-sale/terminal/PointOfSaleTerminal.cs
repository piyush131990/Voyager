using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace point_of_sale.terminal
{
    public class PointOfSaleTerminal
    {
        private readonly Dictionary<string, Productitemcount> data;

        public PointOfSaleTerminal(IEnumerable<PointOfSaleProductmodel> products)
        {
            if(products != null && products.Select(p => p.ProductCode).Distinct().Count() == products.Count())
            {
                data = products.ToDictionary(p => p.ProductCode, p => new Productitemcount(p.PriceCalculation));
            }
            else
            {
                throw new ArgumentException("Product does not exist or already scanned!");
            }
            
        }

        public void Scanforproductcode(string productCode)
        {
            if (!data.ContainsKey(productCode))
            {
                throw new ArgumentException("Unknown product code!");
            }

            data[productCode].AddItem();
        }

        public decimal CalculateTotal()
        {
            return data.Aggregate(0.0M, (a, pr) => a + pr.Value.GetTotalPrice());
        }

    }
}