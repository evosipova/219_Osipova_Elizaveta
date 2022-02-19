using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

/*
 В программе описать классы:

•Human (имя);
•Professor (наследник Human);
•Department  (название, композиционно включает список сотрудников – объекты типа Human);
•University (название, агрегационно включает список департаментов).
•Задать массив университетов. Сериализовать и десериализовать бинарной/xml/json.
 */
namespace task3
{
    [Serializable]
    public class Human
    {
        public string Name { get; set; }

        public Human() { }

        public Human(string name)
        {
            Name = name;
        }
    }

    [Serializable]
    public class Professor : Human
    {
        public Professor(string name) : base(name) { }

        public Professor() { }
    }

    [Serializable]
    [XmlInclude(typeof(Professor))]
    [XmlInclude(typeof(Human))]
    public class Department
    {
        public Department() { }

        public string Name { get; set; }
        public List<Human> Humans { get; set; }

        public Department(List<Human> humans, string name)
        {
            Name = name;
            Humans = humans.ToList();
        }
    }

    [Serializable]
    [XmlInclude(typeof(Professor))]
    [XmlInclude(typeof(Human))]
    [XmlInclude(typeof(Department))]
    public class University
    {
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

        public University() { }

        public University(List<Department> departments, string name)
        {
            Name = name;
            Departments = departments;
        }
    }

    class Program
    {
        static async Task Main()
        {
            var humans = new List<Human>()
            {
                new Human("h1"),
                new Human("h2"), 
                new Human("h3"), 
                new Human("h4"),
                new Professor("p1"), 
                new Professor("p2")
                
            };
            var d1 = new Department(humans, "d1");
            var d2 = new Department(humans, "d2");
            var departments = new List<Department> {d1, d2};
            var unis = new List<University>()
            {
                new University(departments, "u1"),
                new University(departments, "u2")
            };

            using (var fs = new FileStream("JSON.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, unis);
                Console.WriteLine("Объект сериализован");
            }

            using (var fs = new FileStream("JSON.json", FileMode.OpenOrCreate))
            {
                var g = await JsonSerializer.DeserializeAsync<List<University>>(fs);
                Console.WriteLine("Объект десериализован");
            }

            var formatter = new XmlSerializer(typeof(List<University>));

            using (var fs = new FileStream("XML.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, unis);
                Console.WriteLine("Объект сериализован");
            }

            using (var fs = new FileStream("XML.xml", FileMode.OpenOrCreate))
            {
                var newGroup = (List<University>) formatter.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
            }

            var formater = new BinaryFormatter();

            using (var fs = new FileStream("BinaryFormatter.dat", FileMode.OpenOrCreate))
            {
                formater.Serialize(fs, unis);
                Console.WriteLine("Объект сериализован");
            }

            using (var fs = new FileStream("BinaryFormatter.dat", FileMode.OpenOrCreate))
            {
                var newUni = (List<University>) formater.Deserialize(fs);
                Console.WriteLine("Объект десериализован");
            }
        }
    }
}