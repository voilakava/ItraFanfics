using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace cours1test.Models
{
    public class Bookmark
    {

        public int ID { get; set; }
        public string UserId { get; set; }
        public int FanficID { get; set; }

        [NotMapped]
        public Fanfic Fanfic { get; set; }
    }
}
