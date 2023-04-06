using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LabC2
{
    class Student
    {
        public string Name { get; set; }
        public double AverageGrade { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "students.txt";
            List<Student> students = new List<Student>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(',');

                    students.Add(new Student()
                    {
                        Name = data[0],
                        AverageGrade = Convert.ToDouble(data[1])
                    });
                }
            }

            var filteredStudents = students.Where(s => s.AverageGrade > 80 && s.AverageGrade < 90);

            foreach (var student in filteredStudents)
            {
                Console.WriteLine("Name: {0}, Average Grade: {1}", student.Name, student.AverageGrade);
                Console.ReadLine();
            }
        }
    }
}

