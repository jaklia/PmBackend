using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Text;

namespace PmBackend.BLL.Common
{
    public class Policies
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public static AuthorizationPolicy AdminPolicy(/*string authenticationScheme*/) 
        {
            var asd = new AuthorizationPolicyBuilder("Bearer").RequireAuthenticatedUser().RequireAssertion(ctx =>
            {
                return ctx.User.IsInRole("Admin");
            });
            return asd.Build();
           // return new AuthorizationPolicyBuilder("Bearer").RequireAuthenticatedUser().RequireRole(Admin).Build(); 
        }
        public static AuthorizationPolicy UserPolicy(/*string authenticationScheme*/)
        {
             var asd = new AuthorizationPolicyBuilder("Bearer").RequireAuthenticatedUser().RequireAssertion(ctx =>
            {
                return ctx.User.IsInRole("User");
            });
            return asd.Build();
           // return new AuthorizationPolicyBuilder("Bearer").RequireAuthenticatedUser().RequireRole(User).Build();
        }
    }
}

