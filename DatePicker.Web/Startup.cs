using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Http;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.IO;

namespace DatePicker.Web
{
    public class Startup
    {
        public static Dictionary<string, string> MobileReplaceUrls = new Dictionary<string, string>()
        {
            {"layout.css","layout-mobile.css" },
            {"layout.min.css","layout-mobile.min.css" },
        };
        public Startup(IHostingEnvironment env)
        {
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            // Add framework services.
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                SupportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("zh-CN")
                },
                SupportedUICultures = new List<CultureInfo>()
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("zh-CN")
                },
                DefaultRequestCulture = new RequestCulture("en-US")
            });
            //存储当前语言
            app.Use((context, next) =>
            {
                context.Items.Add("lang", context.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name);
                return next();
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.Use((context, next) =>
            {
                string agent = ((FrameRequestHeaders)context.Request.Headers).HeaderUserAgent;
                bool isMobile = Shared.IsMobile(agent);
                string fileName = Path.GetFileName(context.Request.Path.Value);
                if (MobileReplaceUrls.ContainsKey(fileName) && isMobile)
                    context.Request.Path = new PathString(context.Request.Path.Value.Replace(fileName, MobileReplaceUrls[fileName]));
                return next();
            });
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
