using Microsoft.AspNetCore.Mvc.Rendering;
using PrisonManagementSystem.Db_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class CreateDutyViewModel
    {
        public IList<DutyType> DutyTypes { get; set; }
        public IList<Duty> Duties { get; set; }
        public IList<Officer> Officers { get; set; }
        public DutyDto DutyDto { get; set; }      
        public DutyTypeViewModel DutyTypeDto { get; set; }      
    }

    public class DutiesViewModel
    {
        //public IList<Duty> Duties { get; set; }
        //public IList<Officer> Officers { get; set; }
        public SelectList Duties { get; set; }
        public SelectList Officers { get; set; }
    }
}
