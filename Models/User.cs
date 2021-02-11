using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


//NOTE https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx 
namespace TrivitalTracker.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<AccountDetail> AccountDetails { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User-AccDet 1-1
            modelBuilder.Entity<User>()
                .HasOne<AccountDetail>(s => s.AccountDetail)
                .WithOne(g => g.User)
                .HasForeignKey<AccountDetail>(s => s.UserID);
            //User-UsrSett 1-1
            modelBuilder.Entity<User>()
                .HasOne<UserSetting>(s => s.UserSetting)
                .WithOne(g => g.User)
                .HasForeignKey<UserSetting>(s => s.UserID);

            modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(24)]
        public string Username { get; set; }
        [Required]
        [MaxLength(320)]
        public string Email { get; set; }
        [Required]
        [MaxLength(24)]
        public string Password { get; set; }
        public AccountDetail AccountDetail { get; set; }
        public UserSetting UserSetting { get; set; }
    }
    public class AccountDetail
    {
        public int AccountID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public List<Comment> Comments { get; set; }
        public List<KanbanUser> Kanbans { get; set; }

    }

    public class UserSetting
    {
        public int SettingID { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int SettingBitFlag { get; set; }

    }



}