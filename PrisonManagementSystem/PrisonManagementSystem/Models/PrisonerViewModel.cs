using Microsoft.AspNetCore.Http;
using PrisonManagementSystem.Db_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static PrisonManagementSystem.Models.FacilityDto;

namespace PrisonManagementSystem.Models
{
    public class PrisonerViewModel
    {
        [Required(ErrorMessage = "FirstName is required")]
        [DisplayName("FirstName")]
        public string FirstName { get; set; }
        [DisplayName("Other Name")]
        public string OtherName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        [DisplayName("LastName")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Offence is required")]
        [DisplayName("Offence")]
        public string Offence { get; set; }
        [Required(ErrorMessage = "Sentence is required")]
        [DisplayName("Sentence Report")]
        public string Sentence { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required(ErrorMessage = "EmergencyContact is required")]
        [DisplayName("EmergencyContact")]
        public string EmergencyContact { get; set; }
        [Required(ErrorMessage = "Date Convicted is required")]
        [DisplayName("Date Convicted")]
        public DateTime DateConvicted { get; set; }

        //[DateOfBirth(MinAge = 0, MaxAge = 150)]
        [RegularExpression(@"^(?:0[1-9]|[12]\d|3[01])([\/.-])(?:0[1-9]|1[0-2])\1(?:19|20)\d\d$", ErrorMessage ="Date of birth is incorrect")]
        [Required(ErrorMessage = "Date Of Birth is required")]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Expected Jail Term is required")]
        [DisplayName("Expected Jail Term End Date")]
        public DateTime ExpectedJailTerm { get; set; }

        [Display(Name = "Passport Picture")]
        public IFormFile PassportPicture { get; set; }
        public int CellId { get; set; }
  
        public int PrisonerClassificationId { get; set; }
        //public string PassportURL { get; set; }
        [DisplayName("Any Health Conditions/Allergies")]
        public string HealthConditions { get; set; }

        [DisplayName("Height in Centimetres")]
        [Required(ErrorMessage = "Height is required")]
        public double Height { get; set; }
        [Required(ErrorMessage = "Weight is required")]
        [DisplayName("Weight in Kilogram")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Eye colour is required")]
        [DisplayName("Eye Colour")]
        public string ColorOfEye { get; set; }

    }

}
