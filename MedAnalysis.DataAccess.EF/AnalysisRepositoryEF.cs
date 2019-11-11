using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using MedAnalysis.DataAccess.Core;
using MedAnalysis.DataAccess.EF.Configuration;

namespace MedAnalysis.DataAccess.EF
{
    public class AnalysisRepositoryEF : IAnalysisRepository
    {
        private readonly AnalysisContext _context;

        public AnalysisRepositoryEF(AnalysisContext context)
        {
            _context = context;
        }
         
        public async Task<IEnumerable<PatientDto>> GetPatientsAsync()
        {
            return await _context.Patients.Include(nameof(PatientDto.Analysis)).ToArrayAsync();
        }

        public async Task<PatientDto> GetPatientAsync(int patientId)
        {
            var patients = await _context.Patients.Where(p =>  p.Id == patientId).Include(nameof(PatientDto.Analysis)).ToArrayAsync();

            return patients.Single();
        }

        public async Task<AnalysisResultDto> InsertAnalysisAsync(AnalysisResultDto analysis)
        {
            _context.Analysis.AddOrUpdate(analysis);

            await _context.SaveChangesAsync();

            return analysis;
        }

        public async Task<PatientDto> InsertPatientAsync(PatientDto patient)
        {
            _context.Patients.AddOrUpdate(patient);

            await _context.SaveChangesAsync();

            return patient;
        }
    }
}