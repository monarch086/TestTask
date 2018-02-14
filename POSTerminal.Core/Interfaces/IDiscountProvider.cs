using POSTerminal.Domain;

namespace POSTerminal.Core.Interfaces
{
    public interface IDiscountProvider
    {
        void PopulateDiscounts();

        void AddDiscount(string productCode, Discount discount);

        Discount GetDiscountByProductCode(string productCode);
    }
}
