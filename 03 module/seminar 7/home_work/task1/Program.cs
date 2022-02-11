using System;
using System.Text;
namespace task1
{
    public struct Person : IComparable<Person>
    {
        private string name;
        private string surname;
        private int age;
        
        public string Name
        {
            get
            {
               return name; 
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Ошибка!");
                name = value;
            }
        }
        
        public string Surname
        {
            get
            {
                return surname;
            } 
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Ошибка!");
                surname = value;
            }
        }
        
        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("", "Ошибка!");
                age = value;
            }
        }
        
        public Person(string name, string surname, int age)
        {
            this.name = "-";
            this.surname = "-";
            this.age = 0;
            Name = name;
            Surname = surname;
            Age = age;
        }

        public int CompareTo(Person person)
        {
            if (Age > person.Age) return 1;
            else if (Age == person.Age) return 0;
            else return -1;
        }

        public override string ToString() => $"Имя: {Name}. \n" +
                                             $"Фамилия: {Surname}. \n" +
                                             $"Возраст: {Age}.";
    }

    class Program
    {
        static void Main()
        {
            Random random = new Random();
            string[] name = { "Иван", "Анна", "Михаил", "Артем", "Антон"};
            string[] surname =  { "Иванов", "Сидоров", "Попов", "Петров"};
            int n = int.Parse(Console.ReadLine());
            Person[] characters = new Person[n];
            for (int i = 0; i < n; i++)
            {
                characters[i] = new Person(name[random.Next(name.Length)], surname[random.Next(surname.Length)], random.Next(1, 101));
            }
            Array.ForEach(characters, el => Console.WriteLine(el));
            Array.Sort(characters);
            Array.ForEach(characters, el => Console.WriteLine(el));
        }
    }
}