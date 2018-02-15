using POSTerminal.Core;
using System;

namespace POSTerminal.ConsoleUI.Commands
{
    public class _6_ClearCart : Command
    {
        private readonly PointOfSaleTerminal _terminal;

        public _6_ClearCart(PointOfSaleTerminal terminal)
        {
            _terminal = terminal;
        }

        public override string CommandCode => "6";

        public override string Description => "6 - clear cart";

        public override Action CommandAction => () =>
        {
            _terminal.ClearCart();
            Console.WriteLine("Cart is clear");
        };
    }
}
