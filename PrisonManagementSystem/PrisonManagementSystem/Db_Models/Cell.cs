using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Db_Models
{
    public class Cell
    {
        [Key]
        public int CellId { get; set; }
        public string CellName { get; set; }
        public string RenovationIssue { get; set; }
        public bool isOccupied { get; set; }

        //[ForeignKey("BlockId")]
        //public int BlockId { get; set; }
        //public Block Block { get; set; }

        public ICollection<Prisoner> Prisoners { get; set; }
    }
}
