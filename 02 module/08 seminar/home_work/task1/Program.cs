using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace task1
{
    abstract class Person
    {
        public static Random random = new Random();
        public string Name { get; set; }
        public string Pocket { get; set; }
        public abstract void Receive(string present);

        public Person(string name)
        {
            Name = name;
            Pocket = string.Empty;
        }

        public override string ToString()
        {
            return $"Name = {Name} Pocket = {Pocket} ";
        }
    }

    class SnowMaiden : Person
    {
        public SnowMaiden(string name) : base(name)
        {
        }

        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else
                throw new ArgumentException(">1 gifts");
        }

        private string CreateString()
        {
            int n = random.Next(4, 11);
            StringBuilder sb = new StringBuilder(n);
            for (int i = 0; i < n; i++)
                sb.Append((char) random.Next('a', 'z' + 1));
            return sb.ToString();
        }

        public string[] CreatePresents(int amount)
        {
            string[] gifts = new string[amount];
            for (int i = 0; i < amount; i++)
                gifts[i] = CreateString();
            return gifts;
        }
    }

    class Santa : Person
    {
        public List<string> sack;

        public void Request(SnowMaiden snowMaiden, int amount)
        {
            sack.AddRange(snowMaiden.CreatePresents(amount));
        }

        public Santa(string name) : base(name)
        {
            sack = new List<string>();
        }

        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else
                throw new ArgumentException(">1 gifts");
        }

        public void Give(Person person)
        {
            int n = random.Next(0, sack.Count);
            if (sack.Count > 0)
            {
                person.Receive(sack[n]);
                sack.RemoveAt(n);
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }

    class Child : Person
    {
        public string AdditionalPocket { get; set; }

        public Child(string name) : base(name)
        {
            AdditionalPocket = string.Empty;
        }

        public override void Receive(string present)
        {
            if (Pocket.Equals(string.Empty))
                Pocket = present;
            else if (AdditionalPocket.Equals(string.Empty))
                AdditionalPocket = present;
            else
                throw new ArgumentException(">2 gifts");
        }

        public override string ToString()
        {
            return $"Name = {Name} Pocket = {Pocket} Pocket2 = {AdditionalPocket}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Santa santa = new Santa("Santa");
                SnowMaiden snowMaiden = new SnowMaiden("SnowMaiden");
                int n = 10;
                List<Person> people = new List<Person>(n + 2);
                people.Add(santa);
                people.Add(snowMaiden);
                for (int i = 0; i < 10; i++) 
                    people.Add(new Child($"Child {i + 1}"));
                bool flag = true, ch = false;
                while (true)
                {
                    var random = new Random();
                    if (random.Next(1,100)  == 1)
                    {
                        try
                        {
                            santa.Give(santa);
                            Console.WriteLine(santa);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message); break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            if (flag) santa.Request(snowMaiden, random.Next(1, 5));
                            if (ch) break;
                            goto Сheckprint;
                        }
                    }
                    else
                    {
                        var personOfList = random.Next(1, people.Count);
                        try
                        {
                            santa.Give(people[personOfList]);
                            Console.WriteLine(people[personOfList]);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            people.RemoveAt(personOfList);
                            if ((personOfList) == 1 && (ch == false))
                            {
                                flag = false;
                                ch = true;
                            }
                        }
                        catch
                        {
                            if (flag) santa.Request(snowMaiden, random.Next(1, 5));
                            if (ch) break;
                            goto Сheckprint;
                        }
                    }
                    if (flag) santa.Request(snowMaiden, random.Next(1, 5));
                    Сheckprint:
                    if (santa.sack.Count == 0) break;
                    if (people.Count == 1) break;
                }
                Console.WriteLine();
                Console.WriteLine("Для завершения программы нажмите Backspace!");
            } while (Console.ReadKey().Key != ConsoleKey.Backspace);
        }
    }
}