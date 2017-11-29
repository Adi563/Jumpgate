namespace Jumpgate.Database
{
    public class ItemStock
    {
        public Item Item { get; set; }
        public string StationName { get; set; }
        public uint BasePrice { get; set; }
        public uint Amount { get; set; }

        public override string ToString()
        {
            return string.Format("{0}(1): {2}({3})", Item.Name, StationName, BasePrice, Amount);
        }

        public override bool Equals(object obj)
        {
            return Item.Id == ((ItemStock)obj).Item.Id && StationName.Equals(((ItemStock)obj).StationName);
        }

        public override int GetHashCode()
        {
            return Item.Id.GetHashCode() ^ StationName.GetHashCode();
        }
    }
}