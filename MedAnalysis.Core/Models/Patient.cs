using System;
using System.Collections.Generic;

namespace MedAnalysis.Core.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public List<AnalysisResult> Analysis { get; set; }

        public Patient()
        {
            Analysis = new List<AnalysisResult>();
        }
    }
}