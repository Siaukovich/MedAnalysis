using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedAnalysis.DataAccess.Core;

namespace MedAnalysis.DataAccess.File
{
    public class AnalysisRepositoryFile : IAnalysisRepository
    {
        public async Task<IEnumerable<PatientDto>> GetPatientsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PatientDto> GetPatientAsync(int patientId)
        {
            throw new NotImplementedException();
        }

        public async Task<AnalysisResultDto> UpsertAnalysisAsync(AnalysisResultDto analysis)
        {
            throw new NotImplementedException();
        }

        public async Task<PatientDto> UpsertPatientAsync(PatientDto patient)
        {
            throw new NotImplementedException();
        }
    }
}
