using System;
/*
 Результатом работы метода GetStringFromUI() должно стать изменение значения поля str объекта класса UIString.
 Для достижения данного результата изменить существующий код, добавив него событие «Изменение строки интерфейса» и его обработчик:
•Добавьте в программу объявление событийного делегата-типа: 
public delegate void NewStringValue(string s); 
В классе ConsoleUI объявите нестатическое событие NewStringValueHappened с типом делегата NewStringValue. 
•В класс UIString добавьте метод с заголовком:
public void NewStringValueHappenedHandler(string s). 
Метод будет обработчиком события NewStringValueHappened. В ответ на событие метод изменит значение поля str класса UIString на значение s. 
В коде метода CreateUI класса ConsoleUI добавьте в список обработчиков события
NewStringValueHappened метод NewStringValueHappenedHandler (тем самым объект класса UIString подпишите  на получение события NewStringValueHappened).
•Поместите в метод GetStringFromUI класса ConsoleUI код запуска (генерации) события NewStringValueHappened.
•Запустите и отладьте программу.
 */
namespace task1
{
    public delegate void NewStringValue(string s); 
    public class UIString
    {
        string str = "Default text";
        public string Str { get { return str; } private set { str = value; } }

        public void NewStringValueHappenedHandler(string s)
        {
            str = s;
        }
    }
    class ConsoleUI
    {
        
        UIString s = new UIString(); // специальная строка
        public UIString S { get { return s; } set { s = value; } }
        public void GetStringFromUI()
        {
            Console.Write("Введите новое значение строки: ");
            string str = Console.ReadLine();
            NewStringValueHappened?.Invoke(str);
            RefreshUI();
        }
        
        public event   NewStringValue NewStringValueHappened;
        public void CreateUI()
        {
            NewStringValueHappened += S.NewStringValueHappenedHandler;
            RefreshUI();
        }
        public void RefreshUI()
        {      // обновление строки     
            Console.Clear();
            Console.WriteLine("Текст строки: " + s.Str);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleUI c = new ConsoleUI();
            c.CreateUI(); // запускаем выполнение объекта класса ConsoleUI
            do
            {
                c.GetStringFromUI();  // изменяем значение строки
                Console.WriteLine("Чтобы закончить эксперименты, нажмите ESC...");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}