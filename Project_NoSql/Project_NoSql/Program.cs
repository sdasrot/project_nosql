using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using System.Text.RegularExpressions;
using MongoDB.Bson.Serialization;
using System.Xml;
using Newtonsoft.Json;



namespace Project_NoSql
{
    class Program
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;

        static void Main(string[] args)
        {
            _client = new MongoClient();
            _database = _client.GetDatabase("project");
            Console.WriteLine("Connected to project database etablished");


            requestMapReduce();
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



        #region RequetesMika
        public static async void requestMichael() //J'essaie d'instancier dans les classes le doc qu'il me renvoie ici
        {
            var collection = _database.GetCollection<BsonDocument>("artworks");
            var filter = Builders<BsonDocument>.Filter.Eq("_id", "A00001");

            var resultMika = await collection.Find(filter).ToListAsync();

            foreach(BsonDocument doc in resultMika)
            {


                //Conversion en string
                string docJson = doc.ToJson();

                Artwork artwork = new Artwork();
                artwork.instantiateFromXml(docJson);


                Console.WriteLine(artwork.toString());


            }


            //var deserializedDocument = resultMika[0].
        }


        public static async void requestAcquisitionYearEqual(int year)
        {
            var collection = _database.GetCollection<BsonDocument>("artworks");
            var filter = Builders<BsonDocument>.Filter.Eq("acquisitionYear", year);
            var resultMika = await collection.Find(filter).ToListAsync();

            //TODO deserialization
        }

        public static async void requestAcquisitionYearGte(int year)
        {
            var collection = _database.GetCollection<BsonDocument>("artworks");
            var filter = Builders<BsonDocument>.Filter.Gte("acquisitionYear", year);
            var resultMika = await collection.Find(filter).ToListAsync();
            //TODO deserialization

        }

        public static async void requestAcquisitionYearLte(int year)
        {
            var collection = _database.GetCollection<BsonDocument>("artworks");
            var filter = Builders<BsonDocument>.Filter.Lte("acquisitionYear", year);
            var resultMika = await collection.Find(filter).ToListAsync();
            //TODO deserialization

        }

        public static async void requestDimensionGte(int h, int w)
        {
            var collection = _database.GetCollection<BsonDocument>("artworks");
            var filter = Builders<BsonDocument>.Filter.Gte("height", h) | Builders<BsonDocument>.Filter.Gte("width", w);
            var resultMika = await collection.Find(filter).ToListAsync();
            //TODO deserialization
        }

        public static async void requestDimensionLte(int h, int w)
        {
            var collection = _database.GetCollection<BsonDocument>("artworks");
            var filter = Builders<BsonDocument>.Filter.Lte("height", h) | Builders<BsonDocument>.Filter.Lte("width", w);
            var resultMika = await collection.Find(filter).ToListAsync();
            //TODO deserialization
        }

        public static async void requestMapReduce()
        {
            var collection = _database.GetCollection<BsonDocument>("artworks");
            var map = "function() { emit(this.acquisitionYear, 1);}";
            var reduce = "function(key, values) return Array.sum(values):";
            var result = collection.MapReduceAsync<BsonDocument>(map, reduce);

            Console.WriteLine(result.GetType());
        }

        #endregion


    }
}
