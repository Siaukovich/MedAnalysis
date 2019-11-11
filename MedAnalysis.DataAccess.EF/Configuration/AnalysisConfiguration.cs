using System.Data.Entity.ModelConfiguration;
using MedAnalysis.DataAccess.Core;

namespace MedAnalysis.DataAccess.EF.Configuration
{
    public class AnalysisConfiguration : EntityTypeConfiguration<AnalysisResultDto>
    {
        public AnalysisConfiguration()
        {
            ToTable("analysis");
            HasKey(a => a.Id);
            Property(a => a.Name).IsRequired().IsUnicode().IsVariableLength();
            Property(a => a.Result).IsRequired().IsUnicode().IsVariableLength();
            Property(a => a.TakenAt).IsRequired().HasColumnType("Date");
            HasRequired(a => a.Patient).WithMany(u => u.Analysis).WillCascadeOnDelete(true);
        }
    }
}