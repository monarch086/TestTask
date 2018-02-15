using POSTerminal.Domain;

namespace POSTerminal.Core.Interfaces
{
    public interface IProductProvider
    {
        void PopulateProducts();

        void AddProduct(Product product);

        Product GetProductByCode(string productCode);

        bool ContainsProduct(string productCode);
    }
}
