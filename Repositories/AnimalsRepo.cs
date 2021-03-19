using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ZooManagement.Models.Request;
using ZooManagement.Models.Database;
using System.Text.Json;
using ZooManagement.Request;
using System.Data;


namespace ZooManagement.Repositories
{
    public interface IAnimalsRepo
    {
        Animal GetById(int id);
        Animal GetByAnimalName(string animalName);
        Animal Create(CreateAnimalRequest newAnimal);
        List<string> GetAllSpecies();
     
        void Delete(int id); 
        IEnumerable<Animal> Search(AnimalSearchRequest searchRequest);
        int Count(AnimalSearchRequest searchRequest);
       
    }
    
    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
        }
        
        
        public IEnumerable<Animal> Search(AnimalSearchRequest searchRequest)
        {
            IQueryable<Animal> query = _context.Animals;
                               
            if (!string.IsNullOrEmpty(searchRequest.Species))
            {
                query = query.Where(e => e.Species.ToLower().Contains(searchRequest.Species.ToLower()));
                            
            }
            if(!string.IsNullOrEmpty(searchRequest.AnimalName))
            {
                query = query.Where(e => e.AnimalName.ToLower().Contains(searchRequest.AnimalName.ToLower()));
            }
            
            if(searchRequest.AnimalClass != null)
            {
                query=query.Where(e => e.AnimalClass.AnimalClassification == searchRequest.AnimalClass);
            };
            if(searchRequest.Age!=0)
            {
                int ageSearch = DateTime.Now.Year - searchRequest.Age;
                query=query.Where(e=>e.DateOfBirth.Year==ageSearch);
            }
            if(searchRequest.DateAcquired.HasValue)
            {
                query=query.Where(e=>e.DateAcquired >= searchRequest.DateAcquired.Value && e.DateAcquired <searchRequest.DateAcquired.Value.AddDays(1));
            }

            switch (searchRequest.Order)
    {
        case "species":
            query = query.OrderBy(s => s.Species);
            break;
        case "name":
            query = query.OrderBy(s => s.AnimalName);
            break;
        case "class":
            query = query.OrderBy(s => s.AnimalClass);
            break;
             case "acquired":
            query = query.OrderByDescending(s => s.DateAcquired);
             break;
        default:
            query = query.OrderBy(s => s.Species);
            break;
    }
           
            return query.Include(u=>u.AnimalClass)
                .Skip((searchRequest.Page - 1) * searchRequest.PageSize)
                    .Take(searchRequest.PageSize);
        }
                
              
           
        public int Count(AnimalSearchRequest searchRequest)
        { 
            IQueryable<Animal> query = _context.Animals;
           
             if (!string.IsNullOrEmpty(searchRequest.Species))
            {
                query = query.Where(e => e.Species.ToLower().Contains(searchRequest.Species.ToLower()));
                            
            }
            if(!string.IsNullOrEmpty(searchRequest.AnimalName))
            {
                query = query.Where(e => e.AnimalName.ToLower().Contains(searchRequest.AnimalName.ToLower()));
            }
            
            if(searchRequest.AnimalClass != null)
            {
                query=query.Where(e => (e.AnimalClassId-1) == Convert.ToInt32(searchRequest.AnimalClass));
            };
            if(searchRequest.Age!=0)
            {
                int ageSearch = DateTime.Now.Year - searchRequest.Age;
                query=query.Where(e=>e.DateOfBirth.Year==ageSearch);
            }
            Console.WriteLine(searchRequest.DateAcquired);
            if (searchRequest.DateAcquired== null)
            {
                Console.WriteLine("Date is null");
            };
            if(searchRequest.DateAcquired.HasValue)
            {
                query=query.Where(e=>e.DateAcquired >= searchRequest.DateAcquired.Value && e.DateAcquired <searchRequest.DateAcquired.Value.AddDays(1));
            }
         return query.Count();
            
           
        }
       
        
        public Animal GetById(int id)
        {
            return _context.Animals
                .Single(animal => animal.AnimalId == id);
        }

         public IEnumerable<Animal> GetByClassId(int id)
        {
            var animalList=_context.Animals.Where(animal => animal.AnimalClassId == id);
            return (animalList);        
        }

        public List<string> GetSpecies(string species)
        {
            var AnimalSpeciesList = _context.Animals.Where(animal => animal.Species == species);
            var SpeciesList = new List<string>();
            foreach(Animal spec in AnimalSpeciesList)
            {   
                SpeciesList.Add(spec.Species);
            };
            return (SpeciesList);
        }

        public List<string> GetAllSpecies()
        {
            var AnimalList = _context.Animals;
            var SpeciesList = new List<string>();
            foreach(Animal animal in AnimalList)
            {   
                SpeciesList.Add(animal.Species);
            };
            var NoDuplicatesSpeciesList = SpeciesList.Distinct().ToList();
            return (NoDuplicatesSpeciesList);
        }

        public Animal GetByAnimalName(string animalName)
        {
            return _context.Animals.FirstOrDefault(animal => animal.AnimalName == animalName);
        }
         public AnimalClass GetAnimalClass(AnimalClassification animalClass)
        {
            return _context.AnimalClasses.FirstOrDefault(v=>v.AnimalClassification == animalClass);
        }
        public Animal Create(CreateAnimalRequest newAnimal)
        {
           
        if(!_context.AnimalClasses.Any(v => v.AnimalClassification == newAnimal.AnimalClass))
        {
            AnimalClass animalClass = new AnimalClass()
            {
                AnimalClassification = newAnimal.AnimalClass
            };
            _context.AnimalClasses.Add(animalClass);
            _context.SaveChanges();
        }

        var newAnimalClass = GetAnimalClass(newAnimal.AnimalClass);
        var insertResponse = _context.Animals.Add(new Animal
            {
                AnimalName = newAnimal.AnimalName,
                Species = newAnimal.Species,
                Sex = newAnimal.Sex,
                DateOfBirth = newAnimal.DateOfBirth,
                DateAcquired = newAnimal.DateAquired,
                AnimalClassId= newAnimalClass.AnimalClassId
            });
            _context.SaveChanges();

            return insertResponse.Entity;
        }
       

        public void Delete(int id)
        {
            var animal = GetById(id);
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }
    }
}