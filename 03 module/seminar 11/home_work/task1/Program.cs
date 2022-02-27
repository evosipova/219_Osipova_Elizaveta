using System;
using System.IO;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            using (FileStream fileStream = new FileStream("Numbers.txt", 
                FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                if (fileStream.Length == 0)
                {
                    BinaryWriter bw = new(fileStream);
                    for (int i = 0; i < 10; i++)
                    {
                        bw.Write(random.Next(1, 101));
                    }
                }
                else
                {
                    BinaryReader br = new(fileStream);
                    BinaryWriter bw = new(fileStream);
                    int[] arrayNum = new int[10];
                    for (int i = 0; i < 10; i++)
                    {
                        arrayNum[i] = br.ReadInt32();
                        Console.Write(arrayNum[i] + " ");
                    }
                    int a = int.Parse(Console.ReadLine());
                    int id = 0, minDiff = Math.Abs(a - arrayNum[0]);
                    for (int i = 1; i < 10; i++)
                    {
                        if (Math.Abs(a - arrayNum[0]) < minDiff)
                        {
                            id = i;
                        }
                    }
                    arrayNum[id] = a;
                    fileStream.Position = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        bw.Write(arrayNum[i]);
                    }
                    fileStream.Position = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        arrayNum[i] = br.ReadInt32();
                        Console.Write(arrayNum[i] + " ");
                    }
                }
            }
        }
    }
}
