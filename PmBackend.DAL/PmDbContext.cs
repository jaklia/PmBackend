using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PmBackend.DAL.Entities;
using PmBackend.DAL.SeedConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.DAL
{
    public class PmDbContext : IdentityDbContext<User,
        IdentityRole<int>, 
        int/*,
        IdentityUserClaim<int>,
        IdentityUserRole<int>,
        IdentityUserLogin<int>, 
        IdentityRoleClaim<int>, 
        IdentityUserToken<int>*/>
    {
        public PmDbContext(DbContextOptions<PmDbContext> options): base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=pmdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Issue> Issues { get; set;  }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<Leave> Leaves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("Users");

            // Constraints
            modelBuilder.Entity<Issue>()
            .Property(c => c.Subject)
           // .HasMaxLength(15)
            .IsRequired();

            modelBuilder.Entity<Project>()
            .Property(p => p.Name)
            .IsRequired();

            modelBuilder.Entity<TimeEntry>()
                .Property(t => t.Date)
                .IsRequired()
                .HasDefaultValue(DateTime.Now);
            modelBuilder.Entity<TimeEntry>()
                .Property(t => t.Minutes)
                .IsRequired();

            // Seed
            //modelBuilder.Entity<Project>()
            //    .HasData(
            //        new Project { Id = 1, Name = "Sample Project 1"}
            //    );
            //modelBuilder.Entity<Issue>()
            //    .HasData(
            //        new Issue { Id = 1, Subject = "Sample Issue 1", ProjectId = 1 },
            //        new Issue { Id = 2, Subject = "Sample Issue 2", ProjectId = 1 }
            //    );
            //modelBuilder.Entity<TimeEntry>()
            //    .HasData(
            //          new TimeEntry { Id = 1, Date = DateTime.Now, Minutes = 2*60, IssueId = 1, UserId = 1 },
            //          new TimeEntry { Id = 2, Date = DateTime.Now, Minutes = 5*60, IssueId = 1, UserId = 1 },
            //          new TimeEntry { Id = 3, Date = DateTime.Now, Minutes = 10*60, IssueId = 2, UserId = 2 }
            //    );

            modelBuilder.ApplyConfiguration(new ProjectSeed());
            modelBuilder.ApplyConfiguration(new IssueSeed());
            modelBuilder.ApplyConfiguration(new TimeEntrySeed());
            modelBuilder.ApplyConfiguration(new UserSeed());
            modelBuilder.ApplyConfiguration(new RoleSeed());
            modelBuilder.ApplyConfiguration(new UserRoleSeed());
            modelBuilder.ApplyConfiguration(new RoomSeed());

            //modelBuilder.Entity<User>()
            //    .HasData(
            //        new User { Id = 1, UserName = "Teszt Elek", Email = "elek@teszt.com" },
            //        new User { Id = 2, UserName = "Példa Béla", Email = "bela@pelda.com" },
            //        new User { Id = 3, UserName = "Teszt Admin", Email = "admin@teszt.com" }
            //    );
            //modelBuilder.Entity<IdentityRole<int>>()
            //    .HasData(
            //        new IdentityRole<int> {Id = 1, Name = "Admin" },
            //        new IdentityRole<int> { Id = 2, Name = "User" }
            //    ); 
            //modelBuilder.Entity<IdentityUserRole<int>>()
            //    .HasData(
            //        new IdentityUserRole<int> { UserId = 1, RoleId = 2},
            //        new IdentityUserRole<int> { UserId = 2, RoleId = 2},
            //        new IdentityUserRole<int> { UserId = 3, RoleId = 2},
            //        new IdentityUserRole<int> { UserId = 3, RoleId = 1}
            //    );

            //modelBuilder.Entity<Room>()
            //    .HasData(
            //        new Room { Id = 1, Name = "R11", Capacity= 20},
            //        new Room { Id = 2, Name = "R22", Capacity= 50},
            //        new Room { Id = 3, Name = "C111", Capacity= 100},
            //        new Room { Id = 4, Name = "M44", Capacity= 20}
            //    );

        }

    }
}
