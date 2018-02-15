using POSTerminal.Core;

namespace POSTerminal.ConsoleUI.Commands
{
    public delegate void CommandAction(PointOfSaleTerminal terminal);

    public class Command
    {
        public virtual string CommandCode { get; set; }

        public virtual string Description { get; set; }

        public virtual CommandAction CommandAction { get; set; }
    }
}
