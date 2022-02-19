using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
[Serializable]
public class Student{
    public string Surname { get; set; }
    public int Course { get; set; }
    public Student(string surname, int course)
    {
        Surname = surname;
        Course = course;
    }
    public override string ToString()
    {
        return $"Surname {Surname} Course {Course}";
    }
    public Student()
    {
    }
}
[Serializable]
public class Group{
    public List<Student> Students { get; set; }
    public int ID { get; set; }
    public Group()
    {
    }
    public Group(List<Student> students, int id)
    {
        Students = students;
        ID = id;
    }
}
class Program{
    static async Task Main()
    {
        var G1 = new Group(new List<Student> {new Student("gd", 1), new Student("fdadsa", 2)}, 1);
        var G2 = new Group(new List<Student> {new Student("gdgsd", 3), new Student("dfgsfsadsa", 4)}, 2);
        var G = new Group[] {G1, G2};
        using (var fs = new FileStream("note.json", FileMode.OpenOrCreate))
        {
            await JsonSerializer.SerializeAsync<Group[]>(fs, G);
            Console.WriteLine("Data has been saved to file");
        }
        await Task.Delay(1000);
        using (var fs = new FileStream("note.json", FileMode.OpenOrCreate))
        {
            var g = await JsonSerializer.DeserializeAsync<Group[]>(fs);
            foreach (var h in g)
            {
                foreach (var s in h.Students)
                {
                    Console.WriteLine(s);
                }
            }
        }
        await Task.Delay(1000);
        XmlSerializer formatter = new XmlSerializer(typeof(Group[]));
        using (FileStream fs = new FileStream("note2.xml", FileMode.OpenOrCreate))
        {
            formatter.Serialize(fs, G);
        }
        await Task.Delay(1000);
        using (FileStream fs = new FileStream("note2.xml", FileMode.OpenOrCreate))
        {
            Group[] newGroup = (Group[])formatter.Deserialize(fs);
            foreach (var p in newGroup)
            {
                foreach (var s in p.Students)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}