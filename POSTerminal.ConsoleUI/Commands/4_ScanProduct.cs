using POSTerminal.Core;
using System;

namespace POSTerminal.ConsoleUI.Commands
{
    public class _4_ScanProduct : Command
    {
        private readonly PointOfSaleTerminal _terminal;

        public _4_ScanProduct(PointOfSaleTerminal terminal)
        {
            _terminal = terminal;
        }

        public override string CommandCode => "4";

        public override string Description => "4 - scan product";

        public override Action CommandAction => () =>
        {
            Console.Write("Enter product code: ");
            var productCode = Console.ReadLine();

            if (_terminal.Scan(productCode))
            {
                Console.WriteLine($"Product {productCode} was scanned");
                return;
            }

            Console.WriteLine($"Product {productCode} was not found");
        };
    }
}
