using Microsoft.Extensions.DependencyInjection;
using Repository.Repositories;
using Repository.Repositories.Interfaces;

namespace Repository
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));

            return services;
        }
    }
}
