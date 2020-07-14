using FeatureApi.Core.Interfaces;
using FeatureApi.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using AutoMapper;
using FeatureApi.Core;
using FeatureApi.Web.Services;
using FeatureApi.Core.Orders;

namespace FeatureApi.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlite("Data Source=database.sqlite"));
            services.AddControllers();
            services.AddAutoMapper(typeof(AutoMapping).Assembly);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Feature API", Version = "V1" });
                c.EnableAnnotations();
            });

            services.AddSingleton<IFileNumberGenerator, FileNumberGenerator>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EntityRepository<>));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler("/error");

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Feature API V1");
                c.RoutePrefix = "documentation";
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                c.DocumentTitle = "Feature API Documentation";
            });

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
