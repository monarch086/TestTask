using POSTerminal.Core.Model;

namespace POSTerminal.Core.Interfaces
{
    public interface IProductProvider
    {
        void AddProduct(Product product);

        Product GetProductByProductCode(string productCode);
    }
}
