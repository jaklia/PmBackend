using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PmBackend.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly PmDbContext _ctx;
        public UserService(PmDbContext ctx)
        {
            _ctx = ctx;
        }

        public void DeleteUser(int userId)
        {
            _ctx.Users.Remove(new User { Id = userId });
            _ctx.SaveChanges();
        }

        public User GetUser(int userId)
        {
            return _ctx.Users.SingleOrDefault(u => u.Id == userId);
        }

        public IEnumerable<User> GetUsers()
        {
            return _ctx.Users.ToList();
        }

        public User InsertUser(User newUser)
        {
            _ctx.Users.Add(newUser);
            _ctx.SaveChanges();
            return newUser;
        }

        public void UpdateUser(int userId, User updatedUser)
        {
            updatedUser.Id = userId;
            var u = _ctx.Attach(updatedUser);
            u.State = EntityState.Modified;
            _ctx.SaveChanges();
        }
    }
}
