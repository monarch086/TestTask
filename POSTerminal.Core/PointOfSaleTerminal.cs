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

        public PointOfSaleTerminal()
        {
            _productProvider = new ProductProvider();
            _discountProvider = new DiscountProvider();
            _cart = new Cart();
            _calculatorService = new CalculatorService(_productProvider, _discountProvider);
        }

        public void SetPricing()
        {
            _productProvider.PopulateProducts();
            _discountProvider.PopulateDiscounts();
        }

        public void AddCustomProduct(Product product)
        {
            _productProvider.AddProduct(product);
        }

        public void AddCustomDiscount(Discount discount)
        {
            _discountProvider.AddDiscount(discount);
        }

        public bool Scan(string productCode)
        {
            if (_productProvider.ContainsProduct(productCode))
            {
                _cart.AddProduct(productCode);
                return true;
            }

            return false;
        }

        public double CalculateTotal()
        {
            return _calculatorService.GetTotalPrice(_cart);
        }

        public void ClearCart()
        {
            _cart.ClearCart();
        }
    }
}
