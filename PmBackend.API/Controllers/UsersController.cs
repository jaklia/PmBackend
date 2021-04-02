using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using PmBackend.API.DTOs.TimeEntries;
using PmBackend.API.DTOs.Users;
using PmBackend.BLL.Common;
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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsersAsync()
        {
            var user = User; // User prop from ControllerBase (to check claims)
            var users = await _userService.GetUsersAsync();
            var usersDto = users.Select(u => new UserDto(u));
            return Ok(usersDto);
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<ActionResult<UserDto>> GetUserAsync(int id)
        {
            try
            {
                var user = await _userService.GetUserAsync(id);
                return Ok(new UserDto(user));
            } catch 
            {
                return NotFound();
            }
        }

        
        [HttpGet("{id}/timeentries", Name = "GetUserTimeEntries")]
        public async Task<ActionResult<IEnumerable<TimeEntryDto>>> GetUserTimeEntries(int id)
        {
            var timeEntries = await _userService.GetUserTimeEntriesAsync(id);
            return Ok(timeEntries.Select(t => new TimeEntryDto(t)));
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUserAsync([FromBody] User value)
        {
            var created = await _userService.InsertUserAsync(value);
            var createdDto = new UserDto(created);
            return Ok(createdDto);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] User value)
        {
            await _userService.UpdateUserAsync(id, value);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
