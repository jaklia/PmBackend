using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL.Entities;

namespace PmBackend.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [Authorize]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.GetUsers();
        }

        // GET: api/Users/5
        [Authorize]
        [HttpGet("{id}", Name = "GetUser")]
        public User Get(int id)
        {
            return _userService.GetUser(id);
        }

        // POST: api/Users
        [Authorize]
        [HttpPost]
        public User Post([FromBody] User value)
        {
            var created = _userService.InsertUser(value);
            return created;
        }

        // PUT: api/Users/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User value)
        {
            _userService.UpdateUser(id, value);
        }

        // DELETE: api/ApiWithActions/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.DeleteUser(id);
        }
    }
}
