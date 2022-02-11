using System;
using StackExchange.Redis;

namespace TaskListSolution
{
    public static class RedisClient
    {
        public const uint MaxC = 5;

        private static ConnectionMultiplexer redis;
        private static IDatabase database;

        public static void Connect(string connectionString)
        {
            redis = ConnectionMultiplexer.Connect($"{connectionString}:10799,password=BASCd4eHcWd3LP0vC1Tf28OfC5mgQtel,ConnectTimeOut=10000,allowAdmin=true");
            database = redis.GetDatabase();
        }

        public static string Get(string key)
        {
            return database.ListGetByIndex(key,-1);
        }

        public static bool Exist(string key)
        {
            return database.KeyExists(key);
        }

        public static void Add(string key, string value)
        {
            database.ListRightPush(key, value);
            if(database.ListLength(key) > MaxC)
            {
                database.ListLeftPop(key);
            }
        }
        public static string Back(string key)
        {
            if (database.ListLength(key) > 1)
            {
                return $"Version {database.ListRightPop(key)} has been removed";
            }
            else
            {
                database.KeyDelete(key);
                return "Application was deleted";
            }
        }
    }
}