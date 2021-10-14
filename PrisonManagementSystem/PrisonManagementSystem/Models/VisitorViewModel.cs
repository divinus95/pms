using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class VisitorViewModel
    {
        [DisplayName("Visitor Name")]
        public int VisitorId { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        [DisplayName("LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Residential Address is required")]
        [DisplayName("Residential Address")]
        public string ResidentAddress { get; set; }
        [Required(ErrorMessage = "Phone Number is required")]
        [DisplayName("Phone Number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Prisoner To be Visited")]
        public int PrisonerId { get; set; }
    }
}
