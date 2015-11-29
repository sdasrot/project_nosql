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


        public static async void requestMichael() //J'essaie d'instancier dans les classes le doc qu'il me renvoie ici
        {
            var collection = _database.GetCollection<BsonDocument>("artworks");
            var filter = Builders<BsonDocument>.Filter.Eq("acno", "A00001");

            var resultMika = await collection.Find(filter).ToListAsync();


            foreach(BsonDocument doc in resultMika)
            {
                //BsonSerializer.Deserialize<BsonDocument>(doc);

                var myArtwork = new Artwork();
               
                /*
                myArtwork.AcquisitionYear = BsonInt32["acquisitionYear"].AsInt32;
                myArtwork.Classification = BsonElement["classification"].AsString;
                myArtwork.Dimmension
                myArtwork.Title = 
                myArtwork.ThumbnailUrl =
                */

            }


            //var deserializedDocument = resultMika[0].
        }
    }
}
