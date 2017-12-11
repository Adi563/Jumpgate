namespace Jumpgate.Database
{
    using System.Linq;

    public class DatabaseHandler
    {
        private static Sector[] sectors;
        private static Gate[] gates;
        private static Group[] groups;
        private static Item[] items;
        private static ItemStock[] itemStocks;

        static DatabaseHandler()
        {
            var xmlStream = typeof(DatabaseHandler).Assembly.GetManifestResourceStream("Jumpgate.Database.Database.xml");

            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Schema.Database));
            var database = (Schema.Database)serializer.Deserialize(xmlStream);

            // Load sectors
            sectors = database.Sectors.Select(s => new Sector { Id = s.SectorId, Name = s.Name }).ToArray();

            // Load gates
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

            // Load groups
            groups = database.Groups != null ? database.Groups.Select(g => new Group { Id = g.GroupId, Name = g.Name }).ToArray() : new Group[0];

            //Load items
            items = database.Items != null ? database.Items.Select(i => new Item { Id = i.ItemId, Name = i.Name, Group = groups.First(g => g.Id == i.GroupId) }).ToArray() : new Item[0];

            //Load item stocks
            itemStocks = database.ItemStocks != null ? database.ItemStocks.Select(itemStock => new ItemStock { Item = items.First(i => i.Id == itemStock.ItemId), StationName = itemStock.StationName, BasePrice = itemStock.BasePrice, Amount = itemStock.Amount } ).ToArray() : new ItemStock[0];
        }

        public static System.Collections.Generic.IEnumerable<Sector> GetSectors()
        {
            return sectors;
        }

        public static System.Collections.Generic.IEnumerable<Gate> GetGates()
        {
            return gates;
        }

        public static System.Collections.Generic.IEnumerable<Group> GetGroups()
        {
            return groups;
        }

        public static System.Collections.Generic.IEnumerable<Item> GetItems()
        {
            return items;
        }

        public static System.Collections.Generic.IEnumerable<ItemStock> GetItemStocks()
        {
            return itemStocks;
        }

        public static void InsertGroup(uint groupId, string name)
        {
            using (var xmlStream = new System.IO.FileStream(@"C:\Projects\Jumpgate\Database\Database.xml", System.IO.FileMode.Open))
            {
                var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Schema.Database));
                var database = (Schema.Database)serializer.Deserialize(xmlStream);

                var newGroups = new Schema.Group[] { new Schema.Group { GroupId = groupId, Name = name } };
                database.Groups = database.Groups == null ? newGroups : database.Groups.Union(newGroups).ToArray();

                xmlStream.Seek(0, System.IO.SeekOrigin.Begin);

                serializer.Serialize(xmlStream, database);
            }
        }
    }
}