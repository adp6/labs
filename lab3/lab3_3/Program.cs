using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace lab3_3
{
    internal class Point
    {
        private int x = 0;
        private int y = 0;
        private string name;
        public int X
        {
            get { return x; }
        }
        public int Y
        {
            get { return y; }
        }
        public string Name
        {
            get { return name; }
        }
        public Point(int x, int y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }
    }
     internal class Figure
    {
        private string name = "";
        public string Name { get { return name; } }
        Point A;
        Point B;
        Point C;
        Point D;
        Point E;
        public double LengthSide(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.X-B.X,2) + Math.Pow(A.Y-B.Y,2));
        }
        public void PerimeterCalculator()
        {
            double perimeter = LengthSide(A, B) + LengthSide(B, C) + LengthSide(C, D) + LengthSide(D, E) + LengthSide(E, A);
            Console.WriteLine($"Perimeter:{perimeter}");
        }
        public Figure(Point A, Point B, Point C)
        {
            name = "triangle";
            this.A = A;
            this.B = B;
            this.C = C;

        }
        public Figure(Point A, Point B, Point C, Point D)
        {
            name = "rectangle";
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
        }
        public Figure(Point A, Point B, Point C, Point D, Point E)
        {
            name = "pentagon";
            this.A = A;
            this.B = B;
            this.C = C;
            this.D = D;
            this.E = E;
        }
    }
     internal class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point(6, 9, "A");
            Point point2 = new Point(7, 9, "B");
            Point point3 = new Point(8, 7, "C");
            Point point4 = new Point(7, 5, "D");
            Point point5 = new Point(6, 5, "E");
            Figure figure = new Figure(point1, point2, point3, point4, point5);
            Console.WriteLine($"Name: {figure.Name}");
            figure.PerimeterCalculator();
        }
    }
}