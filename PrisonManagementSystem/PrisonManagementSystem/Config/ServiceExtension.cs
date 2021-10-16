using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using PrisonManagementSystem.Config;
using PrisonManagementSystem.Db_Models;
using PrisonManagementSystem.Implementation.Repositories;
using PrisonManagementSystem.Interfaces.Repositories;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PrisonManagementSystem
{
    public static class ServiceExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services)
        {
            try
            {

               // services.AddIdentity<User, IdentityRole>(
               //     option =>
               //     {
               //         option.SignIn.RequireConfirmedEmail = true;
               //         option.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";

               //         option.User.RequireUniqueEmail = true;
                        
               //         option.Password.RequireUppercase = true;
               //         option.Password.RequiredLength = 8;
               //         option.Password.RequireDigit = false;

               //         option.Lockout.AllowedForNewUsers = true;
               //         option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
               //         option.Lockout.MaxFailedAccessAttempts = 3;
               //     })

               // .AddEntityFrameworkStores<AppDbContext>()
               //.AddDefaultTokenProviders()
               //  .AddTokenProvider<EmailConfirmationTokenProvider<User>>("emailconfirmation")
               // .AddPasswordValidator<CustomPasswordValidator<User>>();

                //services.Configure<DataProtectionTokenProviderOptions>(opt =>
                //    opt.TokenLifespan = TimeSpan.FromHours(2));
                //services.Configure<EmailConfirmationTokenProviderOptions>(opt =>
                //    opt.TokenLifespan = TimeSpan.FromDays(3));

                //services.Configure<FormOptions>(o =>
                //{
                //    o.ValueLengthLimit = int.MaxValue;
                //    o.MultipartBodyLengthLimit = int.MaxValue;
                //    o.MemoryBufferThreshold = int.MaxValue;
                //});

                services.AddAutoMapper(typeof(MapperInitializer));
                services.AddTransient<IUnitOfWork, UnitOfWork>();
                services.AddTransient<Logger>();
                services.AddTransient<DbHelper>();
                services.AddTransient<Authenticator>();
               

                services.Configure<CookiePolicyOptions>(options =>
                {
                    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                    options.CheckConsentNeeded = context => false;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

                services.AddAuthorization(config =>
                {
                    var defaultBuider = new AuthorizationPolicyBuilder();
                    var defaultAuthPolicy = defaultBuider
                    .RequireAuthenticatedUser()
                    .Build();

                    config.DefaultPolicy = defaultAuthPolicy;
                });

                services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                })
                    .AddCookie("Cookies", options =>
                    {
                        options.Cookie.Name = "PrisonSystem";
                        options.Cookie.SameSite = SameSiteMode.None;

                        options.LoginPath = "/Account/Login";
                        options.LogoutPath = "/Account/Login";
                        options.ReturnUrlParameter = "Home/Index";
                    });
                services.AddAuthentication(options =>
                {
                    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                });

            }
            catch (Exception)
            {
                //ignore
            }

        }
     
    }
}
