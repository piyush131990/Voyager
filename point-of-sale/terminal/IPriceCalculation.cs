using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace point_of_sale.terminal
{
   public interface IPriceCalculation
    {
        decimal CalculatePrice(int itemsCount);
    }
}
