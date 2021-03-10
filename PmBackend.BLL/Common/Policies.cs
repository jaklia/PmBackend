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
        public static AuthorizationPolicy AdminPolicy(string authenticationScheme ) 
        {
            return new AuthorizationPolicyBuilder(authenticationScheme).RequireAuthenticatedUser().RequireRole(Admin).Build(); 
        }
        public static AuthorizationPolicy UserPolicy(string authenticationScheme )
        {
            return new AuthorizationPolicyBuilder(authenticationScheme).RequireAuthenticatedUser().RequireRole(User).Build();
        }
    }
}

