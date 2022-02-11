using System;
namespace task5
{
    class Program   
    {
        static void Main(string[] args)
        {
            bool flag = true;
            double n = 1; double sum = 0;
            double lastsum = 0; double nextsum = 0;
            while (flag)
            {
                nextsum = 1 / (n * (n + 1) * (n + 2));
                sum = sum + nextsum;
                if (lastsum > nextsum)
                {
                    flag = false;
                    break;
                }
                lastsum = nextsum;
                n += 1;
                Console.WriteLine(sum);
            }
        }
    }
}