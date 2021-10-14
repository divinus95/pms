using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Db_Models
{
    public class Block
    {
        [Key]
        public int BlockId { get; set; }
        public string BlockName { get; set; }
        public string Description { get; set; }
        public string Facilities { get; set; }
        public string GenderType { get; set; }

        [ForeignKey("CareTakerId")]
        public int CareTakerId { get; set; }
        public CareTaker CareTaker { get; set; }


        //public ICollection<Cell> Cells { get; set; }
    }
}
