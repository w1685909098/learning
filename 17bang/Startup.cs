using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _17bang.Pages.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace _17bang
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddMvc().AddRazorPagesOptions(opt =>
            {
                opt.Conventions.AddPageRoute("/ProblemModel/Single", "/ProblemModel/{id}")
                .AddPageRoute("/Log/On","/LogOn")
                .AddPageRoute("/ProblemModel/Edit","/ProblemModel/Edit/{Id}")
                .AddPageRoute("/Message/Mine","/Message/Mine/{opt}");
            });
            services.AddMemoryCache();
            services.AddSession(option => 
            {
                option.Cookie = new CookieBuilder { Name="SetSessionId",Expiration=new TimeSpan(30,0,0,0),HttpOnly=false};
                option.IdleTimeout = new TimeSpan(30, 0, 5);
            });
            services.AddMvc(Options =>
            {
                Options.Filters.Add(new GolablePerRequest());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
