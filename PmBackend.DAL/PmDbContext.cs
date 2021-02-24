using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PmBackend.DAL.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                .Property(t => t.Hours)
                .IsRequired();

            // Seed
            modelBuilder.Entity<Project>()
                .HasData(
                    new Project { Id = 1, Name = "Sample Project 1"}
                );
            modelBuilder.Entity<Issue>()
                .HasData(
                    new Issue { Id = 1, Subject = "Sample Issue 1", ProjectId = 1},
                    new Issue { Id = 2, Subject = "Sample Issue 2", ProjectId = 1 }
                );
            modelBuilder.Entity<TimeEntry>()
                .HasData(
                      new TimeEntry { Id = 1, Date = DateTime.Now, Hours = 2, IssueId = 1, UserId = 1 },
                      new TimeEntry { Id = 2, Date = DateTime.Now, Hours = 5, IssueId = 1, UserId = 1 },
                      new TimeEntry { Id = 3, Date = DateTime.Now, Hours = 10, IssueId = 2, UserId = 2 }
                );
            modelBuilder.Entity<User>()
                .HasData(
                    new User { Id = 1, UserName = "Teszt Elek", Email = "elek@teszt.com"},
                    new User { Id = 2, UserName = "Példa Béla", Email = "bela@pelda.com" }
                );

        }

    }
}
