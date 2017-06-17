using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DatePicker.Business
{
    public class MongoUpload : ModelBase<Data.MongoUpload>
    {
        public MongoUpload() : base(new Data.MongoUpload()) { }
        public ObjectId Upload(string fileName, Stream stream)
        {
            return mongoData.Upload(fileName, stream);
        }
        public Task<ObjectId> UploadAsync(string fileName, Stream stream)
        {
            return mongoData.UploadAsync(fileName, stream);
        }
    }
}
