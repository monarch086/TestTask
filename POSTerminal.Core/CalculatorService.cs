using System.Linq;
using POSTerminal.Core.Model;

namespace POSTerminal.Core
{
    public class CalculatorService
    {
        public double GetTotalPrice(Cart cart, DiscountProvider discountProvider)
        {
            var orderedProducts = cart.GetOrderedProducts();

            return orderedProducts.Sum(op => GetTotalPricePerItem(op, discountProvider.GetDiscountByProductCode(op.Product.ProductCode)));
        }

        private double GetTotalPricePerItem(OrderedProductList orderedItem, Discount discount)
        {
            if (discount != null)
            {
                var discountedCount = orderedItem.TotalCount - orderedItem.TotalCount % discount.MinimalCountNeeded;

                var nonDiscountedCount = orderedItem.TotalCount - discountedCount;

                return discountedCount / discount.MinimalCountNeeded * discount.DiscountedPrice +
                       nonDiscountedCount * orderedItem.Product.Price;
            }

            return orderedItem.TotalCount * orderedItem.Product.Price;
        }
    }
}
