using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class DutyTypeViewModel
    {
        [DisplayName("Duty TYpe Name")]
        public int DutyTypeId { get; set; }
        public string Type { get; set; }
    }
}
