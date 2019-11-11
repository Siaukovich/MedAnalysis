using System.Collections.Generic;
using System.Threading.Tasks;
using MedAnalysis.Core.Models;

namespace MedAnalysis.Core.Interfaces
{
    public interface IAnalysisService
    {
        Task<IEnumerable<AnalysisResult>> GetPatientAnalysisAsync(int patientId);

        Task<IEnumerable<Patient>> GetPatientsAsync();

        Task<AnalysisResult> UpsertAnalysisAsync(AnalysisResult analysis);

        Task<Patient> UpsertPatientAsync(Patient patient);
    }
}