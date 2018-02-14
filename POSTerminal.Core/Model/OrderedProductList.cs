namespace POSTerminal.Core.Model
{
    public class OrderedProductList
    {
        public Product Product { get; set; }

        public int TotalCount { get; set; }

        public OrderedProductList(Product product)
        {
            Product = product;
            TotalCount = 1;
        }
    }
}
