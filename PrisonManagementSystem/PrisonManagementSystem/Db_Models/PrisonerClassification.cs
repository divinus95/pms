using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Db_Models
{
    public class PrisonerClassification
    {
        [Key]
        public int PrisonerClassificationId { get; set; }
        public string  Classification { get; set; }


        public ICollection<Prisoner> Prisoners { get; set; }
    }
}
