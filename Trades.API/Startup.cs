using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;
using Trades.API.Filters;
using Trades.Infrastructure.CrossCutting.IOC;
using Trades.Infrastructure.Data;

namespace Trades.API
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
            var connection = Configuration["SqlConnection:DefaultConnection"];
            services.AddDbContext<SqlContext>(options =>
            {
                options.UseSqlServer(connection);
                options.EnableSensitiveDataLogging();


            });
            services.AddControllers();
            services.AddMvc(options =>
            {
                options.Filters.Add<ApiExceptionFilterAtribute>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API  categories of trades",
                    Version = "v1",
                    Description = "API Trade Categories"
                });
            });

            DependecyInjection.DependencyInjector(services, Configuration);

            services.AddScoped(s =>
            {
                Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Log\\logTradeCategory.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

                return Log.Logger;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Trade Categories");
            });

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
