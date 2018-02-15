using System;
using System.Collections.Generic;
using System.Linq;
using POSTerminal.ConsoleUI.Commands;
using POSTerminal.Core;

namespace POSTerminal.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PointOfSaleTerminal terminal = new PointOfSaleTerminal();
            IEnumerable<Command> commands = new List<Command>
            {
                new _1_SetDefaultPricesAndDiscountsCommand(),
                new _2_AddCustomProduct(),
                new _3_AddCustomDiscount(),
                new _4_ScanProduct(),
                new _5_ShowTotalPrice(),
                new _6_ClearCart()
            };
            
            Console.WriteLine("Welcome to Point-Of-Sale Terminal!");

            string commandCode = "";

            while (commandCode != "q")
            {
                Console.WriteLine("\nEnter one of the following commands or \"q\" to quit:");

                foreach (var command in commands)
                {
                    Console.WriteLine(command.Description);
                }

                commandCode = Console.ReadLine();

                commands.FirstOrDefault(c => c.CommandCode == commandCode)?.CommandAction(terminal);
            }
        }
    }
}
