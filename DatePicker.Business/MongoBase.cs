using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;

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
        public IEnumerable<BsonDocument> Find(BsonDocument document)
        {
            return mongoBase.Find(document);
        }
    }
}
