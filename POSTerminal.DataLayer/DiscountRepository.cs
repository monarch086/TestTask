using System.Collections.Generic;
using POSTerminal.Domain;

namespace POSTerminal.DataLayer
{
    public class DiscountRepository : IRepository<Discount>
    {
        private readonly IEnumerable<Discount> _discounts;

        public DiscountRepository()
        {
            _discounts = new List<Discount>
            {
                new Discount { ProductCode = "A", MinimalCountNeeded = 3, DiscountedPrice = 3.00 },
                new Discount { ProductCode = "C", MinimalCountNeeded = 6, DiscountedPrice = 5.00 }
            };
        }

        public IEnumerable<Discount> GetAll()
        {
            return _discounts;
        }
    }
}
