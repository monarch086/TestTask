using System.Collections.Generic;
using System.Linq;
using POSTerminal.Core.Interfaces;
using POSTerminal.Core.Model;

namespace POSTerminal.Core.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IList<Product> _products;

        public ProductProvider()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public Product GetProductByProductCode(string productCode)
        {
            return _products.FirstOrDefault(d => d.ProductCode == productCode);
        }
    }
}
