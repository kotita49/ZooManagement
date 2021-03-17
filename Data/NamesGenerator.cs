using System;
using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;

namespace ZooManagement.Data
{
    public class NamesGenerator

    {
        private static Random _random = new Random();
        private static IList<IList<string>> _names = new List<IList<string>>
        {
            new List<string> { "Jozeph", "Male" },
            new List<string> { "Logan", "Male" },
            new List<string> { "Chloe", "Female" },
            new List<string> { "Nathan", "Mae" },
            new List<string> { "Benjamin", "Male" },
            new List<string> { "Amy", "Female" },
            new List<string> { "Sarah", "Female" },
            new List<string> { "Hina", "Female" },
            new List<string> { "Tatyana", "Female" },
            new List<string> { "Mark", "Male" },
            new List<string> { "Matt", "Male" },
            new List<string> { "Elise", "Female" },
            new List<string> { "Sam", "Male" },
        };

        //  public static IEnumerable<Animal> GetNames()
        // {
        //     return Enumerable.Range(0, 12).Select(CreateRandomAnimal);
        // }

        public static (string, Sex) GetNames()
        {
            var randomIndex = _random.Next(0, 12);
            var randomName = _names[randomIndex][0];
            Enum.TryParse(_names[randomIndex][1], out Sex randomNameSex);
            return (randomName, randomNameSex);
        }
    }
}