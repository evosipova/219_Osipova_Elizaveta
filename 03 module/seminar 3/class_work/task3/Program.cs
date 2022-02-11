using System;
/*
 •В библиотеке классов описать:
–делегат SquareSizeChanged, представляющий методы c одним вещественным параметром и возвращающие значение void. 
–класс Square – прямоугольник на плоскости. Квадрат задан координатами верхнего левого и правого нижнего углов. В классе разместите:
–событие OnSizeChanged с типом SquareSizeChanged;
–свойства доступа к координатам определяющих углов квадрата. В коде каждого свойства после изменения значения поля запускает событие OnSizeChanged, в качестве параметра передаётся новое значение длины стороны квадрата.
•В основной программе:
– описать статический метод SquareConsoleInfo(A), возвращающий значение void и выводящий в консоль, с точностью до двух знаков после запятой вещественное число A, переданное в качестве параметра.
–В методе Main() получить от пользователя координаты углов квадрата. На основе этих координат создать объект S типа Square. Связать метод SquareConsoleInfo() с событием OnSizeChanged объекта S.  В цикле получать от пользователя координаты правого нижнего угла квадрата X и Y, используя свойства объекта Square, изменять координаты углов S, условие окончания цикла определить самостоятельно.
 */
namespace task3
{
    public delegate void SquareSizeChanged(double d);
    class Square
    {
        private double x1, x2, y1, y2;
        public event SquareSizeChanged OnSizeChanged;
        public Square(double x1, double x2, double y1, double y2)
        {
            this.x1 = x1;
            this.x2 = x2;
            this.y1 = y1;
            this.y2 = y2;
        }
        public double X1
        {
            get { return x1; }
            set
            {
                x1 = value;
                OnSizeChanged?.Invoke(Math.Abs(x1 - x2));
            }
        }
        public double X2
        {
            get { return x2; }
            set
            {
                x2 = value;
                OnSizeChanged?.Invoke(Math.Abs(x1 - x2));
            }
        }
        public double Y1
        {
            get { return y1; }
            set
            {
                y1 = value;
                OnSizeChanged?.Invoke(Math.Abs(y1 - y2));
            }
        }
        public double Y2
        {
            get { return y2; }
            set
            {
                y2 = value;
                OnSizeChanged?.Invoke(Math.Abs(y1 - y2));
            }
        }
    }

    class Program
    {
        private static void SquareConsoleInfo(double d)
        {
            Console.WriteLine($"{d:f3}");
        }
        static void Main(string[] args)
        {
            var x1 = double.Parse(Console.ReadLine());
            var x2 = double.Parse(Console.ReadLine());
            var y1 = double.Parse(Console.ReadLine());
            var y2 = double.Parse(Console.ReadLine());
            Square S = new Square(x1, x2, y1, y2);
            S.OnSizeChanged += SquareConsoleInfo;
            while (true)
            {
                var x = double.Parse(Console.ReadLine());
                var y = double.Parse(Console.ReadLine());
                S.X2 = x2;
                S.Y2 = y2;
            }
        }
    }
}