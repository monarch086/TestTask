using System;

namespace POSTerminal.ConsoleUI.Commands
{
    class _5_ShowTotalPrice : Command
    {
        public override string CommandCode => "5";

        public override string Description => "5 - show total price";

        public override CommandAction CommandAction => terminal =>
        {
            Console.WriteLine($"Total price is {terminal.CalculateTotal()}");
        };
    }
}
