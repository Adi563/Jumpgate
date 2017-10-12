﻿using System;
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
        public void FindShortestPath()
        {
            var gates = DatabaseHandler.GetGates();

            var fromGate = gates.First(g => g.SectorIn.Id == 1);
            var toGate = gates.Last(g => g.SectorIn.Id == 100);

            var pathes = new System.Collections.Generic.List<Jumpgate.Database.Path>();
            
            foreach (var gateInSector in fromGate.SectorIn.Gates.Except(new Gate[] { fromGate }))
            {
                var path = new Path();
                path.Gates.Add(fromGate);
                path.Gates.Add(gateInSector);
                pathes.Add(path);
            }


            while (pathes.Count > 1)
            {
                var pathesCloned = pathes.Select(p => p).ToArray();
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

                        if (newPath.Gates.Last().Id == toGate.Id)
                        {
                            pathes.RemoveAll(p => p.GetDistance() > newPath.GetDistance());
                        }
                    }

                    //if (!lastGate.LeadingTo.Gates.All(g => path.GetSectors().Contains(g.LeadingTo)))
                    //{ pathes.Remove(path); }
                }
            }
        }
    }
}