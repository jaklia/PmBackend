using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<User> _userManager;
        public UserService(PmDbContext ctx, UserManager<User> userManager)
        {
            _ctx = ctx;
            _userManager = userManager;
        }

        public void DeleteUser(int userId)
        {
            var userToDelete = _ctx.Users.SingleOrDefault(u => u.Id == userId);
            _ctx.Users.Remove(userToDelete);
            //_ctx.Users.Remove(new User { Id = userId });
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

        public IEnumerable<TimeEntry> GetUserTimeEntries(int userId)
        {
            return _ctx.TimeEntries.Where(t => t.UserId == userId).ToList();
            //return _ctx.Users.Include(u=>u.TimeEntries).FirstOrDefault(u => u.Id == userId)?.TimeEntries.ToList();
        }

        public User InsertUser(User newUser) // don't need this, use registration
        {
            _ctx.Users.Add(newUser);
            _ctx.SaveChanges();
            return newUser;
        }

        public void UpdateUser(int userId, User updatedUser)
        {
            updatedUser.Id = userId;
            var user = _ctx.Users.SingleOrDefault(u => u.Id == userId);
            user.UserName = updatedUser.UserName;
            user.Email = updatedUser.Email;
            //var u = _ctx.Users.Update(updatedUser);
            //u.State = EntityState.Modified;      
            _ctx.SaveChanges();
        }
    }
}
