using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public class SpeciesGenerator
    
    {
         private static Random _random = new Random();
        public static int NumberOfSpecies = 21;
         private static IList<IList<object>> _species = new List<IList<object>>
        {
            new List<object> { "Elephant", AnimalClassification.Mammal },
            new List<object> { "Tiger", AnimalClassification.Mammal },
            new List<object> { "Seal", AnimalClassification.Mammal },
            new List<object> { "Kakapo", AnimalClassification.Bird },
            new List<object> { "Avocet", AnimalClassification.Bird },
            new List<object> { "Barb", AnimalClassification.Fish },
            new List<object> { "Axolotl", AnimalClassification.Fish },
            new List<object> { "Clown Fish", AnimalClassification.Fish },
            new List<object> { "Bull Shark", AnimalClassification.Fish },
            new List<object> { "Tiger Butterfly", AnimalClassification.Insect },
            new List<object> { "Monarch Butterfly", AnimalClassification.Insect },
            new List<object> { "Wasp", AnimalClassification.Insect },
            new List<object> { "Mollusc", AnimalClassification.Invertebrate },
            new List<object> { "Anteater", AnimalClassification.Mammal },
            new List<object> { "Artic Fox", AnimalClassification.Mammal },
            new List<object> { "Artic Hare", AnimalClassification.Mammal },
            new List<object> { "Python", AnimalClassification.Reptile },
            new List<object> { "Cobra", AnimalClassification.Reptile },
            new List<object> { "Snapping Turtle", AnimalClassification.Reptile },
            new List<object> { "Chameleon", AnimalClassification.Reptile },
            new List<object> { "Crocodile", AnimalClassification.Reptile },
            new List<object> { "Gecko", AnimalClassification.Reptile }

        };
        //mammal = 1
        //bird = 2
        //fish = 3
        //insect = 4
        //invetebrate = 5
        //reptile = 6

        public static (string, string, int) GetSpecies()
        {
          // we need random number generator here between 0 and 21
            var randomIndex = _random.Next(0, 21);
            var randomSpecies = _species[randomIndex][0].ToString();
            string randomClass = _species[randomIndex][1].ToString();
            int randomClassId = Convert.ToInt32(_species[randomIndex][1]);
            return (randomSpecies, randomClass, randomClassId);
        }
        // public static List<Animal> GetAnimals()

        // {
        //     List<Animal> listAnimals = new List<Animal>();
        //     Animal animal = CreateRandomAnimal();
        //     while(listAnimals.Count<100)
        //     {
        //         listAnimals.Add(animal);
        //     }
           
        //     return listAnimals;
        // }
        public static IEnumerable<Animal> GetAnimals()
        {
            return Enumerable.Range(0, 100).Select(CreateRandomAnimal);
        }
        public static Animal CreateRandomAnimal(int index)
        {
            return new Animal
            {
                AnimalName = NamesGenerator.GetNames().Item1,
                Species = GetSpecies().Item1,
                Sex = NamesGenerator.GetNames().Item2,
                DateOfBirth = DateGenerator.GetBirthDate(),
                DateAcquired = DateGenerator.GetAcquiredDate(),
                AnimalClassId = GetSpecies().Item3 +1,
                // AnimalClassification = (AnimalClassification)Enum.Parse(typeof(AnimalClassification), GetSpecies().Item2)
                // AnimalClassification = (AnimalClassification)Enum.Parse(typeof(AnimalClassification), GetSpecies().Item2)
                
            };
        }

        // public static string GetSpecies(int index)
        // {
        //     return _species[index];
        // }
    }
}
