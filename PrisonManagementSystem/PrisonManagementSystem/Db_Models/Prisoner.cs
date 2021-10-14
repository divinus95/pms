using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Db_Models
{
    public class Prisoner
    {
        [Key]
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
        public DateTime DateOfBirth { get; set; }
        public DateTime ExpectedJailTerm { get; set; }
        public DateTime DateRegistered { get; set; } = DateTime.Now;
        public string PassportURL { get; set; }
        public bool Active { get; set; } = true;
        public double Height { get; set; }
        public double Weight { get; set; }
        public string ColorOfEye { get; set; }

        [ForeignKey("CellId")]
        public int CellId { get; set; }
        public Cell Cell { get; set; }

        [ForeignKey("PrisonerClassificationId")]
        public int PrisonerClassificationId { get; set; }
        public PrisonerClassification PrisonerClassification { get; set; }

        public ICollection<VisitorForm> Visitors { get; set; }
        public ICollection<RemandStatus> RemandStatuses { get; set; }
    }
}
