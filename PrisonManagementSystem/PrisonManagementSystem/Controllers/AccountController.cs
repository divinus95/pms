using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using PrisonManagementSystem.Config;
using PrisonManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static PrisonManagementSystem.Models.UserDto;

namespace ConsolidatedServers.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly Logger _logger;
        private readonly DbHelper _dbHelper;
        private readonly Authenticator _authenticator;
        readonly int UserID;
        public AccountController(Logger logger, DbHelper dHelper,
            Authenticator auth)
        {
            _logger = logger;
            _dbHelper = dHelper;
            _authenticator = auth;
            int.TryParse(User?.Claims?.FirstOrDefault(d => d.Type == ClaimTypes.Sid).Value, out UserID);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginSuccessful()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.UserName = model.UserName.Trim();
                    var user = (await _dbHelper.GetAllUsers()).FirstOrDefault(d => d.Username == model.UserName);
                    if (user != null)
                    {
                        bool isValidCredentials = _authenticator.IsValidPassword(model.Password, user.Password);
                        if (isValidCredentials)
                        {
                            await SetCookie(model, user.UserId);
                            return View("LoginSuccessful");
                        }
                    }
                }
                ModelState.AddModelError(string.Empty, "Incorrect username or password");
            }
            catch (Exception e)
            {
                _logger.logError(e);
            }
            return View(model);
        }

        private async Task SetCookie(UserLoginModel user, int UserId)
        {
            var claims = new List<Claim>
        {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Sid, UserId.ToString()),
        new Claim(ClaimTypes.Role, "Member"),
        };
            var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                // Refreshing the authentication session should be allowed.
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                IsPersistent = true,
                RedirectUri = "/Home/Index"
            };

            await HttpContext.SignInAsync(
           CookieAuthenticationDefaults.AuthenticationScheme,
           new ClaimsPrincipal(claimsIdentity),
           authProperties);
        }
        [Route("/Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
             CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete("PrisonSystem");
            return Redirect("/Login");
        }
    }
}