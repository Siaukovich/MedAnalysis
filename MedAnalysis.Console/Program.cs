using System;
using System.Globalization;
using System.Text;
using DependencyResolver;
using MedAnalysis.Core.Interfaces;
using MedAnalysis.Core.Models;
using Ninject;

namespace MedAnalysis.Console
{
    class Program
    {
        private static readonly IKernel Kernel;

        static Program()
        {
            Kernel = new StandardKernel();
            Kernel.Resolve();

            System.Console.OutputEncoding = Encoding.GetEncoding("Cyrillic");
            System.Console.InputEncoding  = Encoding.GetEncoding("Cyrillic");
        }

        static void Main()
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            while (true)
            {
                System.Console.WriteLine("Вы в главном меню.");
                System.Console.WriteLine("1) Вывести всех пациентов");
                System.Console.WriteLine("2) Вывести все анализы пациента");
                System.Console.WriteLine("3) Создать нового пациента");
                System.Console.WriteLine("4) Создать новый анализ");
                System.Console.WriteLine("0) Выйти");

                var input = ReadInt(0, 4);

                if (input == 0)
                {
                    System.Console.WriteLine("До свидания.");
                    return;
                }

                switch (input)
                {
                    case 1: ShowAllPatients(); break;
                    case 2: ShowAllPatientAnalysis(); break;
                    case 3: CreateNewPatient(); break;
                    case 4: CreateNewAnalysis(); break;
                }
            }
        }

        private static void ShowAllPatients()
        {
            var service = Kernel.Get<IAnalysisService>();

            int i = 0;
            foreach (var patient in service.GetPatientsAsync().Result)
            {
                i++;
                System.Console.WriteLine($"{i})");
                System.Console.WriteLine($"Номер пациента: {patient.Id}");
                System.Console.WriteLine($"Имя: {patient.FirstName} {patient.LastName}");
                System.Console.WriteLine($"Дата рождения: {GetFormattedDate(patient.Birthdate)}");
                System.Console.WriteLine($"Количество анализов: {patient.Analysis.Count}");
                System.Console.WriteLine();
            }

            System.Console.WriteLine($"Всего {i} пациентов");
            System.Console.WriteLine();
        }

        public static void ShowAllPatientAnalysis()
        {
            System.Console.WriteLine("Введите номер пациента.");
            var patientNumber = ReadInt();
            
            var service = Kernel.Get<IAnalysisService>();
            int i = 0;
            foreach (var analysis in service.GetPatientAnalysisAsync(patientNumber).Result)
            {
                i++;
                System.Console.WriteLine($"{i})");
                System.Console.WriteLine($"Номер: {analysis.Id}");
                System.Console.WriteLine($"Взят: {GetFormattedDate(analysis.TakenAt)}");
                System.Console.WriteLine($"Название: {analysis.Name}");
                System.Console.WriteLine($"Результат: {analysis.Result}");
                System.Console.WriteLine();
            }

            System.Console.WriteLine($"Всего анализов - {i}");
            System.Console.WriteLine();
        }

        public static void CreateNewPatient()
        {
            System.Console.WriteLine("Создание нового пациента.");

            var name = ReadPatientName();

            var birthDate = ReadDateTime("Введите дату рождения (дд-мм-гггг): ");

            var newPatient = new Patient
            {
                FirstName = name.firstName,
                LastName = name.lastName,
                Birthdate = birthDate
            };

            var service = Kernel.Get<IAnalysisService>();
            service.InsertPatientAsync(newPatient).Wait();

            System.Console.WriteLine("Успешно добавлено.");
        }

        public static void CreateNewAnalysis()
        {
            System.Console.WriteLine("Создание нового анализа.");

            var patientId = ReadInt("Введите номер пациента: ");
            var name = ReadString("Введите имя: ");
            var result = ReadString("Введите результат: ");
            var takenAt = ReadDateTime("Введите дату взятия анализа (дд-мм-гггг): ");

            var newAnalysis = new AnalysisResult
            {
                Name = name,
                Result = result,
                TakenAt = takenAt,
                PatientId = patientId
            };

            var service = Kernel.Get<IAnalysisService>();
            service.InsertAnalysisAsync(newAnalysis).Wait();

            System.Console.WriteLine("Успешно добавлено.");
        }

        private static (string firstName, string lastName) ReadPatientName()
        {
            while (true)
            {
                System.Console.Write("Введите имя (два слова через пробел): ");
                var name = System.Console.ReadLine();
                if (name != null && name.Length > 3)
                {
                    var nameParts = name.Split();
                    if (nameParts.Length == 2)
                    {
                        return (nameParts[0], nameParts[1]);
                    }
                }

                System.Console.WriteLine("Неверный ввод, попробуйте ещё раз.");
            }
        }

        static string ReadString(string prompt)
        {
            while (true)
            {
                System.Console.Write(prompt);
                var name = System.Console.ReadLine();
                if (name != null)
                {
                    return name;
                }

                System.Console.WriteLine("Неверный ввод, попробуйте ещё раз.");
            }
        }

        private static DateTime ReadDateTime(string prompt)
        {
            while (true)
            {
                System.Console.Write(prompt);
                var birthdate = System.Console.ReadLine();
                try
                {
                    return DateTime.ParseExact(birthdate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                }
                catch
                {
                    System.Console.WriteLine("Неверный ввод, попробуйте ещё раз.");
                }
            }
        }

        private static int ReadInt(int min, int max)
        {
            while (true)
            {
                System.Console.Write("Ввод: ");
                var input = System.Console.ReadLine();
                System.Console.WriteLine();
                if (int.TryParse(input, out var res) || (res < min || max < res ))
                {
                    return res;
                }

                System.Console.WriteLine("Неверный ввод, попробуйте ещё раз.");
            }
        }

        private static int ReadInt(string prompt = "Ввод")
        {
            while (true)
            {
                System.Console.Write(prompt);
                var input = System.Console.ReadLine();
                System.Console.WriteLine();
                if (int.TryParse(input, out var res))
                {
                    return res;
                }

                System.Console.WriteLine("Неверный ввод, попробуйте ещё раз.");
            }
        }

        private static string GetFormattedDate(DateTime date) => $"{date:dd-MM-yyyy}";
    }
}
