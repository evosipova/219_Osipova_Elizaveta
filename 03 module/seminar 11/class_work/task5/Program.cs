using System;
using System.IO;
namespace task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            using (StreamWriter writer =
                new StreamWriter(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; ++i)
                    writer.Write((char)rnd.Next(1, 101));
            }

            int[] arr = new int[10];
            using (StreamReader reader
                = new StreamReader(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; ++i)
                {
                    arr[i] = reader.Read();
                    Console.WriteLine(arr[i]);
                }
                int.TryParse(Console.ReadLine(), out int n);
                int min = 1000;
                int ind = 0;
                for (int i = 0; i < 10; ++i)
                {
                    if (Math.Abs(n - arr[i]) < min)
                    {
                        min = Math.Abs(n - arr[i]);
                        ind = i;
                    }
                }
                arr[ind] = n;
            }

            using (StreamWriter writer
                = new StreamWriter(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; ++i)
                    writer.Write((char)arr[i]);
            }
            using (StreamReader reader
                = new StreamReader(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; ++i)
                {
                    arr[i] = reader.Read();
                    Console.WriteLine(arr[i]);
                }
            }
        }
    }
}