using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace cours1test.Models
{
    public class Fanfic
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        //[NotMapped]
        //public int AuthorshipID { get; set; } 
        //public string FText { get; set; }
        //добавляется новая  
        [NotMapped]
        public ICollection<Chapter> Chapters { get; set; } 
        [NotMapped]
        public string AuthorId { get; set; }
        [NotMapped]
        public User Author { get; set; }
        [NotMapped]
        public Fandom Fandom { get; set; }
        [NotMapped]
        public string FandomName { get; set; }
        [NotMapped]
        public Category Category { get; set; }
        [NotMapped]
        public ICollection<Comment> Comments { get; set; }
        [NotMapped]
        public ICollection<PostLike> Likes { get; set; }
        [NotMapped]
        public ICollection<Bookmark> Bookmarks { get; set; }
        [NotMapped]
        public bool? isLiked { get; set; }
        [NotMapped]
        public bool? inBookmarks { get; set; }
        //public byte IsLiked { get; set; }


    }
}
