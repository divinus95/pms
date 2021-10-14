using PrisonManagementSystem.Db_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class CreateVisitorDto
    {
        public List<Prisoner> Prisoners { get; set; }
        //public List<Visitor> Visitors { get; set; }
        public IList<Visitor> Visitors { get; set; }
        public IList<Visiting> Visitings { get; set; }
        public VisitorViewModel VisitorDtos { get; set; }
        public VisitingViewModel VisitingDtos { get; set; }
    }
}
