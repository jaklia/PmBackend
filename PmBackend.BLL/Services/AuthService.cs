using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PmBackend.BLL.DTOs.Auth;
using PmBackend.BLL.Exceptions;
using PmBackend.BLL.Interfaces;
using PmBackend.DAL;
using PmBackend.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PmBackend.BLL.Services
{
    public class AuthService : IAuthService
    {

        private readonly PmDbContext _ctx;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        RoleManager<IdentityRole<int>> _roleManager;
        public AuthService(PmDbContext ctx, UserManager<User> userManager, IConfiguration config, RoleManager<IdentityRole<int>> roleManager)
        {
            _ctx = ctx;
            _userManager = userManager;
            _config = config;
            _roleManager = roleManager;
        }
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var user = await _ctx.Users.SingleOrDefaultAsync(u => u.UserName == loginRequest.UserName);

            if (user == null)
            {
                throw new EntityNotFoundException("No user found with given username");
            }
            var result = _userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, loginRequest.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new AuthenticationException("Incorrect password");
            } else
            {
                var token = await GenerateJWT(user);
                return new LoginResponse { User= user, AccessToken = token};
            }

        }

        public async Task<bool> Register(User user)
        {
           // var admin = await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
           // var u = await _roleManager.CreateAsync(new IdentityRole<int>("User"));

           // foreach (var a in _userManager.Users.ToList())
           // {
           //     await _userManager.AddToRoleAsync(a, "User");
           // }
           // var aa = await _userManager.FindByIdAsync("3");
           //await  _userManager.AddToRoleAsync(aa, "Admin");
           // await _ctx.SaveChangesAsync();
            
            return false;
        }

        async Task<string> GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,  "Bearer");
            // add the roles to the claims
            claimsIdentity.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));


            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                //claims: claims,
                claims: claimsIdentity.Claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
