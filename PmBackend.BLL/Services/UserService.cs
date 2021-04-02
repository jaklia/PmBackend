using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task DeleteUserAsync(int userId)
        {
            var userToDelete = await _userManager.FindByIdAsync(userId.ToString());
                //_ctx.Users.SingleOrDefaultAsync(u => u.Id == userId);
            await _userManager.DeleteAsync(userToDelete);
           // _ctx.Users.Remove(userToDelete);
            await _ctx.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(int userId)
        {
            var user = await _userManager.Users
                .Include(u => u.TimeEntries)
                .ThenInclude(t => t.Issue)
                .FirstOrDefaultAsync(u => u.Id == userId);
            return user;
        }

        public async  Task<IEnumerable<User>> GetUsersAsync()
        {
            //return _ctx.Users.ToList();
            return await _userManager.Users
                .Include(u => u.TimeEntries)
                .ThenInclude(t => t.Issue)
                .ToListAsync();
        }

        public async Task<IEnumerable<TimeEntry>> GetUserTimeEntriesAsync(int userId)
        {
            return await _ctx.TimeEntries
               .Include(t => t.User)
               .Include(t => t.Issue)
               .Where(t => t.UserId == userId)
               .ToListAsync();

        }

        public async Task<User> InsertUserAsync(User newUser) // don't need this, use registration
        {
            _ctx.Users.Add(newUser);
            await _ctx.SaveChangesAsync();
            return newUser;
        }

        public async Task UpdateUserAsync(int userId, User updatedUser) 
            // TODO:  use seaprate endpoints to change password, profile pic etc
        {
            updatedUser.Id = userId;
            var user = await _ctx.Users.SingleOrDefaultAsync(u => u.Id == userId);
            user.UserName = updatedUser.UserName;
            user.Email = updatedUser.Email;
            //var u = _ctx.Users.Update(updatedUser);
            //u.State = EntityState.Modified;      
            await _ctx.SaveChangesAsync();
        }
    }
}
