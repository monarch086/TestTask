using System;

namespace POSTerminal.ConsoleUI.Commands
{
    class _1_SetDefaultPricesAndDiscountsCommand : Command
    {
        public override string CommandCode => "1";

        public override string Description => "1 - load default products and discounts";

        public override CommandAction CommandAction => terminal =>
        {
            terminal.SetPricing();
            Console.WriteLine("Default products and discounts have been loaded");
        };
    }
}
