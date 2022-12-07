using System;
 
 
namespace lab1
{
    class Printer
    {
        public void Print(string value)
        {
            Console.WriteLine(value);
        }
    }
 
    class PrinterBlue : Printer
    {
        public void Print(string value)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            base.Print(value);
        }
    }
 
 
    class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            printer.Print("str1");
 
            PrinterBlue printerBlue = new PrinterBlue();
            printerBlue.Print("str2");
 
            Console.ReadKey();
        }
    }
}