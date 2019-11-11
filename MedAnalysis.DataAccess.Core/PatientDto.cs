using System;
using System.Collections.Generic;

namespace MedAnalysis.DataAccess.Core
{
    public class PatientDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public ICollection<AnalysisResultDto> Analysis { get; set; }

        public PatientDto()
        {
            Analysis = new List<AnalysisResultDto>();
        }
    }
}