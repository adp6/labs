using System;
using System.Collections.Generic;

namespace _4
{
    class Program
    {
        delegate int StringLengthDelegate(string s);

        static void Main(string[] args)
        {
            List<string> strings = new List<string> { "hello", "world", "how", "are", "you" };

            StringLengthDelegate stringLength = s => s.Length;

            foreach (string s in strings)
            {
                int length = stringLength(s);
                Console.WriteLine("Length of " + s + " is " + length);
                Console.ReadLine();
            }
        }
    }
}
