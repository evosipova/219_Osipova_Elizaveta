using System;

namespace task2
{
    class Program
    {
        public static bool Function1(bool p, bool q)
        {
            return !(p && q) && (!(p | !q));
        }

        public static void Function2(out bool x, bool p, bool q)
        {
            x = !(p && q) && (!(p | !q));
        }

        static void Main()
        {
            Console.WriteLine(Function1(true, true));
            Console.WriteLine(Function1(true, false));
            Console.WriteLine(Function1(false, false));
            Console.WriteLine(Function1(false, true));

            bool x;
            Function2(out x, true, true);
            Console.WriteLine(x);
            Function2(out x, true, false);
            Console.WriteLine(x);
            Function2(out x, false, true);
            Console.WriteLine(x);
            Function2(out x, false, false);
            Console.WriteLine(x);
        }
    }
}