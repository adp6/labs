using System;

namespace labC1
{
    class Program
    {

        delegate int Operation(int x, int y);

        delegate int MyDelegate();
        delegate double MyDel(MyDelegate[] a);

        static int GetRandom()
        {
            Random random = new Random();
            int number = random.Next(1, 10);
            Console.WriteLine(number);
            return number;
        }

        delegate int Arithmetic(int x, int y, int z);

        static void Main(string[] args)
        {
            // task 1
            Operation add = Add;
            Operation mul = Mul;
            Operation div = Div;
            Operation sub = Sub;





            int Sub(int x, int y) => x - y;
            int Add(int x, int y) => x + y;
            int Mul(int x, int y) => x * y;
            int Div(int x, int y) => x / y;


            Console.WriteLine(add(2,2));



            // task 2

            Console.WriteLine("Введiть число элементiв массива: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(new string('-', 50));

            var array = new MyDelegate[n];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = () => new MyDelegate(GetRandom)();
            }

            MyDel d = delegate (MyDelegate[] a)
            {
                double sr = 0;
                for (int i = 0; i < a.Length; i++)
                {
                    sr += a[i]();
                }
                return sr / array.Length;
            };


            //task 3
            Arithmetic res = Mid;
            int Mid(int x, int y, int z) => (x + y + z) / 3;
            Console.WriteLine(res(5, 12, 20));
            Console.ReadLine();

        }
    }
}
