namespace Jumpgate.Database
{
    public class Item
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public Group Group { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: ({1})", Id, Name);
        }

        public override bool Equals(object obj)
        {
            return Id == ((Item)obj).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}