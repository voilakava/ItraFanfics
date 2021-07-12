using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace cours1test.Models
{
    public class User: IdentityUser
    {
        public ICollection<Fanfic> Fanfics { get; set; }

    }
}
