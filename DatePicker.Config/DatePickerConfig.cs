using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DatePicker.Config
{
    public class DatePickerConfig
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static AppSettings AppSettings { get; set; }
        static DatePickerConfig()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            AppSettings = Configuration.Get<AppSettings>();
        }
       
    }
}
