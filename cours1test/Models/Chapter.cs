using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace cours1test.Models
{
    public class Chapter
    {
        internal DbSet<Chapter> id;

        [Key]
        public int ID { get; set; }
        public int RangeId { get; set; }
        public string CName { get; set; }
        public string CText { get; set; }

        [NotMapped]
        public int FanficID { get; set; }
        [NotMapped]
        public int bookChapterId { get; set; }
        

    }
} 