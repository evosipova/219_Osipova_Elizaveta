using System;
/*
Определить абстрактный класс «Животное». Животное характеризуется возрастом. 
Определить интерфейсы «Прыгать», «Бегать», специфицирующие соответствующие методы.
Описать классы, наследники класса «Животное», реализующие необходимые интерфейсы: 
«Таракан» - таракан может бегать с известной скоростью (каждый таракан с разной).
«Кенгуру» – кенгуру не может бегать, но может прыгать.
«Гепард» – гепард может и бегать и прыгать.
Создать массив животных разных типов, инициализируя их характеристики (возраст, длина прыжка, скорость) случайными значениями.
Вывести массив на экран.
Самостоятельно: (animal is IJump)
1) Из коллекции Animal[] создайте коллекцию содержащую только умеющих прыгать животных (IJump[]). Продемонстрируйте прыжки.
2) Из коллекции Animal[] создайте коллекцию содержащую только умеющих бегать животных (IRun[]). Продемонстрируйте бег.
3) Отсортировать всех животных по возрасту (Icomparable)
4) Всех тараканов отсортровать по скорости бега (Icomparer)
5) Всех кенгуру по длине прыжка отсортировать (Icomparer)
 */
namespace task4
{
    abstract class Animal
    {
        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public Animal(int age)
        {
            Age = age;
        }
        //public string Info()
        //{ return string.Format($"{this.GetType().Name}. Возраст: {Age}."); }
    }
    public interface IRun
    { string Run(); }
        
    public interface IJump
    { string Jump(); }
    
    //Таракан.
    class Cockroach : Animal, IRun
    {
        private int speed;

        public Cockroach(int age, int speed) : base(age)
        { this.speed = speed; }
        
        public string Run()
        { return string.Format($"Скорость таракана: {speed}."); }
    }
    //Кенгуру.
    class Kangaroo : Animal, IJump
    {
        private int height;

        public Kangaroo(int age, int height) : base(age)
        { this.height = height; }

        public string Jump()
        {
            return string.Format($"Высота прыжка кенгуру: {height}.");
        }
    }
    //Гепард.
    class Cheetah : Animal, IRun, IJump
    {
        private int speed;
        private int height;

        public Cheetah(int age, int speed, int height) : base(age)
        {
            this.height = height;
            this.speed = speed;
        }
        
        public string Run()
        { return string.Format($"Скорость гепарда: {speed}."); }

        public string Jump()
        { return string.Format($"Высота прыжка гепрада: {height}."); }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animal = new Animal[5];
            animal[0] = new Cockroach(3, 7);
            animal[1] = new Kangaroo(10, 2);
            animal[2] = new Cheetah(4, 5, 5);
            foreach (var animals in animal)
            {
                if (animals is IJump)
                    Console.WriteLine(((IJump)animals).Jump());
                
                if (animals is IRun)
                    Console.WriteLine(((IRun)animals).Run());
            }
        }
    }
}