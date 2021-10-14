using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PrisonManagementSystem.Db_Models;

namespace PrisonManagementSystem.Config
{
    public class AppDbContext: IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
                  : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //many-to-many
            builder.Entity<OfficerDuty>()
       .HasKey(bc => new { bc.DutyId, bc.OfficerId });
            builder.Entity<OfficerDuty>()
                .HasOne(bc => bc.Duty)
                .WithMany(b => b.OfficerDuties)
                .HasForeignKey(bc => bc.DutyId);
            builder.Entity<OfficerDuty>()
                .HasOne(bc => bc.Officer)
                .WithMany(c => c.OfficerDuties)
                .HasForeignKey(bc => bc.OfficerId);
        }
     
        public DbSet<CareTaker> CareTaker { get; set; }
        public DbSet<Cell> Cell { get; set; }
        public DbSet<Officer> Officer { get; set; }
        public DbSet<OfficerRank> OfficerRank { get; set; }
        public DbSet<Prisoner> Prisoner { get; set; }
        public DbSet<PrisonerClassification> PrisonerClassification { get; set; }
        public DbSet<Block> Block { get; set; }
        public DbSet<Visiting> Visiting { get; set; }
        public DbSet<VisitorForm> Visitor { get; set; }
        public DbSet<Duty> Duty { get; set; }
        public DbSet<RemandStatus> RemandStatus { get; set; }
        public DbSet<OfficerDuty> OfficerDuty { get; set; }//join table

    }

}
