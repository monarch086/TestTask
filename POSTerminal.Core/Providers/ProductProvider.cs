using System.Collections.Generic;
using POSTerminal.Core.Interfaces;
using POSTerminal.DataLayer;

namespace POSTerminal.Core.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly Dictionary<string, double> _products;

        private readonly IRepository<string, double> _productsRepository;

        public ProductProvider()
        {
            _products = new Dictionary<string, double>();
            _productsRepository = new ProductRepository();
        }

        public void PopulateProducts()
        {
            var repositoryProducts = _productsRepository.GetAll();

            foreach (var product in repositoryProducts)
            {
                _products.Add(product.Key, product.Value);
            }
        }

        public void AddProduct(string productCode, double price)
        {
            _products.Add(productCode, price);
        }

        public double GetPriceByProductCode(string productCode)
        {
            return _products[productCode];
        }

        public bool ContainsProduct(string productCode)
        {
            return _products.ContainsKey(productCode);
        }
    }
}
