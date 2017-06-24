using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DatePicker.Common.Model
{
    public class Image
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("thumbnail")]
        public ObjectId? Thumbnail { get; set; }
        [BsonElement("filename")]
        public string FileName { get; set; }
        [BsonElement("length")]
        public long Length { get; set; }
        [BsonElement("data")]
        public Stream Data { get; set; }
        [BsonElement("uploadDate")]
        public DateTime UploadDate { get; set; }
    }
    public class ImageThumbnail
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("filename")]
        public string FileName { get; set; }
        [BsonElement("length")]
        public long Length { get; set; }
        [BsonElement("data")]
        public Stream Data { get; set; }
        [BsonElement("uploadDate")]
        public DateTime UploadDate { get; set; }
    }
}
