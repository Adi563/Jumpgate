using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jumpgate.Database.Test
{
    using System.Linq;

    [TestClass]
    public class DatabaseTest
    {
        [TestMethod]
        public void GetSectorsTest()
        {
            var sectors = Jumpgate.Database.DatabaseHandler.GetSectors();
        }

        [TestMethod]
        public void GetGatesTest()
        {
            var gates = Jumpgate.Database.DatabaseHandler.GetGates();
        }

        [TestMethod]
        public void GetGroupsTest()
        {
            var groups = Jumpgate.Database.DatabaseHandler.GetGroups();
        }

        [TestMethod]
        public void GetItems()
        {
            var items = Jumpgate.Database.DatabaseHandler.GetItems();
        }

        [TestMethod]
        public void GetItemStocks()
        {
            var itemStocks = Jumpgate.Database.DatabaseHandler.GetItemStocks();
        }

        [TestMethod]
        public void FindShortestPath()
        {
            var gates = DatabaseHandler.GetGates();

            var fromGate = gates.First(g => g.SectorIn.Name.Equals("Solrain Wake") && g.LeadingTo.Name.Equals("Purian Lake"));
            var toGate = gates.First(g => g.SectorIn.Name.Equals("Quantar TriPoint") && g.LeadingTo.Name.Equals("Tictac's Hook"));

            var pathes = new System.Collections.Generic.List<Jumpgate.Database.Path>();
            var pathesFromTo = new System.Collections.Generic.List<Jumpgate.Database.Path>();

            // Add pathes to other gates in sector
            foreach (var gateInSector in fromGate.SectorIn.Gates.Except(new Gate[] { fromGate }))
            {
                var path = new Path();
                path.Gates.Add(fromGate);
                path.Gates.Add(gateInSector);
                pathes.Add(path);
            }

            // Add path to gates in sector leading to
            foreach (var gateInSector in fromGate.LeadingTo.Gates.Except(new Gate[] { fromGate.LeadingTo.Gates.First(g => g.LeadingTo.Id == fromGate.SectorIn.Id) }))
            {
                var path = new Path();
                path.Gates.Add(fromGate);
                path.Gates.Add(gateInSector);
                pathes.Add(path);
            }

            while (pathes.Any())
            {
                var pathesCloned = pathes.ToArray();
                pathes.Clear();
                foreach (var path in pathesCloned)
                {
                    var lastGate = path.Gates.Last();
                    foreach (var gateLeadingTo in lastGate.LeadingTo.Gates)
                    {
                        // Prevent returns
                        if (gateLeadingTo.LeadingTo == lastGate.SectorIn)
                        { continue; }

                        // Prevent loops by sectors
                        if (path.GetSectors().Any(s => s.Id == gateLeadingTo.LeadingTo.Id))
                        { continue; }

                        //Prevent stucks
                        if (gateLeadingTo.LeadingTo.Gates.Count == 1 && gateLeadingTo.LeadingTo.Id != toGate.Id)
                        { continue; }


                        var newPath = new Path();
                        newPath.Gates.AddRange(path.Gates);
                        newPath.Gates.Add(gateLeadingTo);

                        pathes.Remove(path);
                        pathes.Add(newPath);

                        if (newPath.Gates.First().Id == fromGate.Id && newPath.Gates.Last().Id == toGate.Id)
                        { pathesFromTo.Add(newPath); }
                    }
                }
                
                if (!pathesFromTo.Any())
                { continue; }

                var pathShortestDistanceFromTo = pathesFromTo.Min(p => p.GetDistance());
                pathes.RemoveAll(p => p.GetDistance() > pathShortestDistanceFromTo);
            }
        }
    }
}