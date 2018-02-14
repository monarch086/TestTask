using System.Collections.Generic;
using POSTerminal.Domain;

namespace POSTerminal.DataLayer
{
    public class DiscountRepository : IRepository<string, Discount>
    {
        private readonly ICollection<KeyValuePair<string, Discount>> _discounts;

        public DiscountRepository()
        {
            _discounts = new Dictionary<string, Discount>
            {
                { "A", new Discount { MinimalCountNeeded = 3, DiscountedPrice = 3.00 } },
                { "C", new Discount { MinimalCountNeeded = 6, DiscountedPrice = 5.00 } }
            };
        }

        public ICollection<KeyValuePair<string, Discount>> GetAll()
        {
            return _discounts;
        }
    }
}
