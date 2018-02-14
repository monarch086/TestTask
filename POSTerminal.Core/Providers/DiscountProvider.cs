using POSTerminal.Core.Interfaces;
using POSTerminal.DataLayer;
using POSTerminal.Domain;
using System.Collections.Generic;

namespace POSTerminal.Core.Providers
{
    public class DiscountProvider : IDiscountProvider
    {
        private readonly Dictionary<string, Discount> _discounts;

        private readonly IRepository<string, Discount> _discountsRepository;

        public DiscountProvider()
        {
            _discounts = new Dictionary<string, Discount>();
            _discountsRepository = new DiscountRepository();
        }

        public void PopulateDiscounts()
        {
            var repositoryDiscounts = _discountsRepository.GetAll();

            foreach (var discount in repositoryDiscounts)
            {
                _discounts.Add(discount.Key, discount.Value);
            }
        }

        public void AddDiscount(string productCode, Discount discount)
        {
            _discounts.Add(productCode, discount);
        }

        public Discount GetDiscountByProductCode(string productCode)
        {
            if (_discounts.ContainsKey(productCode))
            {
                return _discounts[productCode];
            }

            return null;
        }
    }
}
