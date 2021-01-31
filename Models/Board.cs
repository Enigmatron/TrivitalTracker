using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrivitalTracker.Models
{
    public class BoardContext : DbContext
    {
        public DbSet<Board> Boards{get;set;}
        public DbSet<BoardSetting> BoardSettings{get;set;}
        public DbSet<Item> Items{get;set;}
        public DbSet<Bucket> Bucket{get;set;}
        public DbSet<Comment> Comments{get;set;}
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");
    }
    public class Board
    {
        public int BoardID { get; set; }
        public int OwnerID{get;set;}
        public User Owner{get;set;}
        public string Title { get; set; }
        public string Description { get; set; }

        public List<Bucket> Buckets{get; set;}
    }

    public class BoardSetting{
        public int BoardSettingID;
        public int BoardID;
        public int UserID;

    }

    public class Item
    {
        public int ItemID{get; set;}
        public string Title{get; set;}
        public string Description { get; set;}
        public int BoardId{get; set;}
        public Bucket Bucket{get; set;}

        public List<Comment> Comments{get;set;} 

    }

    public class Bucket
    {
        public int BucketID{get;set;}
        public List<Item> Items{get;set;}
        public int BoardID{get;set;}
        public Board Board{get;set;}
        public string Description{get;set;}
        public string Title{get;set;}

    }
    public class Comment{
        public int CommentID{get;set;}
        public int ItemID{ get; set; }
        public int UserID{get;set;}
        public User User{get;set;}
        public string Content{get;set;}
    }
}
