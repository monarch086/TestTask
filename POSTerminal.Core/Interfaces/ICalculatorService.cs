using POSTerminal.Core.Model;

namespace POSTerminal.Core.Interfaces
{
    public interface ICalculatorService
    {
        double GetTotalPrice(Cart cart, IDiscountProvider discountProvider);
    }
}
