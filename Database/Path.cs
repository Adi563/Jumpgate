namespace Jumpgate.Database
{
    using System.Linq;

    public  class Path
    {
        public Path()
        {
            Gates = new System.Collections.Generic.List<Gate>();
        }

        public System.Collections.Generic.List<Gate> Gates { get; set; }

        public System.Collections.Generic.IEnumerable<Sector> GetSectors()
        {
            return Gates.Select(g => g.SectorIn).Distinct();
        }

        public decimal GetDistance()
        {
            decimal distance = 0;
            for (int i = 0; i < Gates.Count-1; i++)
            {
                distance += Sector.GetDistance(Gates[i], Gates[i + 1]);
            }
            return distance;
        }

        public override string ToString()
        {
            return $"{GetDistance()}: {string.Join(" -> ", Gates)}";
        }
    }
}