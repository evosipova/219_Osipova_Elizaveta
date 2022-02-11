﻿using System;
using System.Collections.Generic;
using System.Linq;
using StackExchange.Redis;

namespace TaskIntSolution
{
    public static class RedisClient
    {
        private static ConnectionMultiplexer redis;
        private static IDatabase database;
        private static IServer server;

        public static void Connect(string connectionString = "localhost")
        {
            redis = ConnectionMultiplexer.Connect("redis-10799.c290.ap-northeast-1-2.ec2.cloud.redislabs.com:10799,password=BASCd4eHcWd3LP0vC1Tf28OfC5mgQtel,ConnectTimeOut=10000,allowAdmin=true");
            database = redis.GetDatabase();
            server = redis.GetServer("redis-10799.c290.ap-northeast-1-2.ec2.cloud.redislabs.com", 10799);
        }

        public static void AddOne(string key)
        {
            if (Exist(key))
            {
                database.StringIncrement(key);
            }
            else
            {
                database.StringSet(key, 1);
            }
        }

        public static void RemoveOne(string key)
        {
            if (database.StringDecrement(key) <= 0)
            {
                database.KeyDelete(key);
            }
        }

        public static bool Exist(string key)
        {
            return database.KeyExists(key);
        }

        public static long GetAsLong(string key)
        {
            return (long)database.StringGet(key);
        }

        /// <summary>
        /// Get keys in Redis server with special beginning.
        /// </summary>
        /// <param name="keyBeginning"> Special beginning. </param>
        public static string[] GetKeys(string keyBeginning = "")
        {
            return server.Keys(pattern: $"{keyBeginning}*")
                .Select(x => x.ToString())
                .ToArray();
        }
    }
}