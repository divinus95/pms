using PrisonManagementSystem.Db_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrisonManagementSystem.Models
{
    public class OfficersInfoViewModel
    {
        public IList<OfficerRank> OfficerRanks { get; set; }
        public OfficerDto OfficerDto { get; set; }
    }
}
