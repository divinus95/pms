using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class UserDto
    {
        public class UserLoginModel
        {
            //[EmailAddress]
            //public string Email { get; set; }

            [Required(ErrorMessage = "Username is required")]
            [DisplayName("Username")]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
        public class UserRegistrationModel
        {
            [Required(ErrorMessage = "Email is required")]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            [DisplayName("First Name")]
            public string FirstName { get; set; }
            [DisplayName("Last Name")]
            public string LastName { get; set; }
            [DisplayName("Username")]
            public string Username { get; set; }
       
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            public bool Active { get; set; }
        }

        public class ForgotPasswordDto
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public class ResetPasswordModel
        {
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            public string Email { get; set; }
            public string Token { get; set; }
        }

        public class TwoStepModel
        {
            [Required]
            [DataType(DataType.Text)]
            public string TwoFactorCode { get; set; }
            public bool RememberMe { get; set; }
        }
    }
}
