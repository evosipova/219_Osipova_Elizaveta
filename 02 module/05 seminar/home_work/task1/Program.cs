using System;

namespace task1
{
   public class Shape
    { 
        public virtual double Area()
        {
            return 0.0;
        }
        public override string ToString()
        {
            return $"Площадь = {Area():0.000}";
        }
    }
    
    class Circle : Shape
    {
        private double Rad { get; set; }

        public Circle(double rad)
        { Rad = rad; }
        public override double Area()
        {
            return 2 * Rad * Math.PI;
        }
    }

    class Cylinder : Shape
    {
        private double Rad { get; set; }
        private double H { get; set; }
        public Cylinder(double rad, double h)
        {
            Rad = rad;
            H = h;
        }
        public override double Area()
        {
            return (2 * Math.PI* Rad * (Rad + H));
        }
    }
    
    class Sphere : Shape
    {
        private double Rad { get; }
        public Sphere(double rad)
        { Rad = rad; }

        public override double Area()
        {
            return (4 * Math.PI * Rad * Rad);
        }
    }
    class Program
    {
        private static void Print(Shape[] shapeArray)
        {
            foreach (var el in shapeArray)
            {
                if (el is Circle)
                {
                    Console.Write("Круг         ");
                }
                else if (el is Cylinder)
                {
                    Console.Write("Цилиндр      ");
                }
                else
                {
                    Console.Write("Сфера        ");
                }
                Console.WriteLine(el); 
            }
        }
        
        static void Main(string[] args)
        {
            Random rnd = new();
            var s1 = rnd.Next(3, 5);
            var s2 = rnd.Next(3, 5);
            var s3 = rnd.Next(3, 5);
            
            Shape[] newArray = new Shape[s1 + s2 + s3];

            for (var i = 0; i < s1; i++)
            {
                newArray[i] = new Circle(rad: rnd.Next(1, 10));
            }

            for (var i = s1; i < s1 + s2; i++)
            {
                newArray[i] = new Cylinder(rad: rnd.Next(1, 10), h: rnd.Next(1, 10));
            }

            for (var i = s2; i < s1 + s2 + s3; i++)
            {
                newArray[i] = new Sphere(rad: rnd.Next(1, 10));
            }
            
            Array.Sort(newArray, Check);
            Print(newArray);
            
            static int Check(Shape k1, Shape k2)
            {
                if ((k1 is Sphere) && (k2 is Circle))
                { return 1; }
                if ((k1 is Sphere) && (k2 is Cylinder))
                { return 1; }
                if ((k1 is Sphere) && (k2 is Sphere))
                { return 0; }
                if ((k1 is Cylinder) && (k2 is Circle))
                { return 1; }

                if ((k1 is Cylinder) && (k2 is Cylinder))
                { return 0; }

                if ((k1 is Circle) && (k2 is Circle))
                { return 0; }
                return -1;
            }
        }
    }
}