using System;

namespace task1
{
    class Creature
    {
        public string Name { get; set; } //имя существа
        private double _Speed; //скорость существа
        public double Speed
        {
            get { return _Speed; }
            set
            {
                if (value < 0) 
                    throw new ArgumentException("Speed has to be greater then 0");
                _Speed = value;
            }
        }
        public Creature(string name, double speed)
        {
            Name = name;
            Speed = speed;
        }
        //Возвращает строку "I am running with a speed of <speed>." 
        public virtual string Run()
        { return $"I am running with such high speed as {Speed}. "; }
        //Переопределенный метод, возвращающий результат метода Run и имя существа (в удобном для чтения формате).
        //К примеру, « I am running with a speed of 85.1. My name is DarkNight.» 
        public override string ToString()
        { return (Run() + $"My name is {Name}. "); }
    }

    class Dwarf : Creature
    {
        private int _strength;
        public int Strength
        {
            get { return _strength; }
            set
            {
                if (value < 1 || value > 20)
                {
                    var r = new Random();
                    _strength = r.Next(1, 21);
                }
                else _strength = value;
            }
        }
        public Dwarf(string name, double speed, int strength) : base(name, speed)
        { Strength = strength; }
        //Переопределенный метод Run — возвращает строку "I am running with a speed of <speed>. My strength is <strength>". 
        public new string Run()
        {
            return base.Run() + $"My strength is {Strength}. ";
        }
        //Метод для создания магической вещи – выводит в консоль строку "I've created a new staff!". 
        public void MakeNewStaff()
        {
            Console.WriteLine("I've created new staff!");
        }
        public override string ToString()
        {
            return Run() + $"My name is {Name}. ";
        }
    }
    class Elf : Creature
    {
        public int Age { get; }
        public Elf(string name, double speed) : base(name, speed)
        {
            var r = new Random();
            Age = r.Next(100, 201); //возраст существа
            Speed = speed + Age / 77;
        }

        //Переопределенный метод Run — возвращает строку "I am running with a speed of <X>. My age is <age>",
        //где X считается как speed + age / 77, так как именно раз в 77 лет скорость эльфа увеличивается на 1.
        public new string Run()
        { return base.Run() + $"My age is {Age}."; }
        public override string ToString()
        { return Run() + $"My name is {Name}."; }

        class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {
                    //Проверка корректности введенного числа.
                    Console.WriteLine("Введите количество существ от 0 до 100:");
                    if (!int.TryParse(Console.ReadLine(), out var n) || (n < 0) || (n > 100))
                    {
                        Console.WriteLine("Введенное число меньше 0 или больше 100!"); return;
                    }
                    var creatures = new Creature[n];
                    for (var i = 0; i < n; i++)
                    {
                        var random = new Random();
                        var character = random.NextDouble();
                        var k = random.Next(3, 11);
                        var name = String.Empty;
                        for (var j = 0; j < k; j++)
                        {
                            var St = random.Next(65, 91);
                            var strengths = random.Next(97, 123);
                            if (name.Length > 1)
                            {
                                var ch = random.Next(0, 2);
                                if (ch == 0) name = name + ((char) strengths).ToString();
                                else name = name + ((char) St).ToString();
                            }
                            else name = name + ((char) St).ToString();
                        }
                        var t = random.Next(10, 19); //от 10 до 18
                        if (character - 0.2 < 0) creatures[i] = new Creature(name, t);
                        else if ((character > 0.2) && (character < 0.2 + 0.4))
                        {
                            var str = random.Next(-50, 51);
                            creatures[i] = new Dwarf(name, t, str);
                        }
                        else creatures[i] = new Elf(name, t);
                    }
                    var count = 0;
                    foreach (var creature in creatures)
                    {
                        Console.WriteLine(creature);
                        if (creature is Dwarf) count++;
                    }
                    Dwarf dw = new Dwarf("elf", 5, 20);
                    for (var i = 0; i < count; i++) dw.MakeNewStaff();
                    Console.WriteLine("Если Вы хотите завершить программу, то нажмите Enter.");
                    if (Console.ReadKey().Key == ConsoleKey.Enter) return;
                }
            }
        }
    }
}