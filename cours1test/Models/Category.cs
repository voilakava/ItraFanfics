using System;
using System.Collections.Generic;

namespace cours1test.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }  

        public ICollection<Fanfic> Fanfics { get; set; }

    }
}
