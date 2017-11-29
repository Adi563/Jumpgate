﻿namespace Jumpgate.Database.Test
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

        public decimal DifferencePerItem { get { return To.Price - From.Price * TaxRate; } }

        public long Profit { get { return (long)(DifferencePerItem) * Amount; } }
    }
}