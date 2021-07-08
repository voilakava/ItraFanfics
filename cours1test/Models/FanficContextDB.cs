﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace cours1test.Models
{
    public class FanficContextDB: DbContext
    {
        public DbSet<Fanfic> Fanfics { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Fandom> Fandom { get; set; }
        public DbSet<Category> Categories { get; set; }

        //осталось продумать логику лайков и комментов

        public DbSet<Fandom> Files { get; set; }
        //public DbSet<PostLike> Liles { get; set; }

        public FanficContextDB(DbContextOptions<FanficContextDB> options) : base(options)
        {
            Database.EnsureCreated();
        }

        internal object First()
        {
            throw new NotImplementedException();
        }
    }

}

