using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.DAL.SeedConfig
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {

        private string HashPassword(User user, string rawPassword)
        {
            var passwordHasher = new PasswordHasher<User>();
            string password = passwordHasher.HashPassword(user, rawPassword);
            return password;
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            var user = new User
            {
                Id = 1,
                UserName = "Teszt Elek",
                Email = "user@teszt.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PasswordHash = "AQAAAAEAACcQAAAAEEvzg8nUYRh8AC1LsDDmc1c86tcRLpPwGikngu5mPfhkyy3VWI8BWoBYGNMNEKJQbA=="
            };
            user.NormalizedEmail = user.Email.ToUpper();

            var user2 = new User
            {
                Id = 2,
                UserName = "Példa Béla",
                Email = "bela@pelda.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PasswordHash = "AQAAAAEAACcQAAAAEEvzg8nUYRh8AC1LsDDmc1c86tcRLpPwGikngu5mPfhkyy3VWI8BWoBYGNMNEKJQbA=="
            };
            user2.NormalizedEmail = user2.Email.ToUpper();

            var admin = new User
            {
                Id = 3,
                UserName = "Teszt Admin",
                Email = "admin@teszt.com",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                PasswordHash = "AQAAAAEAACcQAAAAEEvzg8nUYRh8AC1LsDDmc1c86tcRLpPwGikngu5mPfhkyy3VWI8BWoBYGNMNEKJQbA=="
            };
            admin.NormalizedEmail = admin.Email.ToUpper();
            builder.HasData(
                user,
                user2,
                admin
            );
        }
    }
}
