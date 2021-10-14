using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class PrisonerForm
    {
        public int PrisonerId { get; set; }
        public string FirstName { get; set; }
        public string OtherName { get; set; }
        public string LastName { get; set; }
        public string Offence { get; set; }
        public string Sentence { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string EmergencyContact { get; set; }
        public string HealthConditions { get; set; }
        public DateTime DateConvicted { get; set; }

        //[DateOfBirth(MinAge = 0, MaxAge = 120)]
        public DateTime DateOfBirth { get; set; }
        public DateTime ExpectedJailTerm { get; set; }
        public DateTime DateRegistered { get; set; } = DateTime.Now;
        public string PassportURL { get; set; }
        public IFormFile PassportPicture { get; set; }
        public bool Active { get; set; } = true;

        public int CellId { get; set; }
        public int PrisonerClassificationId { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string ColorOfEye { get; set; }


        public string CellName { get; set; }
        public string Classification { get; set; }
    }

    public class DateOfBirthAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var val = (DateTime)value;

            if (val.AddYears(MinAge) > DateTime.Now)
                return false;

            return (val.AddYears(MaxAge) > DateTime.Now);
        }
    }
}
