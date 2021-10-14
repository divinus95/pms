using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class DutyDto
    {
        //[DisplayName("Duty Name")]
        //public int DutyId { get; set; }
        public string DutyName { get; set; }
        [DisplayName("Duty Description")]
        public string Description { get; set; }
    }
}
