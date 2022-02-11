using System;
namespace task1
{
    class Program
    {
        public delegate void CoordChanged(Dot dot);
        public class Dot
        {
            public double X
            {
                get; 
                private set;
            }

            public double Y
            {
                get;
                private set;
            }
            public Dot(double x, double y) => (X, Y) = (x, y);
            public event CoordChanged OnCoordChanged;
            Random random = new Random();
            public void DotFlow()
            {
                for (var i = 0; i < 10; i++)
                {
                    X = random.Next(-10, 11) + random.NextDouble();
                    Y = random.Next(-10, 11) + random.NextDouble();
                    if (X < 0 && Y < 0)
                    {
                        OnCoordChanged?.Invoke(this);
                    }
                }
            }
        }
        static void PrintInfo(Dot A)
        {
            Console.WriteLine($"X: {A.X:F3}\nY: {A.Y:F3}");
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());
            Dot D = new(x, y);
            D.OnCoordChanged += PrintInfo;
            D.DotFlow();
        }
    }
}