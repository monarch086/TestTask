using System;
using System.Collections.Generic;
using System.Linq;
using POSTerminal.Core.Model;

namespace POSTerminal.Core
{
    public class PointOfSaleTerminal
    {
        private readonly IList<OrderedProductList> _orderedProducts;

        private readonly IList<Product> _availableProducts;

        public PointOfSaleTerminal()
        {
            _orderedProducts = new List<OrderedProductList>();
            _availableProducts = new List<Product>();
        }

        public void SetPricing()
        {
            _availableProducts.Add(new Product { Name = "A", Price = 1.25,
                Discount = new Discount { MinimalCountNeeded = 3, DiscountedPrice = 3.00 } });

            _availableProducts.Add(new Product { Name = "B", Price = 4.25 });

            _availableProducts.Add(new Product { Name = "C", Price = 1.00,
                Discount = new Discount { MinimalCountNeeded = 6, DiscountedPrice = 5.00 } });

            _availableProducts.Add(new Product { Name = "D", Price = 0.75 });
        }

        public void Scan(string productName)
        {
            var orderedProduct = _orderedProducts.FirstOrDefault(op => op.Product.Name == productName);

            if (orderedProduct != null)
            {
                orderedProduct.TotalCount++;
                return;
            }

            var product = _availableProducts.FirstOrDefault(p => p.Name == productName);

            if (product == null)
            {
                throw new ArgumentException($"Product {productName} is not available");
            }

            _orderedProducts.Add(new OrderedProductList(product));
        }

        public double CalculateTotal()
        {
            return _orderedProducts.Sum(op => op.CalculateTotal());
        }

        public void ClearOrderedProductsList()
        {
            _orderedProducts.Clear();
        }
    }
}
