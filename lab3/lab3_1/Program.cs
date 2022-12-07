using System;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace lab3_1
{
    internal class Rectangle
    {
        private double side1 = 0;
        private double side2 = 0;
        private double area = 0;
        private double perimeter = 0;
        public double Area
        {
            get{ return area; }
        }
        public double Perimeter
        {
            get{ return perimeter; }
        }
        public Rectangle(double side1, double side2)
        {
            this.side1 = side1;
            this.side2 = side2;
        }
        public double AreaCalculator()
        {
            double areacal = side1 * side2;
            area = areacal;
            return areacal;
        }
        public double PerimeterCalculator()
        {
            double perimetercal = side1 * side2;
            perimeter = perimetercal;
            return perimetercal;
        }

    }
      internal class Program
    {
        static void Main(string[] args)
        {
            double side1;
            double side2;
            Console.Write("Side 1:");
            side1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Side 2:");
            side2 = Convert.ToDouble(Console.ReadLine());
            Rectangle rectangle = new Rectangle(side1,side2);
            rectangle.PerimeterCalculator();
            rectangle.AreaCalculator();
            Console.WriteLine($"Perimeter is - {rectangle.Perimeter}");
            Console.WriteLine($"Area is - {rectangle.Area}");
        }
    }
}