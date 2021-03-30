using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using NSwag;
using NSwag.Generation.Processors.Security;
using PmBackend.BLL.Common;
using PmBackend.BLL.Interfaces;
using PmBackend.BLL.Services;
using PmBackend.DAL;
using PmBackend.DAL.Entities;

namespace PmBackend.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<PmDbContext>(options => 
                    options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddIdentity<User, IdentityRole<int>>(/*options => options.SignIn.RequireConfirmedAccount = true*/)
                .AddEntityFrameworkStores<PmDbContext>()
                .AddDefaultTokenProviders();



            //services.AddIdentityCore<User>()
            //    .AddEntityFrameworkStores<PmDbContext>()
            //    .AddDefaultTokenProviders()
            //    .AddRoles<IdentityRole<int>>().AddRoleManager<RoleManager<IdentityRole<int>>>();
            //    //.AddSignInManager<SignInManager<User>>();


            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               services.AddAuthentication(options =>
               {
                   options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                   // this all is needed, setting only the DefaultScheme is not enough
                   // otherwise the asp.net Identity stuff will handle the request, 
                   //    and it will randomly redirect to non-existent pages, wich results in 404
                   //      configuring those pages to existing ones, will result in 200 OK
                   //       and then we need to set the status code to 401/403 manually

                   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                   options.DefaultForbidScheme = JwtBearerDefaults.AuthenticationScheme;

               } )
               .AddJwtBearer(options => {
                   options.RequireHttpsMetadata = false;
                   options.SaveToken = true;
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["Jwt:Issuer"],
                       ValidAudience = Configuration["Jwt:Audience"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"])),
                       ClockSkew = TimeSpan.Zero
                   };
                   options.Events = new JwtBearerEvents();
                   options.Events.OnTokenValidated = (ctx) => {
                       var user = ctx.HttpContext.User;
                       var claims = ctx.Principal.Claims;
                     //  var userid = int.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                       return Task.CompletedTask;
                   };
                   // these only needed to be able to set the breakpoints to see what happens
                   options.Events.OnAuthenticationFailed = (ctx) => {
                       var asd = ctx.Result;
                       return Task.CompletedTask;
                   };
                   options.Events.OnForbidden = (ctx) =>
                   {
                       var asd = ctx.Result;
                       return Task.CompletedTask;
                   };
               }
           );
            //services.AddAuthorization(options =>
            //{
            //    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
            //        JwtBearerDefaults.AuthenticationScheme);

            //    defaultAuthorizationPolicyBuilder =
            //        defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

            //    options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            //    //options.AddPolicy(Policies.Admin, Policies.AdminPolicy());
            //    //options.AddPolicy(Policies.User, Policies.UserPolicy());

            //});

            services.AddAuthorization(config =>
            {
                config.FallbackPolicy = Policies.UserPolicy(JwtBearerDefaults.AuthenticationScheme);
                config.DefaultPolicy = Policies.UserPolicy(JwtBearerDefaults.AuthenticationScheme);
                config.AddPolicy(Policies.Admin, Policies.AdminPolicy(JwtBearerDefaults.AuthenticationScheme));
                config.AddPolicy(Policies.User, Policies.UserPolicy(JwtBearerDefaults.AuthenticationScheme));

            });



            #region disable redirect to random non-existent pages (and set status codes accordingly)
            //  not needed now, beacuse the token auth finally works normally
            //   but leaving it here in comment, just in case
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = "auth_cookie";
            //    options.Cookie.SameSite = SameSiteMode.None;
            //    options.LoginPath = new PathString("/api/Auth/login");
            //    options.AccessDeniedPath = String.Empty;
            //    options.Events.OnRedirectToLogin = context =>
            //    {
            //        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //        return Task.CompletedTask;
            //    };
            //    options.Events.OnRedirectToAccessDenied = ctx =>
            //    {
            //        ctx.Response.StatusCode = StatusCodes.Status403Forbidden;
            //        return Task.CompletedTask;
            //    };
                
            //});
            #endregion

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ITimeEntryService, TimeEntryService>();
            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IIssueService, IssueService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoomService, RoomService>();
            services.AddTransient<IMeetingService, MeetingService>();
            services.AddTransient<ILeaveService, LeaveService>();

            services.AddControllers();
            services.AddSwaggerDocument(options =>
            {
                options.Title = "Projekt menedzsment API";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
