using System.Collections.Generic;
using POSTerminal.Core.Interfaces;
using POSTerminal.DataLayer;
using POSTerminal.Domain;

namespace POSTerminal.Core.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly Dictionary<string, Product> _products;

        private readonly IRepository<Product> _productsRepository;

        public ProductProvider()
        {
            _products = new Dictionary<string, Product>();
            _productsRepository = new ProductRepository();
        }

        public void PopulateProducts()
        {
            var repositoryProducts = _productsRepository.GetAll();

            foreach (var product in repositoryProducts)
            {
                _products.Add(product.Code, product);
            }
        }

        public void AddProduct(Product product)
        {
            _products.Add(product.Code, product);
        }

        public Product GetProductByCode(string productCode)
        {
            return _products[productCode];
        }

        public bool ContainsProduct(string productCode)
        {
            return _products.ContainsKey(productCode);
        }
    }
}
