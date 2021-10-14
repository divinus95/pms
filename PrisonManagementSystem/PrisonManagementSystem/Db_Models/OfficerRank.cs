using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Db_Models
{
    public class OfficerRank
    {
        [Key]
        public int RankId { get; set; }
        public string Title { get; set; }

        public ICollection<Officer> Officers { get; set; }
    }
}
