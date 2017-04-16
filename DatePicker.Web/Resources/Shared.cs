using DatePicker.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
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
            Regex regex = new Regex("windows|mac|iphone|android|ipad", RegexOptions.IgnoreCase);
            Match match = regex.Match(userAgent);
            return match.Groups[0].Value;
        }
        public void ZipMiniDatepicker()
        {
            var folder = Directory.GetCurrentDirectory() + @"\wwwroot\datepicker\";
            string[] files = Directory.GetFiles(folder);
            var jsFile = folder + @"datepicker.min.js";
            //ZipHelper.CompressFolder(folder, folder + "datepicker.zip");
        }
    }
}
