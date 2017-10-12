namespace Jumpgate.Database
{
    using System.Linq;

    public class Sector
    {
        public Sector()
        {
            Gates = new System.Collections.Generic.List<Gate>();
        }

        public uint Id { get; set; }

        public string Name { get; set; }

        public System.Collections.Generic.List<Gate> Gates { get; }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            return Id == ((Sector)obj).Id;
        }

        public static decimal GetDistance(Gate gate1, Gate gate2)
        {
            //if (!Gates.Any(g => g.Id == gate1.Id) || !Gates.Any(g => g.Id == gate2.Id))
            //{ throw new System.Exception("Gates not in sector"); }

            return (decimal)System.Math.Sqrt(System.Math.Pow(gate1.X - gate2.X, 2) + System.Math.Pow(gate1.Y - gate2.Y, 2) + System.Math.Pow(gate1.Z - gate2.Z, 2));
        }
    }
}