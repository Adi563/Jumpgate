namespace Jumpgate.Database
{
    using System.Linq;

    public class DatabaseHandler
    {
        private static Sector[] sectors;
        private static Gate[] gates;

        static DatabaseHandler()
        {
            var xmlStream = typeof(DatabaseHandler).Assembly.GetManifestResourceStream("Jumpgate.Database.Database.xml");

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Schema.Database));
            var database = (Schema.Database)serializer.Deserialize(xmlStream);

            sectors = database.Sectors.Select(s => new Sector { Id = s.SectorId, Name = s.Name }).ToArray();

            gates = database.Gates.Select(g => new Gate
            {
                SectorIn = sectors.First(s => s.Id == g.SectorInId),
                LeadingTo = sectors.First(s => s.Id == g.LeadingToId),
                X = (short)g.X,
                Y = (short)g.Y,
                Z = (short)g.Z,
            }).ToArray();

            uint gateId = 0;
            foreach (var gate in gates)
            { gate.Id = ++gateId; }

            foreach (var sector in sectors)
            {
                var gatesInSector = gates.Where(g => g.SectorIn.Id == sector.Id);
                sector.Gates.AddRange(gatesInSector);
            }
        }

        public static System.Collections.Generic.IEnumerable<Sector> GetSectors()
        {
            return sectors;
        }

        public static System.Collections.Generic.IEnumerable<Gate> GetGates()
        {
            return gates;
        }
    }
}