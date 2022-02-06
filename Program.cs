using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechAnalysis.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

//using Microsoft.EntityFrameworkCore;
//using TechAnalysis.Data;
//using TechAnalysis.Hub;

//var builder = WebApplication.CreateBuilder(args);
//builder.UseStartup();

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//builder.Services.AddSignalR();

//builder.Services.AddDbContext<TechAlertDbContext>(options =>
//        options.UseSqlServer("Server=localhost;Database=RetailTrader;Trusted_Connection=True;MultipleActiveResultSets=true"));

//var app = builder.Build();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapHub<BroadcastHub>("/notify");
//});

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.UseCors("CorsPolicy");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

//app.Run();
