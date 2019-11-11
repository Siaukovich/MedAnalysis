using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedAnalysis.DataAccess.Core
{
    public interface IAnalysisRepository
    {
        Task<IEnumerable<PatientDto>> GetPatientsAsync();

        Task<PatientDto> GetPatientAsync(int patientId);

        Task<AnalysisResultDto> InsertAnalysisAsync(AnalysisResultDto analysis);

        Task<PatientDto> InsertPatientAsync(PatientDto patient);
    }
}