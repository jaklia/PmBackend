using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.BLL.DTOs.Auth
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }

        public User User { get; set; }
    }
}
