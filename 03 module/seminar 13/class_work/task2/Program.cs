using System;
using System.Collections;

/*
 Определить коллекцию (класс Fibbonacci) с именованным итератором 
 (в виде метода, возвращающего интерфейс IEnumerable) 
 для получения заданного количества членов ряда Фибоначчи,
 поля класса – последний и предпоследний член ряда Фибоначчи. 
 В основной программе дважды обработать объект (коллекцию) оператором  foreach.
 */

namespace task2
{
    class Fibbonacci
    {
        private int x0 = 1;
        private int x1 = 1;
        
        public IEnumerable NextElement(int n)
        {
            for (int i = 0; i < n; i++)
            { 
                yield return x0;
                int s = x0 + x1;
                x0 = x1;
                x1 = s;
            }
        }
    }
    
    
    class Program
    {
        static void Main(string[] args)
        {
            Fibbonacci fibbonacci = new Fibbonacci();
            foreach (var el in fibbonacci.NextElement(5))
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();
            foreach (var el in fibbonacci.NextElement(5))
            {
                Console.WriteLine(el);
            }
        }
    }
}