using System;
using System.Linq;

/*
В некоторой коллекции хранятся целые числа. Вводите n с клавиатуры и генерируете последовательность от -10000 до 10000.
Все выражения составить в форме запросов и в форме методов расширений.
1) Составить LINQ-выражение, формирующее коллекцию, содержащую их последние цифры.
2) Сгруппировать коллекцию по последней цифре.
3) Составить запрос, формирующий коллекцию четных положительных чисел и выводит их количество
4) Составить запрос, находящий сумму всех четных чисел
5) Составить запрос, который сортирует числа по 1 и по последней цифре числа
 */
namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int.TryParse(Console.ReadLine(), out int n);
            int[] array = new int[n];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-10000, 10001);
            }
            //1 - Составить LINQ-выражение, формирующее коллекцию, содержащую их последние цифры.
            var p1_1 = from el in array 
                select Math.Abs(el) % 10;
            foreach (var el in p1_1) 
                Console.Write(el + " ");
            Console.WriteLine();
            var p1_2 = array.Select(x => Math.Abs(x) % 10);
            foreach (var el in p1_2)
                Console.Write(el + " ");
            Console.WriteLine();
            
            //2 - Сгруппировать коллекцию по последней цифре.
            var p2 = array.GroupBy(el => Math.Abs(el) % 10);
            foreach (var el in p2) 
                Console.Write(el.Key + " ");
            Console.WriteLine();
            
            var p2_2 = from el in array
                group el by Math.Abs(el) % 10
                into newGroup
                select newGroup;
            Console.WriteLine();
            foreach (var el in p2_2)
            {
                Console.Write(el.Key + " ");
            }
            Console.WriteLine();
            
            //3 - Составить запрос, формирующий коллекцию четных положительных чисел и выводит их количество
            var p3_1 = (from el in array where el % 2 == 0 select el).Count();
            Console.Write(p3_1);
            Console.WriteLine();
            var p3_2 = array.Count(el => el % 2 == 0);
            Console.WriteLine(p3_2); 
            Console.WriteLine();
            
            //4 - Составить запрос, находящий сумму всех четных чисел
            var p4_1 = (from el in array where el % 2 == 0 select el).Sum();
            Console.Write(p4_1);
            Console.WriteLine();
            
            var p4_2 = (from el in array
                where el % 2 == 0
                select el).Sum();
            Console.WriteLine(p4_2);
            Console.WriteLine();
            
            //5 - Составить запрос, который сортирует числа по 1 и по последней цифре числа
            var p5_1 = from el in array
                orderby (int)(el / Math.Pow(10, (int)Math.Log10(el))), // первая цифра
                    Math.Abs(el) % 10 // последняя цифра
                select el;
            foreach (var el in p5_1) 
                Console.Write(el + " ");
            Console.WriteLine();
            var p5_2 = array.OrderBy(el => (int)(el / Math.Pow(10, (int)Math.Log10(el)))).ThenBy(el => Math.Abs(el) % 10);
            foreach (var el in p5_2)
                Console.WriteLine(el);
        }
    }
}