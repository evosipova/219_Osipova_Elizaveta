using System;
using StackExchange.Redis;

namespace TaskStringSolution
{
    public static class RedisClient
    {
        private static ConnectionMultiplexer redis;
        private static IDatabase database;

        public static void Connect(string connectionString = "localhost")
        {
            redis = ConnectionMultiplexer.Connect("redis-10799.c290.ap-northeast-1-2.ec2.cloud.redislabs.com:10799,password=BASCd4eHcWd3LP0vC1Tf28OfC5mgQtel,ConnectTimeOut=10000,allowAdmin=true");
            database = redis.GetDatabase();
        }

        public static string GetSet(string key, string value)
        {
            return database.StringGetSet(key, value);
        }

        public static bool Exist(string key)
        {
            return database.KeyExists(key);
        }

        public static void Set(string key, string value)
        {
            database.StringSet(key, value);
        }
        public static string Get(string key)
        {
            return database.StringGet(key);
        }
    }
}