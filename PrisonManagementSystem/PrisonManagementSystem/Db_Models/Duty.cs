using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Db_Models
{
    public class Duty
    {
        [Key]
        public int DutyId { get; set; }
        public string DutyName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        [ForeignKey("DutyTypeId")]
        public int DutyTypeId { get; set; }
        public DutyType DutyType { get; set; }

        //many-to-many
        public ICollection<OfficerDuty> OfficerDuties { get; set; }


    }
}
