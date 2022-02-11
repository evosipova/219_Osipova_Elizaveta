using System;

namespace task1
{
    delegate int Cast(double n);
    class Program
    {
        static void Main(string[] args)
        {
            Cast first = delegate(double k)
            { return Math.Floor(k) % 2 == 0 ? (int)k : (int)(k + 1);};
            Console.WriteLine(first(1.5));
            Console.WriteLine();
            Cast second = (double x) => ((int) x).ToString().Length;
            Console.WriteLine(second(697.970));
            Console.WriteLine(second(29.14));
            Console.WriteLine();
            
            Cast th = first + second;
            Console.WriteLine(th?.Invoke(39.25));
            Console.WriteLine();
            
            th?.Invoke(5.67);
        }
    }
}