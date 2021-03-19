using System.Collections.Generic;
using System.Linq;
using ZooManagement.Models.Database;
using System.Security.Cryptography;
using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ZooManagement.Data
{
    public static class SampleAnimalClasses
    {
        // public static int NumberOfUsers = 100;
        
        private static IList<AnimalClass> _animalclasses = new List<AnimalClass>
        {
            new AnimalClass ()
            {
                AnimalClassification = AnimalClassification.Mammal
            },
            new AnimalClass ()
            {
                AnimalClassification = AnimalClassification.Bird
            },
            new AnimalClass ()
            {
                AnimalClassification = AnimalClassification.Fish
            },
            new AnimalClass() 
            {
                AnimalClassification = AnimalClassification.Insect 
            },
            new AnimalClass() 
            {
                AnimalClassification = AnimalClassification.Invertebrate 
            },
            new AnimalClass() 
            {
                AnimalClassification = AnimalClassification.Reptile 
            }           
        };
       
        public static IEnumerable<AnimalClass> GetClasses()
        {
            return _animalclasses;
           
        }

       
       
    }
}