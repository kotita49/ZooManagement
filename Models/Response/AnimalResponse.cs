using System;
using System.Text.Json.Serialization;
using ZooManagement.Models.Database;

namespace ZooManagement.Models.Response
{
    public class AnimalResponse
    {
        private readonly Animal _animal;

        public AnimalResponse(Animal animal)
        {
            _animal = animal;
        }

        public int AnimalId => _animal.AnimalId;

        public string AnimalName => _animal.AnimalName;

        public string Species => _animal.Species;

        public Sex Sex => _animal.Sex;

        public DateTime DateOfBirth => _animal.DateOfBirth;

        public DateTime DateAquired => _animal.DateAcquired;
        public int EnclosureId => _animal.EnclosureId;

        // [JsonConverter(typeof (JsonStringEnumConverter))]
        public string AnimalClass => _animal.AnimalClass.AnimalClassification.ToString();
    }
}
