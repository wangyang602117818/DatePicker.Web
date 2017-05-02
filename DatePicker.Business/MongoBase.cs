using MongoDB.Bson;
using System;
namespace DatePicker.Business
{
    public class MongoBase
    {
        Data.MongoBase mongoBase;
        public MongoBase(string collectionName)
        {
            mongoBase = new Data.MongoBase(collectionName);
        }
        public void InsertAsync(BsonDocument document)
        {
            mongoBase.InsertAsync(document);
        }
    }
}
