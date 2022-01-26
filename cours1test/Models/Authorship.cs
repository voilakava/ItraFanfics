using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace cours1test.Models
{
    public class Authorship
    {
        [Key]
        public int AuthorshipID { get; set; }
        public int FanficID { get; set; }
        public string UsreId { get; set; }


        [NotMapped]
        public ICollection<Fanfic> Fanfics { get; set; }
    }
}
