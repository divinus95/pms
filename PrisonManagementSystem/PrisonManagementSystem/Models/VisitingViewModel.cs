using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class VisitingViewModel
    {
        [DisplayName("Arrival Time")]
        public DateTime ArrivalTime { get; set; }
        [DisplayName("Departure Time")]
        public DateTime DepartedTime { get; set; }
    }
}
