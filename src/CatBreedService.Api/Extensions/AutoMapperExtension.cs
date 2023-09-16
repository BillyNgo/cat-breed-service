using AutoMapper;
using CatBreedService.Api.Configurations.Mapping;
using CatBreedService.Application.Configurations.Mapping;

namespace CatBreedService.Api.Extensions
{
    internal static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperProfile(this IServiceCollection services)
        {
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ApiAutoMapperProfile());
                mc.AddProfile(new ApplicationAutoMapperProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
