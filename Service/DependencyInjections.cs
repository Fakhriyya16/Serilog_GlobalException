using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Helpers;
using Service.Services;
using Service.Services.Interfaces;


namespace Service
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            });

            return services;
        }
    }
}
