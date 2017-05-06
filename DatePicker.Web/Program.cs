using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using DatePicker.Config;

namespace DatePicker.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //new Shared().ZipMiniDatepicker();  //压缩下载文件

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .UseUrls(DatePickerConfig.AppSettings.WebSiteUrl)
                .Build();
            
            host.Run();

        }
    }
}
