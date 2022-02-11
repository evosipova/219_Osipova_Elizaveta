using System;

namespace task1
{
    class Program
    {
        delegate int Cast(double val);

        public static int C1(double x)
        {
            return (int) (x / 2) * 2;
        }

        public static int C2(double x)
        {
            return (int) (Math.Log10(x)) + 1;
        }

        static void Main(string[] args)
        {
            Cast cast1 = delegate(double x) { return (int) (x % 2) == 0 ? (int) x : (int) x + 1; };
            Cast cast2 = (x) => (int) (Math.Log10(x)) + 1;
            Console.WriteLine(cast1(123.7));
            Console.WriteLine(cast2(12.5)); Console.WriteLine();
            Cast cast3 = cast1 + cast2;
            Console.WriteLine(cast3?.Invoke(145.5));
            cast3 -= (x) => (int) (Math.Log10(x)) + 1;
            Console.WriteLine(cast3?.Invoke(114.2)); Console.WriteLine();
            Cast cast4 = C1;
            Cast cast5 = C2;
            Console.WriteLine(cast4.Invoke(11.7));
            Console.WriteLine(cast5.Invoke(110.7)); Console.WriteLine();
            Cast cast6 = cast4 + cast5;
            Console.WriteLine(cast6?.Invoke(16.7)); Console.WriteLine();
            foreach (Cast el in cast6.GetInvocationList())
            {
                Console.WriteLine(el?.Invoke(1156.7));
            }
        }
    }
}