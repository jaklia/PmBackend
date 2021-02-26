using PmBackend.BLL.DTOs.Auth;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PmBackend.BLL.Interfaces
{
    public interface IAuthService
    {
        public  Task<LoginResponse> Login(LoginRequest loginRequest);
        public Task<bool> Register(User user);
    }
}
