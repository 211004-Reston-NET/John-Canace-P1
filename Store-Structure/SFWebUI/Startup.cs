using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SFBL;
using SFDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SFWebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // This method will essentailly tell this MVC app what projects it will depend on 
        // Note: Cool thing about this is that it essentially will do MenuFactory for us
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<_211004restonnetdemoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Reference2DB")));
            services.AddScoped<IStoreFrontBL, StoreFrontBL>();
            services.AddScoped<ICustomerBL, CustomerBL>();
            services.AddScoped<ILine_ItemBL, Line_ItemBL>();
            services.AddScoped<IOrderBL, OrderBL>();
            services.AddScoped<IProductBL, ProductBL>();
            //services.AddScoped<IRepository, Repository>();
            //services.AddScoped<ICRepository, CRepository>();
            //services.AddScoped<ILRepository, LRepository>();
            //services.AddScoped<IPRepository, CloudRespository>();
            //services.AddScoped<IORepository, ORepository>();
            services.AddScoped<IRepository, CloudRespository>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
