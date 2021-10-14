using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Db_Models
{
    public class Visiting
    {
        [Key]
        public int VisitingId { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartedTime { get; set; }
        public bool Active { get; set; }

        [ForeignKey("VisitorId")]
        public int VisitorId { get; set; }
        public VisitorForm Visitor { get; set; }
    }
}
