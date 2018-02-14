using POSTerminal.Core.Interfaces;
using POSTerminal.Core.Providers;
using POSTerminal.Core.Services;
using POSTerminal.DataLayer;
using POSTerminal.Domain;
using System;

namespace POSTerminal.Core
{
    public class PointOfSaleTerminal
    {
        private readonly IProductProvider _productProvider;

        private readonly IDiscountProvider _discountProvider;

        private readonly Cart _cart;
        
        private readonly ICalculatorService _calculatorService;

        private readonly IRepository<string, Discount> _discounts;

        

        public PointOfSaleTerminal()
        {
            _productProvider = new ProductProvider();
            _discountProvider = new DiscountProvider();
            _cart = new Cart();
            _calculatorService = new CalculatorService(_productProvider, _discountProvider);
        }

        public void SetPricing()
        {
            //_productProvider.AddProduct("A", 1.25);

            //_productProvider.AddProduct("B", 4.25);

            //_productProvider.AddProduct("C", 1.00);

            //_productProvider.AddProduct("D", 0.75);

            //_discountProvider.AddDiscount("A", new Discount { MinimalCountNeeded = 3, DiscountedPrice = 3.00 });

            //_discountProvider.AddDiscount("C", new Discount { MinimalCountNeeded = 6, DiscountedPrice = 5.00 });
            _productProvider.PopulateProducts();
            _discountProvider.PopulateDiscounts();
        }

        public void Scan(string productCode)
        {
            if (_productProvider.ContainsProduct(productCode))
            {
                _cart.AddProduct(productCode);
                return;
            }

            throw new ArgumentException($"Product {productCode} is not available");
        }

        public double CalculateTotal()
        {
            return _calculatorService.GetTotalPrice(_cart);
        }

        public void ClearOrderedProductsList()
        {
            _cart.ClearCart();
        }
    }
}
