using System;

namespace POSTerminal.ConsoleUI.Commands
{
    public class _6_ClearCart : Command
    {
        public override string CommandCode => "6";

        public override string Description => "6 - clear cart";

        public override CommandAction CommandAction => terminal =>
        {
            terminal.ClearCart();
            Console.WriteLine("Cart is clear");
        };
    }
}
