namespace Jumpgate.Database
{
    public class Gate
    {
        public uint Id { get; set; }
        public Sector SectorIn { get; set; }
        public Sector LeadingTo { get; set; }

        public short X { get; set; }
        public short Y { get; set; }
        public short Z { get; set; }

        public override string ToString()
        {
            return string.Format("{0}({1})", SectorIn, LeadingTo);
        }

        public override bool Equals(object obj)
        {
            return Id == ((Gate)obj).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}