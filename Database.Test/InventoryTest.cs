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
            //var jsonData =  new System.Net.WebClient().DownloadData("http://jumpgate-tri.org/jossh-api/stations-inventory.json");
            var streamJson = this.GetType().Assembly.GetManifestResourceStream("Database.Test.stations-inventory.json");
            var jsonData = new byte[streamJson.Length];
            streamJson.Read(jsonData, 0, jsonData.Length);
            Item[] items;

            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Jumpgate.Database.Test.Item[]));
            using (var stream = new System.IO.MemoryStream(jsonData))
            {
                items = (Item[])serializer.ReadObject(stream);
            }

            var itemsCommodities = items.Where(i => i.GroupName.Equals("Commodities"));
            var itemsGroupedByStations = itemsCommodities.GroupBy(i => i.StationName);

            ushort cargoSpace = 500;
            decimal taxRate = 1.0088836385115180153573538098051m;

            var itemsForCurrentStation = itemsCommodities;
            var itemsForOtherStations = itemsCommodities;

            var deliveries = itemsForCurrentStation.SelectMany(
                itemForCurrentStation => itemsForOtherStations.Where(itemForOtherStation => itemForCurrentStation.Id == itemForOtherStation.Id && !itemForCurrentStation.StationName.Equals(itemForOtherStation.StationName)).Select(itemForOtherStation => new Delivery(itemForCurrentStation, itemForOtherStation, Math.Min(cargoSpace, itemForCurrentStation.Amount), taxRate)));

            var deliveriesOrderedByPrice = deliveries.OrderByDescending(delivery => delivery.Profit);

            foreach (var delivery in deliveriesOrderedByPrice)
            {
                System.Diagnostics.Debug.WriteLine($"Item: {delivery.To.Name} ({delivery.Amount}) ({delivery.From.StationName} -> {delivery.To.StationName}) - Profit: {delivery.Profit}");
            }
        }
    }
}