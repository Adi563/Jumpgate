namespace Jumpgate.Database.Test
{
    public class Delivery
    {
        public Delivery(Item itemFrom, Item itemTo, uint amount, decimal taxRate)
        {
            From = itemFrom;
            To = itemTo;
            Amount = amount;
            TaxRate = taxRate;
        }

        public Item From { get; set; }
        public Item To { get; set; }
        public uint Amount { get; set; }
        public decimal TaxRate { get; set; }
        public uint Price { get { return (uint)(From.Price * TaxRate * Amount); } }
        public int Profit { get { return (int)(To.Price * Amount) - (int)Price; } }
    }
}