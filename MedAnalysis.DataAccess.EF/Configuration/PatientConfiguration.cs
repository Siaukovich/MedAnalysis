using System.Data.Entity.ModelConfiguration;
using MedAnalysis.DataAccess.Core;

namespace MedAnalysis.DataAccess.EF.Configuration
{
    public class PatientConfiguration : EntityTypeConfiguration<PatientDto>
    {
        public PatientConfiguration()
        {
            ToTable("patients");
            HasKey(u => u.Id);
            Property(u => u.FirstName).IsRequired().IsUnicode().IsVariableLength();
            Property(u => u.LastName).IsRequired().IsUnicode().IsVariableLength();
            Property(u => u.Birthdate).IsRequired().HasColumnType("Date");
            HasMany(u => u.Analysis).WithRequired(a => a.Patient);
        }
    }
}