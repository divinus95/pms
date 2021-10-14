using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PrisonManagementSystem.Db_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Config
{
    public class CustomPasswordValidator<TUser> : IPasswordValidator<TUser> where TUser : class
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            //var username = await manager.GetUserNameAsync(user);
            var username = await manager.GetEmailAsync(user);
            if (username.ToLower().Equals(password.ToLower()))
                return IdentityResult.Failed(new IdentityError { Description = "Email and Password can't be the same.", Code = "SameUserPass" });

            if (password.ToLower().Contains("password"))
                return IdentityResult.Failed(new IdentityError { Description = "The word password is not allowed for the Password.", Code = "PasswordContainsPassword" });

            return IdentityResult.Success;
        }
    }
}
