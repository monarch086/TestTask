using System;
using POSTerminal.Core.Interfaces;
using POSTerminal.Core.Model;
using POSTerminal.Core.Providers;
using POSTerminal.Core.Services;

namespace POSTerminal.Core
{
    public class PointOfSaleTerminal
    {
        private readonly IProductProvider _productProvider;

        private readonly IDiscountProvider _discountProvider;

        private readonly Cart _cart;
        
        private readonly ICalculatorService _calculatorService;

        public PointOfSaleTerminal()
        {
            _productProvider = new ProductProvider();
            _discountProvider = new DiscountProvider();
            _cart = new Cart();
            _calculatorService = new CalculatorService();
        }

        public void SetPricing()
        {
            _productProvider.AddProduct(new Product { ProductCode = "A", Price = 1.25 });

            _productProvider.AddProduct(new Product { ProductCode = "B", Price = 4.25 });

            _productProvider.AddProduct(new Product { ProductCode = "C", Price = 1.00 });

            _productProvider.AddProduct(new Product { ProductCode = "D", Price = 0.75 });

            _discountProvider.AddDiscount(new Discount { ProductCode = "A", MinimalCountNeeded = 3, DiscountedPrice = 3.00 });

            _discountProvider.AddDiscount(new Discount { ProductCode = "C", MinimalCountNeeded = 6, DiscountedPrice = 5.00 });
        }

        public void Scan(string productCode)
        {
            Product product = _productProvider.GetProductByProductCode(productCode);

            if (product == null)
            {
                throw new ArgumentException($"Product {productCode} is not available");
            }

            _cart.AddProduct(product);
        }

        public double CalculateTotal()
        {
            return _calculatorService.GetTotalPrice(_cart, _discountProvider);
        }

        public void ClearOrderedProductsList()
        {
            _cart.ClearCart();
        }
    }
}
