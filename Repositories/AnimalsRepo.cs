using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ZooManagement.Models.Request;
using ZooManagement.Models.Database;
using System.Text.Json;

namespace ZooManagement.Repositories
{
    public interface IAnimalsRepo
    {
        Animal GetById(int id);
        Animal GetByAnimalName(string animalName);
        Animal Create(CreateAnimalRequest newAnimal);
        List<string> GetAllSpecies();
     
        void Delete(int id); 
    }
    
    public class AnimalsRepo : IAnimalsRepo
    {
        private readonly ZooManagementDbContext _context;

        public AnimalsRepo(ZooManagementDbContext context)
        {
            _context = context;
        }
        
        // public IEnumerable<User> Search(UserSearchRequest search)
        // {
        //     return _context.Users
        //         .Where(p => search.Search == null || 
        //                     (
        //                         p.FirstName.ToLower().Contains(search.Search) ||
        //                         p.LastName.ToLower().Contains(search.Search) ||
        //                         p.Email.ToLower().Contains(search.Search) ||
        //                         p.Username.ToLower().Contains(search.Search)
        //                     ))
        //         .OrderBy(u => u.Username)
        //         .Skip((search.Page - 1) * search.PageSize)
        //         .Take(search.PageSize);
        // }

        // public int Count(UserSearchRequest search)
        // {
        //     return _context.Users
        //         .Count(p => search.Search == null || 
        //                     (
        //                         p.FirstName.ToLower().Contains(search.Search) ||
        //                         p.LastName.ToLower().Contains(search.Search) ||
        //                         p.Email.ToLower().Contains(search.Search) ||
        //                         p.Username.ToLower().Contains(search.Search)
        //                     ));
        // }
       
        
        
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
        // find the id of the animal classification 
        //  GetAnimalClassByClassId(int classid)
        // if it doesnt exsist create new id 
        // _context.AnimalClasses.Add(new AnimalClass
        //once we have the id 
        var newAnimalClass = GetAnimalClass(newAnimal.AnimalClass);
        var insertResponse = _context.Animals.Add(new Animal
            {
                AnimalName = newAnimal.AnimalName,
                Species = newAnimal.Species,
                Sex = newAnimal.Sex,
                DateOfBirth = newAnimal.DateOfBirth,
                DateAquired = newAnimal.DateAquired,
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