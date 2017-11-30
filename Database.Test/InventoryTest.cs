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

            ushort cargoSpace = 499;
            decimal taxRate = 1.0092938888m;
            decimal taxRateRounded = Math.Round(taxRate, 4);

            var itemsForCurrentStation = itemsCommodities.Where(i => i.StationName.Equals("Solrain Wake"));
            var itemsForOtherStations = itemsCommodities;

            var deliveries = itemsForCurrentStation.SelectMany(
                itemForCurrentStation => itemsForOtherStations.Where(itemForOtherStation => itemForCurrentStation.Id == itemForOtherStation.Id && !itemForCurrentStation.StationName.Equals(itemForOtherStation.StationName)).Select(itemForOtherStation => new Delivery(itemForCurrentStation, itemForOtherStation, Math.Min(cargoSpace, itemForCurrentStation.Amount), taxRateRounded)));

            var deliveriesOrderedByPrice = deliveries.OrderByDescending(delivery => delivery.Profit);

            System.Diagnostics.Debug.WriteLine("Name\tAmount\tPrice\tFromStationName\tToStationName\tProfit");

            foreach (var delivery in deliveriesOrderedByPrice.Where(d => d.Profit > 0))
            {
                //System.Diagnostics.Debug.WriteLine($"Item: {delivery.To.Name} ({delivery.Amount}) ({delivery.From.StationName} -> {delivery.To.StationName}) - Profit: {delivery.Profit}");
                System.Diagnostics.Debug.WriteLine($"{delivery.To.Name}\t{delivery.Amount}\t{delivery.Price}\t{delivery.From.StationName}\t{delivery.To.StationName}\t{delivery.Profit}");
            }
        }

        [TestMethod]
        public void GetTaxPercentByPoliticalRatingTest()
        {
            var tax = GetTaxPercentByPoliticalRating(75);
        }

        private static decimal GetTaxPercentByPoliticalRating(sbyte politicalRating)
        {
            return -0.02m * politicalRating + 2;
        }
    }
}