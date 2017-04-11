using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;

namespace DatePicker.Web.Controllers
{
    public class BaseController : Controller
    {
        public IStringLocalizer<Shared> _stringLocalizer;
        
        public BaseController(IStringLocalizer<Shared> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }
    }
}