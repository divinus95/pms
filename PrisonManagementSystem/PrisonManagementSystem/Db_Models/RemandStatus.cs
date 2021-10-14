using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Db_Models
{
    public class RemandStatus
    {
        [Key]
        public int Id { get; set; }
        public string CaseStatement { get; set; }
        public DateTime  NextScheduledCourtDate { get; set; }
        public bool Active { get; set; }

        [ForeignKey("PrisonerId")]
        public int PrisonerId { get; set; }
        public Prisoner Prisoner { get; set; }
    }
}
