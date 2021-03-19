using ZooManagement.Models.Database;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System;

namespace ZooManagement.Request
{
    public class SearchRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
       
    }
    
    public class AnimalSearchRequest : SearchRequest
    {
        public string Species {get; set; }
        public string AnimalName {get; set; }

        [JsonConverter(typeof (JsonStringEnumConverter))]
        public AnimalClassification? AnimalClass { get; set; }

        public int Age {get; set; }

        public DateTime? DateAcquired { get; set; }

        public string Order { get; set; }
        
    }

}