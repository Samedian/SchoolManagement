using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SchoolManagementPresentationLayer;
using SchoolManagementBussinessLayer;
using SchoolManagementDataAcessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SchoolManagementDataAcessLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement
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
            services.AddControllersWithViews();
            services.AddTransient<IBreakData, BreakData>();
            services.AddTransient<SchoolManagementBussinessLayer.ISaveBussinessLayer, SaveBussinessLayer>();
            services.AddTransient<SchoolManagementDataAcessLayer.ISaveDataAccessLayer, SaveDataAccessLayer>();
            services.AddTransient<IConvertEntityToDatabaseEntity, ConvertEntityToDatabaseEntity>();
            services.AddTransient<IGetBussinessLayer, GetBussinessLayer>();
            services.AddTransient<IGetDataAccessLayer, GetDataAccessLayer>();
            services.AddTransient<IFileWrite, FileWrite>();

            services.AddDbContextPool<SchoolContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("SchoolDbConnection")));

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
