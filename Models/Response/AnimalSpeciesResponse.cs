// using ZooManagement.Models.Database;
using System;
using ZooManagement.Models.Database;
using System.Collections.Generic;


namespace ZooManagement.Models.Response
{
    public class AnimalSpeciesResponse
    {
        public AnimalSpeciesResponse (List<string> animalSpecies)
        {
      Species = animalSpecies;
        }
        public List<string> Species {get; set; }
          
       
    }
}