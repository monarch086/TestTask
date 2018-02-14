using System.Collections.Generic;

namespace POSTerminal.Model
{
    public class Cart
    {
        private readonly Dictionary<string, int> _orderedItems;

        public Cart()
        {
            _orderedItems = new Dictionary<string, int>();
        }

        public void AddProduct(string productCode)
        {
            if (_orderedItems.ContainsKey(productCode))
            {
                _orderedItems[productCode]++;
                return;
            }

            _orderedItems.Add(productCode, 1);
        }

        public Dictionary<string, int> GetOrderedProducts()
        {
            return _orderedItems;
        }

        public void ClearCart()
        {
            _orderedItems.Clear();
        }
    }
}
