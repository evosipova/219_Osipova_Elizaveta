using System;
namespace task1
{
    class Program
    {
        public abstract class Creature
        { 
            public abstract string Name { get; set; }
            public abstract string Location { get; set; }
            public abstract void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs e);
        }
        
        public class RingIsFoundEventArgs : EventArgs
        {
            public RingIsFoundEventArgs(string s)
            { Message = s; }
            public  string Message { get; set; }
        }
        
        public sealed class Wizard : Creature
        {
            public override string Name { get;  set; }
            public override string Location { get; set; } 
            public delegate void RingIsFoundEventHandler(object sender, RingIsFoundEventArgs e); 
            public override void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs e) { }
            public event RingIsFoundEventHandler RaiseRingIsFoundEvent;
            public Wizard(string name, string location)
            {
                Name = name;
                Location = location;
            }
            public Wizard() { }
            public void SomeThisIsChangedInTheAir()
            {
                Console.WriteLine($"{Name} >> Кольцо найдено у старого Бильбо! Призываю вас в Ривендейл!");
                RaiseRingIsFoundEvent(this, new("Ривендейл"));
            }
        }
        
        public sealed class Hobbit : Creature
        {
            public override string Name { get;  set; } 
            public override string Location { get; set; }
            public Hobbit(string name, string location)
            {
                Name = name; 
                Location = location;
            }
            public override void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs e)
            {
                Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. Покидаю Шир! Иду в {e.Message}");
                Location = e.Message;
            }
        }
        
        public sealed class Human : Creature
        {
            public override string Name { get; set; }
            public override string Location { get; set; }
            public Human(string name, string location)
            {
                Name = name; 
                Location = location;
            }
            public override void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs e)
            {
                Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. " +
                                  $"Волшебник {((Wizard)(sender)).Name} позвал. Моя цель {e.Message}");
                Location = e.Message;
            }
        }
        
        public sealed class Elf : Creature
        {
            public override string Name { get; set; }
            public override string Location { get; set; }
            public Elf(string name, string location) 
            {
                Name = name; 
                Location = location;
            }
            public override void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs e)
            {
                Console.WriteLine(
                    $"{Name} >> Текущее местоположение: {Location}. Звезды светят не так ярко как обычно. " +
                    $"Цветы увядают. Листья предсказывают идти в {e.Message}");
                Location = e.Message;
            }
        }
        
        public sealed class Dwarf : Creature
        {
            public override string Name { get; set; }
            public override string Location { get; set; }
            public Dwarf(string name, string location)
            {
                Name = name; 
                Location = location;
            }
            public override void RingIsFoundEventHandle(object sender, RingIsFoundEventArgs e)
            {
                Console.WriteLine($"{Name} >> Текущее местоположение: {Location}. " +
                                  $"Точим топоры, собираем припасы! Выдвигаемся в {e.Message}");
                Location = e.Message;
            }
        }
        static void Main(string[] args)
        {
            Wizard wizard = new("Гендальф", "Аваллонэ");
            Creature[] creatures =
            {
                new Hobbit("Фродо", "Валинор"),
                new Hobbit("Сэм", "Форност"),
                new Hobbit("Пэпин", "Бритомбар"),
                new Hobbit("Мэрри", "Ильмарин"),
                new Human("Боромир", "Тирион"),
                new Human("Арагорн", "Белегост"),
                new Dwarf("Гимли", "Изенгард"),
                new Elf("Леголас", "Форменос"),
                new Hobbit("Голлум", "Ангбанд")
            };
            foreach (var creature in creatures)
            {
                wizard.RaiseRingIsFoundEvent += creature.RingIsFoundEventHandle;
            }
            wizard.SomeThisIsChangedInTheAir();
        }
    }
}