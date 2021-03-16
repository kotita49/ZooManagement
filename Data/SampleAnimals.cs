// using System.Collections.Generic;
// using System.Linq;
// // using ZooManagement.Models.Database;
// using System.Security.Cryptography;
// using System;
// using Microsoft.AspNetCore.Cryptography.KeyDerivation;

// namespace ZooManagement
// {
//     public static class SampleAnimals
//     {
//         public static int NumberOfUsers = 100;
        
//         private static IList<IList<string>> _data = new List<IList<string>>
//         {
//             new List<string> { "Kania", "Placido", "kplacido0", "kplacido0@qq.com" },
//             new List<string> { "Scotty", "Gariff", "sgariff1", "sgariff1@biblegateway.com" },
//             new List<string> { "Colly", "Burgiss", "cburgiss2", "cburgiss2@amazon.co.uk" },
//             new List<string> { "Barnie", "Percival", "bpercival3", "bpercival3@cmu.edu" },
//             new List<string> { "Brandon", "Narraway", "bnarraway4", "bnarraway4@trellian.com" },
//             new List<string> { "Carlos", "Sakins", "csakins5", "csakins5@spiegel.de" },
//             new List<string> { "Zeke", "Barkworth", "zbarkworth6", "zbarkworth6@symantec.com" },
//             new List<string> { "Henrietta", "Verick", "hverick7", "hverick7@adobe.com" },
//             new List<string> { "Maxine", "Lovett", "mlovett8", "mlovett8@mac.com" },
//             new List<string> { "Adorne", "Smyth", "asmyth9", "asmyth9@nyu.edu" },
           
            
//         };
        
//         public static IEnumerable<User> GetUsers()
//         {
//             return Enumerable.Range(0, NumberOfUsers).Select(CreateRandomUser);
//         }

//         private static User CreateRandomUser(int index)
//         {
//             byte[] salt = new byte[128 / 8];
//             using (var rng = new RNGCryptoServiceProvider())
//             {
//                 rng.GetBytes(salt);
//             }
    
//             string FakePassword = "password";

//             // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
//             string HashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
//                 password: FakePassword,
//                 salt: salt,
//                 prf: KeyDerivationPrf.HMACSHA1,
//                 iterationCount: 10000,
//                 numBytesRequested: 256 / 8));

//             return new User
//             {
//                 FirstName = _data[index][0],
//                 LastName = _data[index][1],
//                 Username = _data[index][2],
//                 Email = _data[index][3],
//                 ProfileImageUrl = ImageGenerator.GetProfileImage(_data[index][2]),
//                 CoverImageUrl = ImageGenerator.GetCoverImage(index),
//                 Hashed_password = HashedPassword,
//                 Salt = Convert.ToBase64String(salt)
//             };
//         }
//     }
// }