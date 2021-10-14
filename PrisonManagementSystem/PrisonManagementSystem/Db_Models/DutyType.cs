using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Db_Models
{
    public class DutyType
    {
        [Key]
        public int DutyTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<Duty> Duty { get; set; }
    }
}
