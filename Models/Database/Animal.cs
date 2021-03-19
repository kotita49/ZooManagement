using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ZooManagement.Models.Database
{
    public enum Sex
    {
        Male,
        Female,
    }
    public class Animal

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string Species { get; set; } //maybe move to animal class
        public List<string> SpeciesList = new List<string>();
        public Sex Sex { get; set; } // might want to do an enum
        
        public DateTime DateOfBirth { get; set; }
        public DateTime DateAcquired { get; set; }
         [ForeignKey ("AnimalClass")]
        public int AnimalClassId { get; set; }
       
        // public AnimalClassification AnimalClassification { get; set; }
        
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AnimalClass AnimalClass { get; set; }       
    }

}