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

            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Database.Item[]));
            using (var stream = new System.IO.MemoryStream(jsonData))
            {
                items = (Item[])serializer.ReadObject(stream);
            }

            var itemsCommodities = items.Where(i => i.GroupName.Equals("Commodities"));
            var itemsGroupedByStations = itemsCommodities.GroupBy(i => i.StationName);

            var currentStation = "Solrain Wake";
            ushort cargoSpace = 500;

            var itemsForCurrentStation = itemsGroupedByStations.First(ig => ig.Key.Equals(currentStation));
            var itemsForOtherStations = itemsGroupedByStations.Where(ig => !ig.Key.Equals(currentStation)).SelectMany(i => i);

            var itemsOrderedByPriceDifference = itemsForOtherStations.OrderByDescending(itemForOtherStation =>
            {
                var itemForCurrentStation = itemsForCurrentStation.First(i => i.Id == itemForOtherStation.Id);
                
                return Math.Min(itemForCurrentStation.Amount, cargoSpace) * ((int)itemForOtherStation.Price - (int)itemForCurrentStation.Price);
            });

            foreach (var itemForOtherStation in itemsOrderedByPriceDifference)
            {
                var itemForCurrentStation = itemsForCurrentStation.First(i => i.Id == itemForOtherStation.Id);

                System.Diagnostics.Debug.WriteLine($"Item: {itemForCurrentStation.Name} ({itemForCurrentStation.Amount}) -> {itemForOtherStation.StationName} - Difference: {(int)itemForOtherStation.Price - (int)itemForCurrentStation.Price} - Profit: {Math.Min(itemForCurrentStation.Amount, cargoSpace) * ((int)itemForOtherStation.Price - (int)itemForCurrentStation.Price)}");
            }
        }
    }
}