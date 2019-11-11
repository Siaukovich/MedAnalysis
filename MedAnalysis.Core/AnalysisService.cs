using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using MedAnalysis.Core.Interfaces;
using MedAnalysis.Core.Models;
using MedAnalysis.DataAccess.Core;

namespace MedAnalysis.Core
{
    public class AnalysisService : IAnalysisService
    {
        private readonly IAnalysisRepository _repository;

        static AnalysisService()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(Assembly.GetExecutingAssembly()));
        }

        public AnalysisService(IAnalysisRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AnalysisResult>> GetPatientAnalysisAsync(int patientId)
        {
            var patient = await _repository.GetPatientAsync(patientId);

            return Mapper.Map<IEnumerable<AnalysisResult>>(patient.Analysis);
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            var patients = await _repository.GetPatientsAsync();

            return Mapper.Map<IEnumerable<Patient>>(patients);
        }

        public async Task<AnalysisResult> InsertAnalysisAsync(AnalysisResult analysis)
        {
            var patient = await _repository.GetPatientAsync(analysis.PatientId);

            var analysisDto = Mapper.Map<AnalysisResultDto>(analysis);

            analysisDto.Patient = patient;

            var result = await _repository.InsertAnalysisAsync(analysisDto);

            return Mapper.Map<AnalysisResult>(result);
        }

        public async Task<Patient> InsertPatientAsync(Patient patient)
        {
            var patientDto = Mapper.Map<PatientDto>(patient);
            var result = await _repository.InsertPatientAsync(patientDto);

            return Mapper.Map<Patient>(result);
        }
    }
}