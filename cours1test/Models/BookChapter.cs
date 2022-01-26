using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace cours1test.Models
{

    public class BookChapter 
    {
        [Key]
        public int idc { get; set; }

        public int FanficID { get; set; }
        public int ChapterId { get; set; }

        //[NotMapped]
        public Fanfic Fanfic { get; set; }
        
    }
}
