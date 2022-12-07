using System;

namespace lb2_2
{
    class Employee
    {
        private string Name { get; set; }
        private string Surname { get; set; }
        private string Job { get; set; }
        private int Experience { get; set; }
        
        public Employee(string name ,string surname,string job,int experience)
        {
            this.Name = name;
            this.Surname = surname;
            this.Experience = experience;
            this.Job = job;
        }
        public void Salary_and_tax_calculator()
        {
            double salary;
            if (this.Job == "software engineer")
            {
                salary = 1200;
                Console.WriteLine($"Name: {Name} {Surname}\n" +
             $"Salary : {salary = salary + (200 * this.Experience)}$\n" +
             $"ПДФО :{salary * 0.18} ВЗ: {salary * 0.015 } ПСП: {salary * 0.22}");
            }
            else if (this.Job == "designer")
            {
                salary = 900;
                Console.WriteLine($"Name: {Name} {Surname}\n" +
             $"Salary : {salary = salary + (100 * this.Experience)}$\n" +
             $"ПДФО :{salary * 0.18} ВЗ: {salary * 0.015 } ПСП: {salary * 0.22}");
            }
            else if (this.Job == "3d artist")
            {
                salary = 850;
                Console.WriteLine($"Name: {Name} {Surname}\n" +
             $"Salary : {salary = salary + (150 * this.Experience)}$\n" +
             $"ПДФО :{salary * 0.18}$ ВЗ: {salary * 0.015 }$ ПСП: {salary * 0.22}$");
            }
            else
            {
                Console.WriteLine("the job you entered isn't in the list");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Name : ");
            string name  = Console.ReadLine();
            Console.Write("Surname : ");
            string surname = Console.ReadLine();
            Console.Write("Job (software engineer , designer , 3d artist): ");
            string job = Console.ReadLine();
            Console.Write("Experience (in years) : ");
            int experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("-----------------------------");
            Employee employee = new Employee(name, surname,job,experience);
            employee.Salary_and_tax_calculator();
            Console.ReadKey();
        }
    }
}