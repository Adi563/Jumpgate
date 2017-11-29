namespace Jumpgate.Database
{
    public class Group
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        
        public override string ToString()
        {
            return string.Format("{0}: ({1})", Id, Name);
        }

        public override bool Equals(object obj)
        {
            return Id == ((Group)obj).Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}