using MongoDB.Bson;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DatePicker.Data
{
    public class MongoUpload: MongoBase
    {
        public GridFSBucket gridFSBucket;
        public MongoUpload() : base("admin")
        {
            gridFSBucket = new GridFSBucket(MongoDatabase);
        }
        public ObjectId Upload(string fileName, Stream stream)
        {
            return gridFSBucket.UploadFromStream(fileName, stream);
        }
        public Task<ObjectId> UploadAsync(string fileName, Stream stream)
        {
            return gridFSBucket.UploadFromStreamAsync(fileName, stream);
        }
    }
}
