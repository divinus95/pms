using PrisonManagementSystem.Db_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class CreatePrisonerDto
    {
        public List<Cell> Cells { get; set; }
        public List<PrisonerForm> inMates { get; set; }
        public PrisonerForm inMate { get; set; }
        public Prisoner remand { get; set; }
        public List<Prisoner> Remands { get; set; }
        public List<PrisonerClassification> Classifications { get; set; }
        public PrisonerViewModel PrisonerDtos { get; set; }
    }
}
