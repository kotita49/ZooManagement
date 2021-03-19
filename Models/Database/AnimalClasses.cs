using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ZooManagement.Models.Database
{
    public enum AnimalClassification
        { 
            Mammal, 
            Bird, 
            Fish, 
            Insect, 
            Invertebrate,
            Reptile, 
        }; 
    public class AnimalClass

    { [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AnimalClassId { get; set; }

        public ICollection<Animal> Animals { get; set; }
        
        public AnimalClassification AnimalClassification { get; set; }
         
    }

  
}