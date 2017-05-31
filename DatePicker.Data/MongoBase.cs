using DatePicker.Config;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DatePicker.Data
{
    public class MongoBase
    {
        readonly static MongoClient mongoClient;
        public IMongoDatabase MongoDatabase;
        public IMongoCollection<BsonDocument> MongoCollection;
        static MongoBase()
        {
            mongoClient = new MongoClient(DatePickerConfig.AppSettings.MongoUrl.Connection);
        }
        public MongoBase(string collectionName)
        {
            MongoDatabase = mongoClient.GetDatabase(DatePickerConfig.AppSettings.MongoUrl.DataBase);
            MongoCollection = MongoDatabase.GetCollection<BsonDocument>(collectionName);
        }
        public void InsertAsync(BsonDocument document)
        {
            MongoCollection.InsertOneAsync(document);
        }
        public IEnumerable<BsonDocument> Find(BsonDocument document)
        {
            return MongoCollection.Find(document).ToEnumerable();
        }
    }
}
