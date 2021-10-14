using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Db_Models
{
    public class CareTaker
    {
        [Key]
        public int CareTakerId { get; set; }
        public string CareTakerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


        public ICollection<Block> Block { get; set; }
    }
}
