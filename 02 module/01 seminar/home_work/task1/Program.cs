using System;
using System.Linq;

namespace task1
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x = 0, double y = 0) 
        {
            X = x; Y = y;
        }

        public double R
        {
            get 
            { 
                return (Math.Sqrt(X * X + Y * Y)); 
            }
        }
        
        double F
        {
            get
            {
                if (X > 0 && Y >= 0)
                    return Math.Atan(Y / X);
                else 
                if (X > 0 && Y < 0)
                    return Math.Atan(Y / X) + 2 * Math.PI;
                else 
                if (X < 0)
                    return Math.Atan(Y / X) + Math.PI;
                else 
                if (X == 0 && Y > 0)
                    return Math.PI / 2;
                else
                if (X == 0 && Y < 0)
                    return 3 * Math.PI / 2;
                else
                    return 0;
            }
        }
        public void PrintPoint() => Console.WriteLine($"Координата X: {X}\tКоордината Y: {Y}\n");

        public void Print()
        {
            PrintPoint();
            Console.WriteLine($"X = {X:F2}; Y = {Y:F2}; Ro = {R:F2}; Fi = {F:F2}");
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите координату X третьей точки: ");
            double point3x = double.Parse(Console.ReadLine());
            Console.Write("Введите координату Y третьей точки: ");
            double point3y = double.Parse(Console.ReadLine());
            
            while (point3x != 0 && point3y != 0)
            {
                Random random = new Random();
                Point point1 = new Point(random.Next(-1000,1000), random.Next(-1000,1000));
                Point point2 = new Point(random.Next(-1000,1000), random.Next(-1000,1000));
                point1.PrintPoint();
                point2.PrintPoint();
                Point point3 = new Point(point3x, point3y);
                Point[] points = new Point[] { point1, point2, point3 };
                
                var Array
                    = from pointpoint in points 
                    orderby (pointpoint.R) 
                    select pointpoint;
                            
                foreach (var el in Array) el.Print();
                Console.WriteLine();
                Console.Write("Введите координату X третьей точки: ");
                point3x = double.Parse(Console.ReadLine());
                Console.Write("Введите координату Y третьей точки: ");
                point3y = double.Parse(Console.ReadLine());
            }
        }
    }
}