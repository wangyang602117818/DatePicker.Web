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

namespace DatePicker.Web.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ExpressList()
        {
            var filter = new BsonDocument("lang", HttpContext.Items["lang"].ToString().ToLower());
            BsonDocument express = new Express().Find(filter).FirstOrDefault();
            return Content(express.ToJson(),"application/json");
        }
    }
}