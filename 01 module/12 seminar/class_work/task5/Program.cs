using System;
using System.Text.RegularExpressions;

namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = "123, 39782, 56789";
            string ss = (@"[0-9]+");
            foreach (var i in Regex.Matches(s, ss))
            {
                Console.WriteLine(i + " ");
            }
        }
    }
}