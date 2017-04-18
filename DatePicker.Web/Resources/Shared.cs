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
            string[] pathArray = Directory.GetFiles(folder);
            string datePickerEn = Directory.GetCurrentDirectory() + @"\wwwroot\datepicker-en.zip";
            string datePickerZh = Directory.GetCurrentDirectory() + @"\wwwroot\datepicker-zh.zip";
            Dictionary<string, string> filesEn = new Dictionary<string, string>();
            Dictionary<string, string> filesZh = new Dictionary<string, string>();
            foreach (string path in pathArray)
            {
                string fileName = Path.GetFileName(path);
                string fileText = File.ReadAllText(path);
                if (fileName == "datepicker.min.js")
                {
                    if (fileText.Contains("lang:\"en-us\""))
                    {
                        filesEn.Add(fileName, fileText);
                        filesZh.Add(fileName, fileText.Replace("lang:\"en-us\"", "lang:\"zh-cn\""));
                    }
                    if (fileText.Contains("lang:\"zh-cn\""))
                    {
                        filesZh.Add(fileName, fileText);
                        filesEn.Add(fileName, fileText.Replace("lang:\"zh-cn\"", "lang:\"en-us\""));
                    }
                }
                else
                {
                    filesEn.Add(fileName, fileText);
                    filesZh.Add(fileName, fileText);
                }
            }
            ZipHelper.AddFileToZip(datePickerEn, filesEn);
            ZipHelper.AddFileToZip(datePickerZh, filesZh);
        }
    }
}
