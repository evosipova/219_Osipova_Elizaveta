using System;
using System.Linq;
using StackExchange.Redis;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "redis-10799.c290.ap-northeast-1-2.ec2.cloud.redislabs.com";
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("redis-10799.c290.ap-northeast-1-2.ec2.cloud.redislabs.com:10799,password=BASCd4eHcWd3LP0vC1Tf28OfC5mgQtel,ConnectTimeOut=10000,allowAdmin=true");
            IDatabase database = redis.GetDatabase();
            IServer server = redis.GetServer(connectionString, 10799);

            database.StringSet("test 1", "value 1");
            database.StringSet("test 2", "value 2");

            string str1 = database.StringGet("test 1");
            if (database.KeyExists("test 3"))
            {
                string str3 = database.StringGet("test 3");
                Console.WriteLine(str3);
            }
            else
            {
                Console.WriteLine("No");
            }
            Console.WriteLine(str1);
        }
    }
}