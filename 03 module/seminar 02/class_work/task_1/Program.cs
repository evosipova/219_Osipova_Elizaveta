using System;
//Объявите делегат-тип Cast для представления методов с одним
//параметром типа double и возвращаемым значением типа int.
//Создайте два экземпляра типа Cast. Первый свяжите с анонимным методом,
//возвращающим ближайшее чётное целое к переданному в параметре вещественному числу.
//Второй – с лямба-выражением, вычисляющим порядок переданного в параметре положительного числа.
//Протестируйте вызовы при помощи делегатов:
//(1) на одном тестовом вещественном значении;
//(2) на нескольких тестовых вещественных значениях.
//Используя операцию += свяжите оба анонимных метода из задачи 1 с одним многоадресным делегатом.
//Вызовите методы через него.
//Используйте метод Invoke для вызова делегата. 
//Используя операцию -= попытайтесь “удалить” из многоадресного делегата
//лямбда-выражение (объясните результат). 
//Проделайте предыдущий пункт с использованием методов (объясните результат). 


namespace task_1
{
    class Program
    {
        delegate int Cast(double val);
        public static int M1(double x)
        {
            return (int)(x / 2) * 2;
        }
        public static int M2(double x)
        {
            return (int)(Math.Log10(x)) + 1;
        }
        static void Main(string[] args)
        {
            Cast cast1 = delegate (double x)
            {
                return (int)(x % 2) == 0 ? (int)x : (int)x + 1;
            };
            Cast cast2 = (x) => (int)(Math.Log10(x)) + 1;
            Console.WriteLine(cast1(11.7)); //12
            Console.WriteLine(cast2(110.7)); //3
            Cast cast3 = cast1 + cast2;
            Console.WriteLine();
            Console.WriteLine(cast3?.Invoke(110.7));//3
            cast3 -= (x) => (int)(Math.Log10(x)) + 1;
            Console.WriteLine(cast3?.Invoke(110.7));//3
            Console.WriteLine("***");

            Cast cast4 = M1;
            Cast cast5 = M2;
            Console.WriteLine(cast4.Invoke(11.7));
            Console.WriteLine(cast5.Invoke(110.7));
            Cast cast6 = cast4 + cast5;
            Console.WriteLine();
            Console.WriteLine(cast6?.Invoke(110.7)); //3
            //cast6 -= M2;
            //cast6 -= M1;
            Console.WriteLine(cast6?.Invoke(110.7));
            Console.WriteLine("***");
            foreach (Cast d in cast6.GetInvocationList())
            {
                Console.WriteLine(d?.Invoke(110.7));
            }
        }
    }
}