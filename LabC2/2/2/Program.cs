using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _2
{
    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "employees.txt";
            List<Employee> employees = new List<Employee>();

            // Читання даних з файлу
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] data = line.Split(',');

                    employees.Add(new Employee()
                    {
                        Name = data[0],
                        Salary = Convert.ToInt32(data[1])
                    });
                }
            }

            // Сортування даних за зарплатою
            var sortedEmployees = employees.OrderBy(e => e.Salary);

            // Виведення результатів
            foreach (var employee in sortedEmployees)
            {
                Console.WriteLine("Name: {0}, Salary: {1}", employee.Name, employee.Salary);
                Console.ReadLine();
            }
        }
    }
}
