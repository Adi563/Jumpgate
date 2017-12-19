namespace Jumpgate.Database.Test
{
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class InventoryTest
    {
        [TestMethod]
        public void GetDeliveries()
        {
            var items = GetInventory();

            var itemsForCurrentStation = FilterItems(items, "Solrain Wake");
            var itemsForOtherStations = FilterItems(items, "Quantar Core");

            var deliveriesOrderedByProfit = GetDeliveriesOrderedByProfit(itemsForCurrentStation, itemsForOtherStations, 749, 1.0092938888m);

            System.Diagnostics.Debug.WriteLine("Name\tAmount\tPrice\tFromStationName\tToStationName\tProfit");

            foreach (var delivery in deliveriesOrderedByProfit.Where(d => d.Profit > 0))
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


        /// <summary>
        /// Filters the items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <param name="stationName">Name of the station.</param>
        /// <returns></returns>
        private static System.Collections.Generic.IEnumerable<Item> FilterItems(System.Collections.Generic.IEnumerable<Item> items, string stationName)
        {
            return items.Where(i => i.GroupName.Equals("Commodities")).Where(i => i.StationName.Equals(stationName));
        }


        /// <summary>
        /// Filters the items.
        /// </summary>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        private static System.Collections.Generic.IEnumerable<Item> FilterItems(System.Collections.Generic.IEnumerable<Item> items)
        {
            return items.Where(i => i.GroupName.Equals("Commodities"));
        }


        /// <summary>
        /// Gets the deliveries ordered by profit.
        /// </summary>
        /// <param name="itemsForCurrentStation">The items for current station.</param>
        /// <param name="itemsForOtherStations">The items for other stations.</param>
        /// <param name="cargoSpace">The cargo space.</param>
        /// <param name="taxRate">The tax rate.</param>
        /// <returns></returns>
        private static System.Collections.Generic.IEnumerable<Delivery> GetDeliveriesOrderedByProfit(System.Collections.Generic.IEnumerable<Item> itemsForCurrentStation, System.Collections.Generic.IEnumerable<Item> itemsForOtherStations, ushort cargoSpace, decimal taxRate)
        {
            decimal taxRateRounded = Math.Round(taxRate, 4);
            
            var deliveries = itemsForCurrentStation.SelectMany(
                itemForCurrentStation => itemsForOtherStations.Where(itemForOtherStation => itemForCurrentStation.Id == itemForOtherStation.Id && !itemForCurrentStation.StationName.Equals(itemForOtherStation.StationName)).Select(itemForOtherStation => new Delivery(itemForCurrentStation, itemForOtherStation, Math.Min(cargoSpace, itemForCurrentStation.Amount), taxRateRounded)));

            var deliveriesOrderedByProfit = deliveries.OrderByDescending(delivery => delivery.Profit);

            return deliveriesOrderedByProfit;
        }


        /// <summary>
        /// Gets the inventory.
        /// </summary>
        /// <returns></returns>
        private static System.Collections.Generic.IEnumerable<Item> GetInventory()
        {
            var jsonData = new System.Net.WebClient().DownloadData("http://jumpgate-tri.org/jossh-api/stations-inventory.json");
            //var streamJson = typeof(InventoryTest).Assembly.GetManifestResourceStream("Database.Test.stations-inventory.json");
            //var jsonData = new byte[streamJson.Length];
            //streamJson.Read(jsonData, 0, jsonData.Length);
            Item[] items;

            var serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(Jumpgate.Database.Test.Item[]));
            using (var stream = new System.IO.MemoryStream(jsonData))
            {
                items = (Item[])serializer.ReadObject(stream);
            }

            return items;
        }


        /// <summary>
        /// Gets the tax percent by political rating.
        /// </summary>
        /// <param name="politicalRating">The political rating.</param>
        /// <returns></returns>
        private static decimal GetTaxPercentByPoliticalRating(sbyte politicalRating)
        {
            return -0.02m * politicalRating + 2;
        }
    }
}