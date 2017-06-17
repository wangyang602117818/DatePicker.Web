using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace DatePicker.Web.Controllers
{
    public class ImageController : Controller
    {
        public IActionResult Upload(IFormFile files)
        {
            
            return View();
        }
    }
}