
using PrisonManagementSystem.Config;
using PrisonManagementSystem.Db_Models;
using PrisonManagementSystem.Interfaces.Repositories;
using PrisonManagementSystem.Models;
using PrisonManagementSystem.Repositories;
using System;
using System.Threading.Tasks;
using static PrisonManagementSystem.Models.FacilityDto;

namespace PrisonManagementSystem.Implementation.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IGenericRepository<User> _User;
        private IGenericRepository<Prisoner> _Prisoner;
        private IGenericRepository<Block> _Block;
        private IGenericRepository<PrisonerClassification> _Classification;
        private IGenericRepository<Cell> _Cell;
        private IGenericRepository<Visitor> _Visitors;
        private IGenericRepository<Visiting> _Visitings;
        private IGenericRepository<OfficerRank> _Ranks;
        private IGenericRepository<Officer> _Officers;
        private IGenericRepository<DutyType> _DutyTypes;
        private IGenericRepository<Duty> _Duty;
        private IGenericRepository<OfficerDuty> _OfficerDuty;
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<User> Users => _User ??= new GenericRepository<User>(_context);
        public IGenericRepository<Prisoner> Prisoners => _Prisoner ??= new GenericRepository<Prisoner>(_context);
        public IGenericRepository<Block> SegregationUnits => _Block ??= new GenericRepository<Block>(_context);
        public IGenericRepository<Cell> Cells => _Cell ??= new GenericRepository<Cell>(_context);
        public IGenericRepository<PrisonerClassification> PrisonerClassifications => _Classification ??= new GenericRepository<PrisonerClassification>(_context);
        public IGenericRepository<Visitor> Visitors => _Visitors ??= new GenericRepository<Visitor>(_context);
        public IGenericRepository<Visiting> Visitings => _Visitings ??= new GenericRepository<Visiting>(_context);
        public IGenericRepository<OfficerRank> Ranks => _Ranks ??= new GenericRepository<OfficerRank>(_context);
        public IGenericRepository<Officer> Officers => _Officers ??= new GenericRepository<Officer>(_context);
        public IGenericRepository<DutyType> DutyTypes => _DutyTypes ??= new GenericRepository<DutyType>(_context);
        public IGenericRepository<Duty> Duty => _Duty ??= new GenericRepository<Duty>(_context);
        public IGenericRepository<OfficerDuty> OfficerDuty => _OfficerDuty ??= new GenericRepository<OfficerDuty>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
