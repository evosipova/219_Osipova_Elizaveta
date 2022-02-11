using System;
using System.Collections.Generic;
using task1;
namespace task1
{
    class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double Distance(Point k)
        {
            return Math.Sqrt(Math.Pow(this.X - k.X, 2) + Math.Pow(this.Y - k.Y, 2));
        }
        public override string ToString()
        {
            return $"Point({X};{Y})";
        }
    }
    class Circle : IComparable<Circle>
    {
        public double Rad { get; set; }
        public Point center;
        public Circle(double x, double y, double rad)
        {
            Rad = rad;
            center = new Point(x, y);
        }
        public override string ToString()
        {
            return $"Радиус: {this.Rad}. Центр: {this.center}.";
        }
        public int CompareTo(Circle circle)
        {
            if (this.Rad * this.center.Distance(new Point(0, 0)) < circle.Rad * circle.center.Distance(new Point(0, 0)))
            {
                return -1;
            }
            if (this.Rad * this.center.Distance(new Point(0, 0)) > circle.Rad * circle.center.Distance(new Point(0, 0)))
            {
                return 1;
            }
            return 0;
        }
    }
    struct PointStruct
    {
        public double X;
        public double Y;
        public PointStruct(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double Distance(PointStruct k)
        {
            return Math.Sqrt(Math.Pow(this.X - k.X, 2) + Math.Pow(this.Y - k.Y, 2));
        }
    }
    struct CircleStruct
    {
        public double Rad;
        public PointStruct center;
        public CircleStruct(double x, double y, double rad)
        {
            center = new PointStruct(x, y);
            Rad = rad;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            Circle[] circleArray = new Circle[5];
            for (int i = 0; i < 5; i++)
            {
                circleArray[i] = new Circle(random.Next() + random.NextDouble(), random.Next() + random.NextDouble(), random.Next() + random.NextDouble());
            }
            Array.ForEach(circleArray, elCircle => Console.WriteLine(elCircle));
            
            Console.WriteLine("------------------------------");
            
            Array.Sort(circleArray, (circle1, circle2) =>
                (circle1.Rad * circle1.center.Distance(new Point(0, 0))).CompareTo(circle2.Rad * circle2.center.Distance(new Point(0, 0))));
            Array.ForEach(circleArray, elCircle => Console.WriteLine(elCircle));
            
            Console.WriteLine("------------------------------");
            
            Array.Sort(circleArray, delegate (Circle circle1, Circle circle2) 
            {
                if (circle1.Rad * circle1.center.Distance(new Point(0, 0)) < circle2.Rad * circle2.center.Distance(new Point(0, 0))) 
                    return -1; 
                if (circle1.Rad * circle1.center.Distance(new Point(0, 0)) > circle2.Rad * circle2.center.Distance(new Point(0, 0)))
                    return 1;
                return 0;
            });
            Array.ForEach(circleArray, elCircle => Console.WriteLine(elCircle));
            
            Console.WriteLine("------------------------------");
            
            Array.Sort(circleArray);
            Array.ForEach(circleArray, elCircle => Console.WriteLine(elCircle));
            
            Console.WriteLine("------------------------------");
        }
    }
}