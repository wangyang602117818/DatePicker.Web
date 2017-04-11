using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatePicker.Web
{
    public class Shared
    {
        public static bool IsMobile(string userAgent)
        {
            string devices = CheckDevices(userAgent);
            switch (devices.ToLower())
            {
                case "windows": return false;
                case "iphone": return true;
                case "android": return true;
                case "ipad": return false;
                default: return false;
            }
        }
        public static string CheckDevices(string userAgent)
        {
            Regex regex = new Regex("windows|iphone|android|ipad", RegexOptions.IgnoreCase);
            Match match = regex.Match(userAgent);
            return match.Groups[0].Value;
        }
    }
}
