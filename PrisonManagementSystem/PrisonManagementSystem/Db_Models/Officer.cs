using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Db_Models
{
    public class Officer
    {
        [Key]
        public int OfficerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResidentialAddress { get; set; }
        public string Phone { get; set; }
        public string EmergencyContact { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        [ForeignKey("RankId")]
        public int RankId { get; set; }
        public OfficerRank Rank { get; set; }

        //many-to-many
        public ICollection<OfficerDuty> OfficerDuties { get; set; }
    }
}
