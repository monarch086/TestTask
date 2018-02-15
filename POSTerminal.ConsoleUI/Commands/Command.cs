using System;

namespace POSTerminal.ConsoleUI.Commands
{
    public class Command
    {
        public virtual string CommandCode { get; set; }

        public virtual string Description { get; set; }

        public virtual Action CommandAction { get; set; }
    }
}
