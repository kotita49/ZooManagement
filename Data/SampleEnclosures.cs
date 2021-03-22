using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using System.Security.Cryptography;
using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ZooManagement.Data
{
    public static class SampleEnclosures
    {
               
        private static IList<Enclosure> _enclosures = new List<Enclosure>
        {
            new Enclosure ()
            {
                EnclosureName = "Lion",
                MaxCapacity = 10
            },
            new Enclosure()
            {
                EnclosureName = "Aviary",
                MaxCapacity = 50
            }, 
            new Enclosure ()
            {
                EnclosureName = "Reptiles",
                MaxCapacity = 40
            },
            new Enclosure ()
            {
                EnclosureName = "Giraffe",
                MaxCapacity = 6
            },
            new Enclosure ()
            {
                EnclosureName = "Hippo",
                MaxCapacity = 10
            }
                   
        };
       
        public static IEnumerable<Enclosure> GetEnclosures()
        {
            return _enclosures;
           
        }

       
       
    }
}