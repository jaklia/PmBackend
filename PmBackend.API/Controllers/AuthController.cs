using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PmBackend.BLL.DTOs.Auth;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.BLL.Services;

namespace PmBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        //// GET: api/Auth
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Auth/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Auth
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult<LoginResponse>> Post([FromBody] LoginRequest loginRequest)
        {
            try
            {
                return await _authService.Login(loginRequest);
            }
            catch (EntityNotFoundException)
            {

                return NotFound();
            }
            catch (AuthenticationException)
            {
                return Unauthorized();
            }
            
        }
        // POST: api/Auth
        [Route("register")]
        [HttpPost]
        public async Task<bool> Post([FromBody] string value)
        {
            return await _authService.Register(new DAL.Entities.User());
        }


        //// PUT: api/Auth/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
