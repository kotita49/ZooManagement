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

        // IEnumerable<User> Search(UserSearchRequest search);
        // int Count(UserSearchRequest search);
        Animal GetById(int id);
        Animal GetByAnimalName(string animalName);
        Animal Create(CreateAnimalRequest newAnimal);
        
        // User Create(CreateUserRequest newUser);
        // User Update(int id, UpdateUserRequest update);
        void Delete(int id);
    // 
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
        public Animal GetByAnimalName(string animalName)
        {
            return _context.Animals.FirstOrDefault(animal => animal.AnimalName == animalName);
        }
        public Animal Create(CreateAnimalRequest newAnimal)
        {
        // find the id of the animal classification 
        // if it doesnt exsist create new id 
        // _context.AnimalClasses.Add(new AnimalClass
        //once we have the id 

        var insertResponse = _context.Animals.Add(new Animal
            {
                AnimalName = newAnimal.AnimalName,
                Species = newAnimal.Species,
                Sex = newAnimal.Sex,
                DateOfBirth = newAnimal.DateOfBirth,
                DateAquired = newAnimal.DateAquired
                //classId= id
            });
            _context.SaveChanges();

            return insertResponse.Entity;
        }
        // public Animal Create(CreateUserRequest newUser)
        // {
        //     // Generate a salt
        //     byte[] salt = new byte[128 / 8];
        //     using (var rng = new RNGCryptoServiceProvider())
        //     {
        //         rng.GetBytes(salt);
        //     }

        //     // Add salt to the password and hash it all
        //     string HashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        //         password: newUser.Password,
        //         salt: salt,
        //         prf: KeyDerivationPrf.HMACSHA1,
        //         iterationCount: 10000,
        //         numBytesRequested: 256 / 8));

        //     var insertResponse = _context.Users.Add(new User
        //     {
        //         FirstName = newUser.FirstName,
        //         LastName = newUser.LastName,
        //         Email = newUser.Email,
        //         Username = newUser.Username,
        //         ProfileImageUrl = newUser.ProfileImageUrl,
        //         CoverImageUrl = newUser.CoverImageUrl,
        //         Hashed_password = HashedPassword,
        //         Salt = Convert.ToBase64String(salt)
        //     });
        //     _context.SaveChanges();

        //     return insertResponse.Entity;
        // }

        // public User Update(int id, UpdateUserRequest update)
        // {
        //     var user = GetById(id);

        //     user.FirstName = update.FirstName;
        //     user.LastName = update.LastName;
        //     user.Username = update.Username;
        //     user.Email = update.Email;
        //     user.ProfileImageUrl = update.ProfileImageUrl;
        //     user.CoverImageUrl = update.CoverImageUrl;

        //     _context.Users.Update(user);
        //     _context.SaveChanges();

        //     return user;
        // }

        public void Delete(int id)
        {
            var animal = GetById(id);
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }
    }
}