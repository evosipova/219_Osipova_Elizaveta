using System;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
            string u = Console.ReadLine();
            string r = Console.ReadLine();
            int uu = int.Parse(u);
            int rr = int.Parse(r);
            Console.WriteLine(uu / rr);
            Console.WriteLine(uu * uu / rr);
        }
    }
}