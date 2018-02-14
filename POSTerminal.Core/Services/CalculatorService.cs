using System.Linq;
using POSTerminal.Core.Interfaces;
using POSTerminal.Core.Model;

namespace POSTerminal.Core.Services
{
    public class CalculatorService : ICalculatorService
    {
        public double GetTotalPrice(Cart cart, IDiscountProvider discountProvider)
        {
            var orderedProducts = cart.GetOrderedProducts();

            return orderedProducts.Sum(op => GetTotalPricePerItem(op, discountProvider.GetDiscountByProductCode(op.Product.ProductCode)));
        }

        private double GetTotalPricePerItem(OrderedProductList orderedItem, Discount discount)
        {
            if (discount == null)
            {
                return orderedItem.TotalCount * orderedItem.Product.Price;
            }

            var discountedCount = orderedItem.TotalCount - orderedItem.TotalCount % discount.MinimalCountNeeded;

            var nonDiscountedCount = orderedItem.TotalCount - discountedCount;

            return discountedCount / discount.MinimalCountNeeded * discount.DiscountedPrice +
                       nonDiscountedCount * orderedItem.Product.Price;
        }
    }
}
