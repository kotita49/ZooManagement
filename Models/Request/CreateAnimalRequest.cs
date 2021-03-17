using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ZooManagement.Models.Database;

namespace ZooManagement.Models.Request
{
    public class CreateAnimalRequest
    {
        [Required]
        public string AnimalName { get; set; }
        
        [Required]
        public string Species { get; set; }
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AnimalClassification AnimalClass { get; set; }
        
        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        
        public Sex Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
      
        public DateTime DateAquired { get; set; }
    }
}