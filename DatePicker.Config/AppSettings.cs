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
        public MongoUrl MongoUrl { get; set; }

    }
    public class MongoUrl
    {
        public string Connection { get; set; }
        public string DataBase { get; set; }
    }
}
