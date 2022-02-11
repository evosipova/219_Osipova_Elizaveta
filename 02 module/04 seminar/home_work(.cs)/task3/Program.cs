using System;

namespace TaskListSolution
{
    // Сиквел.
    // Разработчики из HSE company просят доработать ваше приложение!
    // Дело в том, что разработчики тоже ошибаются, и приходится откатывать приложение к предыдущей версии.
    // К тому же, HSE company не хочет расходовать много памяти,
    // поэтому было принято решение хранить только определенное колличество последних версий приложений.
    // 
    // На вход программе подаются запросы следующего типа:
    // 1) add <application_name> <version> - добавить актуальную версию приложения.
    // 2) back <application_name> - откатить приложение до предыдущей версии. Если предыдущей нет, то удалить приложение.
    // 3) get <application_name> - получить актуальную версию приложения. Если приложения нет, то сообщить об этом.
    // 4) exit - завершить программу.

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RedisClient.Connect("redis-10799.c290.ap-northeast-1-2.ec2.cloud.redislabs.com");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            string com = "";
            string name;
            string newBase;
            while (com != "exit")
            {
                Console.Write("input: ");
                com = Console.ReadLine();
                try
                {
                    string[] ilinesbase = com.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string command = ilinesbase[0];

                    switch (command)
                    {
                        case "add":
                            name = ilinesbase[1];
                            newBase = ilinesbase[2];
                            RedisClient.Add(name, newBase);
                            Console.WriteLine("New version set");
                            break;
                        case "back":
                            name = ilinesbase[1];
                            Console.WriteLine(RedisClient.Back(name));
                            break;
                        case "get":
                            name = ilinesbase[1];
                            if (RedisClient.Exist(name))
                            { Console.WriteLine(RedisClient.Get(name)); }
                            else { Console.WriteLine("Request failed"); }
                            break;
                        case "exit":
                            break;
                        default:
                            Console.WriteLine("Сommand not found");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Incorrect input");
                }
            }
        }
    }
}