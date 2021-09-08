using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba_OOP.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Laba_OOP.Manager.Readers;
using Laba4._5_OOP.Manager.Books;
using Laba4._5_OOP.Manager.CopyOfBooks;
using Laba4._5_OOP.Manager.Librarys;
using Laba4._5_OOP.Manager.Categorys;
using Laba4._5_OOP.Manager.Authors;
using Laba4._5_OOP.Manager.Workers;

//using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Laba_OOP
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;

        public Startup(IHostingEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder().SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile("LibraryDBSettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibraryDataContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("LibraryDbV2.0")));
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddTransient<IReaderManager, ReaderManager>();//Связываем интерфейс с его реализацией
            services.AddTransient<IBookManager,BookManager>();
            services.AddTransient<ICopyOfBookManager,CopyOfBookManager>();
            services.AddTransient<ILibraryManager,LibraryManager>();
            services.AddTransient<ICategoryManager, CategoryManager>();
            services.AddTransient<IAuthorManager, AuthorManager>();
            services.AddTransient<IWorkerManager, WorkerManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseRouting();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Main}/{action=MainPage}");

            });
        }
    }
}
