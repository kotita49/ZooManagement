using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ZooManagement.Models.Database
{
    public enum Sex
    {
        Male,
        Female,
    }
    public class Animal

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string Species { get; set; } //maybe move to animal class
        
        public Sex Sex { get; set; } // might want to do an enum
        
        public DateTime DateOfBirth { get; set; }
        public DateTime DateAquired { get; set; }

        [ForeignKey ("AnimalClass")]
        public int AnimalClassId { get; set; }
        public AnimalClass AnimalClass { get; set; }       
    }

}