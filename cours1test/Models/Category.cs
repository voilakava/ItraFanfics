using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace cours1test.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public ICollection<Fanfic> Fanfics { get; set; }

    }
}
