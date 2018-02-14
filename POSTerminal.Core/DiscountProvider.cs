using POSTerminal.Core.Model;
using System.Collections.Generic;
using System.Linq;

namespace POSTerminal.Core
{
    public class DiscountProvider
    {
        private readonly IList<Discount> _discounts;

        public DiscountProvider()
        {
            _discounts = new List<Discount>();
        }

        public void AddDiscount(Discount discount)
        {
            _discounts.Add(discount);
        }

        public Discount GetDiscountByProductCode(string productCode)
        {
            return _discounts.FirstOrDefault(d => d.ProductCode == productCode);
        }
    }
}
