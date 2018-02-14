using System.Collections.Generic;

namespace POSTerminal.DataLayer
{
    public class ProductRepository : IRepository<string, double>
    {
        private readonly ICollection<KeyValuePair<string, double>> _products;

        public ProductRepository()
        {
            _products = new Dictionary<string, double>
            {
                { "A", 1.25 },
                { "B", 4.25 },
                { "C", 1.00 },
                { "D", 0.75 }
            };
        }

        public ICollection<KeyValuePair<string, double>> GetAll()
        {
            return _products;
        }
    }
}
