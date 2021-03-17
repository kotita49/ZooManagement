using System;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public class SpeciesGenerator
    
    {
         private static Random _random = new Random();
        public static int NumberOfSpecies = 21;
         private static IList<IList<object>> _species = new List<IList<object>>
        {
            new List<object> { "Elephant", 1 },
            new List<object> { "Tiger", 1 },
            new List<object> { "Seal", 1 },
            new List<object> { "Kakapo", 2 },
            new List<object> { "Avocet", 2 },
            new List<object> { "Barb", 3 },
            new List<object> { "Axolotl", 3 },
            new List<object> { "Clown Fish", 3 },
            new List<object> { "Bull Shark", 3 },
            new List<object> { "Tiger Butterfly", 4 },
            new List<object> { "Monarch Butterfly", 4 },
            new List<object> { "Wasp", 4 },
            new List<object> { "Mollusc", 5 },
            new List<object> { "Anteater", 1 },
            new List<object> { "Artic Fox", 1 },
            new List<object> { "Artic Hare", 1 },
            new List<object> { "Python", 6 },
            new List<object> { "Cobra", 6 },
            new List<object> { "Snapping Turtle", 6 },
            new List<object> { "Chameleon", 6 },
            new List<object> { "Crocodile", 6 },
            new List<object> { "Gecko", 6 }

        };
        //mammal = 1
        //bird = 2
        //fish = 3
        //insect = 4
        //invetebrate = 5
        //reptile = 6

        public static (string, int) GetSpecies()
        {
          // we need random number generator here between 0 and 21
            var randomIndex = _random.Next(0, 21);
            var randomSpecies = _species[randomIndex][0].ToString();
            var randomClassId = Convert.ToInt32(_species[randomIndex][1]);
            return (randomSpecies, randomClassId);
        }
        private static Animal CreateRandomAnimal()
        {
            return new Animal
            {
                AnimalName = NamesGenerator.GetNames().Item1,
                Species = GetSpecies().Item1,
                Sex = NamesGenerator.GetNames().Item2,
                DateOfBirth = DateGenerator.GetBirthDate(),
                DateAquired = DateGenerator.GetAcquiredDate(),
                AnimalClassId = GetSpecies().Item2
            };
        }

        // public static string GetSpecies(int index)
        // {
        //     return _species[index];
        // }
    }
}
