using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Otthonbazar.Data;
using Swashbuckle.AspNetCore.Swagger;

namespace NgOtthonbazar
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                .AddSwaggerGen(o => o.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "NgOtthonbazarAPI", Version = "v1" }))
                .AddSingleton<IActionContextAccessor, ActionContextAccessor>()

                .AddMvc(option => option.EnableEndpointRouting = false)
            .AddNewtonsoftJson(
          options =>
          {
              options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
          });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "_myAllowSpecificOrigins",
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200");
                                  });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
            => app.UseDeveloperExceptionPage()
                .UseStaticFiles()
                .UseCors("_myAllowSpecificOrigins")
                .UseSwagger()
                .UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "NgOtthonbazarAPI v1"))
                .UseMvc();
    }
}
