using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ZooManagement.Models.Database
{
   
    public class Zookeeper

    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ZookeeperId { get; set; }
        public string ZookeeperName { get; set; }
       
        public ICollection<Enclosure> Enclosures { get; set; }

        public ICollection<Animal> Animals { get; set; }
        
   
    }

  
}
