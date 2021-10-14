using PrisonManagementSystem.Db_Models;
using PrisonManagementSystem.Models;
using System;
using System.Threading.Tasks;
using static PrisonManagementSystem.Models.FacilityDto;

namespace PrisonManagementSystem.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> Users { get; }
        IGenericRepository<Prisoner> Prisoners { get; }
        IGenericRepository<Block> SegregationUnits { get; }
        IGenericRepository<Cell> Cells { get; }
        IGenericRepository<PrisonerClassification> PrisonerClassifications { get; }
        IGenericRepository<Visitor> Visitors { get; }
        IGenericRepository<Visiting> Visitings { get; }
        IGenericRepository<OfficerRank> Ranks { get; }
        IGenericRepository<Officer> Officers { get; }
        IGenericRepository<DutyType> DutyTypes { get; }
        IGenericRepository<Duty> Duty { get; }
        IGenericRepository<OfficerDuty> OfficerDuty { get; }

        Task Save();
    }
}
