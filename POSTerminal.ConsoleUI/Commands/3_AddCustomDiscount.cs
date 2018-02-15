using System;
using POSTerminal.Domain;

namespace POSTerminal.ConsoleUI.Commands
{
    public class _3_AddCustomDiscount : Command
    {
        public override string CommandCode => "3";

        public override string Description => "3 - add custom discount";

        public override CommandAction CommandAction => terminal =>
        {
            Console.Write("Enter product code: ");
            var productCode = Console.ReadLine();

            Console.Write("Enter minimal quantity of products to use discount: ");
            var count = Console.ReadLine();
            int parsedCount;
            while (!int.TryParse(count, out parsedCount))
            {
                Console.Write("Please, enter correct value for minimal quantity of products to use discount: ");
                count = Console.ReadLine();
            }

            Console.Write("Enter discounted price: ");
            var price = Console.ReadLine();
            double parsedPrice;
            while (!double.TryParse(price, out parsedPrice))
            {
                Console.Write("Please, enter correct value for discounted price: ");
                price = Console.ReadLine();
            }

            terminal.AddCustomDiscount(new Discount
            {
                ProductCode = productCode,
                MinimalCountNeeded = parsedCount,
                DiscountedPrice = parsedPrice
            });
            Console.WriteLine($"New discount for product code {productCode} was successfully added");
        };
    }
}
