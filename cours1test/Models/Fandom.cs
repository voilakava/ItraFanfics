using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cours1test.Models
{
    public class Fandom
    { 
        public int ID { get; set; }
        public string Titile { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public ICollection<Fanfic> Fanfics { get; set; }
    }
}
