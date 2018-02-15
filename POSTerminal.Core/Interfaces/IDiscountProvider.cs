using POSTerminal.Domain;

namespace POSTerminal.Core.Interfaces
{
    public interface IDiscountProvider
    {
        void AddDiscount(Discount discount);

        Discount GetDiscountByProductCode(string productCode);
    }
}
