using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class Visitor
    {
      
        public int VisitorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ResidentAddress { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public bool Active { get; set; } = true;

     
        public int PrisonerId { get; set; }
        public string PrisonerFirstName { get; set; }
        public string PrisonerLastName { get; set; }
      

        //public ICollection<Visiting> Visitings { get; set; }
    }
}
