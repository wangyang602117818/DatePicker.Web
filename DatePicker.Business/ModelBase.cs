using MongoDB.Bson;
using System;
using System.Collections;
using System.Collections.Generic;

namespace DatePicker.Business
{
    public class ModelBase<T> where T : Data.MongoBase
    {
        public T mongoData;
        public ModelBase(T mongoData)
        {
            this.mongoData = mongoData;
        }
        public void InsertAsync(BsonDocument document)
        {
            mongoData.InsertAsync(document);
        }
        public IEnumerable<BsonDocument> Find(BsonDocument document)
        {
            return mongoData.Find(document);
        }
    }
}
