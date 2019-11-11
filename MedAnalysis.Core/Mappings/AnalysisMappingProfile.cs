using AutoMapper;
using MedAnalysis.Core.Models;
using MedAnalysis.DataAccess.Core;

namespace Users.BLL.Mappings
{
    public class AnalysisMappingProfile : Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<AnalysisResultDto, AnalysisResult>();
            CreateMap<AnalysisResult, AnalysisResultDto>();
        }
    }
}