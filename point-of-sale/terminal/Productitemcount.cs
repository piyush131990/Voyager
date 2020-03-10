using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace point_of_sale.terminal
{
    public class Productitemcount
    {
        private readonly IPriceCalculation priceCalculation;
        private int itemsCount = 0;

        public Productitemcount(IPriceCalculation priceCalculation)
        {
            this.priceCalculation = priceCalculation;
        }

        public void AddItem()
        {
            itemsCount++;
        }

        public decimal GetTotalPrice()
        {
            return priceCalculation.CalculatePrice(itemsCount);
        }
    }
}