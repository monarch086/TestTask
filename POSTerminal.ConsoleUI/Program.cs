using System;
using POSTerminal.Core;

namespace POSTerminal.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PointOfSaleTerminal terminal = new PointOfSaleTerminal();

            terminal.SetPricing();

            var orders = "ABCDABA";

            foreach (var order in orders)
            {
                terminal.Scan(order.ToString());
            }

            Console.WriteLine($"Total price for {orders} is: ${terminal.CalculateTotal()}");

            terminal.ClearOrderedProductsList();

            orders = "CCCCCCC";

            foreach (var order in orders)
            {
                terminal.Scan(order.ToString());
            }

            Console.WriteLine($"Total price for {orders} is: ${terminal.CalculateTotal()}");

            terminal.ClearOrderedProductsList();

            orders = "ABCD";

            foreach (var order in orders)
            {
                terminal.Scan(order.ToString());
            }

            Console.WriteLine($"Total price for {orders} is: ${terminal.CalculateTotal()}");
        }
    }
}
