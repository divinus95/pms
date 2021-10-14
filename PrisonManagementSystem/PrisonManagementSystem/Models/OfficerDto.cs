using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class OfficerDto
    {
        [Required(ErrorMessage ="Officer First Name is required")]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Officer Last Name is required")]
        [DisplayName("LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage ="Officer's Resident Address is required")]
        [DisplayName("Residential Address")]
        public string ResidentialAddress { get; set; }
        [DisplayName("Phone Number")]
        public string Phone { get; set; }

        [DisplayName("Emergency Contact")]
        public string EmergencyContact { get; set; }
        [DisplayName("Gender")]
        public string Gender { get; set; }
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [DisplayName("Officer's Rank")]
        public int RankId { get; set; }
        public bool Active { get; set; }
    }
}
