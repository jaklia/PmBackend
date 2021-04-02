using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PmBackend.BLL.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int userId);
        Task<IEnumerable<User>> GetUsersAsync();

        Task<IEnumerable<TimeEntry>> GetUserTimeEntriesAsync(int userId);

        Task<User> InsertUserAsync(User newUser);
        Task UpdateUserAsync(int userId, User UpdatedUser);
        Task DeleteUserAsync(int userId);
    }
}
