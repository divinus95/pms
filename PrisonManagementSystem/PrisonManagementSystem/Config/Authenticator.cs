using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;


namespace PrisonManagementSystem.Config
{
    public class Authenticator
    {
        private readonly IHostingEnvironment _env;
        private readonly Logger _logger;

        public Authenticator(IHostingEnvironment env, Logger logger)
        {
            _env = env;
            _logger = logger;
        }

        public bool IsValidPassword(string rawPassword, string hashedPassword)
        {
            //if (_env != null && _env.IsDevelopment()) return true;
            try
            {
                return AuthUtils.GetSHA1HashData(rawPassword) == hashedPassword;
            }
            catch
            {
                return false;
            }
        }
    }
}

