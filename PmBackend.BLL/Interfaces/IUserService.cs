using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.BLL.Interfaces
{
    public interface IUserService
    {
        User GetUser(int userId);
        IEnumerable<User> GetUsers();

        IEnumerable<TimeEntry> GetUserTimeEntries(int userId);

        User InsertUser(User newUser);
        void UpdateUser(int userId, User UpdatedUser);
        void DeleteUser(int userId);
    }
}
