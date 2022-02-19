using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
namespace ConsoleApp1
{
    [Serializable]
    public class Person
    {
        [JsonPropertyName("fisrtName")]
        public string Name { set; get; }
        public int Year { get; set; }
        [NonSerialized]
        private int SomeValue;
        [JsonInclude]
        public int a = 100;
        [JsonInclude]
        public int b = 200;
        public Person() { }
        public Person(string name, int year)
        {
            Name = name;
            Year = year;
        }
    }
    class Program
    {
        public static void Main()
        {
            Person person1 = new Person("Bob", 1980);
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream file = new FileStream("out1.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, person1);
            }
            using (FileStream file = new FileStream("out1.txt", FileMode.OpenOrCreate))
            {
                Person p = (Person)formatter.Deserialize(file);
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Year);
            }
            Person person2 = new Person("Tom", 1975);
            Person[] people = { person1, person2 };
            using (FileStream file = new FileStream("out2.txt", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, people);
            }
            using (FileStream file = new FileStream("out2.txt", FileMode.OpenOrCreate))
            {
                Person[] p = (Person[])formatter.Deserialize(file);
                foreach (Person person in p)
                {
                    Console.WriteLine(person.Name);
                    Console.WriteLine(person.Year);
                }
            }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            using (FileStream file =
                new FileStream("out3.txt", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(file, person1);
            }
            using (FileStream file =
                new FileStream("out3.txt", FileMode.OpenOrCreate))
            {
                Person p = (Person)xmlSerializer.Deserialize(file);
                Console.WriteLine(p.Name);
                Console.WriteLine(p.Year);
            }
            XmlSerializer xmlSerializer2 =
                new XmlSerializer(typeof(Person[]));
            using (FileStream file = new FileStream("out4.txt", FileMode.OpenOrCreate))
            {
                xmlSerializer2.Serialize(file, people);
            }
            using (FileStream file = new FileStream("out4.txt", FileMode.OpenOrCreate))
            {
                Person[] p = (Person[])xmlSerializer2.Deserialize(file);
                foreach (Person person in p)
                {
                    Console.WriteLine(person.Name);
                    Console.WriteLine(person.Year);
                }
            }
            var options = new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                WriteIndented = true
            };
            string json = JsonSerializer.Serialize<Person>(person1, options);
            Console.WriteLine(json);
            Person person3 = JsonSerializer.Deserialize<Person>(json, options);
            Console.WriteLine(person3.Name);
            Console.WriteLine(person3.Year);
        }
    }
}