using System.Collections.Generic;
using POSTerminal.Domain;

namespace POSTerminal.DataLayer
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly IEnumerable<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>
            {
                new Product { Code = "A", Price = 1.25 },
                new Product { Code = "B", Price = 4.25 },
                new Product { Code = "C", Price = 1.00 },
                new Product { Code = "D", Price = 0.75 }
            };
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
    }
}
