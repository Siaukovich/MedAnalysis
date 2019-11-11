using System.Data.Entity;
using MedAnalysis.DataAccess.Core;

namespace MedAnalysis.DataAccess.EF.Configuration
{
    public class AnalysisContext : DbContext
    {
        public AnalysisContext() : base("name=analysisdb")
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<PatientDto> Patients { get; set; }

        public DbSet<AnalysisResultDto> Analysis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PatientConfiguration());
            modelBuilder.Configurations.Add(new AnalysisConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
