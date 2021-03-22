using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZooManagement.Repositories;
using ZooManagement.Models.Response;
using ZooManagement.Models.Request;
using ZooManagement.Request;
using ZooManagement.Models.Database;

namespace ZooManagement.Controllers
{
   
    [ApiController]
    [Route("/animals")]
     public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsRepo _animals;

        public AnimalsController(IAnimalsRepo animals) //: base(animals)
        {
            _animals = animals;
        }

        // private readonly ILogger<AnimalsController> _logger;

        // public AnimalsController(ILogger<AnimalsController> logger)
        // {
        //     _logger = logger;
        // }
        [HttpGet("{id}")]
        public ActionResult<AnimalResponse> GetById([FromRoute] int id)
        {
            var animal = _animals.GetById(id);
            return new AnimalResponse(animal);
        }
        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateAnimalRequest newAnimal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Console.WriteLine(newAnimal.EnclosureName);
        
            var enclosure = _animals.GetByEnclosureName(newAnimal.EnclosureName);
            var animal = _animals.Create(newAnimal, enclosure);
            
            var url = Url.Action("GetById", new { id = animal.AnimalId });
            var responseViewModel = new AnimalResponse(animal);

            return Created(url, responseViewModel);
        }
        [HttpGet("")]
        // public ActionResult<AnimalListResponse> Search([FromQuery] AnimalSearchRequest searchRequest)
        public ActionResult<AnimalListResponse> Search([FromQuery] AnimalSearchRequest searchRequest)

        {
            var animals = _animals.Search(searchRequest);
            var animalCount = _animals.Count(searchRequest);
            return AnimalListResponse.Create(searchRequest, animals, animalCount);
        }
        // [HttpGet("{id}/species")]
        // public ActionResult<AnimalListResponse> GetByClassId([FromRoute] int id)
        // {
        //     var speciesInClass _animals.GetByClassId(id)
        //     var responseViewModel = new AnimalListResponse(speciesInClass);
        //     return Created(Url, responseViewModel);
        // };

        [HttpGet("species")]
        public ActionResult<AnimalSpeciesResponse> GetSpecies()
        {
            var allSpecies = _animals.GetAllSpecies();
            return new AnimalSpeciesResponse(allSpecies);
        }

        
    }
}
