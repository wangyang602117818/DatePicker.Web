using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DatePicker.Web.Controllers
{
    public class DownloadController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}