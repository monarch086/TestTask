using POSTerminal.Core;
using System;

namespace POSTerminal.ConsoleUI.Commands
{
    class _5_ShowTotalPrice : Command
    {
        private readonly PointOfSaleTerminal _terminal;

        public _5_ShowTotalPrice(PointOfSaleTerminal terminal)
        {
            _terminal = terminal;
        }

        public override string CommandCode => "5";

        public override string Description => "5 - show total price";

        public override Action CommandAction => () =>
        {
            Console.WriteLine($"Total price is {_terminal.CalculateTotal()}");
        };
    }
}
