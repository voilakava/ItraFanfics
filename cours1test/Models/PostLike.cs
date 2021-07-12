using System;
namespace cours1test.Models
{
    public class PostLike
    {

        public int ID { get; set; }
        public string UserId { get; set; } 
        public int FanficId { get; set; }
        public bool Liked { get; set; }

        //        id
        //user_ip
        //direction
        //entity_id
        //created

    }
}
