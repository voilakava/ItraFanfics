using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace cours1test.Models
{
    
    public class BookCategory 
    {
        [Key]
        public int idc { get; set; }

        public int FanficID { get; set; }
        public int CategoryID { get; set; }
    }
}
