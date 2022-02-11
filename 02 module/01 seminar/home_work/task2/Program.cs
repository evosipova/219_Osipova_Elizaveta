using System;

namespace task2
{
    class Program   
        {
            public static void Print(RegularPolygon[] polygonArray, double minn, double maxx)
            {
                foreach (var el in polygonArray)
                {
                    if (el.S == minn)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(el.Data());
                        Console.ResetColor();
                    }
                    else if (el.S == maxx)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(el.Data());
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine(el.Data());
                }
            }
            static void Main(string[] args)
            {
                do
                {
                    Console.Write("Введите желаемое количество объектов: ");
                    int quantity = int.Parse(Console.ReadLine());
                    RegularPolygon[] arrayp = new RegularPolygon[quantity];
                    double minn = double.MaxValue;
                    double maxx = 0;
                    for (int i = 0; i < quantity; i++)
                    {
                        Console.Write($"Введите количество сторон {i + 1}-ого многоугольника: ");
                        int n = int.Parse(Console.ReadLine());
                        Console.Write($"Введите радиус вписанной окружности для {i + 1}-ого многоугольника: ");
                        double radius = double.Parse(Console.ReadLine());
                        arrayp[i] = new RegularPolygon(n, radius);
                        if (arrayp[i].S <= minn)
                        {
                            minn = arrayp[i].S;
                        }

                        if (arrayp[i].S >= maxx)
                        {
                            maxx = arrayp[i].S;
                        }
                    }
                    Print(arrayp, minn, maxx);
                    Console.WriteLine("Press BACKSPACE to quit");
                } while (Console.ReadKey(true).Key != ConsoleKey.Backspace);

            }
        }
}