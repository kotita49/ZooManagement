using System;

namespace ZooManagement.Data
{
    public class DateGenerator
    {
        private static Random _random = new Random();
        private static int _maxAcquiredAge = 7000; // ~twenty years of days
        
        public static DateTime GetBirthDate()
        {
            // Posts happen longer ago than the max interaction age so that we don't risk
            // interacting with a post before it is created.
            var randomDaysAgo = _random.Next(1, _maxAcquiredAge);
            return DateTime.Now.AddDays(-1 * (_maxAcquiredAge + randomDaysAgo));
        }
        
        public static DateTime GetAcquiredDate()
        {
            var randomDaysAgo = _random.Next(1, _maxAcquiredAge);
            return DateTime.Now.AddDays(-1 * randomDaysAgo);
        }
    }
}