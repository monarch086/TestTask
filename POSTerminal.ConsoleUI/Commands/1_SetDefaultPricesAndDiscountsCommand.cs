using System;
using POSTerminal.Core;

namespace POSTerminal.ConsoleUI.Commands
{
    class _1_SetPricing : Command
    {
        private readonly PointOfSaleTerminal _terminal;

        public _1_SetPricing(PointOfSaleTerminal terminal)
        {
            _terminal = terminal;
        }

        public override string CommandCode => "1";

        public override string Description => "1 - set new price for available product";

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

            if (_terminal.SetPricing(productCode, parsedPrice))
            {
                Console.WriteLine($"Price of product with code {productCode} was successfully set to {parsedPrice}");
                return;
            }

            Console.WriteLine($"Product with code {productCode} was not found");
        };
    }
}
