using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using ZooManagement.Repositories;
// using ZooManagement.Repositories;


namespace ZooManagement
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
            services.AddDbContext<ZooManagementDbContext>(options => 
            {
               
                options.UseSqlite("Data Source=zoomanagement.db");
            });
            
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZooManagement", Version = "v1" });
            });
            services.AddTransient<IAnimalsRepo, AnimalsRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZooManagement v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
//  public Startup(IConfiguration configuration)
//         {
//             Configuration = configuration;
//         }

//         public IConfiguration Configuration { get; }

//         public static readonly ILoggerFactory
//             LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder => { builder.AddConsole(); });

//         private static string CORS_POLICY_NAME = "_myfaceCorsPolicy";
        
//         // This method gets called by the runtime. Use this method to add services to the container.
//         public void ConfigureServices(IServiceCollection services)
//         {
//             services.AddDbContext<MyFaceDbContext>(options =>
//             {
//                 options.UseLoggerFactory(LoggerFactory);
//                 options.UseSqlite("Data Source=myface.db");
//             });

//             services.AddCors(options =>
//             {
//                 options.AddPolicy(CORS_POLICY_NAME, builder =>
//                 {
//                     builder
//                         .WithOrigins("http://localhost:3000")
//                         .AllowAnyMethod()
//                         .AllowAnyHeader();
//                 });
//             });
            
//             services.AddControllers();
            
//             services.AddTransient<IPostsRepo, PostsRepo>();
//             services.AddTransient<IUsersRepo, UsersRepo>();
//         }

//         // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//         public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//         {
//             if (env.IsDevelopment())
//             {
//                 app.UseDeveloperExceptionPage();
//             }
//             else
//             {
//                 // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                 app.UseHsts();
//             }

//             app.UseHttpsRedirection();

//             app.UseRouting();

//             app.UseCors(CORS_POLICY_NAME);

//             app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
//         }
//     }
