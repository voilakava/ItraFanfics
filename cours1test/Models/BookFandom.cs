using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace cours1test.Models
{
    public class BookFandom
    {
        [Key]
        public int idf { get; set; }

        public int FanficID { get; set; }
        public int FandomId { get; set; }
    }
}
