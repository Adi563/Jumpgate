namespace Jumpgate.Database.Test
{
    public class Delivery
    {
        public Delivery(Item itemFrom, Item itemTo, uint amount)
        {
            From = itemFrom;
            To = itemTo;
            Amount = amount;
        }

        public Item From { get; set; }
        public Item To { get; set; }
        public uint Amount { get; set; }

        public int DifferencePerItem { get { return (int)To.Price - (int)From.Price; } }

        public long Profit { get { return DifferencePerItem * Amount; } }
    }
}