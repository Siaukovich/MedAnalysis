using System;
using System.Data.Entity;
using MedAnalysis.DataAccess.Core;

namespace MedAnalysis.DataAccess.EF.Configuration
{
    public class DbInitializer : CreateDatabaseIfNotExists<AnalysisContext>
    {
        protected override void Seed(AnalysisContext context)
        {
            var a1 = new AnalysisResultDto { Name = "Анализ крови", Result = "Уровни тромбоцитов, сахара, лейкоцитов в норме.", TakenAt = new DateTime(2019, 5, 10) };
            var a2 = new AnalysisResultDto { Name = "Анализ на грибы", Result = "Грибов не обнаружено.", TakenAt = new DateTime(2019, 6, 11) };
            var a3 = new AnalysisResultDto { Name = "Анализ крови на алкоголь", Result = "Концентрация спирта в крови - 0.57 промилле.", TakenAt = new DateTime(2018, 3, 20) };

            var u1 = new PatientDto
                         {
                             Analysis = new[] { a1, a2 },
                             Birthdate = new DateTime(1990, 12, 10),
                             FirstName = "Иван",
                             LastName = "Иванов"
                         };

            var u2 = new PatientDto
                         {
                             Analysis = new[] { a3 },
                             Birthdate = new DateTime(2000, 12, 10),
                             FirstName = "Пётр",
                             LastName = "Петров"
                         };

            context.Patients.Add(u1);
            context.Patients.Add(u2);

            base.Seed(context);
        }
    }
}
