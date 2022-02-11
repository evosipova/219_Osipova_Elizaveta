using System;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1
            try
            {
                int[] list = new int[0];
                list[100] = -2;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Индекс вылетел за пределы массива(((");
            }
            
            //2
            try
            {
                int a = 100;
                int b = 0;
                Console.WriteLine(a / b);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Поймал за руку, как дешёвку на делении на нуль!");
            }

            //3
            try
            {
                using (StreamReader sr = new StreamReader("Я люблю пельмени")) { }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Такого файла нет, и быть не может!");
            }
            
            //4
            try
            {
                string d = null;
                string[] data = d.Split();
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Подана пустая строка, она не может быть null");
            }
            
            //5
            try
            {
                using (StreamReader sr = new StreamReader(".txt"))
                {
                    using (StreamWriter sw = new StreamWriter(".txt"))
                    {
                    }
                }
            }
            catch(IOException)
            {
                Console.WriteLine("Невозможно использовать файл, когда он используется другим процессом.");
            }
            
            //6
            try
            {
                int[] arr = new int[1];
                arr[0] = int.Parse("Ауф");
            }
            catch (FormatException)
            {
                Console.WriteLine("Невозможно преобразовать к числу!");
            }
            
            //7
            try
            {
                Console.WriteLine("-".Substring(330));
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Пытаемся получить строку большего размера из строки меньшего!");
            }
            
            //8
            try
            {
                object t = "Пельмень";
                int x = (int)t;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Неверное приведение типов!!!");
            }
            
            //9
            try
            {
                StringBuilder stringBuilder = new StringBuilder(15, 15);
                stringBuilder.Append("ваввававаавав");
                stringBuilder.Insert(0, "аваавваввава ", 1);
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Слишком много памяти...");
            }
            
            
            //10
            try
            {
                string op = null;
                Console.WriteLine("в".IndexOf(op));
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Аргумент не должен быть Null!!!!");
            }
        }
    }
}