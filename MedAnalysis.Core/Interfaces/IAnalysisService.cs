using System.Collections.Generic;
using System.Threading.Tasks;
using MedAnalysis.Core.Models;

namespace MedAnalysis.Core.Interfaces
{
    public interface IAnalysisService
    {
        Task<IEnumerable<AnalysisResult>> GetPatientAnalysisAsync(int patientId);

        Task<IEnumerable<Patient>> GetPatientsAsync();

        Task<Patient> GetPatientAsync(int patientId);

        Task<AnalysisResult> InsertAnalysisAsync(AnalysisResult analysis);

        Task<Patient> InsertPatientAsync(Patient patient);
    }
}