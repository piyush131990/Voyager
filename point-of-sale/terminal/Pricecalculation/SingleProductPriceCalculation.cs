using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace point_of_sale.terminal.Pricecalculation
{
    internal class SingleProductPriceCalculation : IPriceCalculation
    {
        private decimal singleproductprice;
        public SingleProductPriceCalculation(decimal singleproductprice )
        {
            if(singleproductprice > 0.0M)
            {
                this.singleproductprice = singleproductprice;
            }
             else
            {
                throw new ArgumentException("Product price is out of range!");
            }


        }
        public decimal CalculatePrice(int itemcount)
        {
            return singleproductprice * itemcount;
        }

    }
}
