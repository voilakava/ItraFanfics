using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace cours1test.Models
{
    public class Fanfic
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public string FText { get; set; }
        //добавляется новая

        public ICollection<Chapter> Chapters { get; set; }

        public string AuthorId { get; set; }
        public Fandom Fandom { get; set; }
        public Category Category { get; set; }

    }
}
