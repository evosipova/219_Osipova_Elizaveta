using System;
//определить абстрактный класс Animal.
//В классе описать поле «кличка животного», «возраст животного», методы доступа к полям.
//Снабдить класс Animal прототипами методов AnimalSound() - «звук животного» и AnimalInfo() – информация о животном (значения всех его полей).
//описать два класса наследника от Animal.
//Класс Dog, описывающий собаку и класс Cow, описывающий корову.
//Класс Dog инкапсулирует поля «порода собаки» и логическое поле isTrained (true, если собака дрессирована), добавить методы доступа к полям.
//Класс Cow инкапсулирует поле «количество молока в день», добавить метод доступа к полям.
//В каждом классе переопределить методы AnimalSound() и AnimalInfo() в соответствии с типом животного.
//В консольном приложениии на основе данных, полученных от пользователя породить объект класса Dog и Cow, вывести информацию и звуки животных.
namespace task3
{
    public abstract class Animal
    {
        protected Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public abstract string AnimalSound();
        public abstract string AnimalInfo();
    }

    class Dog : Animal
    {
        private string Breed { get; set; }
        private bool isTrained { get; set; }
        
        public Dog(string name, int age, string breed, bool istrained) : base(name, age)
        {
            Breed = breed;
            isTrained = istrained;
        }
        
        public override string AnimalSound()
        { return "гав-гав"; }

        public override string AnimalInfo()
        {
            return $"Breed: {Breed};  " +
                   $"isTrained: {isTrained};  " +
                   $"NickName: {Name};  " +
                   $"Age: {Age};  " +
                   $"Sound: {AnimalSound()}";
        }
    }

    class Cow : Animal
    {
        public Cow(string name, int age, int milkCount) : base(name, age)
        { CountOfMilk = milkCount; }

        private int CountOfMilk { get; set; }

        public override string AnimalSound()
        { return "му-му"; }

        public override string AnimalInfo()
        {
            return $"Milk count: {CountOfMilk};  " +
                   $" NickName: {Name};   " +
                   $"Age: {Age};   " +
                   $"Sound: {AnimalSound()}";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            var cow = new Cow("Милка", 20, 50);
            var dog = new Dog("Джэк", 3, "Лабрадор", true);
            Console.WriteLine(cow.AnimalInfo());
            Console.WriteLine(dog.AnimalInfo());
        }
    }
}