using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n, n];
            var ch = 1; var i = 0; var j = -1;
            while (ch <= n * n)
            {
                while ((j + 1) < n && arr[i, j + 1] == 0)
                {
                    arr[i, j + 1] = ch;
                    ch++;
                    j++;
                }
                while ((i + 1) < n && arr[i + 1, j] == 0)
                {
                    arr[i + 1, j] = ch;
                    ch++;
                    i++;
                }
                while (j - 1 >= 0 && arr[i, j - 1] == 0)
                {
                    arr[i, j - 1] = ch;
                    ch++;
                    j--;
                }
                while (i - 1 >= 0 && arr[i - 1, j] == 0)
                {
                    arr[i - 1, j] = ch;
                    ch++;
                    i--;
                }
            }
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Console.Write($"{arr[i,j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}