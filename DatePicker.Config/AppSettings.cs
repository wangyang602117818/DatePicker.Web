using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DatePicker.Config
{
    public class AppSettings
    {
        public string WebSiteUrl { get; set; }
        public MongoDb MongoDb { get; set; }

    }
    public class MongoDb
    {
        public string Url { get; set; }
        public string DataBase { get; set; }
    }
}
