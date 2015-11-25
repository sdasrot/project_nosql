﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using System.Text.RegularExpressions;

namespace Project_NoSql
{
    class Program
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        static void Main(string[] args)
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("projet");
            Console.WriteLine("Connected to project database etablished");


            requete();
            Console.Read();
        }

        public static async void requete()
        {
            var collection = _database.GetCollection<BsonDocument>("artists");
            //var filter = Builders<BsonDocument>.Filter.Eq("fc", BsonRegularExpression.Create(new Regex("Lemuel")));
            //var result = await collection.Find(filter).ToListAsync();
            var aggregate = collection.Aggregate().Match(new BsonDocument { { "fc", BsonRegularExpression.Create(new Regex("Francis")) }, { "activePlaceCount", 0 } });
            var results = await aggregate.ToListAsync();
            string s = null;
            int i;
            int y = results.Count();
            if (results.Count() != 0)
            {
                for (i = 0; i < y; i++)
                {
                    Console.WriteLine(results[i]);
                }
            }
            else
            {
                Console.WriteLine("Vide sa mere");
            }
        }
    }
}