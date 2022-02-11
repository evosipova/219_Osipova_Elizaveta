using System;
using System.Text;
namespace task2
{
    class Program   
    {
        static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        static string ConvertHex2Bin(string hex)
        {
            long tmp = Convert.ToInt64(hex, 16);
            var sb = new StringBuilder();
            while (tmp > 0)
            {
                sb.Append(tmp % 2);
                tmp /= 2;
            }
            sb.Append(tmp);
            return Reverse(sb.ToString());
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ConvertHex2Bin(Console.ReadLine()));
        }
    }
}