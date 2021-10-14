using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Db_Models
{
    public class OfficerDuty
    {
        //a many-to-many relationship
  
        //[Key]
        //[ForeignKey("OfficerId")]
        public int OfficerId { get; set; }
        public Officer Officer { get; set; }

        //[Key]
        //[ForeignKey("DutyId")]
        public int DutyId { get; set; }
        public Duty Duty { get; set; }
    }
}
