namespace POSTerminal.Core.Model
{
    public class OrderedProductList
    {
        public Product Product { get; set; }

        public int TotalCount { get; set; }

        public double CalculateTotal()
        {
            if (Product.Discount != null)
            {
                var discountedCount = TotalCount - TotalCount % Product.Discount.MinimalCountNeeded;

                var nonDiscountedCount = TotalCount - discountedCount;

                return discountedCount / Product.Discount.MinimalCountNeeded * Product.Discount.DiscountedPrice +
                       nonDiscountedCount * Product.Price;
            }

            return TotalCount * Product.Price;
        }

        public OrderedProductList(Product product)
        {
            Product = product;
            TotalCount = 1;
        }
    }
}
