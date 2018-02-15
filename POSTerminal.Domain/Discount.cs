namespace POSTerminal.Domain
{
    public class Discount
    {
        public string ProductCode { get; set; }

        public int MinimalCountNeeded { get; set; }

        public double DiscountedPrice { get; set; }
    }
}
