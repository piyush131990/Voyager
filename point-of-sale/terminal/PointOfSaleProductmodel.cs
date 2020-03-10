using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace point_of_sale.terminal
{
    public class PointOfSaleProductmodel
    {
        public PointOfSaleProductmodel(string productCode, IPriceCalculation priceCalculation)
        {
            ProductCode = productCode;
            PriceCalculation = priceCalculation;
        }

        public string ProductCode { get; private set; }

        public IPriceCalculation PriceCalculation { get; private set; }
    }
}