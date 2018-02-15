using System;

namespace POSTerminal.ConsoleUI.Commands
{
    public class _4_ScanProduct : Command
    {
        public override string CommandCode => "4";

        public override string Description => "4 - scan product";

        public override CommandAction CommandAction => terminal =>
        {
            Console.Write("Enter product code: ");
            var productCode = Console.ReadLine();

            if (terminal.Scan(productCode))
            {
                Console.WriteLine($"Product {productCode} was scanned");
                return;
            }

            Console.WriteLine($"Product {productCode} was not found");
        };
    }
}
