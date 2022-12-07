using System;

namespace lb2_3
{
    class User
    {
        private string Login { get; set; }
        private string Name { get; set; }
        private string Surname { get; set; }
        private int Age { get; set; }
        private string Date_of_completion { get;}

        public User(string login,string name ,string surname,int age )
        {
            this.Login = login;
            this.Name = name;
            this.Surname = surname;
            this.Age = age;
            DateTime dateTime = new DateTime();
            Console.WriteLine($"Login :{Login}\n" +
                $"Name : {Name}\n" +
                $"Surname : {Surname}\n" +
                $"Age : {Age}\n" +
                $"Date of completion : {DateTime.Now}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Login : ");
            string login = Console.ReadLine();
            Console.Write("Name : ");
            string name = Console.ReadLine();
            Console.Write("Surname : ");
            string surname = Console.ReadLine();
            Console.Write("Age : ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("------------------------------------");
            User user = new User(login,name,surname,age);
        }
    }
}