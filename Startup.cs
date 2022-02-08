using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TechAnalysis.API.Service;
using TechAnalysis.Data;
using TechAnalysis.Hub;

namespace TechAnalysis.API
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TechWatchApi", Version = "v1" });
            });

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder => {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .WithOrigins("http://localhost:4200");
            }));

            services.AddSignalR();
            services.AddHostedService<ConsumeRabbitMQHostedService>();
            services.AddSingleton<TOSPriceService>();
            //services.AddHostedService<TOSPriceService>();
            //services.AddSingleton(typeof(IPriceService), typeof(TOSPriceService));

            //var serviceProvider = services.BuildServiceProvider();
            //var singletonService = serviceProvider.GetService<TOSPriceService>();

            services.AddDbContext<TechAlertDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TechAlertDbContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TechWatchApi v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<BroadcastHub>("/notify");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

