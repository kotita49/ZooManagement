using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using System.Security.Cryptography;
using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ZooManagement.Data
{
    public static class SampleZookeepers

    {
        // private static Random _random = new Random();
        public static IEnumerable<Zookeeper> GetZookeepers(ZooManagementDbContext context)
        {
            IList<Zookeeper> _zookeepers = new List<Zookeeper>()
            {
                new Zookeeper()
                {
                    ZookeeperName = "Odry",
                    Enclosures = new List<Enclosure>()
                    {
                        context.Enclosures.Single(enclosure => enclosure.EnclosureId == 1),
                        context.Enclosures.Single(enclosure => enclosure.EnclosureId == 2)
                    }
                },
                new Zookeeper()
                {
                    ZookeeperName = "Mary",
                    Enclosures = new List<Enclosure>()
                    {
                        context.Enclosures.Single(enclosure => enclosure.EnclosureId == 2),
                        context.Enclosures.Single(enclosure => enclosure.EnclosureId == 4)
                    }
                },
                new Zookeeper()
                {
                    ZookeeperName = "Tom",
                    Enclosures = new List<Enclosure>()
                    {
                        context.Enclosures.Single(enclosure => enclosure.EnclosureId == 3),
                        context.Enclosures.Single(enclosure => enclosure.EnclosureId == 2)
                    }
                },
                new Zookeeper()
                {
                    ZookeeperName = "Rufus",
                    Enclosures = new List<Enclosure>()
                    {
                        context.Enclosures.Single(enclosure => enclosure.EnclosureId == 4),
                        context.Enclosures.Single(enclosure => enclosure.EnclosureId == 3)
                    }
                },
                new Zookeeper()
                {
                    ZookeeperName = "Holly",
                    Enclosures = new List<Enclosure>()
                    {
                        context.Enclosures.Single(enclosure => enclosure.EnclosureId == 5),
                        context.Enclosures.Single(enclosure => enclosure.EnclosureId == 4)
                    }
                }
               
            };
            return _zookeepers;
            
        }
       
    }
}