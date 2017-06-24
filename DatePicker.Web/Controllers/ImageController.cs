using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using DatePicker.Config;
using MongoDB.Bson;
using System.IO;
using DatePicker.Common.Model;

namespace DatePicker.Web.Controllers
{
    public class ImageController : Controller
    {
        string[] contentTypes = DatePickerConfig.AppSettings.UploadedImageContentType;
        [HttpPost]
        public IActionResult Upload(IFormFile files)
        {
            if (files.Length <= 0 || !contentTypes.Contains(files.ContentType)) return Json(new ResponseModel<string>(ErrorCode.invalid_params, null));
            Image image = new Image()
            {
                Id = ObjectId.GenerateNewId(),
                Thumbnail = null,
                FileName = files.FileName,
                Length = files.Length,
                Data = files.OpenReadStream(),
                UploadDate = DateTime.Now
            };
            return null;
        }
    }
}