using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class OfficerForm
    {
        public int OfficerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResidentialAddress { get; set; }
        public string Phone { get; set; }
        public string EmergencyContact { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
        public int RankId { get; set; }
    }
}
