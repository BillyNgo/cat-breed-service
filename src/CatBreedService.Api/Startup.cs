using FluentValidation;
using Microsoft.EntityFrameworkCore;
using CatBreedService.Application;
using CatBreedService.Api.ProblemDetails;
using CatBreedService.Infrastructure;
using Hellang.Middleware.ProblemDetails;
using CatBreedService.Api.Extensions;
using System.Reflection;

namespace CatBreedService.Api
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
            services.AddApplication();

            services.AddProblemDetails(options =>
            {
                options.IncludeExceptionDetails = (ctx, ex) => { return false; };
                // Configure problem details per exception type here.
                options.Map<ValidationException>(ex => new BadRequestProblemDetails(ex));
                options.Map<AggregateException>(ex =>
                {
                    return ex.InnerException switch
                    {
                        null => new UnhandledExceptionProblemDetails(ex),
                        ValidationException validation => new BadRequestProblemDetails(validation),
                        _ => new UnhandledExceptionProblemDetails(ex.InnerException),
                    };
                });

                // This must always be last as this will serve to handle unhandled exceptions.
                options.Map<Exception>(ex => new UnhandledExceptionProblemDetails(ex));
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            
            // Add Swagger documentation.
            services.AddSwaggerGen(options =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });

            // Add AutoMapper Profile.
            services.AddAutoMapperProfile();

            // Add Cosmos DbContext base on configuration.
            services.AddDbContext<CatBreedDbContext>(options =>
                options.UseCosmos(
                    Configuration["Cosmos:AccountEndpoint"],
                    Configuration["Cosmos:AccountKey"],
                    Configuration["Cosmos:DatabaseName"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Seed data from `https://api.thecatapi.com/v1/breeds`
                //app.UseDataSeeding();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CatBreedService v1");
                });
            }

            app.UseProblemDetails();

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
