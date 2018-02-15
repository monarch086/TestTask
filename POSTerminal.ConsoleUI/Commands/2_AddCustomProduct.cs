using System;
using POSTerminal.Core;
using POSTerminal.Domain;

namespace POSTerminal.ConsoleUI.Commands
{
    public class _2_AddCustomProduct : Command
    {
        private readonly PointOfSaleTerminal _terminal;

        public _2_AddCustomProduct(PointOfSaleTerminal terminal)
        {
            _terminal = terminal;
        }

        public override string CommandCode => "2";

        public override string Description => "2 - add custom product";

        public override Action CommandAction => () =>
        {
            Console.Write("Enter product code: ");
            var productCode = Console.ReadLine();

            Console.Write("Enter product price: ");
            var price = Console.ReadLine();
            double parsedPrice;
            while (!double.TryParse(price, out parsedPrice))
            {
                Console.Write("Please, enter correct value for product price: ");
                price = Console.ReadLine();
            }

            _terminal.AddCustomProduct(new Product {Code = productCode, Price = parsedPrice});
            Console.WriteLine($"New product with code {productCode} was successfully added");
        };
    }
}
