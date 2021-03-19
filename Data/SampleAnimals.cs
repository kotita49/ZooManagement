// using System.Collections.Generic;
// using System.Linq;
// using ZooManagement.Models.Database;
// using System.Security.Cryptography;
// using System;
// using Microsoft.AspNetCore.Cryptography.KeyDerivation;

// namespace ZooManagement.Data
// {
   
//  public static class SampleAnimals
//    {

//    }
// //        
            
// //         };
        
// //         public static IEnumerable<User> GetUsers()
// //         {
// //             return Enumerable.Range(0, NumberOfUsers).Select(CreateRandomUser);
// //         }

// //         private static User CreateRandomUser(int index)
// //         {
// //             byte[] salt = new byte[128 / 8];
// //             using (var rng = new RNGCryptoServiceProvider())
// //             {
// //                 rng.GetBytes(salt);
// //             }
    
// //             string FakePassword = "password";

// //             // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
// //             string HashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
// //                 password: FakePassword,
// //                 salt: salt,
// //                 prf: KeyDerivationPrf.HMACSHA1,
// //                 iterationCount: 10000,
// //                 numBytesRequested: 256 / 8));

// //             return new User
// //             {
// //                 FirstName = _data[index][0],
// //                 LastName = _data[index][1],
// //                 Username = _data[index][2],
// //                 Email = _data[index][3],
// //                 ProfileImageUrl = ImageGenerator.GetProfileImage(_data[index][2]),
// //                 CoverImageUrl = ImageGenerator.GetCoverImage(index),
// //                 Hashed_password = HashedPassword,
// //                 Salt = Convert.ToBase64String(salt)
// //             };
// //         }
// //     }
// // }