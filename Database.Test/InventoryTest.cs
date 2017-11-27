namespace Jumpgate.Database.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void GetInventory()
        {
            var jsonData =  new System.Net.WebClient().DownloadData("http://jumpgate-tri.org/jossh-api/stations-inventory.json");

            Item[] items;

            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Database.Item[]));
            using (var stream = new System.IO.MemoryStream(jsonData))
            {
                items = (Item[])serializer.ReadObject(stream);
            }

            var itemsCommodities = items.Where(i => i.GroupName.Equals("Commodities"));
            var itemsGroupedByStations = itemsCommodities.GroupBy(i => i.StationName);

            var currentStation = "Solrain Wake";
            var itemsForCurrentStation = itemsGroupedByStations.First(ig => ig.Key.Equals(currentStation));

            Item itemBest = null;
            int differenceBest = 0;
            foreach (var itemForCurrentStation in itemsForCurrentStation)
            {
                var itemsForOtherStation = itemsCommodities.Where(i => !i.StationName.Equals(currentStation) && i.Id == itemForCurrentStation.Id);
                
                var itemWithBestDifference = itemsForOtherStation.OrderByDescending(i => (int)i.Price - (int)itemForCurrentStation.Price).First();
                
                if ((int)itemWithBestDifference.Price - (int)itemForCurrentStation.Price < differenceBest) { continue; }
                itemBest = itemWithBestDifference;
                differenceBest = (int)itemWithBestDifference.Price - (int)itemForCurrentStation.Price;
            }
        }
    }
}