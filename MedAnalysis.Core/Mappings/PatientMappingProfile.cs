using AutoMapper;
using MedAnalysis.Core.Models;
using MedAnalysis.DataAccess.Core;

namespace Users.BLL.Mappings 
{
    public sealed class PatientMappingProfile : Profile
    {
        public PatientMappingProfile()
        {
            CreateMap<PatientDto, Patient>();
            CreateMap<Patient, PatientDto>();
        }
    }
}
