using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using DatePicker.Business;
using MongoDB.Bson;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;

namespace DatePicker.Web.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ExpressList()
        {
            var filter = new BsonDocument("lang", HttpContext.Items["lang"].ToString().ToLower());
            BsonDocument express = new Express().Find(filter).FirstOrDefault();
            JsonWriterSettings writer = new JsonWriterSettings() { OutputMode = JsonOutputMode.Strict };
            return Content(express.ToJson(writer), "application/json");
        }
        
    }
    public class M
    {
        public string str { get; set; }
    }
}