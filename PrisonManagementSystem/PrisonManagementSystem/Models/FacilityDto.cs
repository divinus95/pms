using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class FacilityDto
    {
        public class CellDto
        {
            public string CellName { get; set; }
            public string CellGenderType { get; set; }
            public string RenovationIssue { get; set; }
            public bool isOccupied { get; set; } = false;
        }
        public class SegregationUnitDto
        {
            public string BlockName { get; set; }
            public string Description { get; set; }
            public string Facilities { get; set; }
        }
    }
}
