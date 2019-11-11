using System;

namespace MedAnalysis.DataAccess.Core
{
    public class AnalysisResultDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Result { get; set; }

        public DateTime TakenAt { get; set; }

        public PatientDto Patient { get; set; }
    }
}