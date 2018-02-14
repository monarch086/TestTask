using System.Collections.Generic;
using System.Linq;

namespace POSTerminal.Core.Model
{
    public class Cart
    {
        private readonly IList<OrderedProductList> _orderedProducts;

        public Cart()
        {
            _orderedProducts = new List<OrderedProductList>();
        }

        public void AddProduct(Product product)
        {
            var orderedProduct = _orderedProducts.FirstOrDefault(op => op.Product.ProductCode == product.ProductCode);

            if (orderedProduct != null)
            {
                orderedProduct.TotalCount++;
                return;
            }

            _orderedProducts.Add(new OrderedProductList(product));
        }

        public IList<OrderedProductList> GetOrderedProducts()
        {
            return _orderedProducts;
        }

        public void ClearCart()
        {
            _orderedProducts.Clear();
        }
    }
}
