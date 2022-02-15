using System;
using System.IO;
namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            int k;
            Random rnd = new Random();
            using (BinaryWriter writer =
                new BinaryWriter(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; ++i)
                    writer.Write(rnd.Next(1, 101));
            }

            int[] arr = new int[10];
            using (BinaryReader reader
                = new BinaryReader(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; ++i)
                {
                    arr[i] = reader.ReadInt32();
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

            using (BinaryWriter writer
                = new BinaryWriter(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; ++i)
                    writer.Write(arr[i]);
            }
            using (BinaryReader reader
                = new BinaryReader(File.Open("Numbers.txt", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < 10; ++i)
                {
                    arr[i] = reader.ReadInt32();
                    Console.WriteLine(arr[i]);
                }
            }
        }
    }
}