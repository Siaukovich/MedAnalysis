using System;

namespace MedAnalysis.Core.Models
{
    public class AnalysisResult
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Result { get; set; }

        public DateTime? TakenAt { get; set; }

        public int PatientId { get; set; }
    }
}