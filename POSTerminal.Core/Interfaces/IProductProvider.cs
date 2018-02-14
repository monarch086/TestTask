namespace POSTerminal.Core.Interfaces
{
    public interface IProductProvider
    {
        void PopulateProducts();

        void AddProduct(string productCode, double price);

        double GetPriceByProductCode(string productCode);

        bool ContainsProduct(string productCode);
    }
}
