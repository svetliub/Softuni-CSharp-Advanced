using System;
using System.Collections.Generic;
using System.Linq;

namespace p04_Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> departments = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Output")
            {
                List<string> tokens = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToList();
                string department = tokens[0];
                string doctorFullname = $"{tokens[1]} {tokens[2]}";
                string patient = tokens[3];

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new List<string>());
                }

                if (departments[department].Count < 60)
                {
                    departments[department].Add(patient);
                }

                if (!doctors.ContainsKey(doctorFullname))
                {
                    doctors.Add(doctorFullname, new List<string>());
                }

                doctors[doctorFullname].Add(patient);
            }

            string commandsArgs;

            while ((commandsArgs = Console.ReadLine()) != "End")
            {
                var inputCommand = commandsArgs.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (inputCommand.Count == 1)
                {
                    PrintDepartmentPatients(inputCommand[0], departments);
                }
                else
                {
                    if (int.TryParse(inputCommand[1], out int number))
                    {
                        int skipPatients = (int.Parse(inputCommand[1]) - 1) * 3;
                        PrintPatientsByRoom(skipPatients, inputCommand[0], departments);
                    }
                    else
                    {
                        string doctorName = inputCommand[0] + " " + inputCommand[1];
                        PrintDoctorPatients(doctorName, doctors);
                    }
                }
            }
        }

        private static void PrintPatientsByRoom(int skipPatients, string department, Dictionary<string, List<string>> departments)
        {
            foreach (var patient in departments[department].Skip(skipPatients).Take(3).OrderBy(p => p))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintDoctorPatients(string doctorName, Dictionary<string, List<string>> doctors)
        {
            foreach (var patient in doctors[doctorName].OrderBy(p => p))
            {
                Console.WriteLine(patient);
            }
        }

        private static void PrintDepartmentPatients(string department, Dictionary<string, List<string>> departments)
        {
            foreach (var patient in departments[department])
            {
                Console.WriteLine(patient);
            }
        }
    }
}
