using System;
using System.ComponentModel.DataAnnotations;

namespace cours1test.Models
{
    public class Chapter
    {
        [Key]
        public int ID { get; set; }
        public int RangeId { get; set; }
        public string CName { get; set; }
        public string CText { get; set; }
        

        public int FanficId { get; set; }
        
    }
}