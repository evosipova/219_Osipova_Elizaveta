using System;

namespace task1
{
    class VideoFile
    {
        private string string_name {get; set; }
        private int int_duration {get; set; }
        private int int_quality {get; set; }
        public VideoFile(string name, int d, int q)
        {
            string_name = name;
            int_duration = d;
            int_quality = q;
        }
        public int Size()
        { return int_duration * int_quality; }
        public string GetInfo()
        { return $"Имя видеофайла: {string_name}\nРазмер видеофайла: {Size()}\nКачество видеофайла: {int_quality}\nДлительность видеофайла: {int_duration}\n"; }
    }
    class Program
    {
        static void Main()
        {
            do
            {
                var rnd = new Random();
                var mainFile = new VideoFile("main", rnd.Next(60, 361), rnd.Next(100, 1001));
                var array = new VideoFile[rnd.Next(5, 16)];
                for (int i = 0; i < array.Length; i++)
                {
                    int d = rnd.Next(60, 361);
                    int qFile = rnd.Next(100, 1001);
                    string nameFile = "";
                    for (int j = 1; j < rnd.Next(3, 10); j++) nameFile += (char)rnd.Next('a', 'z');
                    array[i] = new VideoFile(nameFile, d, qFile);
                }

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Size() > mainFile.Size())
                    {
                        Console.WriteLine($"{array[i].GetInfo()}");
                    }
                }
                    
                Console.WriteLine("Нажмите Backspace, чтобы выйти и любую другую клавишу для продолжения!");
            } while (Console.ReadKey(true).Key != ConsoleKey.Backspace);
        }
    }
}