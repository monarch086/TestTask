using POSTerminal.Core.Interfaces;
using POSTerminal.Domain;
using System.Linq;

namespace POSTerminal.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IProductProvider _productProvider;

        private readonly IDiscountProvider _discountProvider;

        public CalculatorService(IProductProvider productProvider, IDiscountProvider discountProvider)
        {
            _productProvider = productProvider;
            _discountProvider = discountProvider;
        }

        public double GetTotalPrice(Cart cart)
        {
            var orderedItems = cart.GetOrderedProducts();

            return orderedItems.Sum(item => GetTotalPricePerItem(item.Key, item.Value, _discountProvider.GetDiscountByProductCode(item.Key)));
        }

        private double GetTotalPricePerItem(string productCode, int totalCount, Discount discount)
        {
            var price = _productProvider.GetProductByCode(productCode).Price;

            if (discount == null)
            {
                return totalCount * price;
            }

            var discountedCount = totalCount - totalCount % discount.MinimalCountNeeded;

            var nonDiscountedCount = totalCount - discountedCount;

            return discountedCount / discount.MinimalCountNeeded * discount.DiscountedPrice +
                       nonDiscountedCount * price;
        }
    }
}
