using System;
namespace cours1test.Models
{
    public class Bookmark
    {

        public int ID { get; set; }
        public string UserId { get; set; }
        public int FanficId { get; set; }
        public bool InBookmarks { get; set; }
        public Fanfic Fanfic { get; set; }
    }
}
