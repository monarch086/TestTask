using POSTerminal.Domain;

namespace POSTerminal.Core.Interfaces
{
    public interface ICalculatorService
    {
        double GetTotalPrice(Cart cart);
    }
}
